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

namespace Numbers
{
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void txtNumbers_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void txtNumbers_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int num = int.Parse(txtNumbers.Text);
                if (num<0)
                {
                    throw new Exception("The number must be higher than zero");
                }
            }
            catch (Exception ex) {
            {
                if(ex is Exception)
                {

                }
            }
        }
    }
}
