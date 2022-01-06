using System;
using System.Collections.Generic;
using System.Linq;
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
using UserInterface.Windows;
using ProgramosLogika;
using ProgramosLogika.Classes;
using System.Data.SqlClient;



namespace UserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Engine _engine;
        public MainWindow()
        {
            InitializeComponent();
            _engine = new Engine();
            _engine.UserDatabase.OpenConnection();
        }
        //Login funkcija
        private void Prisijungti(object sender, RoutedEventArgs e)
        {
            Vartotojas user;
            user = _engine.UserDatabase.GetUser(usernameLogin.Text, passwordLogin.Password);
            if(user != null)
            {
                if (user.Pareigos.Trim() == "Darbuotojas")
                {
                    WorkerUI workerUI = new WorkerUI(user, _engine);
                    workerUI.Show();
                }
                else if (user.Pareigos == "Agronomas")
                {
                    AgroUI agroUI = new AgroUI(user, _engine);
                    agroUI.Show();
                }
                this.Close();
            }
            else
            {
                loginError.Content = "Blogas įvestas prisijungimo vardas arba slaptažodis!";
            }
        }
        //registracija
        private void Registruotis(object sender, RoutedEventArgs e)
        {
            RegForm registracija = new RegForm(this, _engine);
            loginError.Content = "";
            this.Hide();
            registracija.Show();
            
        }
        //abu metotai isvalo ismesta error'a del blogo prisijungimo, kai juose pasikeicia informacija
        private void ClearLoginError(object sender, TextChangedEventArgs e)
        {
            loginError.Content = "";
        }

        private void passwordLogin_PasswordChanged(object sender, RoutedEventArgs e)
        {
            loginError.Content = "";
        }
    }
}
