using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.IRepo
{
    public interface IMessageRepo
    {
        IQueryable<Message> GetMessagesForCurrentUser(string userId);

        IQueryable<Message> GetSentMessagesByCurrentUser(string userId);

        Message GetMessage(int? id);

        bool IfExist(string mail);

        string GetRecipientIdByEmail(string email);

        void SetDateTime(int? id, DateTime dt);

        void DeleteMessage(int? id);

        void SendMessage(Message msg);

        void SaveChanges();

    }
}
