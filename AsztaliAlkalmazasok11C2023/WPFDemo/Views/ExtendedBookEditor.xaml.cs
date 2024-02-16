using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFDemo.Models;

namespace WPFDemo.Views
{
    /// <summary>
    /// Interaction logic for ExtendedBookEditor.xaml
    /// </summary>
    public partial class ExtendedBookEditor : Window
    {
        public ExtendedBookEditor()
        {
            InitializeComponent();
            Book = new Book();
        }
        public ExtendedBookEditor(Book book)
        {
            InitializeComponent();
            Book = book;
        }

        public Book Book { get; internal set; }

        private void BTN_Save_Click(object sender, RoutedEventArgs e)
        {
            Book.Author = TB_Author.Text;
            Book.Publish = DP_Publish.SelectedDate;
            Book.Title = TB_Title.Text;
            Book.Type = TB_Type.Text;
            DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TB_Author.Text = Book.Author;
            TB_Title.Text = Book.Title;
            TB_Type.Text = Book.Type;
            DP_Publish.SelectedDate = Book.Publish;
        }
    }
}
