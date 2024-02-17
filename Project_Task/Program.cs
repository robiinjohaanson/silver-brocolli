using System;
using System.Threading;

namespace Project_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            RegistreraFilmer.HämtaFilmerFrånFil();

            while (true)
            {

                SkrivUtMeny();
                int menyVal = -1;

                while (!int.TryParse(Console.ReadLine(), out menyVal))
                {
                    Console.WriteLine("Du behöver skriva in ett heltal.");
                }

                switch (menyVal)
                {
                    case 1:
                        RegistreraFilmer.SparaFilmer();
                        //RegistreraFilmer.SkapaNyFilm();
                        break;

                    case 2:
                        HanteraFilmer.SorteraFilmerTitel(RegistreraFilmer.HämtaFilmer());
                        SkrivUt.SkrivUtFilmer(RegistreraFilmer.HämtaFilmer());
                        break;

                    case 3:
                        HanteraFilmer.SorteraFilmerGenre(RegistreraFilmer.HämtaFilmer());
                        SkrivUt.SkrivUtFilmer(RegistreraFilmer.HämtaFilmer());
                        break;

                    case 4:
                        HanteraFilmer.SorteraFilmerUtgÅr(RegistreraFilmer.HämtaFilmer());
                        SkrivUt.SkrivUtFilmer(RegistreraFilmer.HämtaFilmer());
                        break;

                    case 5:
                        HanteraFilmer.SökFilmer();
                        break;

                    case 6:
                        Console.Write("Programmet avslutas.");
                        Thread.Sleep(500);
                        return;
                        //break;

                    default:
                        break;
                }
            }
        }

        public static void SkrivUtMeny()
        {
            Console.WriteLine("Val 1 för att lagra filmer.\n" +
                "Val 2 för att skriva ut filmer efter titel.\n" +
                "Val 3 för att skriva ut filmer efter genre.\n" +
                "Val 4 för att skriva ut filmer efter utgivningsårtal.\n" +
                "Val 5 för att söka filmer.\n" +
                "Val 6 för att avsluta programmet och återgå.");
        }

    }
}
