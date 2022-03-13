using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.User
{
    public interface User
    {
        UserType UserType { get;  set; }
      
    }
    public class RD : User
    {
        public UserType UserType
        {
            get { return UserType.RD;}
            set{}
        }
       
    }

    public class QA : User
    {
        public UserType UserType
        {
            get { return UserType.QA; }
            set { }
        }
      
    }

    public class PM : User
    {
        public UserType UserType
        {
            get { return UserType.PM; }
            set { }
        }
      
    }
}
