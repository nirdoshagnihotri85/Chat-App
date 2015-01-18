using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetsChatApi.Dto
{
    public class MessageDto
    {
        public Int64 userId { get; set; }
        public string message { get; set; }
        public string name { get; set; }
        public DateTime time { get; set; }
    }
}