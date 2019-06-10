using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            string hstr;
            string[] hmas;
            hstr = Console.ReadLine();
            hmas = hstr.Split(' ');
            n = Convert.ToInt32(hmas[0]);
            m = Convert.ToInt32(hmas[1]);
            int[,] down = new int[n, m + 1], right = new int[n + 1, m];
            for (int i = 0; i < n; i++)
            {
                hstr = Console.ReadLine();
                hmas = hstr.Split(' ');
                for (int j = 0; j < m + 1; j++)
                    down[i, j] = Convert.ToInt32(hmas[j]);
            }
            hstr = Console.ReadLine();
            for (int i = 0; i < n+1; i++)
            {
                hstr = Console.ReadLine();
                hmas = hstr.Split(' ');
                for (int j = 0; j < m; j++)
                    right[i, j] = Convert.ToInt32(hmas[j]);
            }

            int[,] s = new int[n+1, m+1];
            s[0, 0] = 0;
            for (int i = 1; i <= n; i++)
                s[i, 0] = s[i - 1, 0] + down[i-1, 0];
            for (int i = 1; i <= m; i++)
                s[0, i] = s[0, i-1] + right[0, i-1];
            for(int i=1; i<=n;i++)
                for (int j = 1; j <= m; j++)
                {
                    s[i, j] = Math.Max(s[i-1,j]+down[i-1,j], s[i,j-1]+right[i,j-1]);
                }
            Console.WriteLine(s[n,m]);
        }
    }
}
