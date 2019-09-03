using NotesApp.Model;
using NotesApp.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.ViewModel
{
    public class LoginVM
    {
        private User user;

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public RegisterCommand RegisterCommand{ get; set; }
        public LoginCommand LoginCommand { get; set; }

        public event EventHandler HasLoggedIn;

        public LoginVM()
        {
            User = new User();
            RegisterCommand = new RegisterCommand(this);
            LoginCommand = new LoginCommand(this);
        }

        public void Login()
        {
            using (SQLite.SQLiteConnection c = new SQLite.SQLiteConnection(DatabaseHelper.dbFile, true))
            {
                c.CreateTable<User>();

                var user = c.Table<User>().Where(u => u.UserName == User.UserName).FirstOrDefault();

                if(user.Password == User.Password)
                {
                    App.UserId = user.Id.ToString();
                    HasLoggedIn(this, new EventArgs());
                }
            }
        }

        public void Register()
        {
            using (SQLite.SQLiteConnection c = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
            {
                c.CreateTable<User>();

                var result = DatabaseHelper.Insert(User);

                if (result)
                {
                    App.UserId = user.Id.ToString();
                    HasLoggedIn(this, new EventArgs());
                }
            }
        }


    }
}
