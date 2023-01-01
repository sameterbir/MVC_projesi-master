using System.ComponentModel.DataAnnotations;

namespace KutuphaneProgrami.Data.Model
{
    public abstract class AnaEntity
    {

        [Key]
        public int Id { get; set; }
    }
}
