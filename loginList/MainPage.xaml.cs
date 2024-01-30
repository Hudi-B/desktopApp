using Android.Service.Notification;

namespace loginList
{
    public partial class MainPage : ContentPage
    {
        public static string Username { get; set; }
        string Password;
        public static bool IsLoggedIn { get; set; } = false;
        Dictionary<string, string> usersDict = new Dictionary<string, string>();

        public MainPage()
        {
            InitializeComponent();
            usersDict["Hudi"] = "Password";
            usersDict["Roland"] = "Password1";
        }

        private void LoginBtn_Clicked(object sender, EventArgs e)
        {
            Username = UsernameEnt.Text; 
            Password = PasswordEnt.Text;

            if (usersDict.ContainsKey(Username) && usersDict[Username] == Password)
            {
                DisplayAlert("Login Successful", $"Welcome, {Username}!", "OK");
                IsLoggedIn = true;
                Navigation.PushAsync(new ListPage());
            }
            else
            {
                DisplayAlert("Login Unsuccessful", $"Redirecting as Guest", "OK");
                Navigation.PushAsync(new ListPage());
            }
        }
    }

}
