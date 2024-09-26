using Entity.Model.Security;

namespace Entity.Dto
{
    public class UserRoleDto
    {
        public int Id { get; set; }
        //role
        public int RoleId { get; set; }
        public string ? Role { get; set; }
        //user
        public int UserId { get; set; }
        public string ? User { get; set; }

        public bool State { get; set; }
    }
}
