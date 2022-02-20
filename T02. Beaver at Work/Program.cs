using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace T02._Beaver_at_Work
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] pond = new char[size, size];

            int r = 0;
            int c = 0;

            int branchesCount = 0;

            for (int i = 0; i < pond.GetLength(0); i++)
            {
                char[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < pond.GetLength(1); j++)
                {
                    pond[i, j] = input[j];

                    if (pond[i, j] == 'B')
                    {
                        r = i;
                        c = j;
                    }
                    else if (pond[i, j] >= 97 && pond[i, j] <= 122)
                    {
                        branchesCount++;
                    }
                }
            }

            List<char> branches = new List<char>();

            string movement = Console.ReadLine();

            while (branchesCount != 0 && movement != "end")
            {
                pond[r, c] = '-';

                if (movement == "up")
                {
                    r--;

                    if (!IsInRange(pond, r, c, branches))
                    {
                        r++;
                        pond[r, c] = 'B';

                        movement = Console.ReadLine();
                        continue;
                    }

                    if (pond[r, c] == 'F')
                    {
                        pond[r, c] = '-';
                        if (r == 0)
                        {
                            r = pond.GetLength(0) - 1;
                        }
                        else
                        {
                            r--;
                        }
                    }
                }
                else if (movement == "down")
                {
                    r++;

                    if (!IsInRange(pond, r, c, branches))
                    {
                        r--;
                        pond[r, c] = 'B';

                        movement = Console.ReadLine();
                        continue;
                    }

                    if (pond[r, c] == 'F')
                    {
                        pond[r, c] = '-';

                        if (r == pond.GetLength(0) - 1)
                        {
                            r = 0;
                        }
                        else
                        {
                            r++;
                        }
                    }

                }
                else if (movement == "left")
                {
                    c--;

                    if (!IsInRange(pond, r, c, branches))
                    {
                        c++;
                        pond[r, c] = 'B';

                        movement = Console.ReadLine();
                        continue;
                    }

                    if (pond[r, c] == 'F')
                    {
                        pond[r, c] = '-';

                        if (c == 0)
                        {
                            r = pond.GetLength(1) - 1;
                        }
                        else
                        {
                            r--;
                        }
                    }

                }
                else if (movement == "right")
                {
                    c++;

                    if (!IsInRange(pond, r, c, branches))
                    {
                        c--;
                        pond[r, c] = 'B';

                        movement = Console.ReadLine();
                        continue;
                    }

                    if (pond[r, c] == 'F')
                    {
                        pond[r, c] = '-';

                        if (r == pond.GetLength(1) - 1)
                        {
                            r = 0;
                        }
                        else
                        {
                            r++;
                        }
                    }
                }

                if (!IsInRange(pond, r, c, branches))
                {
                    pond[r, c] = 'B';
                    movement = Console.ReadLine();
                    continue;
                }

                if (pond[r, c] >= 97 && pond[r, c] <= 122)
                {
                    branchesCount--;
                    branches.Add(pond[r, c]);
                }

                pond[r, c] = 'B';

                if (branchesCount == 0)
                {
                    break;
                }
                movement = Console.ReadLine();
            }

            if (branchesCount == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branchesCount} branches left.");
            }

            for (int i = 0; i < pond.GetLength(0); i++)
            {
                for (int j = 0; j < pond.GetLength(1); j++)
                {
                    if (j == pond.GetLength(1) - 1)
                    {
                        Console.Write(pond[i,j]);
                        continue;
                    }
                    Console.Write(pond[i,j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool IsInRange(char[,] pond, int r, int c, List<char> branches)
        {
            if (r >= 0 && r < pond.GetLength(0) && c >= 0 && c < pond.GetLength(1))
            {
                return true;
            }

            if (branches.Count > 0)
            {
                branches.RemoveAt(branches.Count - 1);
            }

            return false;

        }
    }
}
