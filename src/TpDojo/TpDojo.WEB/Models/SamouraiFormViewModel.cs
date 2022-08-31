namespace TpDojo.Web.Models;

using System.ComponentModel.DataAnnotations;
using TpDojo.Business.DTO;

public class SamouraiFormViewModel
{
    public int Id { get; set; }

    [Required]
    public int Force { get; set; }

    [Required]
    public string Nom { get; set; } = string.Empty;

    [Display(Name = "Arme")]
    public int? ArmeId { get; set; }

    internal static SamouraiFormViewModel FromSamouraiDto(SamouraiDTO? samourai)
        => samourai is null
        ? new()
        : new SamouraiFormViewModel { Id = samourai.Id, Nom = samourai.Nom, Force = samourai.Force };

    internal static List<SamouraiFormViewModel> FromSamourais(List<SamouraiDTO> samouraiDtos)
        => samouraiDtos.Select(FromSamouraiDto).ToList();

    internal static SamouraiDTO ToSamouraiDto(SamouraiFormViewModel samouraiViewModel)
        => new() { Id = samouraiViewModel.Id, Nom = samouraiViewModel.Nom, Force = samouraiViewModel.Force };

}