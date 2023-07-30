using Notifyer.Data.Context.Entities;

namespace Notifyer.Data.UserDataRepository
{
    public interface IUserDataRepository
    {
        Task AddAsync(UserData userData);
        Task<IEnumerable<UserData>> GetAllAsync();
        Task<IEnumerable<UserData>> GetByCathegoryAsync(string id);
        Task<UserData> GetAsync(int id);
        Task UpdateAsync(UserData userData);
        Task DeleteAsync(int id);
    }
}