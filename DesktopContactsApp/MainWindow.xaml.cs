using DesktopContactsApp.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DesktopContactsApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();

            contacts = new List<Contact>();

            ReadDatabase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow contactWindow = new NewContactWindow();
            contactWindow.ShowDialog();

            ReadDatabase();
        }

        void ReadDatabase()
        {

            using(SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                contacts = (connection.Table<Contact>().ToList()).OrderBy(c => c.Name).ToList();
            }
            if(contacts != null)
            {
                contactListView.ItemsSource = contacts;
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;
            var filteredList = contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();

            contactListView.ItemsSource = filteredList;
        }

        private void ContactListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedContact = (Contact)contactListView.SelectedItem;

            if(selectedContact != null)
            {
                ContactDetailsWindow contactDetailWindow = new ContactDetailsWindow(selectedContact);
                contactDetailWindow.ShowDialog();
            }
            ReadDatabase();
        }
    }
}
