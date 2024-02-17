using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Project_Task
{
    class HanteraFilmer
    {
        public static string valAvSortering = "ingen sortering";

        public static void SökFilmer()
        {
            int sökning = -1;
            Console.Write("Val 1 för att söka efter titel.\n" +
                "Val 2 för att söka efter genre.\n" +
                "Val 3 för att söka efter utgiven årtal.");
            while (!int.TryParse(Console.ReadLine(), out sökning))
            {
                Console.WriteLine("Du behöver ange ett heltal mellan 1 - 3.");
            }
            switch (sökning)
            {
                case 1:
                    SökFilmerTitel(RegistreraFilmer.HämtaFilmer());
                    break;

                case 2:
                    SökFilmerGenre(RegistreraFilmer.HämtaFilmer());
                    break;
                case 3:

                    SökFilmerUtgÅr(RegistreraFilmer.HämtaFilmer());
                    break;

                default:
                    Console.WriteLine("Fel val, välj 1-3");
                    break;
            }
        }
        /* *************************************************************
        * This Program uses the bubble sort algorithm to sort an array*
        * The program sorts the largest elements first in array.      *
        ***************************************************************/
        public static void SorteraFilmerTitel(Film[] filmer)
        {
            for (int i = 0; i < filmer.Length; i++)
            {
                for (int j = 0; j < filmer.Length - i - 1; j++)
                {
                    if (filmer[j].titel.CompareTo(filmer[j + 1].titel) > 0)
                    {
                        Film temp;
                        temp = filmer[j];
                        filmer[j] = filmer[j + 1];
                        filmer[j + 1] = temp;
                    }
                }
            }
            valAvSortering = "titel";
        }

        public static void SorteraFilmerGenre(Film[] filmer)
        {
            for (int i = 0; i < filmer.Length; i++)
            {
                for (int j = 0; j < filmer.Length - i - 1; j++)
                {
                    if (filmer[j].genre.CompareTo(filmer[j + 1].genre) > 0)
                    {
                        Film temp;
                        temp = filmer[j];
                        filmer[j] = filmer[j + 1];
                        filmer[j + 1] = temp;
                    }
                }
            }
            valAvSortering = "genre";
        }

        public static void SorteraFilmerUtgÅr(Film[] filmer)
        {
            for (int i = 0; i < filmer.Length; i++)
            {
                for (int j = 0; j < filmer.Length - i - 1; j++)
                {
                    if (filmer[j].utgÅr > (filmer[j + 1].utgÅr))
                    {
                        Film temp;
                        temp = filmer[j];
                        filmer[j] = filmer[j + 1];
                        filmer[j + 1] = temp;
                    }
                }
            }
            valAvSortering = "utgår";
        }

        public static void SökFilmerGenre(Film[] filmer)
        {
            Console.Write("Ange genre att söka: ");
            string sökGenre = Console.ReadLine();
            Film[] hittadeFilmer = new Film[0];
            for (int c = 0; c < filmer.Length; c++)
            {
                if (filmer[c].genre.Equals(sökGenre))
                {
                    SparaIVektor(filmer[c], ref hittadeFilmer);
                }
            }
            SorteraFilmerTitel(hittadeFilmer);
            SkrivUt.SkrivUtFilmer(hittadeFilmer);
        }


        public static void SökFilmerTitel(Film[] filmer)
        {
            Console.Write("Ange titel att söka: ");
            string sökTitel = Console.ReadLine();
            Film[] hittadeFilmer = new Film[0];
            for (int c = 0; c < filmer.Length; c++)
            {
                if (filmer[c].titel.Equals(sökTitel))
                {
                    SparaIVektor(filmer[c], ref hittadeFilmer);
                }
            }
            SorteraFilmerTitel(hittadeFilmer);
            SkrivUt.SkrivUtFilmer(hittadeFilmer);
        }

        public static void SökFilmerUtgÅr(Film[] filmer)
        {
            Console.Write("Ange utgivningsår att söka: ");
            string sökUtgÅr = Console.ReadLine();
            Film[] hittadeFilmer = new Film[0];
            for (int c = 0; c < filmer.Length; c++)
            {
                if (filmer[c].utgÅr.Equals(sökUtgÅr))
                {
                    SparaIVektor(filmer[c], ref hittadeFilmer);
                }
            }
            SorteraFilmerTitel(hittadeFilmer);
            SkrivUt.SkrivUtFilmer(hittadeFilmer);
        }
        public static void SparaIVektor(Film nyFilm, ref Film[] filmer)
        {
            Console.WriteLine(nyFilm.titel);
            Film[] temp = new Film[filmer.Length + 1];
            for (int i = 0; i < filmer.Length; i++)
            {
                temp[i] = filmer[i];
            }
            temp[filmer.Length] = nyFilm;
            filmer = temp;
        }
    }
}
