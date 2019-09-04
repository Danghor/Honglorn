using System.Windows.Controls;
using HonglornWPF.ViewModels;

namespace HonglornWPF.Views
{
    /// <summary>
    /// Interaction logic for MasterDataView.xaml
    /// </summary>
    public partial class MasterDataView
    {
        public MasterDataView()
        {
            InitializeComponent();
        }

        private void ListViewItem_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var listViewItem = (ListViewItem)sender;
            var viewModelInfo = (ViewModelInfo)listViewItem.DataContext;

            ((MasterDataViewModel)DataContext).Tabs.Add(viewModelInfo.CreateViewModel());
        }
    }
}
