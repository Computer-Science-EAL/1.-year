using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mocking
{
    public interface ILoginModule
    {
        void Login(User user);
        void Register(User user);
        void ResendPassword(User user);
    }
}
