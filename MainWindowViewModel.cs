using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MaterialCalculator
{
    public class MainWindowViewModel : ViewModel
    {

        private CalculatorModel Calculation = new CalculatorModel();

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
        public ICommand EqualsCommand { get; }
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

            NumberCommand = new LambdaCommand(param => { Number(Convert.ToInt32(param)); },
                                            param => CanDoNumber());

            PlusCommand = new LambdaCommand(param => { Plus(); },
                                            param => CanDoOperator());

            MinusCommand = new LambdaCommand(param => { Minus(); },
                                            param => CanDoOperator());

            MultiplyCommand = new LambdaCommand(param => { Multiply(); },
                                            param => CanDoOperator());

            DivideCommand = new LambdaCommand(param => { Divide(); },
                                            param => CanDoOperator());

            EqualsCommand = new LambdaCommand(param => { Calculate(); },
                                                param => CanCalculate());


            #endregion

        }

        ////
        public bool CanDoOperator()
        {
            return _operand1.HasValue && !_operator.HasValue;
        }
        //// Выполнение оператора
        private void DoOperator(char o)
        {
            if (!CanDoOperator())
            {
                throw new InvalidOperationException();
            }

            _operator = o;
            Display += " " + o + " ";
        }
        ////

        //Do operator
        public void Plus()
        {
            DoOperator('+');
        }

        public void Minus()
        {
            DoOperator('-');
        }

        public void Multiply()
        {
            DoOperator('*');
        }

        public void Divide()
        {
            DoOperator('/');
        }
        //////
        ///
        //Can Do Number? 
        public bool CanDoNumber()
        {
            return _result == null;
        }

        /// <summary>
        /// 
        // Number
        public void Number(int num)
        {
            if (!CanDoNumber())
            {
                throw new InvalidOperationException();
            }

            if ((num < 0) || (num > 9))
            {
                throw new ArgumentException();
            }

            if (!_operator.HasValue)
            {
                if (!_operand1.HasValue)
                {
                    _operand1 = num;
                    Display = num.ToString();
                }
                else
                {
                    _operand1 = _operand1 * 10 + num;
                    Display += num;
                }
            }
            else
            {
                if (!_operand2.HasValue)
                {
                    _operand2 = num;
                }
                else
                {
                    _operand2 = _operand2 * 10 + num;
                }

                Display += num;
            }
        }

        // Can Calculate ? 
        public bool CanCalculate()
        {
            return (_operand1.HasValue && _operator.HasValue && _operand2.HasValue && _result == null);
        }

        // Calculate Button method
        private void Calculate()
        {
            if (!CanCalculate())
            {
                throw new InvalidOperationException();
            }

            _result = this.Calculation.Calculate(_operand1.Value, _operand2.Value, _operator.Value);
            if (_result == null)
            {
                MessageBox.Show("Ошибка вычисления!");
                return;
            }

            Display = _result.ToString();
            EquationDisplay = Convert.ToString(_operand1.Value) + " " + _operator.Value + " " + Convert.ToString(_operand2.Value) + " = "+ Convert.ToString(_result);
        }


    }
}
