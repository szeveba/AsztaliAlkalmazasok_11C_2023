using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFDemo.Views;

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Thread.Sleep(1000);
        }
        const string bookDBName = "books.txt";

        private void CreateBook_Click(object sender, RoutedEventArgs e)
        {
            var window = new BookEditorWindow();
            if (window.ShowDialog() == true)
            {
                LB_Books.Items.Add(window.TB_Title.Text);
                SaveBooks();
            }
        }

        private void BTN_DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Biztos törölni szeretné a kiválasztott könyvet?", "Törlés", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                LB_Books.Items.Remove(LB_Books.SelectedItem);
                SaveBooks();
            }
        }

        private void SaveBooks()
        {
            var op = new List<string>();
            foreach (string item in LB_Books.Items)
            {
                op.Add(item);
            }
            File.WriteAllLines(bookDBName, op);
        }

        private void BTN_EditBook_Click(object sender, RoutedEventArgs e)
        {
            var window = new BookEditorWindow();
            window.TB_Title.Text = (string)LB_Books.SelectedValue;
            window.TB_Title.CaretIndex = window.TB_Title.Text.Length;
            if (window.ShowDialog() == true)
            {
                var index = LB_Books.SelectedIndex;
                LB_Books.Items.RemoveAt(index);
                LB_Books.Items.Insert(index, window.TB_Title.Text);
                SaveBooks();
            }
        }

        private void LB_Books_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BTN_EditBook_Click(sender, e);
        }

        private void LB_Books_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BTN_DeleteBook.IsEnabled = LB_Books.SelectedItem != null;
            BTN_EditBook.IsEnabled = LB_Books.SelectedItem != null;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(bookDBName))
            {
                var bookLines = File.ReadAllLines(bookDBName);
                foreach (var line in bookLines)
                {
                    LB_Books.Items.Add(line);
                }
            }
            else
            {
                File.Create(bookDBName);
            }
        }

        private void LB_Books_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    BTN_EditBook_Click(sender, e);
                    break;
                case Key.Delete:
                    BTN_DeleteBook_Click(sender, e);
                    break;
            }
        }
    }
}