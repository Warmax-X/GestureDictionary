using System.ComponentModel.DataAnnotations;

namespace GestureDictionary.Models;

public class WordGesture: Gesture // модель жеста слова
{
    [Key] public string? Word { get; set; } // слово жеста
}