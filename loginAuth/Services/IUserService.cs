using loginAuth.DTO;

namespace loginAuth.Services
{
    public interface IUserService
    {
        
        
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<UserDTO> CreateUserAsync(CreateUserDTO createUserDto);
        Task<bool> UpdateUserAsync(int id, UpdateUserDTO updateUserDto);
    }
}
