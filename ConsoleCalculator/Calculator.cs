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
        
        public string GetEnterValue(string value,bool flag,Operations operations,bool otherFlag)
        {
            ConsoleKeyInfo key;
            while (IsKillSwitch(key = Console.ReadKey(true)) == false)
            {
                string inputKey=  SendKeyPress(key.KeyChar);
                //Console.WriteLine(ss);
                if (int.TryParse(inputKey, out _))
                {
                    if (value == "0")
                    {
                        value = "";
                    }
                    value += inputKey;
                    operations.setConsole(value);
                }
                else if (!int.TryParse(inputKey, out _) && inputKey.ToLower() == "c")
                {
                    return "c";
                }
                else if (!int.TryParse(inputKey, out _) && inputKey.ToLower() == "s")
                {
                    if (value != "0")
                    {
                        value = Convert.ToString(Convert.ToInt32(value) * -1);
                    }else
                    {
                        value = "0";
                    }
                    operations.setConsole(value);
                }
                else if ((inputKey  == "+" || inputKey == "-" || inputKey == "*"))
                {
                   // operations.setConsole(value);
                    operations.setOperation(key.KeyChar);
                    return value;
                }else if(inputKey == "/"){
                    if(value == "0" && otherFlag == true)
                    {
                       // return "ERR01"; 
                    }
                    operations.setOperation(key.KeyChar);
                    return value;
                }
                else if ((inputKey == "=" || key.Key == ConsoleKey.Enter) && flag == false)
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
                    if(b == 0 && a != 0)
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
