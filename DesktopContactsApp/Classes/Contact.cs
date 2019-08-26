using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopContactsApp.Classes
{
    public class Contact
    {
        private string name;
        private string eMail;
        private string phoneNumber;

        #region Properties
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Phone
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string EMail
        {
            get { return eMail; }
            set { eMail = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        #endregion Properties

    }
}
