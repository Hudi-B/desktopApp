namespace loginList1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("List", typeof(ListPage));
        }
    }
}
