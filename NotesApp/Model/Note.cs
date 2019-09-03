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
    public class Note
    {

        #region Fields
        private int id;
        private int notebookId;
        private string title;
        private DateTime createdTime;
        private DateTime updatedTime;
        private string fileLocation;
        #endregion Fields

        #region Properties
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [Indexed]
        public int NotebookId
        {
            get { return notebookId; }
            set { notebookId = value; }
        }

        public string Titel
        {
            get { return title; }
            set { title = value; }
        }

        public DateTime CreatedTime
        {
            get { return createdTime; }
            set { createdTime = value; }
        }

        public DateTime UpdatedTime
        {
            get { return updatedTime; }
            set { updatedTime = value; }
        }

        public string FileLocation
        {
            get { return fileLocation; }
            set { fileLocation = value; }
        }


        #endregion Properties

    }
}
