namespace kzug
{
    public partial class MainPage : ContentPage
    {
        static int count = 0;

        public static int Count { get => count; set => count = value; }

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            Count++;

            if (Count == 1)
                CounterBtn.Text = $"Clicked {Count} time";
            else
                CounterBtn.Text = $"Clicked {Count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void OnLogNavigateButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void OnCalcNavigateButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CalculatorPage());
        }

        private async void OnListNavigateButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListPage());
        }
    }

}
