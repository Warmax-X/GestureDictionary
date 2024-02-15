namespace GestureDictionary.Models;

public abstract class Gesture // абстрактный класс для моедил жеста
{
    public string? Description { get; set; } // опсиание жеста
    public string? PathToVideo { get; set; } // путь к видео файлу с жестом
}
