using LetsChatApi.DAO;
using LetsChatApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LetsChatApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Message")]
    public class MessageController : ApiController
    {
        MessageDAO _messageDAO = new MessageDAO();

        // GET: api/Message
        public IEnumerable<MessageDto> Get()
        {
            return _messageDAO.GetLast15Messages();
        }

        // POST: api/Message
        public void Post(MessageDto message)
        {
            _messageDAO.AddMessage(message.userId, message.message);
        }
    }
}
