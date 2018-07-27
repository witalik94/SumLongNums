//Сложение длинных чисел. Не реализовано сложение отрицательных чисел (или числа) и двух нулевых чисел.

using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main()
        {
            string num1;
            string num2;
            
            //Строки могут иметь посторонние символы (ошибки набора со стороны пользователя)

            //Ввод чисел 
            Console.WriteLine("Enter num 1:");
            num1 = Console.ReadLine();
            Console.WriteLine("Enter num 2:");
            num2 = Console.ReadLine();
            //Отбрасываем лишние символы
            num1 = Regex.Replace(num1, @"[^\d]", string.Empty);
            num2 = Regex.Replace(num2, @"[^\d]", string.Empty);
            
            //Находим число наибольшей длины 
            int len1 = num1.Length;
            int len2 = num2.Length;
            int len = (len1 > len2) ? len1 : len2;
            len++;

            //сложение чисел
            char[] sum = new char[len];
            
            int e = 0; //запоминание единицы для переноса на старший разряд при сложении
            for (int i = 1; i <= len; i++)
            {
                int a = (i > len1) ? 0 : num1[len1 - i] - '0';
                int b = (i > len2) ? 0 : num2[len2 - i] - '0';
                int c = a + b + e;
                int d = '0' + (c % 10);
                sum[len - i] = (char)d;
                e = c / 10;
            }

            // Вывод чисел без нулей спереди
            bool f = true;
            Console.Write("Сумма чисел равна: ");
            foreach (char cc in sum)
            {
                if ((cc != '0') && (f == true))
                    f = !f;
                if (f == false)
                    Console.Write(cc);
            }

            if (f == true)
                Console.Write('0');

            Console.ReadKey();


        }
    }
}
