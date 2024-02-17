using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Task
{
    class SkrivUt
    {
        public static void SkrivUtFilmer(Film[] filmer)
        {
            for (int i = 0; i < filmer.Length; i++)
            {
                Console.WriteLine("{0}\t{1}\t{2}", filmer[i].titel, filmer[i].genre, filmer[i].utgÅr);
            }
        }
    }
}