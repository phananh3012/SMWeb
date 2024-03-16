using SMWeb.Models;
using System.ComponentModel;

namespace SMWeb.ViewModels
{
    public class ClassroomVM
    {
        [DisplayName("Tên sinh viên")]
        public string? StudentName { get; set; }
        public Classroom Classroom { get; set; }


    }
}
