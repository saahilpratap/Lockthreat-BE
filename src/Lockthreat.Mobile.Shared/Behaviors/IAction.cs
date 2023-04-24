using Xamarin.Forms.Internals;

namespace Lockthreat.Behaviors
{
    [Preserve(AllMembers = true)]
    public interface IAction
    {
        bool Execute(object sender, object parameter);
    }
}