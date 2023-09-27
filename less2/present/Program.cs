namespace present
{
    internal class Program
    {
        struct Pelda //Pelda struktura/kollekcio
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        static void Main(string[] args)
        {
            var elemek = new List<Pelda> //Pelda feltoltese
            {
            new Pelda { X = 10, Y = 20 },
            new Pelda { X = 11, Y = 23 },
            new Pelda { X = 44, Y = 42 },
            new Pelda { X = 7, Y = 1 },
            new Pelda { X = 9, Y = 12 },
            };

            var eredmeny = from elem in elemek //Linq kivalasztas
                           select elem.X;

            var eredmeny2 = elemek.Select(i => i.X); //Linq lambda kivalasztas

            foreach (var item in eredmeny) //Kivalasztas elemeinek ki listazasa
            {
                Console.WriteLine(item);
            }

            /*var eredmeny = from elem in elemek //Linq projekcio
                           select new
                           {
                               X2 = elem.X * 2,
                               Y2 = elem.Y * 2
                           };

            var eredmeny2 = elemek.Select(i => new //Linq lambda projekcio
            {
                X2 = i.X * 2,
                Y2 = i.Y * 2
            });

            foreach (var item in eredmeny) //Projekcio elemeinek ki listazasa
            {
                Console.WriteLine("{0}, {1}", item.X2, item.Y2);
            };*/

            /*
            var eredmeny = from elem in elemek //Linq szures
                           where elem.X > 10
                           select elem.X;

            var eredmeny2 = elemek.Where(i => i.X > 10).Select(i => i.X); //Linq lambda szures

            foreach (var item in eredmeny) //Szurt elemek kilistazasa
            {
                Console.WriteLine(item);
            };
             */

            /*
            var eredmeny = from elem in elemek //Linq sorba rendezes
                           orderby elem.X ascending
                           select elem;

            var eredmeny2 = elemek.OrderBy(i => i.X); //Linq lambda sorba rendezes

            foreach (var item in eredmeny) //Sorba rendezett elemek kilistazasa
            {
                Console.WriteLine("{0}, {1}", item.X, item.Y);
            }

            //Tobb felteteles sorba rendezes

            var eredmeny = from elem in elemek //Linq sorba rendezes tobb feltetellel
                           orderby elem.X ascending
                           orderby elem.Y descending
                           select elem;

            var eredmeny2 = elemek.OrderBy(i => i.X).OrderByDescending(i => i.Y); //Linq lambda sorba rendezes tobb feltetellel
            */


        }
    }
}