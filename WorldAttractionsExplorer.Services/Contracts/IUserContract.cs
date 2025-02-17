using WorldAttractionsExplorer.DataAccess.DTOs;

namespace WorldAttractionsExplorer.Services.Contracts
{
    public interface IUserContract
    {
        public Task<bool> RegisterUserAsync(RegisterModel model);

        public Task<string?> LoginUserAsync(LoginModel model);

        public Task<bool> AddRoleToUserAsync(AssignModel assignModel);
    }
}
