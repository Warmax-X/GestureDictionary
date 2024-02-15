using System.ComponentModel.DataAnnotations;

namespace GestureDictionary.Models;

public class LetterGesture: Gesture // модель жеста буквы
{
    [Key] public string? Letter { get; set; } // буква жеста
}