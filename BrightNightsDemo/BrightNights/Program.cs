using System;
using System.Globalization;

namespace BrightNights
{
    class Program
    {
        public static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("dk-DA");
            int userInputYear = 0;
            int userInputMonth = 0;
            int userInputDay = 0;
            bool bol = false;

            while (true)
            {
                try
                {
                    Console.Clear();
                    do
                    {
                        try
                        {
                            Console.Write("Indtast årstal (eks. 2022) :");
                            userInputYear = int.Parse(Console.ReadLine());
                            bol = true;
                        }
                        catch (Exception)
                        {
                            bol = false;
                        }
                    } while (bol == false);

                    Console.WriteLine();
                    do
                    {
                        try
                        {
                            Console.Write($"Indtast månedstal (eks. 12) :");
                            userInputMonth = int.Parse(Console.ReadLine());
                            bol = true;
                        }
                        catch (Exception)
                        {
                            bol = false;
                        }
                    } while (bol == false);

                    Console.WriteLine();
                    do
                    {
                        try
                        {
                            Console.Write($"Indtast månedsdag (eks. 31) :");
                            userInputDay = int.Parse(Console.ReadLine());
                            bol = true;
                        }
                        catch (Exception)
                        {
                            bol = false;
                        }
                    } while (bol == false);

                    DateTime dtUserInputDateTime = new DateTime(userInputYear, userInputMonth, userInputDay);

                    DateTime dtBrightBightsStart = new DateTime(userInputYear, 05, 05);
                    DateTime dtBrightBightsEnd = new DateTime(userInputYear, 08, 08);

                    TimeSpan tsBrightBightsStart = dtBrightBightsStart - new DateTime(userInputYear, 01, 01);
                    TimeSpan tsBrightBightsEnd = dtBrightBightsEnd - new DateTime(userInputYear, 01, 01);
                    TimeSpan tsUserInputDateTime = dtUserInputDateTime - new DateTime(userInputYear, 01, 01);
                    TimeSpan tsBrightBightsStartNextYear = new DateTime(userInputYear + 1, 05, 05) - dtUserInputDateTime;

                    TimeSpan tsResult;

                    Console.WriteLine();
                    if (tsUserInputDateTime < tsBrightBightsStart)
                    {
                        tsResult = tsBrightBightsStart - tsUserInputDateTime;
                        Console.WriteLine($"Din indtastede dato er {dtUserInputDateTime.ToLongDateString()}.\nDer er {tsResult.Days} dage til de lyse nætter.");
                    }
                    else if (tsUserInputDateTime > tsBrightBightsEnd)
                    {
                        tsResult = tsBrightBightsStartNextYear;
                        Console.WriteLine($"Din indtastede dato er {dtUserInputDateTime.ToLongDateString()}.\nDe lyse nætter er over. Der er {tsResult.Days} dage til de lyse nætter.");
                    }
                    else
                    {
                        tsResult = tsBrightBightsEnd - tsUserInputDateTime;
                        Console.WriteLine($"Din indtastede dato er {dtUserInputDateTime.ToLongDateString()}.\nDu befinder dig i de lyse nætters periode. Der er {tsResult.Days} til de lyse nætter slutter.");
                    }

                    Console.WriteLine($"\nTryk på Esc for at lukke ned ellers tryk på en vilkårlig tast for at prøve igen.");
                    ConsoleKeyInfo cki = new();
                    cki = Console.ReadKey();
                    if (cki.Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("Programmet lukker.");
                        Environment.Exit(0);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Dato angivelsen er forkert. Prøv igen.");
                    Console.ReadLine();
                }

            }
        }
    }
}