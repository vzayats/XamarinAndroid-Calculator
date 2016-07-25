using System;
using Android.App;
using Android.Widget;
using Android.OS;

namespace AndroidCalculator
{
    [Activity(Label = "Android Calculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private readonly Calc _calc;

        public KeyInput? InputKey = KeyInput.Digit;
        public enum Operations { Addition, Subtraction, Division, Multiply, Evolution }
        public enum KeyInput { Digit, Operator, Equal, DecimalPoint, Sign }

        public double? DigitalMemory;
        public double? TotalMemory;

        public Operations? OperateMemory;
        public MainActivity()
        {
            _calc = new Calc(this);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            Button button0 = FindViewById<Button>(Resource.Id.button0);
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            Button button5 = FindViewById<Button>(Resource.Id.button5);
            Button button6 = FindViewById<Button>(Resource.Id.button6);
            Button button7 = FindViewById<Button>(Resource.Id.button7);
            Button button8 = FindViewById<Button>(Resource.Id.button8);
            Button button9 = FindViewById<Button>(Resource.Id.button9);
            Button buttonMultiply = FindViewById<Button>(Resource.Id.buttonMultiply);
            Button buttonDivision = FindViewById<Button>(Resource.Id.buttonDivision);
            Button buttonSubtraction = FindViewById<Button>(Resource.Id.buttonSubtraction);
            Button buttonAddition = FindViewById<Button>(Resource.Id.buttonAddition);
            Button buttonResult = FindViewById<Button>(Resource.Id.buttonResult);
            Button buttonPoint = FindViewById<Button>(Resource.Id.buttonPoint);
            Button buttonClear = FindViewById<Button>(Resource.Id.buttonClear);
            Button buttonCe = FindViewById<Button>(Resource.Id.buttonCe);
            Button buttonSqrt = FindViewById<Button>(Resource.Id.buttonSqrt);

            EditText editTextOperate = FindViewById<EditText>(Resource.Id.editTextOperate);
            TextView textViewResult = FindViewById<TextView>(Resource.Id.textViewResult);

            buttonPoint.Click += delegate
            {
                if (InputKey != KeyInput.Digit && InputKey != KeyInput.DecimalPoint && InputKey != KeyInput.Sign)
                {
                    editTextOperate.Text = ".";
                    InputKey = KeyInput.DecimalPoint;
                    return;
                }
                if (!editTextOperate.Text.Contains("."))
                {
                    editTextOperate.Text = DigitalMemory + ".";
                    InputKey = KeyInput.DecimalPoint;
                }
            };

            button1.Click += delegate
            {                 
                CurrentValueToMemory(editTextOperate.Text, "1");
                editTextOperate.Text = DigitalMemory.ToString();
                _calc.Calculation();
                InputKey = KeyInput.Digit;
            };

            button2.Click += delegate
            {
                CurrentValueToMemory(editTextOperate.Text, "2");
                editTextOperate.Text = DigitalMemory.ToString();
                _calc.Calculation();
                InputKey = KeyInput.Digit;
            };

            button3.Click += delegate
            {
                 
                CurrentValueToMemory(editTextOperate.Text, "3");
                editTextOperate.Text = DigitalMemory.ToString();
                _calc.Calculation();
                InputKey = KeyInput.Digit;
            };

            button4.Click += delegate
            {                 
                CurrentValueToMemory(editTextOperate.Text, "4");
                editTextOperate.Text = DigitalMemory.ToString();
                _calc.Calculation();
                InputKey = KeyInput.Digit;
            };

            button5.Click += delegate
            {                 
                CurrentValueToMemory(editTextOperate.Text, "5");
                editTextOperate.Text = DigitalMemory.ToString();
                _calc.Calculation();
                InputKey = KeyInput.Digit;
            };

            button6.Click += delegate
            {                
                CurrentValueToMemory(editTextOperate.Text, "6");
                editTextOperate.Text = DigitalMemory.ToString();
                _calc.Calculation();
                InputKey = KeyInput.Digit;
            };

            button7.Click += delegate
            {
                CurrentValueToMemory(editTextOperate.Text, "7");
                editTextOperate.Text = DigitalMemory.ToString();
                _calc.Calculation();
                InputKey = KeyInput.Digit;
            };

            button8.Click += delegate
            {
                CurrentValueToMemory(editTextOperate.Text, "8");
                editTextOperate.Text = DigitalMemory.ToString();
                _calc.Calculation();
                InputKey = KeyInput.Digit;
            };

            button9.Click += delegate
            {
                CurrentValueToMemory(editTextOperate.Text, "9");
                editTextOperate.Text = DigitalMemory.ToString();
                _calc.Calculation();
                InputKey = KeyInput.Digit;
            };

            button0.Click += delegate
            {
                CurrentValueToMemory(editTextOperate.Text, "0");
                editTextOperate.Text = DigitalMemory.ToString();
                _calc.Calculation();
                InputKey = KeyInput.Digit;
            };

            buttonClear.Click += delegate
            {
                editTextOperate.Text = String.Empty;
                ClearMemory();
            };

            buttonAddition.Click += delegate
            {
                if (InputKey == KeyInput.Digit || InputKey == KeyInput.Operator)
                {
                    PerformCalculation(Operations.Addition, editTextOperate);
                }
            };

            buttonSubtraction.Click += delegate
            {
                if (InputKey == KeyInput.Digit || InputKey == KeyInput.Operator)
                {
                    PerformCalculation(Operations.Subtraction, editTextOperate);
                }
            };

            buttonMultiply.Click += delegate
            {
                if (InputKey == KeyInput.Digit || InputKey == KeyInput.Operator)
                {
                    PerformCalculation(Operations.Multiply, editTextOperate);
                }
            };

            buttonDivision.Click += delegate
            {
                if (InputKey == KeyInput.Digit || InputKey == KeyInput.Operator)
                {
                    PerformCalculation(Operations.Division, editTextOperate);
                }
            };

            buttonSqrt.Click += delegate
            {
                PerformCalculation(Operations.Evolution, editTextOperate);
                textViewResult.Text = string.Empty;
            };

            buttonResult.Click += delegate
            {
                InputKey = KeyInput.Equal;
                textViewResult.Text = TotalMemory.ToString();
                ClearMemory();
            };

            buttonClear.Click += delegate
            {
                ClearDisplayText(editTextOperate, textViewResult);
                ClearMemory();
            };

            buttonCe.Click += delegate {
                if (editTextOperate.Text.Length > 0)
                {
                    editTextOperate.Text = editTextOperate.Text.Remove(editTextOperate.Text.Length - 1);
                }
            };
        }
        private void PerformCalculation(Operations operations, EditText editTextOperate)
        {
            OperateMemory = operations;
            editTextOperate.Text = TotalMemory.ToString();
            InputKey = KeyInput.Operator;
        }
        private void CurrentValueToMemory(string currentValue, string character)
        {
            if (InputKey == KeyInput.Digit || InputKey == KeyInput.DecimalPoint || InputKey == KeyInput.Sign)
            {
                DigitalMemory = double.Parse(currentValue + character);
            }
            else
            {
                DigitalMemory = double.Parse(character);
            }
        }

        private void ClearDisplayText(EditText editTextOperate, TextView textViewResult)
        {
            editTextOperate.Text = string.Empty;
            textViewResult.Text = string.Empty;
        }

        private void ClearMemory()
        {
            OperateMemory = null;
            TotalMemory = null;
            DigitalMemory = null;
            InputKey = KeyInput.Digit;
        }
    }
}

