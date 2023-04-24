using System.ComponentModel.DataAnnotations;

namespace Lockthreat.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}