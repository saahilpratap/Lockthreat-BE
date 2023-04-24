using System.Collections.Generic;
using MvvmHelpers;
using Lockthreat.Models.NavigationMenu;

namespace Lockthreat.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}