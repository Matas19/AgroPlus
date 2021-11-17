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
using ProgramosLogika.Classes;
using ProgramosLogika;
using UserInterface.Windows;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for AgroUI.xaml
    /// </summary>
    public partial class AgroUI : Window
    {
        private Vartotojas _user;
        private Engine _engine;

        public AgroUI(Vartotojas user, Engine engine)
        {
            
            InitializeComponent();
            _user = user;
            _engine = engine;
            introLabel.Content = $"{user.Vardas}";
        }

        private void PridetiLauka(object sender, RoutedEventArgs e)
        {
            AddFieldUI ui = new AddFieldUI(_engine);
            ui.Show();

        }

        private void atsijungtiBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ui = new MainWindow();
            ui.Show();
            this.Close();
        }

        private void PridetiDarba(object sender, RoutedEventArgs e)
        {
            AddJobUI ui = new AddJobUI(_engine);
            ui.Show();
        }
    }
}
