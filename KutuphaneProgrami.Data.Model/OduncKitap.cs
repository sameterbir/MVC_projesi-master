using System;
using System.ComponentModel.DataAnnotations;

namespace KutuphaneProgrami.Data.Model
{
    public class OduncKitap : AnaEntity
    {
        [Required]
        public int KitapId { get; set; }
        [Required]
        public int UyeId { get; set; }
        [Required]
        public DateTime AlisTarihi { get; set; }
        [Required]
        public DateTime GetirecegiTarih { get; set; }

        public DateTime? GetirdigiTarih { get; set; }

        public virtual Uye Uye { get; set; }

        public virtual Kitap Kitap { get; set; }
    }
}
