using Entity.Model.Security;

namespace Entity.Dto
{
    public class UserRoleDto
    {
        public int Id { get; set; }
        private int PersonId { get; set; }
        private Person Person { get; set; }
    }
}
