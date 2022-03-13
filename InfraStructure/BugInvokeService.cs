using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using DomainModel.Ticket;
using DomainModel.User;

namespace InfraStructure
{
    public class BugInvokeService
    {
        private User _user;

        public Ticket _ticket;


        public BugInvokeService(User user, Ticket ticket)
        {
            _user = user;
            _ticket = ticket;
        }

        public Ticket GetTicket()
        {
            return _ticket;
        }

        public User GetUser()
        {
            return _user;
        }

        public bool ExecuteCreateTicket(string summary, string description)
        {
            if (_ticket == null && _ticket.CanExecuteEdit(_user))
                return false;

            _ticket.SetSummary(summary);
            _ticket.SetDescription(description);
            return true;
        }

        public bool ExecuteEditTicket(string summary,string description)
        {
            if (_ticket == null && _ticket.CanExecuteEdit(_user))
                return false;

            _ticket.SetSummary(summary);
            _ticket.SetDescription(description);
             
            return true;
        }

        public bool ExecuteResolvedTicket()
        {
            if ( _ticket == null && _ticket.CanExecuteResolved(_user))
                return false;

            _ticket.SetBugStatus(TicketStatus.Resolved);

            return true;
        }

        public bool ExecuteDeleteTicket()
        {
            if (_ticket == null && _ticket.CanExecuteDelete(_user))
                return false;

            _ticket.SetBugStatus(TicketStatus.Deleted);

            return true;
        }

        public bool IsEnableCreate()
        {
            return GetTicket().CanExecuteCreate(GetUser());
        }

        public bool IsEnableEdit()
        {
            return GetTicket().CanExecuteEdit(GetUser());
        }

        public bool IsEnableDelete()
        {
            return GetTicket().CanExecuteDelete(GetUser());
        }

        public bool IsEnableResolve()
        {
            return GetTicket().CanExecuteResolved(GetUser());
        }
    }
}
