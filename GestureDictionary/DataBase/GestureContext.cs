using GestureDictionary.Models;
using Microsoft.EntityFrameworkCore;

namespace GestureDictionary.DataBase;

public class GestureContext: DbContext
{
    public DbSet<LetterGesture> LetterGestures { get; set; } // создание базы данных для жестов букв
    public DbSet<WordGesture> WordGestures { get; set; } // создание базы данных для жестов слов
    public DbSet<PhraseGesture> PhraseGestures { get; set; } // создание базы данных для жестов фраз

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = LocalStorage.db");
    }
}