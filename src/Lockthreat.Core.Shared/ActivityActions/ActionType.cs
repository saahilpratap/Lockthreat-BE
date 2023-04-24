using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.ActivityActions
{
   public enum ActionType
    {
        Email = 1,
        SMS = 2,
        webhook = 3,
        customfunction=4
    }

    public enum ActionCategory
    {
        Early = 1,
        Onday = 2,
        Escalation = 3
        
    }
    public enum ActionTimeType
    {
        Minutes=1,
        Hours=2,
        Days=3,
        Weeks=4,
        Months=5
    }
  
    
}
