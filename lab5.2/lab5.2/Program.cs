using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5._2
{
    class Program
    {
        static double[,] makeprof(string[] motifs, int n, int m)
        {
            double[,] res = new double[4, n];
            for(int i=0;i<m;i++)
            {
                for(int j=0;j<n; j++)
                {
                    if (motifs[i].Substring(j, 1) == "A") res[0, j]++;
                    if (motifs[i].Substring(j, 1) == "C") res[1, j]++;
                    if (motifs[i].Substring(j, 1) == "G") res[2, j]++;
                    if (motifs[i].Substring(j, 1) == "T") res[3, j]++;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    res[i, j] = (res[i, j]+1) / m;
                }
            }
            return res;
        }

        static string mostmotif(string str, double[,] p, int n)
        {
            string res=str.Substring(0,n), helpstr;
            double score, bestscore=0;
            for (int i = 0; i < str.Length - n + 1; i++)
            {
                helpstr = str.Substring(i, n);
                score = 1;
                for (int j = 0; j < n; j++)
                {
                    if (helpstr.Substring(j, 1) == "A") score = score * p[0, j];
                    if (helpstr.Substring(j, 1) == "C") score = score * p[1, j];
                    if (helpstr.Substring(j, 1) == "G") score = score * p[2, j];
                    if (helpstr.Substring(j, 1) == "T") score = score * p[3, j];
                }
                if (score > bestscore)
                {
                    bestscore = score;
                    res = helpstr;
                }
            }
            return res;
        }

        static int score(string[] mot)
        {
            int a,c,g,t, min, res=0;
            for (int i = 0; i < mot[0].Length; i++)
            {
                min=a=c=g=t=0;
                for (int j = 0; j < mot.Length; j++)
                {
                    if (mot[j].Substring(i, 1) != "A") a++;
                    if (mot[j].Substring(i, 1) != "C") c++;
                    if (mot[j].Substring(i, 1) != "G") g++;
                    if (mot[j].Substring(i, 1) != "T") t++;
                }
                min = a;
                if (c < min) min = c;
                if (g < min) min = g;
                if (t < min) min = t;
                res += min;
            }
            return res;
        }

        static void Main(string[] args)
        {
            string helpstr;
            int k, t;
            helpstr = Console.ReadLine();
            k = Convert.ToInt32(helpstr.Substring(0,1));
            t = Convert.ToInt32(helpstr.Substring(2,1));
            string[] masstr=new string[t], bestmotifs=new string[t], motifs=new string[t];
            for (int i = 0; i < t; i++)
            {
                masstr[i] = Console.ReadLine();
            }

            for(int i=0;i<t;i++)
            {
                bestmotifs[i] = masstr[i].Substring(0,k);
            }

            double[,] prof = new double[4, k];
            for (int j = 0; j < masstr[0].Length - k + 1; j++)
            {
                motifs[0] = masstr[0].Substring(j, k);
                for (int i = 1; i < t; i++)
                {
                    prof = makeprof(motifs, k, i);
                    motifs[i] = mostmotif(masstr[i], prof, k);
                }
                if (score(bestmotifs) > score(motifs))
                    bestmotifs = motifs;
            }
            for (int i = 0; i < t; i++)
            {
                Console.WriteLine(bestmotifs[i]);
            }
        }
    }
}
