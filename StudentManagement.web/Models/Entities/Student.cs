namespace StudentManagement.web.Models.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public String Course { get; set; }
    }
}
