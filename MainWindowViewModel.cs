using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MaterialCalculator
{
    public class MainWindowViewModel : ViewModel
    {

        private CalculatorModel Calculation;

        private int? _operand1;
        private char? _operator;
        private int? _operand2;
        private object _result;


       
        #region Program Title
        private string _Title = "Material Calculator";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        #endregion


        #region Display // main display
        private string _Display = "64";
        public string Display
        {
            get => _Display;
            set => Set(ref _Display, value);
        }
        #endregion

        #region EquationDisplay // EquationDisplay display
        private string _EquationDisplay = "5+12=17";
        public string EquationDisplay
        {
            get => _EquationDisplay;
            set => Set(ref _EquationDisplay, value);
        }
        #endregion


        #region Clear Display Command
        public ICommand ClearDisplayCommand { get; }
        private void OnClearDisplayCommandExecuted(object p)
        {
            _operand1 = null;
            _operator = null;
            _operand2 = null;
            _result = null;
            Display = "0";
            EquationDisplay = "";
        }
        private bool CanClearDisplayCommandExecute(object p) => true;

        #endregion


        #region NumberCommand
        public ICommand NumberCommand { get; }
        private void OnNumberCommandExecuted(object p)
        {
            if (Display != null)
            {
                Display = "";
            }
            Display += (string)p;
        }
        private bool CanNumberCommandExecute(object p) => true;
        #endregion

        #region PlusCommand
        public ICommand PlusCommand { get; }
        private void OnPlusCommandExecuted(object p)
        {           
            EquationDisplay += Display + "+";          
        }
        private bool CanPlusCommandExecute(object p) => true;
        #endregion


        #region MinusCommand
        public ICommand MinusCommand { get; }
        private void OnMinusCommandExecuted(object p)
        {
            //TODO
        }
        private bool CanMinusCommandExecute(object p) => true;
        #endregion


        #region MultiplyCommand
        public ICommand MultiplyCommand { get; }
        private void OnMultiplyCommandExecuted(object p)
        {
           //TODO
        }
        private bool CanMultiplyCommandExecute(object p) => true;
        #endregion


        #region DivideCommand
        public ICommand DivideCommand { get; }
        private void OnDivideCommandExecuted(object p)
        {
            //TODO
        }
        private bool CanDivideCommandExecute(object p) => true;
        #endregion


        #region EqualCommand
        public ICommand EqualCommand { get; }
        private void OnEqualCommandExecuted(object p)
        {
           //TODO
        }
        private bool CanEqualCommandExecute(object p) => true;
        #endregion


        public MainWindowViewModel()
        {
            #region Commands in application

            ClearDisplayCommand = new LambdaCommand(OnClearDisplayCommandExecuted, CanClearDisplayCommandExecute);
            NumberCommand = new LambdaCommand(OnNumberCommandExecuted, CanNumberCommandExecute);

            PlusCommand = new LambdaCommand(OnPlusCommandExecuted, CanPlusCommandExecute);
            MinusCommand = new LambdaCommand(OnMinusCommandExecuted, CanMinusCommandExecute);
            MultiplyCommand = new LambdaCommand(OnMultiplyCommandExecuted, CanMultiplyCommandExecute);
            DivideCommand = new LambdaCommand(OnDivideCommandExecuted, CanDivideCommandExecute);

            #endregion

        }
    }
}
