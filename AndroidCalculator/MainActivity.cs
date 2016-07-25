using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Android.App;
using Android.Widget;
using Android.OS;
using NCalc;
using static System.Double;

namespace AndroidCalculator
{
    [Activity(Label = "Android Calculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
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
            Button buttonSqr = FindViewById<Button>(Resource.Id.buttonSqr);

            EditText editTextOperate = FindViewById<EditText>(Resource.Id.editTextOperate);
            TextView textViewResult = FindViewById<TextView>(Resource.Id.textViewResult);

            buttonPoint.Click += delegate
            {
                if (editTextOperate.Text.Trim().EndsWith("."))
                {
                    editTextOperate.Text += "";
                }
                else if (editTextOperate.Text.Trim().Length != 0)
                {
                    editTextOperate.Text += ".";
                }
            };

            button1.Click += delegate
            {
                editTextOperate.Text += "1";
            };

            button2.Click += delegate
            {
                editTextOperate.Text += "2";
            };

            button3.Click += delegate
            {

                editTextOperate.Text += "3";
            };

            button4.Click += delegate
            {
                editTextOperate.Text += "4";
            };

            button5.Click += delegate
            {
                editTextOperate.Text += "5";
            };

            button6.Click += delegate
            {
                editTextOperate.Text += "6";
            };

            button7.Click += delegate
            {
                editTextOperate.Text += "7";
            };

            button8.Click += delegate
            {
                editTextOperate.Text += "8";
            };

            button9.Click += delegate
            {
                editTextOperate.Text += "9";
            };

            button0.Click += delegate
            {
                editTextOperate.Text += "0";
            };

            buttonAddition.Click += delegate
            {
                if (editTextOperate.Text.Length != 0)
                {
                    editTextOperate.Text += " + ";
                }
            };

            buttonSubtraction.Click += delegate
            {
                if (editTextOperate.Text.Length != 0)
                {
                    editTextOperate.Text += " - ";
                }
            };

            buttonMultiply.Click += delegate
            {
                if (editTextOperate.Text.Length != 0)
                {
                    editTextOperate.Text += " * ";
                }
            };

            buttonDivision.Click += delegate
            {
                if (editTextOperate.Text.Length != 0)
                {
                    editTextOperate.Text += " / ";
                }
            };

            Regex regex = new Regex(@"^-?\d*\.?\d*");

            buttonSqrt.Click += delegate
            {
                if (editTextOperate.Text != string.Empty & regex.IsMatch(editTextOperate.Text))
                {
                    double sqrt = Math.Sqrt(Parse(editTextOperate.Text.Trim()));
                    textViewResult.Text = Convert.ToString(sqrt, CultureInfo.InvariantCulture);
                }
            };

            buttonSqr.Click += delegate
            {
                if (editTextOperate.Text != string.Empty & regex.IsMatch(editTextOperate.Text))
                {
                    double sqrt = Math.Pow(Parse(editTextOperate.Text.Trim()), 2);
                    textViewResult.Text = Convert.ToString(sqrt, CultureInfo.InvariantCulture);
                }
            };

            buttonResult.Click += delegate
            {
                if (editTextOperate.Text != string.Empty)
                {
                    try
                    {
                        Expression expression = new Expression(editTextOperate.Text.Trim());
                        object result = expression.Evaluate();

                        textViewResult.Text = Convert.ToString(result);
                    }
                    catch (EvaluationException e)
                    {
                        textViewResult.Text = "Error: " + e.Message;
                    }
                }
            };

            buttonClear.Click += delegate
            {
                ClearDisplay(editTextOperate, textViewResult);
            };

            buttonCe.Click += delegate {
                if (editTextOperate.Text.Length > 0)
                {
                    editTextOperate.Text = editTextOperate.Text.Remove(editTextOperate.Text.Length - 1);
                }
            };
        }

        private void ClearDisplay(EditText editTextOperate, TextView textViewResult)
        {
            editTextOperate.Text = string.Empty;
            textViewResult.Text = string.Empty;
        }
    }
}