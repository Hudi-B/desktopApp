namespace kzug;

public partial class ListPage : ContentPage
{
    List<string> textStrings = new List<string>();
    public ListPage()
	{
		InitializeComponent();
        textStrings.Add("asdasd");
        ThingList.ItemsSource = textStrings;
    }
    private void AddTextClicked(object sender, EventArgs e)
	{
        textStrings.Add(TextIn.Text);
        ThingList.ItemsSource = textStrings;
	}
    private void DeleteTextClicked(object sender, EventArgs e)
    {
        int tempIndex = textStrings.IndexOf(ThingList.SelectedItem.ToString());
        textStrings.RemoveAt(tempIndex);
        ThingList.ItemsSource = textStrings;
    }
    private void InsertTextClicked(object sender, EventArgs e)
    {
        int tempIndex = Convert.ToInt32(IndexIn.Text);
        textStrings.Insert(tempIndex, TextIn.Text);
        ThingList.ItemsSource = textStrings;
    }
}