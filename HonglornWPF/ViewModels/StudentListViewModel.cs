using HonglornBL;
using HonglornBL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HonglornWPF.ViewModels
{
    class StudentListViewModel : ListViewModel<StudentManager, StudentDetailViewModel, IStudentModel>
    {
        public StudentListViewModel()
        {
            DetailViewModel = new StudentDetailViewModel(() => DetailViewIsVisible = false);

            service = Honglorn.StudentService();

            RefreshViewModel();
        }
    }
}