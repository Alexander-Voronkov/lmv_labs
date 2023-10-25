using System.Diagnostics;
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

namespace lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty MessageText = DependencyProperty.Register(nameof(MessageText), typeof(string), typeof(MainWindow));
        public MainWindow()
        {
            InitializeComponent();
            ProgramComboBox.Items.Add("explorer.exe");
            ProgramComboBox.Items.Add("notepad.exe");
            ProgramComboBox.Items.Add("cmd.exe");
            ProgramComboBox.SelectedIndex = 0;
            CB1.IsChecked = true;
            CB2.IsChecked = true;
            ShowCB1.IsChecked = true;
            ShowCB2.IsChecked = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((string)GetValue(MessageText));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SetValue(MessageText, "Enter a message here");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SetValue(MessageText, string.Empty);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MessageLabel.IsEnabled = true;
            MessageTextBox.IsEnabled = true;
            ShowMessageBtn.IsEnabled = true;
            ClearMessageBtn.IsEnabled = true;
            DefaultMessageBtn.IsEnabled = true;
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            ProgramLabel.IsEnabled = true;
            ProgramBtn.IsEnabled = true;
            ProgramComboBox.IsEnabled = true;
        }

        private void ProgramBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(ProgramComboBox.Text))
                    Process.Start(ProgramComboBox.SelectedValue.ToString()!);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Set_Show_Actions_Check_Click(object sender, RoutedEventArgs e)
        {
            if (Set_Show_Actions_Check.Content == "SetShowActionsCheck")
            {
                ShowCB1.IsChecked = true; 
                ShowCB2.IsChecked = true;
                Set_Show_Actions_Check.Content = "SetShowActionsUnCheck"; 
            }
            else
            {
                ShowCB1.IsChecked = false;
                ShowCB2.IsChecked = false;
                Set_Show_Actions_Check.Content = "SetShowActionsCheck";
            }
        }

        private void ShowCB2_Checked(object sender, RoutedEventArgs e)
        {
            ProgramLabel.Visibility = Visibility.Visible;
            ProgramBtn.Visibility = Visibility.Visible;
            ProgramComboBox.Visibility = Visibility.Visible;
        }

        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {
            MessageLabel.Visibility = Visibility.Visible;
            MessageTextBox.Visibility = Visibility.Visible;
            ShowMessageBtn.Visibility = Visibility.Visible;
            ClearMessageBtn.Visibility = Visibility.Visible;
            DefaultMessageBtn.Visibility = Visibility.Visible;
        }

        private void ShowCB1_Unchecked(object sender, RoutedEventArgs e)
        {
            MessageLabel.Visibility = Visibility.Hidden;
            MessageTextBox.Visibility = Visibility.Hidden;
            ShowMessageBtn.Visibility = Visibility.Hidden;
            ClearMessageBtn.Visibility = Visibility.Hidden;
            DefaultMessageBtn.Visibility = Visibility.Hidden;
        }

        private void ShowCB2_Unchecked(object sender, RoutedEventArgs e)
        {

            ProgramLabel.Visibility = Visibility.Hidden;
            ProgramBtn.Visibility = Visibility.Hidden;
            ProgramComboBox.Visibility = Visibility.Hidden;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            MessageLabel.IsEnabled = false;
            MessageTextBox.IsEnabled = false;
            ShowMessageBtn.IsEnabled = false;
            ClearMessageBtn.IsEnabled = false;
            DefaultMessageBtn.IsEnabled = false;
        }

        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            ProgramLabel.IsEnabled = false;
            ProgramBtn.IsEnabled = false;
            ProgramComboBox.IsEnabled = false;
        }
    }
}