using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpDojo.DAL.Models;

namespace TpDojo.Business.DTO
{
    public class ArmeDTO

    {    public int Id { get; set; }
        public string Nom { get; set; }
        public int Degats { get; set; }

        public static ArmeDTO FromArmeEntity(ArmeEntity? arme)
       => arme is null
       ? new()
       : new ArmeDTO { Id = arme.Id, Nom = arme.Nom, Degats = arme.Degats };

        internal static List<ArmeDTO> FromArmesEntity(List<ArmeEntity> samourais)
            => samourais.Select(FromArmeEntity).ToList();

        internal static ArmeEntity ToArmeEntity(ArmeDTO arme)
            => new() { Id = arme.Id, Nom = arme.Nom, Degats = arme.Degats };

    }
}
