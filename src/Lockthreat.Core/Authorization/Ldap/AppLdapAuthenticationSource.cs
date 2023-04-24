using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using Lockthreat.Authorization.Users;
using Lockthreat.MultiTenancy;

namespace Lockthreat.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}