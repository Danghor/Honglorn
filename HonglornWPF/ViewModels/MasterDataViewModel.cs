using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HonglornWPF.ViewModels
{
    class MasterDataViewModel : ViewModel
    {
        public ObservableCollection<ViewModel> Tabs { get; } = new ObservableCollection<ViewModel>();

        public IEnumerable<ViewModelInfo> ViewModelInfos { get; } = new[]
        {
            new ViewModelInfo(() => new ClassListViewModel(), "Classes"),
            new ViewModelInfo(() => new CourseListViewModel(), "Courses"),
            new ViewModelInfo(() => new StudentListViewModel(), "Students")
        };

        private ViewModelInfo currentViewModelInfo;

        public ViewModelInfo CurrentViewModelInfo
        {
            get => currentViewModelInfo;
            set
            {
                Tabs.Add(value.CreateViewModel());
                OnPropertyChanged(out currentViewModelInfo, value);
            }
        }
    }
}