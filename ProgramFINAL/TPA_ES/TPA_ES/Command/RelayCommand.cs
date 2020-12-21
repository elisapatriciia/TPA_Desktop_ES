﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;
namespace TPA_ES.Command
{
    class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action DoWork;

        public RelayCommand(Action work)
        {
            DoWork = work;
        }
        public bool CanExecute(object parameter)
        {
            //ubah jadi ini
            return true;
        }

        public void Execute(object parameter)
        {
            DoWork();
        }
    }
}
