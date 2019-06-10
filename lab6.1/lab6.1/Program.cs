using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int money;
            money = Convert.ToInt32(Console.ReadLine());
            string[] mas;
            string hstr;
            hstr = Console.ReadLine();
            mas = hstr.Split(',');
            int l = mas.Length;
            int[] coins = new int[l];
            for (int i=0;i<l;i++)
                coins[i] = Convert.ToInt32(mas[i]);

            int[] minncoins = new int[money+1];
            for (int i = 1; i <= money; i++)
            {
                minncoins[i] = 1000;
                for (int j = 0; j < l; j++)
                {
                    if (i >= coins[j])
                        if ((minncoins[i - coins[j]] + 1) < minncoins[i])
                            minncoins[i] = minncoins[i - coins[j]] + 1;
                }
            }
            Console.WriteLine(minncoins[money]);
        }
    }
}