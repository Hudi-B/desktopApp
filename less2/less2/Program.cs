namespace less2
{
    class Cheese
    {
        protected int price;
        protected string origin;

        public Cheese(int price)
        {
            this.price = price;
        }
        public virtual void Origin()
        {
            origin = "";
        }

        public string Originated()
        { 
            return origin;
        }
    }
    class Cheddar : Cheese 
    {
        protected string usedIn;

        public Cheddar(int price, string usedIn) : base(price)
        {
            this.usedIn = usedIn;
            base.price += 50000;
        }

        public override void Origin()
        {
            origin = "Italy";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Cheese a = new Cheese(200000);
            Console.WriteLine(a.Originated);
            Cheddar b = new Cheddar(23211, "Salad");
            Console.WriteLine(b.Originated);
        }
    }
}