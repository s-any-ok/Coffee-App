using CA.WPF.ViewModel;
using System.Windows;

namespace CA.WPF.View
{
    public partial class MakeOrderWindow : Window
    {
        public MakeOrderWindow()
        {
            InitializeComponent();
            DataContext = new OrderViewModel();
        }
    }
}