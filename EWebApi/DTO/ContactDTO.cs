using EWebApi.Models;

namespace EWebApi.DTO
{
    public class ContactDTO
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public int CompanyId { get; set; }
       public int CountryId { get; set; }   
    }
}
