using System;
using System.Collections.Generic;
using System.Text;

namespace MobinTrader.Enums
{
    public enum OrderValidity
    {
        DAY = 74,
        VALID_UNTIL_SPECIFIC_DAY = 68,
        VALID = 70,
        FILL_AND_KILL = 69,
        SESSION = 83
    }
}
