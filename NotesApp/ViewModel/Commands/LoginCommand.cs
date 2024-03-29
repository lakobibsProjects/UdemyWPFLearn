﻿using NotesApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotesApp.ViewModel.Commands
{
    public class LoginCommand : ICommand
    {
        public LoginVM VM { get; set; }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //var user = parameter as User;
            //if(user != null)
            //{
            //if (string.IsNullOrEmpty(user.UserName))
            //    return false;
            //if (string.IsNullOrEmpty(user.Password))
            //    return false;


            //}
            return true;
        }
        public LoginCommand(LoginVM vm)
        {
            VM = vm;
        }

        public void Execute(object parameter)
        {
            VM.Login();
        }
    }
}
