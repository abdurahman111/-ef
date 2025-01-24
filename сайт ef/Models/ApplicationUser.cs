namespace сайт_ef.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        // Дополнительные свойства пользователя, если нужно
        public string FullName { get; set; }
    }
}
