using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    internal class Program
    {
        //Деление на 0
        //static void Main(string[] args)
        //{
        //    double x = 10;
        //    double y = 0;
        //    double z = y / x;
        //    Console.WriteLine(z);

        //}
        //Не присвоенно значение к переменой x
        //static void Main(string[] args)
        //{
        //    int x = 0;
        //    Console.WriteLine(x);
        //}
        //static void Main(string[] args)
        //{
        //    string s = "Hello";
        //    if (int.TryParse(s, out int x))
        //    {
        //        Console.WriteLine(x);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Нельзя преоброзовать");
        //    }
        //}
        enum DayOfWeek
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        enum Color
        {
            Red,
            Green,
            Blue,
            Yellow,
            Cyan,
            Magenta
        }
        enum Operation
        {
            Add,
            Subtract,
            Multiply,
            Divide
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите день недели на английском:");
            string input = Console.ReadLine();

            if (Enum.TryParse(input, true, out DayOfWeek day))
            {
                PrintDay(day);
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }

            Console.WriteLine("Введите цвет на английском:");
            input = Console.ReadLine();

            if (Enum.TryParse(input, true, out Color color))
            {
                Console.WriteLine($"Код {color} - {GetColorCode(color)};");
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
            Console.WriteLine("Введите первое число:");
            double num1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите второе число:");
            double num2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите операцию (Add, Subtract, Multiply, Divide):");
            input = Console.ReadLine();
            if (Enum.TryParse(input, true, out Operation operation))
            {
                try
                {
                    Console.WriteLine($"Результат: {PerformOperation(num1, num2, operation)}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void PrintDay(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday:
                    Console.WriteLine("Понедельник");
                    break;
                case DayOfWeek.Tuesday:
                    Console.WriteLine("Вторник");
                    break;
                case DayOfWeek.Wednesday:
                    Console.WriteLine("Среда");
                    break;
                case DayOfWeek.Thursday:
                    Console.WriteLine("Четверг");
                    break;
                case DayOfWeek.Friday:
                    Console.WriteLine("Пятница");
                    break;
                case DayOfWeek.Saturday:
                    Console.WriteLine("Суббота");
                    break;
                case DayOfWeek.Sunday:
                    Console.WriteLine("Воскресенье");
                    break;
                default:
                    Console.WriteLine("Неизвестный день недели");
                    break;
            }
        }

        static string GetColorCode(Color color)
        {
            switch (color)
            {
                case Color.Red:
                    return "#FF0000";
                case Color.Green:
                    return "#00FF00";
                case Color.Blue:
                    return "#0000FF";
                case Color.Yellow:
                    return "#FFFF00";
                case Color.Cyan:
                    return "#00FFFF";
                case Color.Magenta:
                    return "#FF00FF";
                default:
                    return "#000000"; 
            }
        }
        static double PerformOperation(double num1, double num2, Operation operation)
        {
            switch (operation)
            {
                case Operation.Add:
                    return num1 + num2;
                case Operation.Subtract:
                    return num1 - num2;
                case Operation.Multiply:
                    return num1 * num2;
                case Operation.Divide:
                    if (num2 == 0)
                    {
                        throw new DivideByZeroException("Деление на ноль невозможно.");
                    }
                    return num1 / num2;
                default:
                    throw new ArgumentException("Неизвестная операция.");
            }
        }
    }
}
