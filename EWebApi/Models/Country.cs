namespace EWebApi.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public virtual ICollection<Contact> contacts { get; set; }
    }
}
