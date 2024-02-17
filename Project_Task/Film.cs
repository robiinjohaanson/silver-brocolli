using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Task
{
    class Film
    {
        public Film(string titel, string genre, int utgÅr)
        {
            this.titel = titel;
            this.genre = genre;
            this.utgÅr = utgÅr;
        }

        public Film()
        {
            titel = "default";
            genre = "default";
            utgÅr = -1;
        }

        public string titel;
        public string genre;
        public int utgÅr;

    }
}
