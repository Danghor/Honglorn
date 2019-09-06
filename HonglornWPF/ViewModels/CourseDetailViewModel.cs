using HonglornBL.MasterData.Course;
using HonglornBL.Models.Entities;
using System;
using System.Collections.ObjectModel;

namespace HonglornWPF.ViewModels
{
    class CourseDetailViewModel : NGDetailViewModel<CourseService, Course>
    {
        public ObservableCollection<Class> ValidClassValues { get; } = new ObservableCollection<Class>();

        public CourseDetailViewModel(CourseService service, Guid entityKey) : base(service, entityKey)
        {
            ClearAndFill(ValidClassValues, service.GetValidClasses());
        }
    }
}