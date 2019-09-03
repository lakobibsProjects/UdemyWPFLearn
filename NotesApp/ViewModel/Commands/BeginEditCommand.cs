using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotesApp.ViewModel.Commands
{
    public class BeginEditCommand : ICommand
    {
        public NotesVM NotesVM { get; set; }
        public event EventHandler CanExecuteChanged;

        public BeginEditCommand(NotesVM vm)
        {
            NotesVM = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            NotesVM.StartEditing();
        }
    }
}
