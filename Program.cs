using System.Security.Cryptography;
using System.Xml.Serialization;

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
            }
            else
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
            string[] maganhangzok = { "a", "á", "e", "é", "i", "í", "u", "ú", "ü", "ű", "o", "ó", "ö", "ő" };
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
            Osszmenu();
        }

        //FELADAT 2

        static int[] szamok = new int[10];
        static Random r = new Random();

        static void FeltoltEgyediekkel(int min, int max)
        {
            for (int i = 0; i < szamok.Length; i++)
            {
                int szam;
                do
                {
                    szam = r.Next(min, max);
                } while (szamok.Contains(szam));
                szamok[i] = szam;
            }
            for (int i = 0; i < szamok.Length; i++)
            {
                Console.WriteLine(szamok[i]);
            }
            SzamokMenu();
        }


        static int[] LeghosszabbNovekvo()
        {
            int[] leghosszabb = new int[szamok.Length];
            int[] segedLeghosszabb = new int[szamok.Length];
            int index = 0;
            int segedindex = 0;
            int elso = szamok[0];
            int masodik = szamok[1];
            int masodikindex = 2;
            for (int i = 0; i < szamok.Length - 2 ; i++)
            {
                if (elso < masodik)
                {
                    if (segedindex == 0)
                    {
                        segedLeghosszabb[segedindex] = elso;
                        segedLeghosszabb[segedindex + 1] = masodik;
                        segedindex += 2;
                    }
                    else
                    {
                        segedLeghosszabb[segedindex] = masodik;
                        segedindex += 1;
                    }
                }
                else
                {
                    if (segedindex > index)
                    {
                        for (int j = 0; j < segedLeghosszabb.Length; j++)
                        {
                            leghosszabb[j] = segedLeghosszabb[j];                                              
                        }
                    }
                    index = segedindex;
                    segedindex = 0;
                }
                elso = masodik;
                masodik = szamok[masodikindex];
                masodikindex++;
            }
            return leghosszabb;
        }

        static void LeghosszabbNovekvoKiir()
        {
            int[] leghosszabbnovekvo = LeghosszabbNovekvo();
            Console.WriteLine(leghosszabbnovekvo.Length);
            int[] tomb = new int[leghosszabbnovekvo.Length];
            int index = 0;
            int vegsoindex = 0;
            for (int i = 0; i < leghosszabbnovekvo.Length; i++)
            {
                if (leghosszabbnovekvo[i] != 0)
                {
                    tomb[index] = leghosszabbnovekvo[i];
                    index += 1;
                }
            }

            int[] vegsotomb = new int[index];
            for (int i = 0; i < vegsotomb.Length; i++)
            {
                vegsotomb[vegsoindex] = tomb[vegsoindex];
                vegsoindex += 1;
            }
            //Console.WriteLine("-----------------");
            //for (int i = 0; i < leghosszabbnovekvo.Length; i++)
            //{
            //    Console.WriteLine(leghosszabbnovekvo[i] + ", ");
            //}
            //Console.WriteLine("----------------");
            //for (int i = 0; i < tomb.Length; i++)
            //{
            //    Console.WriteLine(tomb[i] + ", ");
            //}
            Console.WriteLine("-----------------");
            for (int i = 0; i < vegsotomb.Length; i++)
            {
                Console.WriteLine(vegsotomb[i] + ", ");
            }
            SzamokMenu();
        }

        static void AtlagAlattiDuplazas()
        {
            int atlag = 0;
            int osszeg = 0;
            for (int i = 0; i < szamok.Length; i++)
            {
                osszeg += szamok[i];
            }
            atlag = osszeg / szamok.Length;
            for (int i = 0; i < szamok.Length;i++)
            {
                if (szamok[i] < atlag)
                {
                    Console.WriteLine(i + 1 + ". értéke duplázva!");
                    int seged = szamok[i];
                    szamok[i] = seged * 2;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Az új lista: ");
            for (int i = 0; i < szamok.Length; i++)
            {
                Console.WriteLine(szamok[i]);
            }
            SzamokMenu();
        }

        static void SzamokMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Üdvözöllek a számok világában! Miben segíthetek?");
            Console.WriteLine("1. Számok feltöltése");
            Console.WriteLine("2. Leghosszabb szigorúan növekvők kiírása");
            Console.WriteLine("3. Átlag alatti duplázás");
            Console.WriteLine("4. Kilépés");
            Console.Write("Kérem adja meg a művelet számát: ");
            int muvelet = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (muvelet)
            {
                case 1: FeltoltEgyediekkel(10, 20); break;
                case 2: LeghosszabbNovekvoKiir(); break;
                case 3: AtlagAlattiDuplazas(); break;
                case 4: kilepes(); break;
            }
            Osszmenu();
        }

        static void Osszmenu()
        {
            Console.WriteLine();
            Console.WriteLine("Üdvözöllek a menüben! Miben segíthetek?");
            Console.WriteLine("1. Számok világa");
            Console.WriteLine("2. Hűtőszekrény kezelő");
            Console.WriteLine("3. Kilépés");
            Console.Write("Kérem adja meg a művelet számát: ");
            int muvelet = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (muvelet)
            {
                case 1: SzamokMenu(); break;
                case 2: HutoMenu(); break;
                case 3: kilepes(); break;
            }
        }

        static void Main(string[] args)
        {
            Osszmenu();
        }
    }
}
