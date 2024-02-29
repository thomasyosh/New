using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Model
{
    public class UserMessage
    {
        public string UserId { get; set; }
        public string MessageId { get; set; }

        public User? User { get; set; }
        public Message? Message { get; set; }
    }
}
