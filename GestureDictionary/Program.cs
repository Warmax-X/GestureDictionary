using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using GestureDictionary.DataBase;
using GestureDictionary.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<GestureContext>();

builder.Services.AddScoped<DbController>(); // добавление контроллера базы данных 

builder.Services.AddScoped<FileController>(); // добавление файлового контроллера

builder.Services.AddSingleton<DescriptionCreator>(); // добавление создателя описаний

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();