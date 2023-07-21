using EWebApi.Models;

namespace EWebApi.DTO
{
    public class CompanyDTO
    {
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public virtual ICollection<ContactDTO> contacts { get; set; }
    }
}

