using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        public string SendKeyPress(char key)
        {
            // Add your implementation here.
            return key.ToString();
            //throw new NotImplementedException();
        }
        
        public string GetEnterValue(string value,bool flag)
        {
            ConsoleKeyInfo key;
            while (IsKillSwitch(key = Console.ReadKey(true)) == false)
            {
                string ss=  SendKeyPress(key.KeyChar);
                Console.WriteLine(ss);
                if (int.TryParse(SendKeyPress(key.KeyChar), out _))
                {
                    if (value == "0")
                    {
                        value = "";
                    }
                    value +=   SendKeyPress(key.KeyChar);
                    Console.Clear();
                    Console.WriteLine(value);
                }
                else if (!int.TryParse(  SendKeyPress(key.KeyChar), out _) &&   SendKeyPress(key.KeyChar).ToLower() == "c")
                {
                    value = "0";
                    Console.Clear();
                    Console.WriteLine(value);
                }
                else if (!int.TryParse( SendKeyPress(key.KeyChar), out _) &&  SendKeyPress(key.KeyChar).ToLower() == "s")
                {
                    Console.Clear();
                    if (value != "0")
                    {
                        value = Convert.ToString(Convert.ToInt32(value) * -1);
                    }else
                    {
                        value = "0";
                    }
                    Console.WriteLine(value);
                }
                else if ((SendKeyPress(key.KeyChar) == "+" || SendKeyPress(key.KeyChar) == "-" || SendKeyPress(key.KeyChar) == "*" || SendKeyPress(key.KeyChar) == "/")  )
                {
                    return value + SendKeyPress(key.KeyChar);
                }
                else if ((SendKeyPress(key.KeyChar) == "=" || key.Key == ConsoleKey.Enter) && flag == false)
                {
                    return value;
                }
            }
            return value;
        }

        public double Calculate(double a, double b, string opration)
        {
            double result = 0;
            switch (opration)
            {
                case "+": 
                    result =a+b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "*":
                    result = a * b;
                    break;
                case "/":
                    if(b == 0)
                    {
                        result = 0;
                    }
                    else { result = a / b; }
                    
                    break;
                default:
                    result = 0; 
                    break;

            }

            return result;
        }
        private static bool IsKillSwitch(ConsoleKeyInfo key)
        {
            return key.Key == ConsoleKey.C && key.Modifiers == ConsoleModifiers.Control;
        }
    }
}
