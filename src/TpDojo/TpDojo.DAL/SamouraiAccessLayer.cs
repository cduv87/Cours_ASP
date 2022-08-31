using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpDojo.DAL.Models;


namespace TpDojo.DAL
{
    public class SamouraiAccessLayer
    {
        private readonly TpDojoWEBContext context;

        public SamouraiAccessLayer(TpDojoWEBContext context)
        {
            this.context = context;
        }

        public async Task<List<SamouraiEntity>> GetAllAsync()
          => await this.context.Samourai.Include(s => s.Arme).ToListAsync();

        public async Task<bool> ExistsAsync(int id)
            => await this.context.Samourai.AnyAsync(a => a.Id == id);

        public async Task<SamouraiEntity?> GetByIdAsync(int? id)
        => await this.context.Samourai.Include(s => s.Arme).FirstOrDefaultAsync(a => a.Id == id);

        public async Task AddAsync(SamouraiEntity sam)
        {
            this.context.Samourai.Add(sam);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SamouraiEntity samourai)
        {
            var samouraiToUpdate = await this.GetByIdAsync(samourai.Id);

            if (samouraiToUpdate is null)
                return;

            samouraiToUpdate.Nom = samourai.Nom;
            samouraiToUpdate.Force = samourai.Force;
            samouraiToUpdate.Arme = samourai.Arme;

            this.context.Update(samouraiToUpdate);
            await this.context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var samourai = await this.GetByIdAsync(id);
            if (samourai != null)
            {
                this.context.Samourai.Remove(samourai);
            }

            await this.context.SaveChangesAsync();
        }

    }
}
