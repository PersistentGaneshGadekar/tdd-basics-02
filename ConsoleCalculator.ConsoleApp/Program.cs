using System;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleCalculator.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConsoleKeyInfo key= Console.ReadKey();
            //Console.WriteLine(key.Key);
            //Console.ReadLine();
            //return;
            var calc = new Calculator();
            set:
            string val = "0"; 
            set2:
            val = calc.GetEnterValue(val, true);
            Console.Clear();
            string opration = val.Substring(val.Length - 1, 1);
            string firstValue = val.Substring(0, val.Length - 1);
            if (Convert.ToInt32(firstValue)  != 0)
            {
                Console.WriteLine(firstValue);
                //place:
                string value = "0";
                value = calc.GetEnterValue(value, false);
                //ConsoleKeyInfo key= Console.ReadKey();
                //if(key.KeyChar == '+'|| key.KeyChar == '-' || key.KeyChar == '*' || key.KeyChar == '/')
                //{
                //    goto place;
                //}
                if (opration == "/" && value == "0")
                {
                    Console.Clear();
                    Console.WriteLine("-E-"); 
                    goto set;
                }
                Console.Clear();
                double result = calc.Calculate(Convert.ToDouble(firstValue), Convert.ToDouble(value), opration);
                Console.WriteLine(result.ToString());
                if (result > 0)
                {
                    val = result.ToString();
                    goto set2;
                }
                goto set;
            }
            else
            {
                goto set;
            }
            //Console.Clear();
            //Console.WriteLine(calc.SendKeyPress(key.KeyChar));
            //Console.ReadLine();
        }
    }
}
