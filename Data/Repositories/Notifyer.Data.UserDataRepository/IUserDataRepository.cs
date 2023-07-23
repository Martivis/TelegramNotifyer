using Notifyer.Data.Context.Entities;

namespace Notifyer.Data.UserDataRepository
{
    public interface IUserDataRepository
    {
        Task AddUserAsync(UserData userData);
        Task<IEnumerable<UserData>> GetAllUsersAsync();
        Task<UserData> GetUserAsync(int id);
        Task UpdateUserAsync(UserData userData);
        Task DeleteUserAsync(int id);
    }
}