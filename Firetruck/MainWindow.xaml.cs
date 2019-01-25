using System;
using System.Collections.Generic;
using System.IO;
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

namespace Firetruck
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VM vm = new VM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void BtnReadFile_Click(object sender, RoutedEventArgs e)
        {
            vm.SelectFile();
            vm.ReadFile();
        }

        private void BtnGetRouts_Click(object sender, RoutedEventArgs e)
        {
            Graph g = new Graph(6);
            g.AddEdge(1,2);
            g.AddEdge(1,3);
            g.AddEdge(3,4);
            g.AddEdge(3,5);
            g.AddEdge(4,6);
            g.AddEdge(5,6);
            g.AddEdge(2,3);
            g.AddEdge(2,4);

            Console.Write("Depth First Traversal from vertex 2:\n");
            g.DepthFirstSearch(1);
        }
    }
}
