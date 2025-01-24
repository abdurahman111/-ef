using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using сайт_ef.Models; // Замените на реальный namespace вашего проекта

var builder = WebApplication.CreateBuilder(args);

// Добавление конфигурации для подключения к базе данных
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Регистрация Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Добавление Swagger
builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Применение HSTS (HTTP Strict Transport Security) в production
}

// Настройка редиректа на HTTPS
app.UseHttpsRedirection();
app.UseStaticFiles(); // Для обслуживания статических файлов (CSS, JavaScript, изображения и т.д.)
app.UseRouting(); // Настройка маршрутов

// Включение Swagger UI для API
app.UseSwagger(); // Генерация Swagger документации
app.UseSwaggerUI(); // Включение интерфейса Swagger UI для тестирования API

app.UseAuthorization(); // Включение авторизации

app.MapControllers(); // Настройка маршрутов для контроллеров API

app.Run(); // Запуск приложения
