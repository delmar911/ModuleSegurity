
namespace Entity.Dto
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string isoCode { get; set; }
        //moneda
        public string Currency { get; set; }
        public bool State { get; set; }
    }
}
