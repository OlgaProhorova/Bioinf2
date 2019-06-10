using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5._1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            string str, helpstr, resstr="";
            string[] massstr;
            double score, bestscore = 0;
            int k;
            str = Console.ReadLine();
            k = Convert.ToInt32(Console.ReadLine());
            double[,] prof=new double[4,k];
            for (int i = 0; i < 4; i++)
            {
                helpstr = Console.ReadLine();
                massstr = helpstr.Split(' ');            
                for (int j = 0; j < k; j++)
                {
                    prof[i, j] = double.Parse(massstr[j]);
                }
            }
            for (int i = 0; i < str.Length - k + 1; i++)
            {
                helpstr = str.Substring(i, k);
                score =1;
                for (int j = 0; j < k; j++)
                {
                    if(helpstr.Substring(j, 1)=="A") score = score*prof[0,j];
                    if (helpstr.Substring(j, 1) == "C") score = score * prof[1, j];
                    if (helpstr.Substring(j, 1) == "G") score = score * prof[2, j];
                    if (helpstr.Substring(j, 1) == "T") score = score * prof[3, j];
                }
                if (score > bestscore)
                {
                    bestscore = score;
                    resstr = helpstr;
                }
            }
            Console.WriteLine(resstr);
        }
    }
}
