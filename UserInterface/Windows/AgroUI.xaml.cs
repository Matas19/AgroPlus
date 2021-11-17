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
        public Laukas FieldForInfo { get; set; }
        public List<Darbas> _jobs { get; set; }

        public AgroUI(Vartotojas user, Engine engine)
        {
            _user = user;
            _engine = engine;
            AtnaujintiDarbuSarasa();
            InitializeComponent();
            
            introLabel.Content = $"{user.Vardas}";
            //DataContext = this;
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
        private void AtnaujintiDarbuSarasa()
        {
            _jobs = _engine.UserDatabase.GetJobs();
        }

        private void atnaujintiBtn_Click(object sender, RoutedEventArgs e)
        {
            jobsListBox.ItemsSource = null;
            AtnaujintiDarbuSarasa();
            jobsListBox.ItemsSource = _jobs;
        }

        private void PasirinktiLauka(object sender, RoutedEventArgs e)
        {
            FieldInfoUI ui = new FieldInfoUI(this, _engine);
            ui.Show();
        }
        public void AtnaujintiSarasaPagalLauka(Laukas field)
        {
            jobsListBox.ItemsSource = null;
            _jobs = _engine.UserDatabase.GetByField(field);
            jobsListBox.ItemsSource = _jobs;
        }

        private void RodytiLaisvusDarbus(object sender, RoutedEventArgs e)
        {
            jobsListBox.ItemsSource = null;
            _jobs = _engine.UserDatabase.GetFieldsByWorker(false);
            jobsListBox.ItemsSource = _jobs;
        }

        private void RodytiUzimtusDarbus(object sender, RoutedEventArgs e)
        {
            jobsListBox.ItemsSource = null;
            _jobs = _engine.UserDatabase.GetFieldsByWorker(true);
            jobsListBox.ItemsSource = _jobs;
        }
    }
}
