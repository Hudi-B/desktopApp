namespace kzug;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        CountOut.Text = MainPage.Count.ToString();
	}
    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Login Successful", $"Welcome, {username}!", "OK");
            UsernameEntry.Text = "";
            PasswordEntry.Text = "";
        }
        else
        {
            await DisplayAlert("Error", "Please enter both username and password.", "OK");
            UsernameEntry.Text = "";
            PasswordEntry.Text = "";
        }
    }
}