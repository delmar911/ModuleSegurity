using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string isoCode { get; set; }
        //moneda
        public string Currency { get; set; }
    }
}
