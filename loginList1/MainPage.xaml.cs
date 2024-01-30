namespace loginList1
{
    public partial class MainPage : ContentPage
    {
        public static string Username { get; set; }
        string Password;
        public static bool IsLoggedIn { get; set; }
        Dictionary<string, string> usersDict = new Dictionary<string, string>();

        public MainPage()
        {
            InitializeComponent();
            usersDict["Hudi"] = "Password";
            usersDict["Roli"] = "Password1";
            usersDict["Admin"] = "Admin";
        }

        private void LoginBtn_Clicked(object sender, EventArgs e)
        {
            Username = UsernameEnt.Text;
            Password = PasswordEnt.Text;

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                DisplayAlert("Error", "Missing input", "OK");
            }
            else
            {
                if (usersDict.ContainsKey(Username) && usersDict[Username] == Password)
                {
                    DisplayAlert("Login Successful", $"Welcome, {Username}!", "OK");
                    IsLoggedIn = true;
                    Navigation.PushAsync(new ListPage());
                }
                else
                {
                    DisplayAlert("Login Failed", $"Redirecting as Guest", "OK");
                    IsLoggedIn = false;
                    Navigation.PushAsync(new ListPage());
                }
            }
        }
    }

}
