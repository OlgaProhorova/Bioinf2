using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_9._1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> str = new List<string> { };
            string hstr;
            while ((hstr = Console.ReadLine()) != "")
            {
                str.Add(hstr);
            }
            
            Dictionary<string, List<string>> di = new Dictionary<string, List<string>> { };
            for (int i = 0; i < str.Count(); i++)
            {
                hstr = str[i].Substring(0, str[i].IndexOf(" "));
                di.Add(hstr, new List<string> { });
                str[i]=str[i].Remove(0, str[i].IndexOf(">")+2);
                while (str[i].IndexOf(",") > -1)
                {
                    di[hstr].Add(str[i].Substring(0, str[i].IndexOf(",")));
                    str[i]=str[i].Remove(0, str[i].IndexOf(",") + 1);
                }
                di[hstr].Add(str[i]);
            }

            List<string> res = new List<string> { }, t = new List<string> { };
            bool f = true;
            hstr = di.Keys.First();
            string curr, temp;
            str.Clear();
            int ind = 0;

            while (f)
            {
                res.Clear();
                res.AddRange(t.ToArray());
                t.Clear();
                curr = hstr;
                while (!(di[curr].Count()==0))
                {
                    res.Add(curr);
                    temp = curr;
                    curr = di[curr].Last();
                    di[temp].Remove(di[temp].Last());
                }
                f = false;
                for (int i = 0; i < res.Count(); i++)
                    if (di[res[i]].Count()>0)
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

            for (int i = 0; i < res.Count(); i++) Console.Write(res[i]+"->");
            Console.WriteLine(hstr);
        }
    }
}
