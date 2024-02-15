using Microsoft.AspNetCore.Components.Forms;

namespace GestureDictionary.Services;

public class FileController // контролер файлов
{
    private readonly IWebHostEnvironment? _env;
    private IBrowserFile? _selectedFile; // поле для выбранного файла
    private const long MaxSize = 2560 * 1440; // максимальный размер файла

    public FileController(IWebHostEnvironment? env)
        => _env = env;

    public string? ErrorMessage;
    public string? PathToVideo;
    public string? FileType;

    public void OnInputFileChange(InputFileChangeEventArgs e) // метод вызывающийся при выборе файла
    {
        // получение файла и данных о нём
        _selectedFile = e.File; 
        PathToVideo = _selectedFile?.Name;
        FileType = _selectedFile?.ContentType;
    }

    public async void OnSubmit(bool isConfirm) // метод для загрузки файла в файлы проекта
    {
        if (_selectedFile?.ContentType != "video/mp4") // проверка на соответствие требованием формата файла
            return;
        if (!isConfirm) // проверка на наличие подтверждения от контроллера базы данных
            return;

        try
        {
            Stream? stream = _selectedFile?.OpenReadStream(MaxSize); // открытие потока для чтения содержимого хагруженного файла
            var path = $"{_env?.WebRootPath}/Videos/{_selectedFile?.Name}"; // задаётся путь для сохранения файлов
            FileStream fs = File.Create(path);
            await stream?.CopyToAsync(fs)!; // копирование содежимого файла в файловый потое по указаному пути
            stream.Close(); // закрытие потоков
            fs.Close();
        }
        catch (Exception e) // ловля исключений
        {
            ErrorMessage = e.Message;
        }

        ErrorMessage = string.Empty;
        _selectedFile = null;
    }
}