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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ThePetExamn.View.CreationView;
using ThePetExamn.ViewModel;

namespace ThePetExamn.View
{
    /// <summary>
    /// Interaction logic for AgentsControl.xaml
    /// </summary>
    public partial class AgentsControl : UserControl
    {
        public AgentsControl()
        {
            InitializeComponent();
        }

        private void CreateBTN_Click(object sender, RoutedEventArgs e)
        {
            CreateAgent createAgent = new CreateAgent();
            createAgent.Show();
        }
    }
}
