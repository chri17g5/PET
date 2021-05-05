using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ThePetExamn.View.CreationView
{
    /// <summary>
    /// Interaction logic for CreateAgent.xaml
    /// </summary>
    public partial class CreateAgent : Window
    {
        public CreateAgent()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Using regex to only display numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumsOnly(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        /// <summary>
        /// Using regex to only display letters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LettersOnly(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^aA-zZ]+");
        }
    }
}
