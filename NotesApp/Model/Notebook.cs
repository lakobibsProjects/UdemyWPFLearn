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
    public class Notebook
    {
        #region Fields
        private int id;
        private int userId;
        private string name;
        #endregion Fields

        #region Properties
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [Indexed]
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        #endregion Properties

    }
}
