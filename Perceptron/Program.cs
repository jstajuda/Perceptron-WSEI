using System;
using System.Collections.Generic;

namespace JS_Perceptron_Project
{
    class Program
    {

        static void Main(string[] args)
        {
            //utworzenie listy 25 punktow o losowych wspolrzednych
            List<Point> points = new List<Point>();
            initPointsList(points, 25);

            //zdefiniowanie funkcji liniowej wg wzoru f(x) = 3x + 5
            LinearFunction linFunc = new LinearFunction(3, 5);
            Console.WriteLine(linFunc.ToString());

            //utworzenie Perceptronu przyjmujacego dwa sygnaly wejsciowe
            Perceptron prc = new Perceptron(2);

            //uruchomienie metody Run po raz pierwszy (bool initial = true)
            int totalError = prc.Run(points, linFunc, true);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Początkowa liczba bledow: {0} / {1}", totalError, points.Count);
            Console.WriteLine("Nacisnij dowolny klawisz, aby kontynuować trening. (ESC aby zakonczyc)");
            if (Console.ReadKey().Key == ConsoleKey.Escape) Environment.Exit(0);

            //uczenie Perceptronu do momentu wyeliminowania bledow
            while (totalError > 0)
            {
                totalError = prc.Run(points, linFunc);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Liczba bledow: {0} / {1}", totalError, points.Count);

                if (totalError == 0)
                {
                    Console.WriteLine("Nacisnij dowolny klawisz, aby zakończyć program.");
                }
                else
                {
                    Console.WriteLine("Nacisnij dowolny klawisz, aby sprobowac ponownie. (ESC aby zakonczyc)");
                }

                if( Console.ReadKey().Key == ConsoleKey.Escape) break;
            }
           
        }

        public static void initPointsList(List<Point> points, int count)
        {
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                Point p = new Point(rnd.Next(-100, 100), rnd.Next(-100, 100));
                points.Add(p);
            }
        }
    }
    
}
