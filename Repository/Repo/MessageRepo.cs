using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Repository.IRepo;
using Repository.Models;
using EntityState = System.Data.Entity.EntityState;

namespace Repository.Repo
{
    public class MessageRepo: IMessageRepo
    {
        private readonly ICrudoContext _db;

        public MessageRepo(ICrudoContext db)
        {
            _db = db;
        }

        public IQueryable<Message> GetMessagesForCurrentUser(string userId)
        {
            return _db.Messages.Where(x => x.RecipientId.Equals(userId)).AsNoTracking();
        }

        public IQueryable<Message> GetSentMessagesByCurrentUser(string userId)
        {
            return _db.Messages.Where(x => x.SenderId.Equals(userId)).AsNoTracking();
        }

        public Message GetMessage(int? id)
        {
            if (id != null)
            {
                return _db.Messages.Find(id);
            }

            return null;
        }

        public bool IfExist(string mail)
        {
            var user = _db.WebsiteUsers.Where(x => x.EmailAddress.Equals(mail)).FirstOrDefault();
            if (user != null)
            {
                return true;
            }

            return false;
        }

        public string GetRecipientIdByEmail(string email)
        {
            
            return _db.WebsiteUsers.Where(x => x.EmailAddress.Equals(email)).FirstOrDefault().Id;
        }

        public void SetDateTime(int? id, DateTime dt)
        {
            var msg = _db.Messages.Find(id);
            if (msg != null)
            {
                msg.OpenTime = dt;
            }

            _db.Entry(msg).State = EntityState.Modified;
        }

        public void DeleteMessage(int? id)
        {
            var msg = _db.Messages.Find(id);
            if (msg != null)
            {
                _db.Messages.Remove(msg);
            }
        }

        public void SendMessage(Message msg)
        {
            if (msg != null)
            {
                _db.Messages.Add(msg);
            }
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}