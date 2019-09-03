﻿using NotesApp.Model;
using NotesApp.ViewModel.Commands;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.ViewModel
{
    [AddINotifyPropertyChangedInterfaceAttribute]
    public class NotesVM
    {
        public bool IsEditing { get; set; }
        public ObservableCollection<Notebook> Notebooks { get; set; }
        public event EventHandler SelectedNotedChanged;

        private Note note;

        public Note SelectedNote
        {
            get { return note; }
            set
            {
                note = value;
                SelectedNotedChanged(this, new EventArgs());
            }
        }


        private Notebook selectedBook;

        public Notebook SelectedBook
        {
            get { return selectedBook; }
            set
            {
                selectedBook = value;
                ReadNotes();
            }
        }
        public ObservableCollection<Note> Notes { get; set; }

        public NewNotebookCommand NewNotebookCommand { get; set; }
        public NewNoteCommand NewNoteCommand { get; set; }
        public BeginEditCommand BeginEditCommand { get; set; }
        public HasEditedCommand HasEditedCommand { get; set; }

        public NotesVM()
        {
            IsEditing = false;

            NewNoteCommand = new NewNoteCommand(this);
            NewNotebookCommand = new NewNotebookCommand(this);
            BeginEditCommand = new BeginEditCommand(this);
            HasEditedCommand = new HasEditedCommand(this);

            Notebooks = new ObservableCollection<Notebook>();
            Notes = new ObservableCollection<Note>();

            ReadNotebooks();
            ReadNotes();
        }

        public void CreateNotebook()
        {
            Notebook newNotebook = new Notebook()
            {
                Name = "New notebook",
                UserId = int.Parse(App.UserId),
            };

            DatabaseHelper.Insert(newNotebook);

            ReadNotebooks();
        }
        public void CreateNote (int notebookId)
        {
            Note newNote = new Note()
            {
                NotebookId = notebookId,
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now,
                Titel = "New note"
            };

            DatabaseHelper.Insert(newNote);

            ReadNotes();
        }

        public void ReadNotebooks()
        {
            using(SQLite.SQLiteConnection c = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
            {
                var notebooks = c.Table<Notebook>().ToList();

                Notebooks.Clear();
                foreach (var nb in notebooks)
                {
                    Notebooks.Add(nb);
                }
            }
        }

        public void ReadNotes()
        {

            using (SQLite.SQLiteConnection c = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
            {
                if (SelectedBook != null)
                {
                    try
                    {
                        var notes = c.Table<Note>().Where(n => n.NotebookId == SelectedBook.Id).ToList();

                        Notes.Clear();                        
                        foreach (var n in notes)
                        {
                            Notes.Add(n);
                        }
                        //SelectedBook = Notebooks.FirstOrDefault();

                    }
                    catch(StackOverflowException ex)
                    {

                    }
                    catch(Exception ex)
                    {

                    }
                }
            }
        }

        public void StartEditing()
        {
            IsEditing = true;
        }


        public void HasRenamed(Notebook notebook)
        {
            if(notebook != null)
            {
                DatabaseHelper.Update(notebook);
                IsEditing = false;
                ReadNotebooks();
            }

        }

        public void UpdateSelectedNote()
        {
            DatabaseHelper.Update(SelectedNote);
        }
    }
}
