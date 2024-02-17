using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Project_Task
{
    class RegistreraFilmer
    {
        public static Film[] filmer = new Film[0];

        public static void SparaFilmer()
        {
            SkapaNyFilm();
            
            bool run = true;
            string flerTitlar;
            while (run)
            {
                Console.Write("Vill du lägga till fler filmer? [J]a, [N]ej: ");
                flerTitlar = Console.ReadLine().ToUpper();

                switch (flerTitlar)
                {
                    case "J":
                        SkapaNyFilm();
                        break;

                    case "N":
                        Console.WriteLine("Avslutar körning.");
                        System.Threading.Thread.Sleep(500);
                        run = false;
                        break;

                    default:
                        Console.WriteLine("Svara med [J] eller [N]");
                        break;
                }
            }
        }
        public static void SparaIFil(Film nyFilm)
        {
            StreamWriter skrivFilm = new StreamWriter("filmer.txt", true);
            skrivFilm.WriteLine("{0}\t{1}\t{2}\t", nyFilm.titel, nyFilm.genre, nyFilm.utgÅr);
            skrivFilm.Close();
        }
        public static void HämtaFilmerFrånFil()
        {
            StreamReader läsFilm = new StreamReader("filmer.txt", true);

            while (!läsFilm.EndOfStream)
            {
                string nyFilm = läsFilm.ReadLine();
                Film nästaFilm = new Film();
                string[] data = nyFilm.Split("\t");

                nästaFilm.titel = data[0];
                nästaFilm.genre = data[1];
                nästaFilm.utgÅr = int.Parse(data[2]);

                SparaIVektor(nästaFilm, ref filmer);
            }
            läsFilm.Close();
        }
        public static void SparaIVektor(Film nyFilm, ref Film[] filmer)
        {
            Film[] temp = new Film[filmer.Length + 1];
            for (int i = 0; i < filmer.Length; i++)
            {
                temp[i] = filmer[i];
            }
            temp[filmer.Length] = nyFilm;
            filmer = temp;
        }
        public static void SparaISorteradVektor(Film nyFilm, ref Film[] filmer, int index)
        {
            Film[] temp = new Film[filmer.Length + 1];
            for (int föreNyFilm = 0; föreNyFilm < index; föreNyFilm++)
            {
                temp[föreNyFilm] = filmer[föreNyFilm];
            }
            temp[index] = nyFilm;
            for (int efterNyFilm = index + 1; efterNyFilm < temp.Length; efterNyFilm++)
            {
                temp[efterNyFilm] = filmer[efterNyFilm - 1];
            }
            filmer = temp;
        }

        public static void SkapaNyFilm()
        {
            string titel, genre;
            int utgÅr = 0;
            Console.Write("Ange titel på filmen: ");
            titel = Console.ReadLine();
            Console.Write("Ange genre på filmen: ");
            genre = Console.ReadLine();
            Console.Write("Ange utgivningsår på filmen: ");
            while (!int.TryParse(Console.ReadLine(), out utgÅr))
            {
                Console.WriteLine("Skriv in utgivningsår i format ÅÅÅÅ");
            }

            Film nästaFilm = new Film(titel, genre, utgÅr);
            SparaIFil(nästaFilm);


            if (HanteraFilmer.valAvSortering.Equals("ingen sortering") || filmer.Length == 0)
            {
                SparaIVektor(nästaFilm, ref filmer);
            }

            else if (HanteraFilmer.valAvSortering.Equals("titel"))
            {
                int rättIndex = -1;
                for (int letaIndex = 0; letaIndex < filmer.Length; letaIndex++)
                {
                    if (filmer[letaIndex].titel.CompareTo(nästaFilm.titel) > 0 || filmer[letaIndex].titel.CompareTo(nästaFilm.titel) == 0 || letaIndex == filmer.Length - 1)
                    {
                        rättIndex = letaIndex + 1;
                        SparaISorteradVektor(nästaFilm, ref filmer, rättIndex);
                        return;
                    }
                }
            }

            else if (HanteraFilmer.valAvSortering.Equals("genre"))
            {
                int rättIndex = -1;
                for (int letaIndex = 0; letaIndex < filmer.Length; letaIndex++)
                {
                    if (filmer[letaIndex].genre.CompareTo(nästaFilm.genre) > 0 || filmer[letaIndex].genre.CompareTo(nästaFilm.genre) == 0 || letaIndex == filmer.Length - 1)
                    {
                        rättIndex = letaIndex + 1;
                        SparaISorteradVektor(nästaFilm, ref filmer, rättIndex);
                        return;
                    }
                }
            }

            else if (HanteraFilmer.valAvSortering.Equals("utgår"))
            {
                int rättIndex = -1;
                for (int letaIndex = 0; letaIndex < filmer.Length; letaIndex++)
                {
                    if (filmer[letaIndex].utgÅr > nästaFilm.utgÅr || filmer[letaIndex].utgÅr == nästaFilm.utgÅr || letaIndex == filmer.Length - 1)
                    {
                        rättIndex = letaIndex + 1;
                        SparaISorteradVektor(nästaFilm, ref filmer, rättIndex);
                        return;
                    }
                }
            }
        }
        public static Film[] HämtaFilmer()
        {
            return filmer;
        }
    }
}
