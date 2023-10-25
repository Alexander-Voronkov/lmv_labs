using Microsoft.Win32;
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

namespace lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogWindow dialogWindow = new DialogWindow((sender as Button).Content.ToString().Split(','));
            if (dialogWindow.ShowDialog() == true)
            {
                DialogResult.Text = dialogWindow.Message;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Cpp-files|*.cpp|C-files|*.c|Header-files|*.h";
            var res = ofd.ShowDialog();
            if(res == true)
            {
                DialogResult.Text = System.IO.Path.GetExtension(ofd.FileName);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Which option");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("No dialog");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}