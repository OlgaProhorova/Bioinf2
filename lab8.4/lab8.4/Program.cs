using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8._4
{
    class Program
    {
        static int chislovh(string t, string s)
        {
            int res = 0;
            string temp = "";
            for (int i = 0; i <= s.Length - t.Length; i++)
            {
                for (int j = i; j < t.Length + i; j++)
                    temp += s[j];
                if (temp == t)
                    res++;
                temp = "";
            }
            return res;
        }

        static void Main(string[] args)
        {
            string str, hstr;
            int k, n;
            hstr = Console.ReadLine();
            k = Convert.ToInt32(hstr);
            str = Console.ReadLine();
            n = str.Length - k + 1;
            string[] res = new string[n];
            for (int i = 0; i < n; i++)
                res[i] = str.Substring(i, k);
            Array.Sort(res);
            List<string> v = new List<string> { };
            List<string> vres = new List<string> { };
            bool f1, f2;
            int ch;
            for (int i = 0; i < res.Length; i++)
            {
                f1 = f2 = true;
                for (int j = 0; j < v.Count; j++)
                {
                    if (res[i].Substring(0, k - 1) == v[j]) f1 = false;
                    if (res[i].Substring(1, k - 1) == v[j]) f2 = false;
                }
                if (res[i].Substring(0, k - 1) == res[i].Substring(1, k - 1)) f1 = f2 = false;
                if (f1) v.Add(res[i].Substring(0, k - 1));
                if (f2) v.Add(res[i].Substring(1, k - 1));
            }
            for (int i = 0; i < v.Count; i++)
            {
                for (int j = 0; j < v.Count; j++)
                {
                    if ((i != j) && (v[i].Substring(1, k - 2) == v[j].Substring(0, k - 2)))
                    {
                        hstr = v[i] + v[j].Substring(k - 2, 1);
                        f1 = false;
                        if (str.IndexOf(hstr, 0) > -1) f1 = true;
                        if (f1)
                        {
                            ch = chislovh(hstr, str);
                            for (int ij = 0; ij < ch; ij++)
                            {
                                vres.Add(v[i]);
                                vres.Add(v[j]);
                            }
                        }
                    }
                }
            }
            v.Clear();

            for (int i = 0; i < vres.Count - 1; i += 2)
            {
                v.Add(vres[i] + " -> " + vres[i + 1]);
            }
            for (int i = 0; i < v.Count-2; i++)
            {
                if (v[i].Substring(0, k - 1) == v[i + 1].Substring(0, k - 1))
                {
                    v[i] = v[i] + "," + v[i + 1].Substring(k + 3, k - 1);
                    v.Remove(v[i + 1]);
                }
            }
            v.Sort();
            for (int i = 0; i < v.Count; i++)
            {
                    Console.WriteLine(v[i]);
            }
        }
    }
}