using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Ticket
{
    public class TestCase:Ticket
    {
        public TestCase(string summary, string description) : base(summary, description)
        {
        }

        public override bool CanExecuteCreate(User.User user)
        {
            if (user == null)
                return false;

            return user.UserType == UserType.QA;
        }

        public override bool CanExecuteEdit(User.User user)
        {
            if (user == null)
                return false;

            return user.UserType == UserType.QA;
        }

        public override bool CanExecuteDelete(User.User user)
        {
            if (user == null)
                return false;

            return user.UserType == UserType.QA;
        }

        public override bool CanExecuteResolved(User.User user)
        {
            if (user == null)
                return false;

            return user.UserType == UserType.QA;
        }
    }
}
