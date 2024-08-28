namespace Entity.Model.Security
{
    public class Person
    {
        public int Id { get; set; }
        public  string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string TypeDocument { get; set; }

        public string Document { get; set; }

        public string BirthOfDate { get; set; }

        public string Phone { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public DateTime DeletedAt { get; set; }

        public bool State { get; set; }

    }
}
