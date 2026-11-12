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

        static void Main(string[] args)
        {
            hutoFeltoltese();
        }
    }
}
