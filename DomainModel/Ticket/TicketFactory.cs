using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Ticket
{
    public class TicketFactory
    {
        public static Ticket Create(TicketType type,string summary = "",string description = "")
        {
            switch (type)
            {
                case TicketType.Bug:
                    return new Bug(summary, description);
                    break;
                case TicketType.FeatureRequest:
                    return new FeatureRequest(summary, description);
                    break;
                case TicketType.TestCase:
                    return new TestCase(summary, description);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
