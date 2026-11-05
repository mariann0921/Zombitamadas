namespace Zombitamadas
{
    internal class Program
    {
        static Random r = new Random();
        static string[] Nevkiosztas(int elemekSzama)
        {
            string[] nevek ={"Adam",     "Bence",   "Dani",    "Eszter",    "Flora",    "Gabor",    "Hanna",    "Istvan",    "Judit",    "Krisztian",    "Lili",    "Mate",
                        "Nora",    "Oliver",    "Peter",    "Ricsi",    "Sara",    "Tamas",    "Viktor",    "Zsofi",    "ZombiBob",    "HullaHugo",    "Csonti",    "Agyfaló",
                        "Vonyito",    "Rothado",    "Zombika",    "Halalos",    "Koponya",    "Sirásó"};
            string[] tomb = new string[elemekSzama];
            for (int i = 0; i < elemekSzama; i++)
            {
                int index = r.Next(0,nevek.Length);
                tomb[i] = nevek[index];
            }
            return tomb; //itt nem a tömböt küldi, hanem a memóriaból a referenciacimet
        }
        static void Kiir(string[] tomb) //megkapjaa memóriacimet, és azzal dolgozoik, amit ott talál, kiirja
        {
            foreach (var item in tomb)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
        }

        static int[] LakossagEreje(int lakossagSzama)
        {
            int[] tomb = new int[lakossagSzama];
            for (int i = 0; i < lakossagSzama; i++)
            {
                tomb[i] = 100;
            }
            return tomb;
        }
        static int[] ZombikErejeKezdeti(int lakossagSzama, int sebzesMin, int sebzesMax)
        {
            int[] tomb = new int[lakossagSzama];
            for (int i = 0; i < lakossagSzama; i++)
            {
                tomb[i] = r.Next(sebzesMin, sebzesMax);
            }
            return tomb;
        }

        static void KiirSzamokat(int[] tomb)
        {
            foreach (var item in tomb)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n----------------------------------------------------");
        }
        private static void Harc(string[] lakossag, string[] zombik, int[] lakossagEletereje, int[] zombikEreje)
        {
            for (int i = 0; i < zombik.Length; i++)
            {
                int index = r.Next(0, lakossag.Length); //hanyadik lakost támadjuk meg
                Console.WriteLine($"{zombik[i]} zombi rátámadt {zombikEreje[i]} erővel {lakossag[index]}, akinek kezdeti életereje: {lakossagEletereje[index]}.");
                lakossagEletereje[index] -= zombikEreje[i];
                if (lakossagEletereje[index] <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{lakossag[index]} lakos meghalt.");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{lakossag[index]} lakos életereje: {lakossagEletereje[index]}");

                }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("HÁny lakosa legyen a városnak: (1-20)");
            int lakossagSzama = Convert.ToInt32(Console.ReadLine());
            string[] lakossag = Nevkiosztas(lakossagSzama);
            int[] lakossagEletereje = LakossagEreje(lakossagSzama);

            Console.Write("A lakosság: ");
            Kiir(lakossag); //memóriacimet adjuk át
            KiirSzamokat(lakossagEletereje);

            string[] zombik = Nevkiosztas(lakossagSzama);
            int sebzesMin= 10;
            int sebzesMax = 30;
            int[] zombikEreje = ZombikErejeKezdeti(lakossagSzama, sebzesMin, sebzesMax);

            Console.Write("A zombik: ");
            Kiir(zombik);
            KiirSzamokat(zombikEreje);

            Harc(lakossag, zombik, lakossagEletereje, zombikEreje);


        }

      
    }
}


//harc működése:
//1. minden zombi sebez véletlenszerűen egy lakost