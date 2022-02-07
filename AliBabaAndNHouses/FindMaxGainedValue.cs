using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AliBaba_ModifiedWithSolutionPath
{
    // *************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // *************
    class FindMaxGainedValue
    {
        //========================================================================================================
        //Your Code is Here:
        //===================
        /// <summary>
        /// This function finds the maximum amount of money that Ali baba can get, given the number of houses 👎 and a list of the net gained value for each consecutive house (V)
        /// </summary>
        /// <param name="values">Array of the values of each given house (ordered by their consecutive placement in the city)</param>
        /// <param name="N">The number of the houses</param>
        /// <returns>Array of the indices of the robbed houses (1-based and ordered from left to right) as a return param and the maximum amount of money the Ali Baba can get as a reference param</returns>
        static int qwe = 0;
        public static long[] GetMaxGainedValue(long[] values, long N, ref long res)
        {
            qwe += 1;
            //if (qwe == 2)
            //{
            //    qwe = 2;
            //}
            List<Tuple<long, List<long>>> dp1 = new List<Tuple<long, List<long>>>();
            Dictionary<long, List<long>> dp = new Dictionary<long, List<long>>();
            List<long> dp_key = new List<long>();
            List<long> ls = new List<long>();

            if (N == 0)
                res = 0;
            else if (N == 1)
                res = values[0];

            else if (N == 2)
                res = Math.Max(values[0], values[1]);
            else
            {
                int rand_val = -10;
                if (values[0] != values[1])
                {
                    ls = new List<long>();
                    ls.Add(1);
                    dp.Add(Math.Min(values[0], values[1]), ls);                            //dp1[2,7,11,11,12]
                    dp_key.Add(values[0]);                                                  //                              //    t f  

                    ls = new List<long>();
                    ls.Add(2);
                    dp.Add(Math.Max(values[0], values[1]), ls);                                               //dp2[7, 11]   
                    dp_key.Add(Math.Max(values[0], values[1]));
                }
                else
                {
                    ls = new List<long>();
                    ls.Add(1);
                    dp.Add(values[0], ls);                            //dp1[2,7,11,11,12]
                    dp_key.Add(values[0]);                                                  //                              //    t f  

                    ls = new List<long>();
                    ls.Add(2);
                    dp.Add(rand_val, ls);                                               //dp2[7, 11]   
                    dp_key.Add(values[0]);
                    rand_val -= 1;
                }
                                                              //t f t f t
                for (int i = 2; i < N; i++)
                {
                    //dp[i] = Math.Max(values[i] + dp.ElementAt(i-2).Key, );  
                    if (values[i] + dp_key.ElementAt(i - 2) > dp_key.ElementAt(i - 1))
                    {
                        
                        dp.Add(values[i] + dp_key.ElementAt(i - 2), dp.ElementAt(i - 2).Value);
                        //if (dp.ElementAt(i).Value.Last() == i)
                        //    dp.ElementAt(i).Value.RemoveAt(dp.ElementAt(i).Value.Count - 1);
                        dp.ElementAt(i).Value.Add(i + 1);
                        
                        dp_key.Add(values[i] + dp_key.ElementAt(i - 2));
                    }
                    else
                    {
                        dp.Add(rand_val, dp.ElementAt(i - 1).Value);
                        rand_val--;
                        dp_key.Add(dp_key.ElementAt(i - 1));
                    }


                }

            }
            res = dp_key.ElementAt((int)N - 1);

            long[] arr = new long[N];

            

            int j = 0;
            for (int i = 0; i < dp.ElementAt((int)N - 1).Value.Count; i++)
            {
                //if (j > 0 && dp.ElementAt((int)N - 1).Value.ElementAt(j) - dp.ElementAt((int)N - 1).Value.ElementAt(j - 1) <= 1 && dp.ElementAt((int)N - 1).Value.ElementAt(j + 1) - dp.ElementAt((int)N - 1).Value.ElementAt(j) <= 1)
                //{
                //    continue;
                //}
                arr[j] = dp.ElementAt((int)N - 1).Value.ElementAt(j);
                j++;
               
            }

            if (qwe == 10)
            {
                qwe = 10;
            }

            return arr;
        }
    }
}