namespace WebApplicationMVC.Models.Entity
{
    public class Student
    {
        public Guid Id { get; set; } //Entity framework sets its id automatically

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool Subscribed { get; set; }
    }
}
