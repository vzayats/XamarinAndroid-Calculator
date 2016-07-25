using System;

namespace AndroidCalculator
{
    public class Calc
    {
        private MainActivity _main;

        public Calc(MainActivity mainActivity)
        {
            _main = mainActivity;
        }

        public void Calculation()
        {
            if (_main.OperateMemory != null)
            {
                switch (_main.OperateMemory)
                {
                    case MainActivity.Operations.Addition:
                        if (_main.TotalMemory == null)
                        {
                            _main.TotalMemory = _main.DigitalMemory;
                        }
                        else
                        {
                            _main.TotalMemory = _main.TotalMemory + _main.DigitalMemory;
                        }
                        _main.InputKey = MainActivity.KeyInput.Operator;
                        break;

                    case MainActivity.Operations.Subtraction:
                        if (_main.TotalMemory == null)
                        {
                            _main.TotalMemory = _main.DigitalMemory;
                        }
                        else
                        {
                            _main.TotalMemory = _main.TotalMemory - _main.DigitalMemory;
                        }
                        _main.InputKey = MainActivity.KeyInput.Operator;
                        break;

                    case MainActivity.Operations.Multiply:
                        if (_main.TotalMemory == null)
                        {
                            _main.TotalMemory = _main.DigitalMemory;
                        }
                        else
                        {
                            _main.TotalMemory = _main.TotalMemory *_main.DigitalMemory;
                        }
                        _main.InputKey = MainActivity.KeyInput.Operator;
                        break;

                    case MainActivity.Operations.Division:
                        if (_main.TotalMemory == null)
                        {
                            _main.TotalMemory = _main.DigitalMemory;
                        }
                        else
                        {
                            _main.TotalMemory = _main.TotalMemory /_main.DigitalMemory;
                        }
                        _main.InputKey = MainActivity.KeyInput.Operator;
                        break;
                    case MainActivity.Operations.Evolution:
                        if (_main.TotalMemory == null)
                        {
                            _main.TotalMemory = _main.DigitalMemory;
                        }
                        else
                        {
                            if (_main.DigitalMemory != null)
                                _main.TotalMemory =  Math.Sqrt((double) _main.DigitalMemory);
                        }
                        _main.InputKey = MainActivity.KeyInput.Operator;
                        break;
                }
            }
            else
            {
                _main.TotalMemory = _main.DigitalMemory;
            }
        }
    }
}