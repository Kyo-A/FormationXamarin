using FormationXamForms.Commands;
using FormationXamForms.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using static FormationXamForms.Models.CalculModel;

namespace FormationXamForms.ViewModels
{
    public class CalculViewModel : BaseViewModel
    {
        private double numberOne;

        ObservableCollection<Result> Results { get; set; }

        public double NumberOne
        {
            get { return numberOne; }
            set
            {
                numberOne = value;
                OnPropertyChanged("NumberOne");
            }
        }

        private double numberTwo;

        public double NumberTwo
        {
            get { return numberTwo; }
            set
            {
                numberTwo = value;
                OnPropertyChanged("NumberTwo");
            }
        }

        private double result;

        public double Result
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChanged("Result");
                Results.Add(new CalculModel.Result() { Value = result });
            }
        }

        public AddCommand AddCommand { get; set; }
        public DivideCommand DivideCommand { get; set; }

        public CalculViewModel()
        {
            AddCommand = new AddCommand(this);
            DivideCommand = new DivideCommand(this);

            Results = new ObservableCollection<Result>();
        }

        public void Add()
        {
            Result = CalculModel.Add(NumberOne, NumberTwo);
        }

        public void Divide()
        {
            Result = CalculModel.Divide(NumberOne, NumberTwo);
        }

    }
}
