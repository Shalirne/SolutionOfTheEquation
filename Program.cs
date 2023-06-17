
using System.Linq.Expressions;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Решение_уравнения
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float x1;
            float x2;
            string NumberA = "";
            string NumberB = "";
            string NumberC = "";
            int a = 1;
            int b = 1;
            int c = 1;
            bool ResultcC = false;
            bool ResultsB = false; ;
            bool ResultsA = false; ;
            string ResultForExceptiong = "";
            Console.WriteLine("a * x^2 + b * x + c = 0");
            try
            {
                do
                {
                    try
                    {
                        ResultForExceptiong = "";
                        Console.WriteLine("Введите значение а");
                        NumberA = Input();
                        ResultsA = int.TryParse(NumberA, out a);


                        Console.WriteLine("Введите значение b");
                        NumberB = Input();
                        ResultsB = int.TryParse(NumberB, out b);

                        Console.WriteLine("Введите значение c");
                        NumberC = Input();
                        ResultcC = int.TryParse(NumberC, out c);
                        if (ResultsA == false | ResultsB == false | ResultcC == false)
                        {
                            if (ResultsA == false)
                            {
                                ResultForExceptiong = "a";
                            }
                            if (ResultsB == false)
                            {
                                ResultForExceptiong = ResultForExceptiong + "b";
                            }
                            if (ResultcC == false)
                            {
                                ResultForExceptiong = ResultForExceptiong + "c";
                            }
                            throw new Exception();

                        }


                    }
                    catch (Exception)
                    {
                        FormatData(ResultForExceptiong, Severity.Error, NumberA, NumberB, NumberC);
                    }
                }
                while ((ResultsA == false | ResultsB == false | ResultcC == false));


                int discriminant = (b * b) - 4 * a * c;
                if (a == 0)
                {
                    throw new HaveNoSolutionException();
                }

                if (discriminant < 0)
                {
                    throw new HaveNoSolutionException();
                }
                else if (discriminant == 0)
                {
                    x1 = (-b + float.Sqrt(discriminant)) / (2 * a);
                    Console.WriteLine($"x = {x1}");
                }
                else if (discriminant > 0)
                {
                    x1 = (-b + float.Sqrt(discriminant)) / (2 * a);
                    x2 = (-b - float.Sqrt(discriminant)) / (2 * a);
                    Console.WriteLine($"x1 = {x1} , x2 = {x2}");

                }
            }
            catch (HaveNoSolutionException e)
            {
                FormatData("Вещественных значений не найдено", Severity.Warning, NumberA, NumberB, NumberC);
            }


        }

        public static void FormatData(string message, Severity severity, string a, string b, string c)
        {
            if (severity == Severity.Error)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Неверный формат параметра {message}");
                Console.WriteLine("--------------------------------------------------");
                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"a == {a}");
                Console.WriteLine($"b == {b}");
                Console.WriteLine($"c == {c}");
                Console.ResetColor();
            }
            else if (severity == Severity.Warning)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Вещественных значений не найдено");
                Console.ResetColor();
            }
        }

        public enum Severity
        {
            Warning,
            Error
        }

        public static string Input()
        {
            var a = Console.ReadLine();
            return a;

        }
    }







}