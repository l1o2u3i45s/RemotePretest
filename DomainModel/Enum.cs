using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public enum TicketStatus
    {
        Created,
        Deleted,
        Resolved
    }

    public enum UserType
    {
        QA,
        RD,
        PM
    }

    public enum TicketType
    {
        Bug,
        FeatureRequest,
        TestCase
    }
}
