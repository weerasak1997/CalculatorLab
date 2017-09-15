using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorEngine
    {
        private bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        private bool isOperator(string str)
        {
            switch(str) {
                case "+":
                case "-":
                case "X":
                case "÷":
                    return true;
            }
            return false;
        }
        string num;
        public string Process(string str)
        {
            string[] parts = str.Split(' ');
            int element = 0;
            Boolean number = false;
            num = parts[0];
            for(int j = 0; j < parts.Length; j++)
            {
                if (parts[j] == "÷")
                {
                    num = calculate(parts[j], parts[j - 1], parts[j + 1], 4);
                    parts[j - 1] = num;
                    for (int k = j; k < parts.Length - 2; k++)
                    {
                        parts[k] = parts[k + 2];
                    }
                    j += 2;
                    element++;
                }
                
            }
            for (int a = 1; a <= element; a++)
            {
                parts[parts.Length - (a + 1)] = "+";
                parts[parts.Length - a] = "0";
            }
            element = 0;
            for (int j = 0; j < parts.Length; j++)
            {
                if (parts[j] == "X")
                {
                    num = calculate(parts[j], parts[j-1], parts[j + 1], 4);
                        parts[j-1] = num;
                    for(int k =j;k<parts.Length-2; k++)
                    {
                        parts[k] = parts[k + 2];
                    }
                    j += 2;
                    element++;
                }
            } 
            for (int a = 1;a <= element; a++){
                parts[parts.Length - (a+1)] = "+";
                parts[parts.Length - a] = "0";
            }
            for (int i = 0; i < parts.Length;i+=2)
            {
            if(i< parts.Length-1)
                {
                if(!(isNumber(parts[i]) && isOperator(parts[i+1]) && isNumber(parts[i+2])))
                {
                    return "E";
                }
                    else
                {
                    if (number)
                    {
                    num = calculate(parts[i+1],num , parts[i + 2], 4);
                    }
                    else
                    {
                    num = calculate(parts[i+1],parts[i], parts[i+2], 4);
                    number =true;
                    }
                }       
            }
        }
             
             return num;

        }
        public string unaryCalculate(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = Math.Sqrt(Convert.ToDouble(operand));
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
                case "1/x":
                    if(operand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (1.0 / Convert.ToDouble(operand));
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
                    return (Convert.ToDouble(firstOperand) * (Convert.ToDouble(secondOperand)/100.0)).ToString();
                    break;
            }
            return "E";
        }
    }
}
