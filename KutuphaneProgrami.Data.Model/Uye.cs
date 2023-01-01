using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KutuphaneProgrami.Data.Model
{
   public class Uye :AnaEntity
    {
        [Required]  // zorunlu kılıyoruz
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public  string Ad { get; set; }

        [Required]  
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Soyad { get; set; }

        [Required]  
        [Column(TypeName = "char")]
        [MaxLength(11),MinLength(11)]
        public string Tc { get; set; }

        [Required]  // zorunlu kılıyoruz
        [Column(TypeName = "char")]
        [MaxLength(11),MinLength(11)]
        public string Telefon { get; set; }

        [Required]
        public DateTime KayitTarihi { get; set; }

        
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Mail { get; set; }

        [Column(TypeName = "char")]
        [MaxLength(32)]
        public string Sifre { get; set; }

        
        public int Ceza { get; set; }

        
        [Column(TypeName = "char")]
        [MaxLength(1), MinLength(1)]

        public string Yetki { get; set; }

        public virtual List<OduncKitap> OduncKitaplar { get; set; } 


    }
}
