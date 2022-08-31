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

        public async Task<ArmeDTO> GetArmeByIdAsync(int? id)
        {
            var arme = await this.armeAccessLayer.GetByIdAsync(id);
            return ArmeDTO.FromArmeEntity(arme);
        }

        public async Task<List<ArmeDTO>> GetArmesAsync()
        {
            var armes = await this.armeAccessLayer.GetAllAsync();
            return ArmeDTO.FromArmesEntity(armes);
        }

        public async Task AddArmeAsync(ArmeDTO arme) => await armeAccessLayer.AddAsync(ArmeDTO.ToArmeEntity(arme));

        public async Task RemoveArmeAsync(int id)
        {
            await armeAccessLayer.RemoveAsync(id);
        }

        public async Task<bool> ArmeExistsAsync(int id)
        {
            bool status = await armeAccessLayer.ExistsAsync(id);
            return status;
        }
    }
}
