using TpDojo.Business.DTO;

namespace TpDojo.WEB.Models
{
    public class ArmeViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Degats { get; set; }

        internal static ArmeViewModel FromArmeDTO(ArmeDTO arme)
       => arme is null
       ? new ArmeViewModel()
       : new ArmeViewModel { Id = arme.Id, Nom = arme.Nom, Degats = arme.Degats };

        internal static List<ArmeViewModel> FromArmessDTO(List<ArmeDTO> armes)
            => armes.Select(s => FromArmeDTO(s)).ToList();

        internal static ArmeDTO ToArmeDto(ArmeViewModel armeViewModel)
    => new()
    {
        Id = armeViewModel.Id,
        Nom = armeViewModel.Nom,
        Degats = armeViewModel.Degats,
        /*ImageUrl = armeViewModel.ImageUrl,*/
    };

    }
}