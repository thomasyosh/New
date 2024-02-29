using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Model
{
    public class User
    {
        [Key]
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Boolean isActive { get; set; }

        public DateTime date { get; set; }

        public ICollection<Message> Message { get; set; } = new List<Message>();   

        public User(string UserName, string Password) { 
           Guid guid = Guid.NewGuid();
           this.UserId = guid.ToString();
           this.UserName = UserName;
           this.Password = Password;
           this.isActive = true;
           this.date = DateTime.Now;
        }

        public User()
        {
        }
    }
}
