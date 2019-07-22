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

namespace Demo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window
    {
        private double width;
        public MainView()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
            this.opRecordView.SizeChanged += (s, e) => width = this.opRecordView.ActualWidth;
        }

        private void CollapseButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.opRecordView.Visibility == Visibility.Collapsed)
            {
                (sender as Button).Content = ">";
                this.opRecordView.Visibility = Visibility.Visible;
                this.cd2.Width =width>0? new GridLength(width ): new GridLength(0.35, GridUnitType.Star);
                this.cd2.MinWidth = 100;
            }
            else
            {
                (sender as Button).Content = "<";
                this.opRecordView.Visibility = Visibility.Collapsed;
                this.cd2.Width = GridLength.Auto;
                this.cd2.MinWidth = 0;
            }
        }
    }
}
