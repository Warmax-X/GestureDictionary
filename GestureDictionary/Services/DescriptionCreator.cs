namespace GestureDictionary.Services;

public class DescriptionCreator // класс для автоматического создания описания
{
    public string? Create(string? wordPhrase,  out string? message) // метод для создания описания
    {
        string? description = null;
        
        if (string.IsNullOrEmpty(wordPhrase)) // действия при пустом значении жеста
        {
            message = "Для создания автоматического описания введите значение жеста";
            return description;
        }
        
        description = wordPhrase.Contains(' ') ? $"Этот жест обозначает фразу \"{wordPhrase}\"" : $"Этот жест обозначает слово \"{wordPhrase}\""; // создание описания в зависимости от типа жеста

        message = null;
        return description;
    }
}