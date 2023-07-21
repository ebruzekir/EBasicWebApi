namespace EWebApi.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public int CompanyId { get; set; }
        public int CountryId { get; set; }  
        public virtual Company Company { get; set; }
        public virtual Country Country { get; set; }
    }
}
