using FormationXamForms.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace FormationXamForms.Commands
{
    public class AddCommand : ICommand
    {
        public CalculViewModel calculViewModel { get; set; }

        public AddCommand(CalculViewModel calculViewModel)
        {
            this.calculViewModel = calculViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            calculViewModel.Add();
        }
    }
}
