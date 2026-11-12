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
                        for (int j = 0; j < huto.Length; j++)
                        {
                            Console.Write(huto[j] + ", ");
                        }
                        return;
                    }
                }
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
        }

        static void Main(string[] args)
        {
            KeresEtelKiir();
        }
    }
}
