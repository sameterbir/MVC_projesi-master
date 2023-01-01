using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KutuphaneProgrami.Data.Model
{
    public class Yazar : AnaEntity
    {
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string YazarAdi { get; set; }

        public virtual List<Kitap> Kitaplar { get; set; }

        public static implicit operator Yazar(int v)
        {
            throw new NotImplementedException();
        }
    }
}
