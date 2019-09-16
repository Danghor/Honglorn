using System.Windows.Controls;
using HonglornBL;
using HonglornWPF.ViewModels;

namespace HonglornWPF.Views.MasterData
{
    /// <summary>
    /// Interaction logic for StudentDetailView.xaml
    /// </summary>
    public partial class StudentDetailView : UserControl
    {
        public StudentDetailView()
        {
            InitializeComponent();

            DataContextChanged += StudentDetailView_DataContextChanged;
        }

        private void StudentDetailView_DataContextChanged(object sender,
            System.Windows.DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue is NotifyPropertyChangedInformer oldContext)
            {
                oldContext.PropertyChanged -= StudentDetailViewModel_PropertyChanged;
            }

            if (e.NewValue is NotifyPropertyChangedInformer newContext)
            {
                newContext.PropertyChanged += StudentDetailViewModel_PropertyChanged;
            }
        }

        private void StudentDetailViewModel_PropertyChanged(object sender,
            System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(StudentDetailViewModel.StudentCourseDetailViewModel))
            {
                var view = new StudentCourseDetailView
                {
                    DataContext = ((StudentDetailViewModel)sender).StudentCourseDetailViewModel
                };

                view.ShowDialog();
            }
        }
    }
}
