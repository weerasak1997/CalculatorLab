﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorEngine
    {
        string result;
        public string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "÷":
                    // Not allow devide be zero
                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result.ToString("N" + remainLength);
                    }
                    break;
                case "%":
                    return ((Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100).ToString());
                    //your code here
                    break;
            }
            return "E";
        }
        public string SystemOperater(string operate, string firstOperand)
        {
            char[] sum = new char[8];
            switch (operate)
            {
                case "1/x": result = (1 / Convert.ToDouble(firstOperand)).ToString();break;
                case "SR": result = (System.Math.Sqrt(Convert.ToDouble(firstOperand))).ToString(); break;
            }
           string rub = result.Substring(0, 8);
            return rub;
        }
        internal class engine
        {
        }

        public double Percentage(double first, double second)
        {
            return (first * second / 100);

        }
        

    }
}
