﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotesApp.ViewModel.Commands
{
    public class NewNotebookCommand : ICommand
    {
        public NotesVM VM { get; set; }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public NewNotebookCommand(NotesVM vm)
        {
            VM = vm;
        }

        public void Execute(object parameter)
        {
            //TODO new notebook functionality
            VM.CreateNotebook();
        }
    
    }
}
