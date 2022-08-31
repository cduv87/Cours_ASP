using TpPizza.business.Models;

namespace TpPizza.Web.ViewModels
{
    public class PateViewModel
    {
        public int Id { get; set; }
        public string Nom
        {
            get; set;
        }

        public static PateViewModel PateToPateVM(Pate p) => new PateViewModel { Id = p.Id, Nom = p.Nom };
        public static Pate PateVMToPate(PateViewModel pvm) => new Pate { Id = pvm.Id, Nom = pvm.Nom };

    }
}
