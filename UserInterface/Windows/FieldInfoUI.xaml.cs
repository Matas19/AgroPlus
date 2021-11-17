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
    /// Interaction logic for FieldInfoUI.xaml
    /// </summary>
    public partial class FieldInfoUI : Window
    {
        private Engine _engine;
        private List<Laukas> _fields;
        private AgroUI _parent;
        public FieldInfoUI(AgroUI agroUI, Engine engine)
        {
            _engine = engine;
            _parent = agroUI;
            InitializeComponent();
            ReadFields();
        }
        private void ReadFields()
        {
            _fields = _engine.UserDatabase.GetFields();
            for (int i = 0; i < _fields.Count; i++)
            {
                fieldInfoBox.Items.Insert(i, _fields[i].Pavadinimas);
            }
        }
        private void PasirinktiLauka(object sender, RoutedEventArgs e)
        {
            if (fieldInfoBox.SelectedIndex != -1)
            {
                _parent.AtnaujintiSarasaPagalLauka(_fields[fieldInfoBox.SelectedIndex]);
                this.Close();
            }
        }
    }
}
