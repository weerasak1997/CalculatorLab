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
                        double result = 0;
                        string[] parts = null;
                        int remainLength = 0;

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
            }
            return "E";
        }
        public string SystemOperater(string operate, string firstOperand, string secondOperand)
        {
            string rub = null;
            switch (operate)
            {
                case "%": result = (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100).ToString();break;
                case "1/x": result = (1 / Convert.ToDouble(firstOperand)).ToString();break;
                case "SR": result = (System.Math.Sqrt(Convert.ToDouble(firstOperand))).ToString(); break;
            }
            if(result.Length > 8)
            {
               return rub = result.Substring(0, 8);
            }
                return result;
            
        }
        internal class engine
        {
        }
    }
}
