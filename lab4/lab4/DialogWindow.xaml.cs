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

namespace lab4
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public string Message { get; set; }
        public DialogWindow(string[] radio)
        {
            InitializeComponent();
            if(radio != null && radio.Length > 0)
            {
                foreach (var item in radio)
                {
                    RadioContainer.Children.Add(new RadioButton() { Content = item, VerticalContentAlignment = VerticalAlignment.Center, GroupName = "radiobtns" });
                }
                (RadioContainer.Children[0] as RadioButton)!.IsChecked = true;
            }      
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Message += RadioContainer.Children
                .Cast<RadioButton>()
                .Where(x => x.IsChecked == true)
                .ElementAt(0).Content.ToString();
            this.DialogResult = true;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void MessageText_TextChanged(object sender, TextChangedEventArgs e)
        {
            Message = (sender as TextBox)!.Text;
        }
    }
}
