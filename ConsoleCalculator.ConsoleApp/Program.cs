using System;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleCalculator.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Operations operations = new Operations();
            var calc = new Calculator();
            string prevOperation = "";
            bool devideFlag = false;
        top:
            try
            {
                string firstValue = "0";
                operations.setConsole(firstValue);
                top2:
                firstValue = calc.GetEnterValue(firstValue, true, operations,false);
                if (firstValue == "c")
                {
                    firstValue = "";
                    operations.setConsole("0");
                    goto top;
                }
            place:
                char currentOperation = operations.getOperation();
                string secoundValue = "0";
                
                secoundValue = calc.GetEnterValue(secoundValue, false, operations, devideFlag);
                if (secoundValue == "c")
                {
                    firstValue = "";
                    secoundValue = "";
                    operations.setConsole("0");
                    goto top;
                }

                if (secoundValue == "0" && !operations.checkDevideByZeroErr(prevOperation, Convert.ToString(currentOperation), Convert.ToDouble(firstValue), Convert.ToDouble(secoundValue)))
                {
                    goto place;
                }
                
                double result = 0;
                try
                {
                    if (!operations.checkDevideByZeroErr(prevOperation, Convert.ToString(currentOperation), Convert.ToDouble(firstValue), Convert.ToDouble(secoundValue)))
                    {
                        if (String.Compare(prevOperation, Convert.ToString(currentOperation), true) == 0)
                        {

                            result = calc.Calculate(Convert.ToDouble(firstValue), Convert.ToDouble(secoundValue), prevOperation);
                        }
                        else
                        {
                            result = calc.Calculate(Convert.ToDouble(firstValue), Convert.ToDouble(secoundValue), Convert.ToString(currentOperation));
                            prevOperation = Convert.ToString(operations.getOperation());
                        }
                    }
                    else
                    {
                        firstValue = "";
                        secoundValue = "";
                        operations.setConsole("-E-");
                        goto top2;
                    }
                }
                catch(Exception ex)
                {
                    goto top2;
                }
               
                if(result == 0 && currentOperation == '/' )
                {
                    devideFlag = true;
                }
                else { devideFlag = false; }
                firstValue = result.ToString();
                operations.setConsole(firstValue);
                goto place;
                //Console.Clear();
                //Console.WriteLine(calc.SendKeyPress(key.KeyChar));
                //Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error. Do you want to continue?");
                string ip = Console.ReadLine();
                if (ip.ToLower() == "y" || ip.ToLower() == "yes")
                {
                    Console.Clear();
                    Console.WriteLine("0");
                    goto top;
                }
                else if (ip.ToLower() == "n" || ip.ToLower() == "no")
                {
                    Console.Clear();
                    Console.WriteLine("Error. Do you want to continue?");
                }
                else
                {
                    System.Environment.Exit(0);
                }
            }
        }
    }
}
