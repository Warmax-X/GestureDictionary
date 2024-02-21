using GestureDictionary.DataBase;
using GestureDictionary.Enums;
using GestureDictionary.Models;

namespace GestureDictionary.Services;

public class DbController // контролеер базы данных
{
    private GestureContext _ef;

    public DbController(GestureContext ef)
        => _ef = ef;

    public string? ErrorMessage; 

    public string? GetVideo(string? key, TypeOfGesture type, out string? description, out string? meaning) // метод для получения видео жеста
    {
        string? foundedVideo = string.Empty;
        description = null;
        meaning = null;

        switch (type)
        {
            case TypeOfGesture.LetterGesture:
                foundedVideo = _ef.LetterGestures.FirstOrDefault(g => g.Letter == key)?.PathToVideo;
                description = _ef.LetterGestures.FirstOrDefault(g => g.Letter == key)?.Description;
                meaning = _ef.LetterGestures.FirstOrDefault(g => g.Letter == key)?.Letter;
                break;
            case TypeOfGesture.WordGesture:
                foundedVideo = _ef.WordGestures.FirstOrDefault(g => g.Word == key)?.PathToVideo;
                description = _ef.WordGestures.FirstOrDefault(g => g.Word == key)?.Description;
                meaning = _ef.WordGestures.FirstOrDefault(g => g.Word == key)?.Word;
                break;
            case TypeOfGesture.PhraseGesture:
                foundedVideo = _ef.PhraseGestures.FirstOrDefault(g => g.Phrase == key)?.PathToVideo;
                description = _ef.PhraseGestures.FirstOrDefault(g => g.Phrase == key)?.Description;
                meaning = _ef.PhraseGestures.FirstOrDefault(g => g.Phrase == key)?.Phrase;
                break;
        }

        return foundedVideo;
    }

    public List<string?> GetKeys(TypeOfGesture type) // метод для получения спика ключей (буквы, слова, фразы)
    {
        List<string?> keys = new List<string?>();

        switch (type)
        {
            case TypeOfGesture.LetterGesture:
                keys = _ef.LetterGestures.Select(g => g.Letter).ToList().OrderBy(k => k).ToList();
                break;
            case TypeOfGesture.WordGesture:
                keys = _ef.WordGestures.Select(g => g.Word).ToList().OrderBy(k => k).ToList();
                break;
            case TypeOfGesture.PhraseGesture:
                keys = _ef.PhraseGestures.Select(g => g.Phrase).ToList().OrderBy(k => k).ToList();
                break;
        }

        return keys;
    }

    public void AddGesture(string? wordPhrase, string? description, string? pathToVideo, TypeOfGesture type, out bool isConfirm) // метод для добавления нового жеста
    {
        isConfirm = false;
        ErrorMessage = string.Empty;

        if (wordPhrase == null || description == null || pathToVideo == null) // проверка на наличие занчений
            return;
        try
        {
            switch (type) // добавление жеста в базу данных в зависимости от его типа 
            {
                case TypeOfGesture.WordGesture:
                    
                    if (_ef.WordGestures.Any(g => g.Word == wordPhrase)) // действия если такой жест уже существует
                    {
                        ErrorMessage = "Такое слово уже существует";
                        return;
                    }

                    var newWordGesture = new WordGesture
                    {
                        Word = wordPhrase,
                        Description = description,
                        PathToVideo = pathToVideo
                    };

                    _ef.Add(newWordGesture);
                    _ef.SaveChanges();
                    break;

                case TypeOfGesture.PhraseGesture:
                    
                    if (_ef.PhraseGestures.Any(g => g.Phrase == wordPhrase)) // действия если такой жест уже существует
                    {
                        ErrorMessage = "Такая фраза уже существует";
                        return;
                    }

                    var newPhraseGesture = new PhraseGesture
                    {
                        Phrase = wordPhrase,
                        Description = description,
                        PathToVideo = pathToVideo
                    };

                    _ef.Add(newPhraseGesture);
                    _ef.SaveChanges();
                    break;
            }
        }
        catch (Exception e) // ловля исключений
        {
            ErrorMessage = e.Message;
            return;
        }

        ErrorMessage = string.Empty;
        isConfirm = true; // отправка подтверждения при успешном добавлении нового жеста
    }
}