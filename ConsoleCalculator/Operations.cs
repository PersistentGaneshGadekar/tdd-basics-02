using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    public class Operations
    {
        public char operation { get; set; }

        public void setOperation(char op)
        {
            operation = op;
        }

        public char getOperation()
        {
            return operation;
        }

        public void setConsole(string result)
        {
            Console.Clear();
            Console.WriteLine(result);
        }

        public bool checkDevideByZeroErr(string pOp,string cOp, double a,double b)
        {
            if(a != 0 && b == 0 && cOp == "/")
            {
                return true;
            }
            return false;
        }
    }
}
