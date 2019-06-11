using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_9._3
{
    class Program
    {
        static List<string> ec(Dictionary<string, List<string>> di)
        {
            List<string> res = new List<string> { }, t = new List<string> { };
            bool f = true;
            string curr, temp, hstr = di.Keys.First();
            int ind = 0;
            while (f)
            {
                res.Clear();
                res.AddRange(t.ToArray());
                t.Clear();
                curr = hstr;
                while (!(di[curr].Count() == 0))
                {
                    res.Add(curr);
                    temp = curr;
                    curr = di[curr].Last();
                    di[temp].Remove(di[temp].Last());
                }
                f = false;
                for (int i = 0; i < res.Count(); i++)
                    if (di[res[i]].Count() > 0)
                    {
                        f = true;
                        hstr = res[i];
                        ind = i;
                        break;
                    }
                int n = res.Count();
                for (int i = ind; i < n; i++)
                    t.Add(res[i]);

                for (int i = 0; i < ind; i++)
                    t.Add(res[i]);
            }
            res.Add(hstr);
            return res;
        }

        static List<string> ep(Dictionary<string, List<string>> dict)
        {
            Dictionary<string, List<string>> di = new Dictionary<string, List<string>> { };
            Dictionary<string, int> s = new Dictionary<string, int> { };
            string f = "", l = "";
            List<string> res = new List<string> { }, temp = new List<string> { };

            foreach (string str in dict.Keys)
            {
                di[str] = new List<string> { };
                di[str].AddRange(dict[str].ToArray());
            }

            foreach (string str in di.Keys)
            {
                s.Add(str, di[str].Count());
            }
            foreach (string str in di.Keys)
            {
                while (di[str].Count() > 0)
                {
                    s[di[str].Last()]--;
                    di[str].Remove(di[str].Last());
                }
            }
            foreach (string str in s.Keys)
            {
                if (s[str] > 0) f = str;
                if (s[str] < 0) l = str;
            }

            dict[l].Add(f);

            res = ec(dict);

            int ind = 0;
            for (int i = 1; i < res.Count(); i++)
            {
                if (res[i] == f && res[i - 1] == l)
                {
                    ind = i;
                    break;
                }
            }
            for (int i = ind; i < res.Count(); i++)
            {
                temp.Add(res[i]);
            }
            for (int i = 1; i < ind; i++)
            {
                temp.Add(res[i]);
            }
            return temp;
        }

        static string st(int k, List<string> str)
        {
            string res = "";
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>> { };
            for (int i = 0; i < str.Count(); i++)
            {
                graph.Add(str[i], new List<string> { });
                for (int j = 0; j < str.Count(); j++)
                {
                    if ((i != j) && (str[i].Substring(1, k - 1) == str[j].Substring(0, k - 1)))
                    {
                        graph[str[i]].Add(str[j]);
                    }
                }
            }
            List<string> resl = ep(graph);
            res = resl[0];
            int s = resl[0].Count();
            for (int i = 1; i < resl.Count(); i++)
                res += resl[i][s - 1];
            return res;
        }

        static void Main(string[] args)
        {
            List<string> str = new List<string> { };
            string hstr, res="";
            int k;
            hstr = Console.ReadLine();
            k = Convert.ToInt32(hstr);
            while ((hstr = Console.ReadLine()) != "")
            {
                str.Add(hstr);
            }

            res=st(k, str);

            Console.WriteLine(res);
        }
    }
}
