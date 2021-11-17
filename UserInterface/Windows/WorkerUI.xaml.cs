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


namespace UserInterface.Windows
{
    /// <summary>
    /// Interaction logic for WorkerUI.xaml
    /// </summary>
    public partial class WorkerUI : Window
    {
        private Vartotojas _user;
        private Engine _engine;
        public List<Darbas> Jobs { get; set; }
        public WorkerUI(Vartotojas user, Engine engine)
        {
            _user = user;
            _engine = engine;
            AtnaujintiManoDarbuSarasa();
            InitializeComponent();
            finishJobBtn.Visibility = Visibility.Collapsed;
            introLabel.Content=$"{user.Vardas} {user.Pavarde}";
        }
        private void Atsijungti(object sender, RoutedEventArgs e)
        {
            MainWindow ui = new MainWindow();
            ui.Show();
            this.Close();
        }
        private void AtnaujintiManoDarbuSarasa()
        {
            Jobs = _engine.UserDatabase.GetJobsByWorkerId(_user.Id);
        }
        private void RodytiManoDarbus(object sender, RoutedEventArgs e)
        {
            AtnaujintiManoDarbus();
            selectJobBtn.Visibility = Visibility.Collapsed;
            finishJobBtn.Visibility = Visibility.Visible;
            
        }
        public void AtnaujintiManoDarbus()
        {
            jobsListBox.ItemsSource = null;
            AtnaujintiManoDarbuSarasa();
            jobsListBox.ItemsSource = Jobs;
        }
        private void RodytiLaisvusDarbus(object sender, RoutedEventArgs e)
        {
            AtnaujintiLaisvusDarbus();
            selectJobBtn.Visibility = Visibility.Visible;
            finishJobBtn.Visibility = Visibility.Collapsed;
        }
        public void AtnaujintiLaisvusDarbus()
        {
            jobsListBox.ItemsSource = null;
            Jobs = _engine.UserDatabase.GetJobsByWorker(false);
            jobsListBox.ItemsSource = Jobs;
        }
        private void PasirinktiDarba(object sender, RoutedEventArgs e)
        {
            if (jobsListBox.SelectedItem is Darbas darbas)
            {
                _engine.UserDatabase.AssignJob(_user.Id, darbas.Id);
                AtnaujintiLaisvusDarbus();
            }
        }

        private void BaigtiDarba(object sender, RoutedEventArgs e)
        {
            if (jobsListBox.SelectedItem is Darbas darbas)
            {
                _engine.UserDatabase.FinishJob(darbas.Id);
                AtnaujintiManoDarbus();
            }
        }
    }
}
