using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Microsoft.Maui.Controls;
using static System.Net.Mime.MediaTypeNames;


namespace loginList1
{
    public partial class ListPage : ContentPage
    {
        private ListPageViewModel viewModel;

        public ListPage()
        {
            InitializeComponent();
            viewModel = new ListPageViewModel();
            BindingContext = viewModel;
            WelcomeMessage.Text = MainPage.IsLoggedIn ? $"Welcome {MainPage.Username}!" : "Welcome Guest!";
            ImportBtn.IsEnabled = MainPage.IsLoggedIn ? true : false;
            ExportBtn.IsEnabled = MainPage.IsLoggedIn ? true : false;
        }

        private void AddItem_Clicked(object sender, EventArgs e)
        {
            string temp = TextIn.Text;
            viewModel.AddItem(temp);
        }

        private void InsertItem_Clicked(object sender, EventArgs e)
        {
            string temp = TextIn.Text;
            string tempItem = itemsListView.SelectedItem as string;
            viewModel.InsertItem(temp, tempItem);
        }

        private void DeleteItem_Clicked(object sender, EventArgs e)
        {
            string tempItem = itemsListView.SelectedItem as string;
            viewModel.DeleteItem(tempItem);
        }

        private void ClearList_Clicked(object sender, EventArgs e)
        {
            viewModel.ClearList();
        }

        private void SaveToFile_Clicked(object sender, EventArgs e)
        {
            viewModel.SaveToFile();
        }

        private void LoadFromFile_Clicked(object sender, EventArgs e)
        {
            viewModel.LoadFromFile();
        }

        private void Logout_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void Generate_Clicked(object sender, EventArgs e)
        {
            viewModel.GenarateItems();
        }
    }

    public class ListPageViewModel
    {
        public ObservableCollection<string> Items { get; set; }

        public ListPageViewModel()
        {
            Items = new ObservableCollection<string>{};
        }

        public void AddItem(string text)
        {
            Items.Add(text);
        }

        public void InsertItem(string text, string selectedItem)
        {
            if (!string.IsNullOrEmpty(selectedItem))
            {
                int selectedIndex = Items.IndexOf(selectedItem);

                if (selectedIndex >= 0)
                {
                    Items.Insert(selectedIndex + 1, text);
                }
            }
        }

        public void DeleteItem(string selectedItem)
        {
            if (!string.IsNullOrEmpty(selectedItem))
            {
                int selectedIndex = Items.IndexOf(selectedItem);

                if (selectedIndex >= 0)
                {
                    Items.RemoveAt(selectedIndex);
                }
            }
        }

        public void GenarateItems()
        {
            for (int i = 0; i < 5; i++)
            {
                Items.Add($"Item{ i + 1 }");
            }
        }

        public void ClearList()
        {
            Items.Clear();
        }

        public void SaveToFile()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "items.txt");
            File.WriteAllLines(filePath, Items);
        }

        public void LoadFromFile()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "items.txt");
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                Items.Clear();

                foreach (var line in lines)
                {
                    Items.Add(line);
                }
            }
        }
    }
}
