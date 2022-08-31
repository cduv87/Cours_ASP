using TpDojo.DAL.Models;
using TpDojo.Business.DTO;

namespace TpDojo.WEB.Models
{
    public class SamouraiViewModel
    {
        public int Id { get; set; }
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual ArmeViewModel Arme { get; set; }


        internal static SamouraiViewModel FromSamouraiDTO(SamouraiDTO? samourai)
       => samourai is null
       ? new()
       : new SamouraiViewModel { Id = samourai.Id, Nom = samourai.Nom, Force = samourai.Force };

        internal static List<SamouraiViewModel> FromSamouraisDTO(List<SamouraiDTO> samourais)
            => samourais.Select(s => FromSamouraiDTO(s)).ToList();
    }
}
