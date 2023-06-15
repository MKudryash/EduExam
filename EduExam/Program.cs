using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;

namespace EduExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Z4();
            Console.ReadKey();
        }

        /*В конце появилось понимание, как надо делать, но времени не хватило*/
        static List<char> checkPalindrom(List<char> massiv, int i)
        {
            if (Convert.ToInt32(massiv[i]) != 97)
            {
                massiv[i] = Convert.ToChar(massiv[i] - 1);
                if (check(massiv)) checkPalindrom(massiv, i);
                else return massiv;
            }
            return massiv;
        }
        static bool check(List<char> massiv)
        {
            for (int i = 0, j = massiv.Count - 1; i < massiv.Count; i++, j--)
            {
                if (massiv[i] != massiv[j]) return true;
            }
            return false;
        }

        /*
         3 задание
         Дается строка палиндром, нужно изменить символы так, чтобы строка имела наименьший вес (там объяснялось, что это такое
        дословно не помню, но как пример: abca весит меньше, чем abda)
        Пример вход: abba выход: aaba
         */
        static void Z3()
        {
            List<char> str = Console.ReadLine().ToList();
            char symbol = str[0];
            for (int d = 0; d < str.Count; d++)
            {
                if (str[d] != symbol)
                {
                    for (int i = 0; i < str.Count; i++)
                    {
                        str = checkPalindrom(str, i);
                        if (check(str))
                        {

                            foreach (var item in str)
                            {
                                Console.Write(item);
                            }
                            d = str.Count;
                            break;
                        }
                    }

                }
            }

        }

        /*
         4 задание.
        На вход подавется два слова нужно проверить являются ли они анаграммой. Если да вывести "YES", иначе "NO"
        Вход: heart
              earth
        Выход: YES

        Вход: bad
              bat
        Выход: NO
         */
        static void Z4()
        {
            List<char> str1 = Console.ReadLine().ToList();
            List<char> str2 = Console.ReadLine().ToList();

            /*Не самое оптимальное решение, за то все тесты прошло*/
            foreach (var item in str1)
            {
                for (int i = 0; i < str2.Count; i++)
                {
                    if (str2[i] == item)
                    {
                        str2.RemoveAt(i);
                        break;
                    }
                }
            }

            if (str2.Count() == 0)
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");

        }
        /*
         2 задание. Тут была дана формула по заданию, не помню ее
        На входе задается число, и надо найти x, который нужно найти в диапазоне от 0 до 100. Если такого x нет, то вывести -1.
         */
        static void Z2()
        {
            long q = Convert.ToInt64(Console.ReadLine());
            List<int> list = Console.ReadLine().Split().Select(y => int.Parse(y)).ToList();
            int x = -1;
            for (int i = 0; i < 100; i++)
            {
                long testQ = 0;
                for (int j = 0; j < list.Count; j++)
                {
                    testQ += Convert.ToInt64(list[j] * Math.Pow(i, j));
                }
                if (Convert.ToInt64(testQ) == q)
                {
                    x = i;
                    break;
                }
            }
            Console.WriteLine(x);
        }

        /*
         1 задание
        Входными данными является n - количество секунд, нужно перевести в часы и минуты.
        На выходе строка: It is H hours M minutes.
         */
        static void Z1()
        {
            int k = Convert.ToInt32(Console.ReadLine());
            DateTime t = new DateTime();
            t = t.AddSeconds(k);
            Console.WriteLine($"It is {t.Hour} hours {t.Minute} minutes.");
        }
    }
}
