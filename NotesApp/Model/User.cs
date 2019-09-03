using PropertyChanged;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Model
{
    [AddINotifyPropertyChangedInterfaceAttribute]
    public class User
    {
        #region Fields
        private int id;
        private string userName;
        private string name;
        private string lastName;
        private string email;
        private string password;
        #endregion

        #region Properties
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        [MaxLength(50)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [MaxLength(50)]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        #endregion Properties

    }
}
