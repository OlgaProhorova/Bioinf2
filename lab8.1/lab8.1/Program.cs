using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str, hstr;
            int k, n;
            hstr = Console.ReadLine();
            k = Convert.ToInt32(hstr);
            str = Console.ReadLine();
            n = str.Length - k + 1;
            string[] res=new string[n];
            for (int i = 0; i < n; i++)
                res[i] = str.Substring(i,k);
            Array.Sort(res);
            for (int i = 0; i < n; i++)
                Console.WriteLine(res[i]);
        }
    }
}
