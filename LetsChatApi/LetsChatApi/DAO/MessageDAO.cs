using LetsChatApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetsChatApi.DAO
{
    public class MessageDAO
    {
        LetsChatEntities entities = new LetsChatEntities();

        public void AddMessage(Int64 userId, string messageText)
        {
            Message message = new Message
            {
                UserId = userId,
                MesssageText = messageText,
                Time = DateTime.Now
            };

            entities.Messages.Add(message);
            entities.SaveChanges();
        }

        public List<MessageDto> GetLast15Messages()
        {
            return entities.Messages.OrderByDescending(x => x.Time).Take(15).OrderBy(x => x.Time).
                Select(x => new MessageDto { name = x.User.Username, message = x.MesssageText, time = x.Time }).ToList();
        }
    }
}