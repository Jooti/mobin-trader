using System;
using System.Collections.Generic;
using System.Text;

namespace MobinTrader.Enums
{
    public enum OrderStatus
    {
        None = 0,
        Modify,
        Error,
        Cancel,
        Delete,
        Done,
        OnBoard,
        OnSending,
        PartiallyExcution,
        OnCanceling,
        OnCancelError,
        OnModifyError,
        DeleteByBroker,
        Expired,
        PartiallyExcutionAndExpired,
        CancelByBrokerForUnBlock,
        OnModify,
        DeleteByNSC,
        CancelByBrokerForOrderOnAir,
        OnModifyBoard,
        OrderExecuted,
        PendingConfirm,
        Confirmed,
        PendingCancelOrder,
        CancelOrderConfirmed,
        Reject,
        CancelPendingOrderByUser,
        CancelCancelPendingOrderByUser,
        InOmsQueue
    }
}
