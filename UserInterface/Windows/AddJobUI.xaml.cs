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
        private List<Laukas> fields;
        
        public AddJobUI(Engine engine)
        {
            InitializeComponent();
            _engine = engine;
            ReadFields();
        }
        private void ReadFields()
        {
            fields = _engine.UserDatabase.GetFields();
            //MessageBox.Show($"{fields[1].Id} {fields[1].Pavadinimas} {fields[1].Vieta}");
            //foreach(Laukas field in fields)
            //{
            //    jobFieldBox.Items.Insert(field.Id, field.Pavadinimas);
            //}
            for(int i = 0; i<fields.Count; i++)
            {
                jobFieldBox.Items.Insert(i, fields[i].Pavadinimas);
            }
        }

        private void PridetiDarba(object sender, RoutedEventArgs e)
        {
            if (jobNameBox.Text != "" && jobDiscriptionBox.Text != ""&&jobDatePicker.SelectedDate!=null&&jobFieldBox.SelectedIndex!=-1)
            {
                Laukas selectedField = fields[jobFieldBox.SelectedIndex];
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
