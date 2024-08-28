namespace Entity.Model.Security
{
    public class UserRole
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public DateTime ? DeletedAt { get; set; }

        public bool State { get; set; }
        //ralacion con person
        private int PersonId { get; set; }
        private Person Person { get; set; }
    }
}
