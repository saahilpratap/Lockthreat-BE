namespace Lockthreat
{
    public class LockthreatConsts
    {
        public const string LocalizationSourceName = "Lockthreat";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;

        public const bool AllowTenantsToChangeEmailSettings = false;

        public const string Currency = "USD";

        public const string CurrencySign = "$";

        public const string AbpApiClientUserAgent = "AbpApiClient";

        public const string Entity = "Entity";

        public const string Unit = "Unit";

        public const string Employee = "Employee";

        public const string Project = "Project";

        public const string Program = "program";

        public const string StrategicObjective = "StrategicObjective";
        public const string SOB = "SOB";

        public const string BusinessService  = "BusinessServices";

        public const string KRI = "KRI";

        public const string KPI  = "KPI";

        public const string BusinessProcess = "Business Process";

        public const string ITService = "ITService";
        public const string ITS = "ITS";

        public const string MOM = "Minutes of Meetings";

        public const string TASk  = "Task";

        public const string FID = "FID";

        public const string HAR = "HardWareAsset";

        public const string AST = "AST";

        public const string VAM = "VAM";

        public const string SYS = "SYS";
        public const string AUD = "AUD";
        public const string EXC = "EXC";
        public const string VEN = "VEN";
        public const string CON = "CON";
        public const string CNT = "CNT";
        // Note:
        // Minimum accepted payment amount. If a payment amount is less then that minimum value payment progress will continue without charging payment
        // Even though we can use multiple payment methods, users always can go and use the highest accepted payment amount.
        //For example, you use Stripe and PayPal. Let say that stripe accepts min 5$ and PayPal accepts min 3$. If your payment amount is 4$.
        // User will prefer to use a payment method with the highest accept value which is a Stripe in this case.
        public const decimal MinimumUpgradePaymentAmount = 1M;
    }
}
