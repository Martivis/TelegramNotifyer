using Notifyer.Data.Context.Entities;

namespace Notifyer.Data.NewsCathegoryRepository
{
    public interface INewsCathegoryRepository
    {
        Task AddAsync(NewsCathegory cathegory);
        Task<IEnumerable<NewsCathegory>> GetAllAsync();
        Task<IEnumerable<NewsCathegory>> GetByUserAsync(int id);
        Task<NewsCathegory> GetAsync(int id);
        Task UpdateAsync(NewsCathegory cathegory);
        Task DeleteAsync(int id);
    }
}