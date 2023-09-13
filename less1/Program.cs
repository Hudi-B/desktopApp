namespace asdasd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Dolgozo> data = new List<Dolgozo>();
            string[] szakmaT = { "ács", "asztalos", "hegesztő", "festő", "burkolo" };
            for (int i = 1; i < 21; i++)
            {
                string nev = "Dolgozó" + i;
                int szuletesiEv = new Random().Next(1960, 2002);
                int fizetes = new Random().Next(200000, 1000000);
                int rnd = new Random().Next(0, 4);
                string szakma = szakmaT[rnd];
                data.Add(new Dolgozo(fizetes, nev, szakma, szuletesiEv));
            }

            foreach (var item in data)
            {
                Console.WriteLine(item.Kiir());
            }

            int legtobbetKeres = data.IndexOf(data.MaxBy(x => x.Fizetes)!);
            Console.WriteLine();
            Console.WriteLine(data[legtobbetKeres].Kiir());
            Console.WriteLine();
            int acsok = 0;

            foreach (var item in data)
            {
                if (item.GetSzakma() == "ács")
                {
                    acsok++;
                }
            }

            Console.WriteLine($"{acsok} db ács dolgozik");
        }
    }
} 