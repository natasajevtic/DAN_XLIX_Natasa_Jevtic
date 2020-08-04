using System.Windows;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for OwnerView.xaml
    /// </summary>
    public partial class OwnerView : Window
    {
        public OwnerView()
        {
            InitializeComponent();
            this.DataContext = new OwnerViewModel(this);
        }
    }
}