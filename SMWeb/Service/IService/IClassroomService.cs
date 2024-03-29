﻿using Microsoft.AspNetCore.Mvc.Rendering;
using SMWeb.Models;

namespace SMWeb.Service.IService
{
    public interface IClassroomService
    {
        Classroom GetClassroom(int id);
        IEnumerable<Classroom> GetBySubject(int id);
        IEnumerable<Subject> GetSubjects();
        string GetSubjectName(int id);
        string GetStudentName(int id);
        void Update(Classroom classroom);
        void UpdateFinalGrade(Classroom classroom);
        void Add(Classroom classroom);
        void Remove(int id);
        List<SelectListItem> StudentListItem();
    }
}
