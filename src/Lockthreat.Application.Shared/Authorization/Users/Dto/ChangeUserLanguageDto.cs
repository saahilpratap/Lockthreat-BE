using System.ComponentModel.DataAnnotations;

namespace Lockthreat.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
