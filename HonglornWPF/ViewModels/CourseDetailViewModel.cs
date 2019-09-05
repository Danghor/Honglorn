using HonglornBL.MasterData.Course;
using HonglornBL.Models.Entities;
using System;
using System.Collections.ObjectModel;

namespace HonglornWPF.ViewModels
{
    class CourseDetailViewModel : NGDetailViewModel<Course>
    {
        public ObservableCollection<Class> ValidClassValues { get; } = new ObservableCollection<Class>();

        public CourseDetailViewModel(Action cancelAction, Action acceptAction, Course entity, CourseService service) : base(cancelAction, acceptAction, entity)
        {
            ClearAndFill(ValidClassValues, service.GetValidClasses());
        }

        public override string ToString() => $"Course - {Entity.Name}";
    }
}