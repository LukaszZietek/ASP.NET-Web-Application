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

        Message GetMessage(int? id);

        void SetDateTime(int? id, DateTime dt);

        void DeleteMessage(int? id);

        void SendMessage(Message msg);

        void SaveChanges();

    }
}
