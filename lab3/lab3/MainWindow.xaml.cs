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

namespace lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool IsMessageAvailable = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                switch (e.Key)
                {
                    case Key.M: OnMessage(null,null); break;
                    case Key.C: OnCheck(null,null); break;
                    case Key.E: OnExit(null,null); break;
                    case Key.A: OnAbout(null,null); break;
                }
                return;
            }
            switch (e.Key)
            {
                case Key.D: ToggleInsert(); break;
                case Key.S: ToggleObjectMenuItem(); break;
            }
        }

        private void ToggleInsert()
        {
            if (InsertMenuItem.Items.Count == 0)
            {
                InsertMenuItem.Items.Add(new MenuItem() { Header = "Picture" });
                InsertMenuItem.Items.Add(new MenuItem() { Header = "Object" });
                InsertMenuItem.Items.Add(new MenuItem() { Header = "Symbol" });
            }
            else
            {
                InsertMenuItem.Items.Clear();
            }
        }

        private void ToggleObjectMenuItem()
        {
            if(InsertMenuItem.Items.Count > 0)
                (InsertMenuItem.Items[1] as MenuItem)!.IsEnabled = !(InsertMenuItem.Items[1] as MenuItem)!.IsEnabled;
        }

        private void OnExit(Object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OnMessage(Object sender, EventArgs e)
        {
            if(IsMessageAvailable) 
                MessageBox.Show("Message");
            else
                MessageBox.Show("Message is not available.");
        }

        private void OnAbout(Object sender, EventArgs e)
        {
            MessageBox.Show("About");
        }

        private void OnCheck(Object sender, EventArgs e)
        {
            IsMessageAvailable = !IsMessageAvailable;
        }
    }
}