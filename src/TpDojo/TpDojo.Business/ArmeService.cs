using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpDojo.Business.DTO;
using TpDojo.DAL;

namespace TpDojo.Business
{
    public class ArmeService
    {

        private readonly ArmeAccessLayer armeAccessLayer;

        public ArmeService(ArmeAccessLayer armeAccessLayer)
        {
            this.armeAccessLayer = armeAccessLayer;
        }

        public async Task<List<ArmeDTO>> GetArmeAsync()
        {
            var samourais = await this.armeAccessLayer.GetAllAsync();
            return ArmeDTO.FromArmesEntity(samourais);
        }

    }
}
