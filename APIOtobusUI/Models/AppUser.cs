using Microsoft.AspNetCore.Identity;

namespace OtobusAPI.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Sifre { get; set; }
    }
}
