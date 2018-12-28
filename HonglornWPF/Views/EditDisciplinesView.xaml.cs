using HonglornWPF.ViewModels;
using MahApps.Metro.Controls.Dialogs;

namespace HonglornWPF.Views
{
    /// <summary>
    /// Interaction logic for EditDisciplinesView.xaml
    /// </summary>
    partial class EditDisciplinesView
    {
        public EditDisciplinesView()
        {
            DataContext = new EditDisciplinesViewModel(DialogCoordinator.Instance);

            InitializeComponent();
        }
    }
}