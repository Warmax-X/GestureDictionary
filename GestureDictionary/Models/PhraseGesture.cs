using System.ComponentModel.DataAnnotations;

namespace GestureDictionary.Models;

public class PhraseGesture: Gesture // модель жеста фразы
{
    [Key] public string? Phrase { get; set; } // фраза жеста
}