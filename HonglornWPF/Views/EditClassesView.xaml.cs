using HonglornWPF.ViewModels;
using MahApps.Metro.Controls.Dialogs;

namespace HonglornWPF.Views
{
    /// <summary>
    /// Interaction logic for EditDisciplinesView.xaml
    /// </summary>
    partial class EditClassesView
    {
        public EditClassesView()
        {
            DataContext = new EditClassesViewModel(DialogCoordinator.Instance);

            InitializeComponent();
        }
    }
}