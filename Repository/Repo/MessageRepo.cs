using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
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
            return _db.Messages.Where(x => x.RecipientId == userId).AsNoTracking();
        }

        public Message GetMessage(int? id)
        {
            if (id != null)
            {
                return _db.Messages.Find(id);
            }

            return null;
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