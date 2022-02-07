using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AliBaba_ModifiedWithSolutionPath
{
    class Program
    {
        #region IO
        static void Main(string[] args)
        {
            int nCases;
            StreamReader sr;
            TextReader origConsole = Console.In;
            Console.WriteLine("Ali Baba Problem:\n[1] Sample test cases\n[2] Complete testing");
            Console.Write("\nEnter your choice [1-2]: ");
            char choice = (char)Console.ReadLine()[0];
            switch (choice)
            {
                case '1':
                    sr = new StreamReader("samples.txt");
                    Console.SetIn(sr);
                    bool wrongIndicesFlag = false;
                    nCases = int.Parse(Console.ReadLine());
                    Console.ReadLine();
                    for (int i = 0; i < nCases; i++)
                    {
                        bool wrongIndices = false;

                        long N = long.Parse(Console.ReadLine());
                        long[] values = new long[N];

                        string[] lineItems = Console.ReadLine().Split(' ');

                        for (int j = 0; j < N; j++)
                        {
                            values[j] = int.Parse(lineItems[j]);
                        }

                        Console.Write("Case " + (i + 1).ToString() + ": ");
                        Console.WriteLine("# of Houses = " + N);

                        long actualResult = 0;
                        long timeBefore = System.Environment.TickCount;
                        long[] HousesChosen = FindMaxGainedValue.GetMaxGainedValue(values, N, ref actualResult);
                        long timeAfter = System.Environment.TickCount;
                        long elapsedTime = timeAfter - timeBefore;
                        int expectedResult = int.Parse(Console.ReadLine());
                        if (actualResult != expectedResult)
                        {
                            Console.WriteLine("Wrong Answer! Case#" + (i + 1) + ":\n" + "Your answer = " + actualResult);
                            Console.WriteLine("Correct Answer = " + expectedResult);
                            sr.Close();
                            return;
                        }
                        else
                        {
                            
                            string[] lineResItems = Console.ReadLine().Split(' ');
                            if (HousesChosen == null)
                            {
                                wrongIndices = true;
                            }
                            else
                            {
                                int lastMatchIndex = -1;
                            
                                for (int k = 0; k < lineResItems.Length; k++)
                                {
                                    if (int.Parse(lineResItems[k]) != HousesChosen[k])
                                    {
                                        lastMatchIndex = k;
                                        break;
                                        //Console.WriteLine("Wrong Answer! Indices of selected values are wrong. Case #" + (i+1) + "\n");
                                        //sr.Close();
                                        //return;
                                    }
                                }
                                if (lastMatchIndex != -1)
                                {
                                    //Check sum of the selected items
                                    long sum = 0;
                                    for (int k = 0; k < HousesChosen.Length; k++)
                                    {
                                        if (HousesChosen[k] <= 0 || HousesChosen[k] > values.Length)
                                            continue;
                                        sum += values[HousesChosen[k] - 1];
                                    }
                                    if (sum != actualResult)
                                    {
                                        wrongIndices = true;
                                    }
                                }
                            }
                            if (wrongIndices)
                            {
                                wrongIndicesFlag = true;
                                Console.WriteLine("Wrong Indices! Indices of selected values are wrong. Case #" + (i + 1) + "\n");
                                //sr.Close();
                                //return;
                            }
                        }
                        Console.ReadLine();
                        if (elapsedTime > 30)
                        {
                            Console.WriteLine("Time limit exceed: case # " + (i + 1));
                            sr.Close();
                            return;
                        }
                        if (wrongIndices)
                            Console.WriteLine("Case#" + (i + 1) + " PARTIALLY succeed with WRONG indices");
                        else
                            Console.WriteLine("Case#" + (i + 1) + " COMPLETELY succeed");

                    }
                    sr.Close();

                    Console.SetIn(origConsole);
                    Console.WriteLine("\n");
                    if (wrongIndicesFlag)
                        Console.WriteLine("Sample cases are PARTIALLY succeed with WRONG indices");
                    else
                        Console.WriteLine("Sample cases are COMPLETELY succeed");
                    Console.WriteLine("\n");
                    Console.WriteLine("You should run Complete Testing... ");
                    Console.Write("Do you want to run Complete Testing now (y/n)? ");
                    choice = (char)Console.Read();
                    if (choice == 'n' || choice == 'N')
                        break;
                    else if (choice == 'y' || choice == 'Y')
                        goto CompleteTest;
                    else
                    {
                        Console.WriteLine("Invalid Choice!");
                        break;
                    }

                case '2':
                CompleteTest:
                    Console.WriteLine("Complete Testing is running now...");
                    sr = new StreamReader("input.txt");
                    Console.SetIn(sr);

                    double totalTime = 0;
                    double maxTime = 0;
                    wrongIndicesFlag = false;
                    
                    nCases = int.Parse(Console.ReadLine());
                    Console.ReadLine();
                    for (int i = 0; i < nCases; i++)
                    {
                        bool wrongIndices = false;

                        Console.WriteLine("Case#" + (i + 1));
                        long N = long.Parse(Console.ReadLine());
                        long[] values = new long[N];

                        string[] lineItems = Console.ReadLine().Split(' ');

                        for (int j = 0; j < N; j++)
                        {
                            values[j] = int.Parse(lineItems[j]);
                        }

                        //Console.Write("Case " + (i + 1).ToString() + ": ");
                        //Console.WriteLine("# of Houses = " + N);

                        long actualResult = 0;
                        //long timeBefore = System.Environment.TickCount;
                        Stopwatch sw = Stopwatch.StartNew() ;
                        long[] HousesChosen = FindMaxGainedValue.GetMaxGainedValue(values, N, ref actualResult);
                        sw.Stop() ;
                        //long timeAfter = System.Environment.TickCount;
                        totalTime += sw.ElapsedMilliseconds;
                        if (sw.ElapsedMilliseconds > maxTime)
                            maxTime = sw.ElapsedMilliseconds;
                        
                        int expectedResult = int.Parse(Console.ReadLine());
                        if (actualResult != expectedResult)
                        {
                            Console.WriteLine("Wrong Answer! Case#" + (i+1) + ":\n" + "Your answer = " + actualResult);
                            Console.WriteLine("Correct Answer = " + expectedResult);
                            sr.Close();
                            return;
                        }
                        else
                        {
                            string[] lineResItems = Console.ReadLine().Split(' ');
                            if (HousesChosen == null)
                            {
                                wrongIndices = true;
                            }
                            else
                            {
                                int lastMatchIndex = -1;
                                for (int k = 0; k < lineResItems.Length; k++)
                                {
                                    if (int.Parse(lineResItems[k]) != HousesChosen[k])
                                    {
                                        lastMatchIndex = k;
                                        break;
                                        //Console.WriteLine("Wrong Answer! Indices of selected values are wrong. Case #" + (i+1) + "\n");
                                        //sr.Close();
                                        //return;
                                    }
                                }
                                if (lastMatchIndex != -1)
                                {
                                    //Check sum of the selected items
                                    long sum = 0;
                                    for (int k = 0; k < HousesChosen.Length; k++)
                                    {
                                        if (HousesChosen[k] <= 0 || HousesChosen[k] > values.Length)
                                            continue;
                                        sum += values[HousesChosen[k] - 1];
                                    }
                                    if (sum != actualResult)
                                    {
                                        wrongIndices = true;
                                    }
                                }
                            }
                            if (wrongIndices)
                            {
                                wrongIndicesFlag = true;
                                Console.WriteLine("Wrong Indices! Indices of selected values are wrong. Case #" + (i + 1) + "\n");
                                //sr.Close();
                                //return;
                            }
                        }
                        Console.ReadLine();
                        if (sw.ElapsedMilliseconds > 100)
                        {
                            Console.WriteLine("Time limit exceed: case # " + (i + 1));
                            sr.Close();
                            return;
                        }
                        
                    }
                    sr.Close();
                    Console.WriteLine("\n");
                     if (wrongIndicesFlag)
                        Console.WriteLine("Complete test are PARTIALLY succeed with WRONG indices");
                    else
                         Console.WriteLine("Complete test are COMPLETELY succeed");
                    Console.WriteLine("\n");
                    
                    Console.WriteLine("Average execution time (ms) = " + Math.Round(totalTime / nCases, 2)) ;
                    Console.WriteLine("Max execution time (ms) = " + maxTime);
                    break;
            }
        }
        #endregion
    }
}
