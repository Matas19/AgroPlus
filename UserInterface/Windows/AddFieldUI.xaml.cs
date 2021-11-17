using ProgramosLogika;
using ProgramosLogika.Classes;
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

namespace UserInterface.Windows
{
    /// <summary>
    /// Interaction logic for AddFieldUI.xaml
    /// </summary>
    public partial class AddFieldUI : Window
    {
        private Engine _engine;
        public AddFieldUI(Engine engine)
        {
            _engine = engine;
            InitializeComponent();
        }

        private void PridetiLauka(object sender, RoutedEventArgs e)
        {
            if(fieldNameBox.Text != "" && fieldPlaceBox.Text != "")
            {
                if (!_engine.UserDatabase.CheckFieldName(fieldNameBox.Text))
                {
                    Laukas field = new Laukas(fieldNameBox.Text, fieldPlaceBox.Text, fieldDiscriptionBox.Text);
                    _engine.UserDatabase.AddField(field);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Toks lauko pavadinimas jau egzistuoja");
                }
            }
            else
            {
                MessageBox.Show("Butina užpildyti pavadinimo ir lauko vietos laukus");
            }
        }
    }
}
