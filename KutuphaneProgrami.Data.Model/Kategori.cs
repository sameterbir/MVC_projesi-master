using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KutuphaneProgrami.Data.Model
{
    public class Kategori : AnaEntity
    {

        [Required]  // zorunlu kılıyoruz
        [Column(TypeName ="varchar")]
        [MaxLength(50)]
        public string Ad { get; set; }

        public virtual List<Kitap> Kitaplar { get; set; }
    }
}
