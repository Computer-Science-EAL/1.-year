using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mocking
{
    public interface IMailModule
    {
        void SendMail(Mail mail, Employee employee);
        Mail GetEmailById(int id);
        void AddToDraft(Mail mail);
        void AddToSentMessages(Mail mail);
        void AddToSentSpam(Mail mail);
        List<Mail> GetAllMail();
    }
}
