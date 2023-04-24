using System.Threading.Tasks;
using Lockthreat.Views;
using Xamarin.Forms;

namespace Lockthreat.Services.Modal
{
    public interface IModalService
    {
        Task ShowModalAsync(Page page);

        Task ShowModalAsync<TView>(object navigationParameter) where TView : IXamarinView;

        Task<Page> CloseModalAsync();
    }
}
