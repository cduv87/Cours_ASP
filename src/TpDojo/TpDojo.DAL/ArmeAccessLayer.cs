using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpDojo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using static TpDojo.DAL.ArmeAccessLayer;

namespace TpDojo.DAL
{
    public class ArmeAccessLayer
    {  
            private readonly TpDojoWEBContext context;

            public ArmeAccessLayer(TpDojoWEBContext context)
            {
                this.context = context;
            }

            public async Task<List<ArmeEntity>> GetAllAsync()
                => await this.context.Arme.ToListAsync();

            public async Task<bool> ExistsAsync(int id)
                => await this.context.Arme.AnyAsync(a => a.Id == id);

            public async Task<ArmeEntity?> GetByIdAsync(int? id)
            => await this.context.Arme.FirstOrDefaultAsync(a => a.Id == id);

            public async Task AddAsync(ArmeEntity arme)
            {
                this.context.Add(arme);
                await this.context.SaveChangesAsync();
            }

            public async Task UpdateAsync(ArmeEntity arme)
            {
                var armeToUpdate = await this.GetByIdAsync(arme.Id);

                if (armeToUpdate is null)
                    return;

                armeToUpdate.Nom = arme.Nom;
                armeToUpdate.Degats = arme.Degats;

                this.context.Update(armeToUpdate);
                await this.context.SaveChangesAsync();
            }

            public async Task RemoveAsync(int id)
            {
                var arme = await this.GetByIdAsync(id);
                if (arme != null)
                {
                    this.context.Arme.Remove(arme);
                }

                await this.context.SaveChangesAsync();
            }

        }
}
