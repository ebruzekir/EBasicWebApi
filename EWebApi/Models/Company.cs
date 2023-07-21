namespace EWebApi.Models

    
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public virtual ICollection<Contact> contacts { get; set; }


    }
}
