using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LR_5.Models;

public class CreateUserViewModel
{
    public int UserId { get; set; }
    [Required(ErrorMessage = "Имя пользователя обязательно")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Пароль обязателен")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Роль обязательна")]
    public string Role { get; set; }

    // Дополнительные свойства для роли "Администратор"
    public string? AdminSurname { get; set; }
    public string? AdminName { get; set; }

    // Дополнительные свойства для роли "Администратор"
    public string? MetSurname { get; set; }
    public string? MetName { get; set; }

    // Дополнительные свойства для роли "Инструктор"
    public int? InstructorId { get; set; }
    public string? InstructorSurname { get; set; }
    public string? InstructorName { get; set; }

    // Дополнительные свойства для роли "Пользователь"
    public int? StudentId { get; set; }
    public string? UserSurname { get; set; }
    public string? UsName { get; set; }
}