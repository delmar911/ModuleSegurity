namespace Entity.Model.Security
{
    public class RoleView
    {
        public int Id { get; set; }
       
        public DateTime CreateAt { get; set; }

        public DateTime ? UpdateAt { get; set; }

        public DateTime ? DeletedAt { get; set; }

        public bool State { get; set; }
        //role
        public int RoleId { get; set; }
        public Role Role { get; set; }
        //view
        public int ViewId { get; set; }
        public View View { get; set; }
    }
}
