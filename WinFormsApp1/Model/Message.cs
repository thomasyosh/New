using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Model
{
    public class Message
    {
        [Key]
        public string MessageId { get; set; }
        public ICollection<User> User { get; set; }
        public string Content { get; set; }
        public DateTime MessageDate { get; set; }
        public bool isActive { get; set; }
    }
}
