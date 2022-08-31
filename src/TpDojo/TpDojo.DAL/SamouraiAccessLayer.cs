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

        public async Task<List<ArmeEntity>> GetAllAsync()
            => await this.context.Samourai.ToListAsync();

        public async Task AddAsync(ArmeEntity sam)
        {
            this.context.Samourai.Add(sam);
            await this.context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
    => await this.context.Samourai.AnyAsync(a => a.Id == id);

        public async Task<ArmeEntity?> GetByIdAsync(int? id)
        => await this.context.Samourai.Include(s => s.Arme).FirstOrDefaultAsync(a => a.Id == id);


        public async Task UpdateAsync(ArmeEntity samourai)
        {
            var samouraiToUpdate = await this.GetByIdAsync(samourai.Id);

            if (samouraiToUpdate is null)
                return;

            samouraiToUpdate.Nom = samourai.Nom;
            samouraiToUpdate.Force = samourai.Force;

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
