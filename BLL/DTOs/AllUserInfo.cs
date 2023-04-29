using System.ComponentModel.DataAnnotations;

namespace HarryPotterWebsite
{
    public class AllUserInfo
    {
        [Required]
        public string? UserLogin { get; init; }
        [Required]
        public string? UserPassword { get; set; }
        public string? UserInfoName { get; set; }
        public string? UserInfoEmail { get; set; }
    }
}
