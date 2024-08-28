namespace Entity.Model.Security
{
    public class RoleView
    {
        public int Id { get; set; }
       
        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public DateTime DeletedAt { get; set; }

        public bool State { get; set; }
    }
}
