using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StunasMobile.Core.Utils;
using StunasMobile.Data.DbContext;
using StunasMobile.Entities.Entitites;

namespace StunasMobile.Data.Repositories
{
    public class MobileRepository : IMobileRepository
    {
        private readonly StunasDBContext _context;


        public MobileRepository(StunasDBContext context)
        {
            _context = context;
        }

        public async Task<List<Mobile>> GetAllWithPagination(PaginationParams param)
        {
            return await _context.Mobiles.OrderBy(on=>on.Montant)
                .Skip((param.PageNumber-1)*param.PageSize)
                .Take(param.PageSize).ToListAsync();
        }

        public async Task<List<Mobile>> GetAll()
        {
            return await _context.Mobiles.Include(m=>m.Historiques).ToListAsync();
        }

        public async Task<Mobile> GetById(int id)
        {
            return  _context.Mobiles.AsNoTracking().Include(m=>m.Historiques).FirstOrDefault(Mb => Mb.Id == id);
        }

        public async Task<Mobile> Add(Mobile entity)
        {
             _context.Mobiles.Add(entity);
             await _context.SaveChangesAsync();
             return entity;
        }

        public async Task<Mobile> Update(Mobile entity)
        {
            
            _context.Mobiles.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Mobile> Delete(Mobile entity)
        {
            _context.Mobiles.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Historique> CompareMobilesRecords(Mobile MobileToUpdate, Mobile mobileUpdated)
        {
            Historique newHistoryRecord = new Historique();
            List<string> changedColumnsList = new List<string>();
            List<string> newValuesList = new List<string>();
            List<string> oldValuesList = new List<string>();
            
            
            if (MobileToUpdate.Codeclient != mobileUpdated.Codeclient)
            {
                changedColumnsList.Add("Code Client");
                oldValuesList.Add(MobileToUpdate.Codeclient);
                newValuesList.Add(mobileUpdated.Codeclient);
            }
            
            if (MobileToUpdate.Forfait != mobileUpdated.Forfait)
            {
                changedColumnsList.Add("Forfait");
                oldValuesList.Add(MobileToUpdate.Forfait);
                newValuesList.Add(mobileUpdated.Forfait);
            }
            
            if (MobileToUpdate.Data != mobileUpdated.Data)
            {
                changedColumnsList.Add("Data");
                oldValuesList.Add(MobileToUpdate.Data);
                newValuesList.Add(mobileUpdated.Data);
            }
            
            if (MobileToUpdate.Montant != mobileUpdated.Montant)
            {
                changedColumnsList.Add("Montant");
                oldValuesList.Add(MobileToUpdate.Montant);
                newValuesList.Add(mobileUpdated.Montant);
            }
            
            if (MobileToUpdate.Handset != mobileUpdated.Handset)
            {
                changedColumnsList.Add("Handset");
                oldValuesList.Add(MobileToUpdate.Handset);
                newValuesList.Add(mobileUpdated.Handset);
            }
            
            if (MobileToUpdate.Nom != mobileUpdated.Nom)
            {
                changedColumnsList.Add("Nom");
                oldValuesList.Add(MobileToUpdate.Nom);
                newValuesList.Add(mobileUpdated.Nom);
            }
            
            if (MobileToUpdate.Societe != mobileUpdated.Societe)
            {
                changedColumnsList.Add("Societe");
                oldValuesList.Add(MobileToUpdate.Societe);
                newValuesList.Add(mobileUpdated.Societe);
            }
            
            if (MobileToUpdate.Site != mobileUpdated.Site)
            {
                changedColumnsList.Add("Site");
                oldValuesList.Add(MobileToUpdate.Site);
                newValuesList.Add(mobileUpdated.Site);
            }
            
            if (MobileToUpdate.Prixhandset != mobileUpdated.Prixhandset)
            {
                changedColumnsList.Add("Prixhandset");
                oldValuesList.Add(MobileToUpdate.Prixhandset);
                newValuesList.Add(mobileUpdated.Prixhandset);
            }

            newHistoryRecord.ChangedColumns = changedColumnsList;
            newHistoryRecord.PreviousValues = oldValuesList;
            newHistoryRecord.NewValues = newValuesList;
            newHistoryRecord.CreatedAt = DateTime.Now;

            return newHistoryRecord;
        }
    }
}
