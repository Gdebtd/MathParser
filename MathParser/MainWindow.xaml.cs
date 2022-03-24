using System;
using System.Collections.Generic;
using System.Data;
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
using org.mariuszgromada.math.mxparser;

namespace MathParser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach(UIElement el in MainRoot.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;
            if (str == "AC")
                textLabel.Text = "";
            else if (str == "=")
            {
                //string value = new DataTable().Compute(textLabel.Text, null).ToString();
                //textLabel.Text = value;
                org.mariuszgromada.math.mxparser.Expression ex = new org.mariuszgromada.math.mxparser.Expression(textLabel.Text);
                textLabel.Text = ex.calculate().ToString();
            }
            else
                textLabel.Text += str;
        }
    }
}
