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

namespace WPFDemo.Views
{
    /// <summary>
    /// Interaction logic for BookEditorWindow.xaml
    /// </summary>
    public partial class BookEditorWindow : Window
    {
        public BookEditorWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void TB_Title_TextChanged(object sender, TextChangedEventArgs e)
        {
            BTN_Save.IsEnabled = !string.IsNullOrWhiteSpace(TB_Title.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TB_Title.Focus();
        }

        private void TB_Title_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !string.IsNullOrWhiteSpace(TB_Title.Text))
            {
                Save_Click(sender, e);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
