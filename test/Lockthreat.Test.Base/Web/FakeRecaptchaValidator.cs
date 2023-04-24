using System.Threading.Tasks;
using Lockthreat.Security.Recaptcha;

namespace Lockthreat.Test.Base.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}
