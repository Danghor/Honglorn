using System;
using HonglornBL.MasterData;
using HonglornBL.MasterData.Course;
using HonglornBL.Models.Entities;

namespace HonglornWPF.ViewModels
{
    class CourseListViewModel : NGListViewModel<CourseService, Course>
    {
        public CourseListViewModel(CourseService service) : base(service) { }

        protected override NGDetailViewModel<CourseService, Course> CreateDetailViewModel(CourseService service, Guid entityKey)
        {
            return new CourseDetailViewModel(service, entityKey);
        }

        public override string ToString() => "Courses";
    }
}