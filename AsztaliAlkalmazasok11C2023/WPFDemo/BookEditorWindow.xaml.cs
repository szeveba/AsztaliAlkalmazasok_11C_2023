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

namespace WPFDemo
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

        private void ShowMessage_Click(object sender, RoutedEventArgs e)
        {
            var message = TBMessage.Text;
            MessageBox.Show(message, "Üzenet", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
