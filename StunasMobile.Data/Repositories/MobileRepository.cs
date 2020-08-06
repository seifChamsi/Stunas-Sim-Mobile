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
            return await _context.Mobiles.ToListAsync();
        }

        public async Task<Mobile> GetById(int id)
        {
            return  _context.Mobiles.AsNoTracking().FirstOrDefault(Mb => Mb.Id == id);
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
    }
}