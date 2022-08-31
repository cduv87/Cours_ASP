using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpDojo.DAL.Models;

namespace TpDojo.Business.DTO
{
    public class SamouraiDTO
    {

        public int Id { get; set; }
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual ArmeDTO? Arme { get; set; }

        internal static SamouraiDTO FromSamourai(SamouraiEntity? samourai)
     => samourai is null
     ? new()
     : new SamouraiDTO { Id = samourai.Id, Nom = samourai.Nom, Force = samourai.Force, Arme = ArmeDTO.FromArmeEntity(samourai.Arme) };

        internal static List<SamouraiDTO> FromSamourais(List<SamouraiEntity> samourais)
            => samourais.Select(FromSamourai).ToList();

        internal static SamouraiEntity ToSamourai(SamouraiDTO samouraiDto)
            => new() { Id = samouraiDto.Id, Nom = samouraiDto.Nom, Force = samouraiDto.Force };


    }
}
