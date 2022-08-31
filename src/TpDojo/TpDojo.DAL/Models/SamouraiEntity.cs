using System.ComponentModel.DataAnnotations.Schema;

namespace TpDojo.DAL.Models
{
    [Table("Samourai")]
    public class SamouraiEntity
    {
        public int Id { get; set; }
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual ArmeEntity Arme { get; set; }
    }
}
