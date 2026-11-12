namespace Dolgozat_Acsai_Dominik
{
    internal class Program
    {
        static string[] huto = { "", "", "", "", "", "", "", "", "", "" };

        static void hutoFeltoltese()
        {
            Console.Write("Kérem adja meg a hűtőbe berakandó termék nevét: ");
            string item = Console.ReadLine();

            if (item == null)
            {
                Console.WriteLine("A hűtőbe rakandó termék nem lehet semmi!");
            }
            else
            {
                for (int i = 0; i < huto.Length; i++)
                {
                    if (huto[i] == "")
                    {
                        huto[i] = item;
                        HutoMenu();
                        return;
                    }
                }
                Console.WriteLine("A hűtő tele van!");
            }
        }

        static int Takarit()
        {
            int darabszam = 0;
            for (int i = 0; i < huto.Length; i++)
            {
                if (huto[i] != "")
                {
                    darabszam += 1;
                }
            }
            return darabszam;
        }

        static void TakaritKiir()
        {
            int takarit = Takarit();
            if (takarit == 0)
            {
                Console.WriteLine("A hűtő üres!");
            } else
            {
                Console.WriteLine(takarit + " db étel van a hűtőben.");
            }
            HutoMenu();
        }

        static int KeresEtel()
        {
            Console.Write("Kérem adja meg milyen ételt keres: ");
            string etel = Console.ReadLine();

            if (etel == null)
            {
                Console.WriteLine("A keresett étel nem lehet semmi!");
                return -1;
            }

            for (int i = 0; i < huto.Length; i++)
            {
                if (huto[i].ToLower() == etel.ToLower())
                {
                    return i;
                }
            }
            return -1;
        }

        static void KeresEtelKiir()
        {
            int etel = KeresEtel();

            if (etel == -1)
            {
                Console.WriteLine("A hűtőben nem található ilyen étel!");
            }
            else
            {
                Console.WriteLine(etel + ". helyen található a keresett étel!");
            }
            HutoMenu();
        }

        static void MaganhangzovalKezdodik()
        {
            string[] maganhangzok = {"a", "á", "e", "é", "i", "í", "u", "ú", "ü", "ű", "o", "ó", "ö", "ő" };
            for (int i = 0; i < huto.Length; i++)
            {
                for (int j = 0; j < maganhangzok.Length; j++)
                {
                    if (huto[i].ToLower().StartsWith(maganhangzok[j]))
                    {
                        Console.Write(huto[i] + ", ");
                    }
                }
            }
            HutoMenu();
        }

        static void kilepes()
        {
            Console.WriteLine("Viszlát!");
        }

        static void HutoMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Üdvözöllek a hűtőszekrény előtt! Miben segíthetek?");
            Console.WriteLine("1. Hűtő feltöltése");
            Console.WriteLine("2. Hűtő telítetségének száma");
            Console.WriteLine("3. Étel keresése");
            Console.WriteLine("4. Magánhangzóval kezdődő ételek");
            Console.WriteLine("5. Kilépés");
            Console.Write("Kérem adja meg a művelet számát: ");
            int muvelet = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (muvelet)
            {
                case 1: hutoFeltoltese(); break;
                case 2: TakaritKiir(); break;
                case 3: KeresEtelKiir(); break;
                case 4: MaganhangzovalKezdodik(); break;
                case 5: kilepes(); break;
            }
        }

        //FELADAT 2

        static int[] szamok = new int[10];
        static Random r = new Random();

        static void FeltoltEgyediekkel (int min, int max)
        {
            for (int i = 0;  i < szamok.Length; i++)
            {
                int szam;
                do
                {
                    szam = r.Next(min, max);
                } while (szamok.Contains(szam));
                szamok[i] = szam;
            }
            //for (int i = 0; i < szamok.Length;i++)
            //{
            //    Console.WriteLine(szamok[i]);
            //}
        }

        static int LeghosszabbNovekvo()
        {

        }

        static void Main(string[] args)
        {
            //HutoMenu();
            FeltoltEgyediekkel(1, 20);
        }
    }
}
