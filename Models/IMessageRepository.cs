using System.Collections.Generic;

namespace GetOnTrades.Models
{
    public interface IMessageRepository
    {
            IEnumerable<ProcessedMessage> AllMessages { get;  }
            string AllMessagesString { get;  }
    }
}
