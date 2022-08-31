using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpDojo.Business.DTO;
using TpDojo.DAL;


namespace TpDojo.Business
{
    public class SamouraiService
    {
        private readonly SamouraiAccessLayer samouraiAccessLayer;

            public SamouraiService(SamouraiAccessLayer samouraiAccessLayer)
            {
            this.samouraiAccessLayer = samouraiAccessLayer;
            }

        public async Task<List<ArmeDTO>> GetSamouraisAsync()
        {
            var samourais = await this.samouraiAccessLayer.GetAllAsync();
            return ArmeDTO.FromSamourais(samourais);
        }


    }
}
