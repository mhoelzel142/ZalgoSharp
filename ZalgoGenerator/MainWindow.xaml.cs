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

namespace ZalgoGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random rand;
        private string text;
        public MainWindow()
        {
            rand = new Random();

            InitializeComponent();
        }

        private void TestingText_KeyDown(object sender, KeyEventArgs e)
        {
            var lastchar = e.Key.ToString().First();


        }

        private void ZalgoGenerate_Click(object sender, RoutedEventArgs e)
        {
            text = ZalgoEntry.Text;
            TestingText.Text = ZalgoHelper.ToZalgo(text);
        }

        private void ZalgoCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(TestingText.Text);
        }
    }
}
