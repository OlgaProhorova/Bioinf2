using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_9._2
{
    class Program
    {
        static Dictionary<string, List<string>> d(List<string> str)
        {
            Dictionary<string, List<string>> di = new Dictionary<string, List<string>> { };
            string hstr;
            for (int i = 0; i < str.Count(); i++)
            {
                hstr = str[i].Substring(0, str[i].IndexOf(" "));
                di.Add(hstr, new List<string> { });
                str[i] = str[i].Remove(0, str[i].IndexOf(">") + 2);
                while (str[i].IndexOf(",") > -1)
                {
                    di[hstr].Add(str[i].Substring(0, str[i].IndexOf(",")));
                    str[i] = str[i].Remove(0, str[i].IndexOf(",") + 1);
                }
                di[hstr].Add(str[i]);
            }
            return di;
        }

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
            string f="", l="";
            List<string> res = new List<string> { }, temp = new List<string> { };

            foreach(string str in dict.Keys)
            {
                di[str] = new List<string> { };
                di[str].AddRange(dict[str].ToArray());
            }

            foreach(string str in di.Keys)
            {
                s.Add(str, di[str].Count());
            }
            foreach (string str in di.Keys)
            {
                while(di[str].Count()>0)
                {
                    s[di[str].Last()]--;
                    di[str].Remove(di[str].Last());
                }
            }
            foreach(string str in s.Keys)
            {
                if(s[str] > 0) f= str;
                if(s[str]<0) l = str;
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

        static void Main(string[] args)
        {
            List<string> str = new List<string> { };
            string hstr;
            while ((hstr = Console.ReadLine()) != "")
            {
                str.Add(hstr);
            }
            str = ep(d(str));

            for (int i = 0; i < str.Count() - 1; i++)
                Console.Write(str[i]+"->");
            Console.WriteLine(str.Last());
        }
    }
}
