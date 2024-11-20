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

namespace RimeControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _pg1.SelectedObject = Ogee;
        }

        public Man Ogee = new Man { Name = "Ogee", Age = 29, Birthday = new DateTime(1993, 08, 28).Date};

    }

    public class Man
    {
        public string Name { get; set; }
        public double Age { get; set; }
        public DateTime Birthday { get; set; }
    }



}
