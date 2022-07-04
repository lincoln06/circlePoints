using System;

namespace circlePoints
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj promień okręgu");
            double radius = double.Parse(Console.ReadLine());
            int points = 0;
            int choose=0;
            while (choose < 1 || choose > 2)
            {
                Console.WriteLine("1\tIteracja\n2\tRekurencja");
                choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        points = FindPointsByIteration(radius);
                        break;
                    case 2:
                        points=4* FindPointsByRecursion(radius, 1, (int)radius, points);
                        points+= ((int)radius - 1) * 4 + 1; //Punkty położone na osiach OX i OY oraz punkt (0,0)
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja");
                        points = 0;
                        break;
                }
            }
            Console.WriteLine($"Ilość punktów kratowych w okręgu: {points}");
            Console.ReadKey();            
        }
        static int FindPointsByIteration(double radius)
        {
            int result = 0;
            for (int x = (int)-radius; x <= (int)radius; x += 1)
            {
                for (int y = (int)-radius; y <= (int)radius; y += 1)
                {
                    if (((x * x) + (y * y)) < (radius * radius)) result++;

                }
            }
            return result;
        }
        //Funkcja policzy ilość punktów kratowych w jednej ćwiartce okręgu
        static int FindPointsByRecursion(double radius, int x, int y, int points)
        {
            if (y < 1) return points;
            if ((x * x) + (y * y) < (int)(radius * radius))
            {
                points++;
                return FindPointsByRecursion(radius, x + 1, y, points);
            }
            else
            {
                x = 1;
                return FindPointsByRecursion(radius, x, y - 1, points);
            }
        }
    }
}
