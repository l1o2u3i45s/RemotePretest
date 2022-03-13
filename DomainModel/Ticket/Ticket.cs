using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Ticket
{ 
    public abstract class Ticket  
    {
        protected string _summary { get; set; }

        protected string _description { get; set; }

        protected TicketStatus _status { get; set; }= TicketStatus.Created;

        public Ticket(string summary, string description)
        {
            _summary = summary;
            _description = description;
        }

        public void SetBugStatus(TicketStatus status)
        {
            _status = status;
        }

        public string GetSummary()
        {
            return _summary;
        }

        public void SetSummary(string summary)
        {
            _summary = summary;
        }

        public void SetDescription(string description)
        {
            _description = description;
        }

        public string GetDescription()
        {
            return _description;
        }

        public abstract bool CanExecuteCreate(User.User user);
         
        public abstract bool CanExecuteEdit(User.User user); 

        public abstract bool CanExecuteDelete(User.User user); 

        public abstract bool CanExecuteResolved(User.User user);

    }
}
