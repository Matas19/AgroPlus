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
using ProgramosLogika;
using ProgramosLogika.Classes;

namespace UserInterface.Windows
{
    /// <summary>
    /// Interaction logic for AddJobUI.xaml
    /// </summary>
    public partial class AddJobUI : Window
    {
        private Engine _engine;
        private List<Laukas> _fields;
        
        public AddJobUI(Engine engine)
        {
            InitializeComponent();
            _engine = engine;
            ReadFields();
        }
        private void ReadFields()   //nuskaito esamus laukus, norint gauti juos ComboBox'e
        {
            _fields = _engine.UserDatabase.GetFields();
            for(int i = 0; i<_fields.Count; i++)
            {
                jobFieldBox.Items.Insert(i, _fields[i].Pavadinimas);
            }
        }
        private void PridetiDarba(object sender, RoutedEventArgs e)
        {
            if (jobNameBox.Text != "" && jobDiscriptionBox.Text != ""&&jobDatePicker.SelectedDate!=null&&jobFieldBox.SelectedIndex!=-1)
            {
                Laukas selectedField = _fields[jobFieldBox.SelectedIndex];
                DateTime newDate = jobDatePicker.SelectedDate ?? DateTime.Now;
                Darbas job = new Darbas(jobNameBox.Text, jobDiscriptionBox.Text, newDate, selectedField);
                _engine.UserDatabase.AddJob(job);
                this.Close();
            }
            else
            {
                MessageBox.Show("Neuzpildyti visi laukai!");
            }
        }
    }
}
