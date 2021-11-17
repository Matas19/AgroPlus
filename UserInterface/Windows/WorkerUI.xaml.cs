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
        public WorkerUI(Vartotojas user)
        {
            _user = user;
            InitializeComponent();
            introLabel.Content=$"{user.Vardas} {user.Pavarde}";
        }

        
    }
}
