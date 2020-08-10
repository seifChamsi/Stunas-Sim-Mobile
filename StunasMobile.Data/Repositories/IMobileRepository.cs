using System.Collections.Generic;
using System.Threading.Tasks;
using StunasMobile.Core.Utils;
using StunasMobile.Entities.Entitites;
namespace StunasMobile.Data.Repositories
{
    public interface IMobileRepository
    {
        Task<List<Mobile>> GetAllWithPagination(PaginationParams param);
        Task<List<Mobile>> GetAll();
        Task<Mobile> GetById(int id);
        Task<Mobile> Add(Mobile entity);
        Task<Mobile> Update(Mobile entity);
        Task<Mobile> Delete(Mobile entity);
        Task<Historique> CompareMobilesRecords(Mobile MobileToUpdate, Mobile mobileUpdated);
    }
}