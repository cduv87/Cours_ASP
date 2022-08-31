using System.ComponentModel.DataAnnotations.Schema;

namespace TpDojo.DAL.Models
{
    [Table("Arme")]
    public class ArmeEntity
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Degats { get; set; }
    }
}