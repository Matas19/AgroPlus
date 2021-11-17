using ProgramosLogika;
using ProgramosLogika.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for RegForm.xaml
    /// </summary>
    public partial class RegForm : Window
    {
        private MainWindow _parent;
        private Engine _engine;
        
        public RegForm(MainWindow main, Engine logika)
        {
            _engine = logika;
            _parent = main;
            _engine.UserDatabase.OpenConnection();
            InitializeComponent();
        }

        private void Registruotis(object sender, RoutedEventArgs e)
        {
            int logInResult = Functions.CheckRegFields(usernameReg.Text, vardasReg.Text, pavardeReg.Text, passwordReg.Password, rePasswordReg.Password);
            if (logInResult == 0 && ProfessionChoiseReg.SelectedItem!=null)
            {
                if (!_engine.UsernameExists(usernameReg.Text))
                {
                    Vartotojas usr = new Vartotojas(vardasReg.Text, pavardeReg.Text, ProfessionChoiseReg.Text, usernameReg.Text);
                    MessageBox.Show("Registracija sekminga!");
                    
                    _engine.UserDatabase.AddUser(usr, passwordReg.Password);
                    
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Toks vartotojo vardas jau egzistuoja!");
                }

            }
            else if(logInResult == 1 && ProfessionChoiseReg.SelectedItem != null)
            {
                MessageBox.Show("Blogai pakartotas slaptažodis!");
            }
            else
            {
                MessageBox.Show("Yra neužpildytų laukelių!");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _parent.Show();
        }
    }
}
