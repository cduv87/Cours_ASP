﻿using System;
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

        public async Task<SamouraiDTO> GetSamouraiByIdAsync(int? id)
        {
            var sam = await samouraiAccessLayer.GetByIdAsync(id);
            return SamouraiDTO.FromSamourai(sam);
        }

        public async Task<List<SamouraiDTO>> GetSamouraisAsync()
        {
            var samourais = await this.samouraiAccessLayer.GetAllAsync();
            return SamouraiDTO.FromSamourais(samourais);
        }


    }
}
