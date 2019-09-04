using System.Windows.Controls;
using HonglornWPF.ViewModels;

namespace HonglornWPF.Views
{
    /// <summary>
    /// Interaction logic for MasterDataView.xaml
    /// </summary>
    public partial class MasterDataView : UserControl
    {
        public MasterDataView()
        {
            InitializeComponent();
        }

        private void HandleDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ((MasterDataViewModel)DataContext).Tabs.Add(new ClassListViewModel());
        }
    }
}
