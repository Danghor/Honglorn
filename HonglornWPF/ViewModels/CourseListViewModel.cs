using System;
using HonglornBL.MasterData;
using HonglornBL.MasterData.Course;
using HonglornBL.Models.Entities;

namespace HonglornWPF.ViewModels
{
    class CourseListViewModel : NGListViewModel<Course>
    {
        readonly CourseService courseService;

        protected override NGService<Course> Service => courseService;

        public CourseListViewModel()
        {
            courseService = Honglorn.CourseService();
        }

        protected override NGDetailViewModel<Course> CreateDetailViewModel(Action cancelAction, Action acceptAction, Course entity)
        {
            return new CourseDetailViewModel(cancelAction, acceptAction, entity, courseService);
        }

        public override string ToString() => "Courses";
    }
}