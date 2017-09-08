using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    

    class RPNcalculatorEngin : CalculatorEngine
    {
        Stack myStack = new Stack();
        string result;
        public string Process(string str)
        {
            List<string> part = str.Split(' ').ToList<string>();
            string second,first;
            string [] parts = str.Split(' ');
            for(int i =0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    myStack.Push(parts[i]);

                }
                if (isOperator(part[i]) && isOperator(parts[1]))
                {
                    while (part.Count > 1)
                    {
                        if (!(isNumber(part[0]) && isOperator(part[1]) && isNumber(part[2])))
                        {
                            return "E";
                        }
                        else
                        {
                            result = calculate(part[1], part[0], part[2], 4);
                            part.RemoveRange(0, 3);
                            part.Insert(0, result);
                        }
                    }
                    return part[0];
                }
                if (isOperator(parts[i])&& !isOperator(parts[1]))
                {
                    second = Convert.ToString(myStack.Pop()) ;
                    first = Convert.ToString(myStack.Pop());
                    myStack.Push(calculate(parts[i],first,second,4));

                }
                
            }
            return Convert.ToString(myStack.Peek());
        }

        //split str to parts
        //loop each part 
        // if part is number
        // push to stack
        // if part is operator
        // pop to time => second, first operand
        // calculate(operator, first, seconf) => result
        // return result
    }
}
