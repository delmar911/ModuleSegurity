namespace Entity.Dto
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string TypeDocument { get; set; }

        public string Document { get; set; }

        public string BirthOfDate { get; set; }

        public string Phone { get; set; }
        public bool State { get; set; }
    }
}
