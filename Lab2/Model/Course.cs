using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Model
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }

        public string Title { get; set; }

        public int Credits {  get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
