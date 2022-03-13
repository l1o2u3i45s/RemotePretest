using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.User
{
    public class UserFactory
    {
        public static User CreateUser(UserType type)
        {
            switch (type)
            {
                case UserType.QA:
                    return new QA();
                case UserType.RD:
                    return new RD();
                case UserType.PM:
                    return new PM();
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

    }
}
