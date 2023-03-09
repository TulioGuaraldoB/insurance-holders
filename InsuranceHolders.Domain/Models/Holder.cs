using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceHolders.Domain.Models
{
    public class Holder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DocumentCode { get; set; }
    }
}