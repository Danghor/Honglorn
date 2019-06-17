﻿using HonglornBL.MasterData.Course;

namespace HonglornWPF.ViewModels
{
    class CourseListViewModel : ListViewModel<CourseManager, CourseDetailViewModel, ICourseModel>
    {
        public CourseListViewModel()
        {
            DetailViewModel = new CourseDetailViewModel(() => DetailViewIsVisible = false);

            service = Honglorn.CourseService();

            RefreshViewModel();
        }

        public override string ToString() => "Course";
    }
}