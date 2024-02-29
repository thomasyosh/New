using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Model;

namespace WinFormsApp1.Controller
{
    public class UserController
    {
        User user;
        AppDbContext db = new AppDbContext();

        public UserController(User _user) {
            this.user = _user;
        }
        public UserController()
        {
        }


        public string AddUser() {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            User temp = db.Users.FirstOrDefault(x => x.UserName == user.UserName); 
            if (temp == null)
            {
                db.Add(user);
                db.SaveChanges();
                return "user create successfully";
            }
            else
                return "duplicate use found";

        }


        public IQueryable<User> FindUser(){
            return db.Users;
    }

        public bool isActiveUser(User _user) {
            User user = db.Users.
                Where(s => s.isActive == true).
                Where(u => u.UserName == _user.UserName).
                FirstOrDefault();
            return user != null? true : false;
        }

        
        public bool isExistUser(User _user) {
            User user = db.Users.
                Where(u => u.UserName == _user.UserName).
                FirstOrDefault();
            if (user != null)
                return true;
            else
                return false;
        }
        
        
        public bool isPasswordCorrect(User _user)
        {

            if (isExistUser(_user)) {
                User user = db.Users.
                Where(u => u.UserName == _user.UserName).
                FirstOrDefault();
            return BCrypt.Net.BCrypt.Verify(_user.Password, user.Password);
            }
                
            else
                return false;
        
    }


        public int isValidUser(User _user) {
            bool isActive = isActiveUser(_user);
            bool isExist = isExistUser(_user);
            bool isPwdCorrect = isPasswordCorrect(_user);

            if (!isExist)
                return 1;
            else if (!isActive)
                return 2;
            else if (!(isPwdCorrect && isActive))
                return 3;
            else if (isActive && isPwdCorrect)
                return 9;
            else
                return 0;



        }

 
    }
}
