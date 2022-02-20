using System;
using System.Collections.Generic;
using System.Linq;

namespace T01._Bakery_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));
            Stack<double> flour = new Stack<double>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));

            Dictionary<string, int> baked = new Dictionary<string, int>();
            baked.Add("Croissant", 0);
            baked.Add("Muffin", 0);
            baked.Add("Baguette", 0);
            baked.Add("Bagel", 0);

            while (water.Count > 0 && flour.Count > 0)
            {
                double value = water.Peek() + flour.Peek();

                double waterPer = (water.Peek() * 100) / value;

                //double flourPer = 100 - waterPer;
                double tempWater = water.Dequeue();

                double tempFlour = flour.Pop();

                if (waterPer == 50)
                {
                    baked["Croissant"]++;

                }
                else if (waterPer == 40)
                {
                    baked["Muffin"]++;

                }
                else if (waterPer == 30)
                {
                    baked["Baguette"]++;

                }
                else if (waterPer == 20)
                {
                    baked["Bagel"]++;
                }
                else
                {
                    double temp = tempFlour - tempWater;

                    baked["Croissant"]++;
                    flour.Push(temp);
                }
            }

            foreach (KeyValuePair<string, int> pair in baked.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (pair.Value == 0)
                {
                    continue;
                }
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

            
            if (water.Count == 0)
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }

            if (flour.Count == 0)
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }

        }
    }
}
