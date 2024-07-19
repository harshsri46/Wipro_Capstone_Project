using loginAuth.Data;
using loginAuth.DTO;
using loginAuth.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace loginAuth.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return null;
            }

            return new UserDTO
            {
                Id = user.Id.ToString(), // Convert int to string if DTO expects string
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role?.Name // Ensure Role is not null
            };
        }

        public async Task<UserDTO> CreateUserAsync(CreateUserDTO createUserDto)
        {
            var role = await _context.Roles
                .FirstOrDefaultAsync(r => r.Name == createUserDto.Role);

            if (role == null)
            {
                // Handle the case where the role does not exist
                return null;
            }

            var newUser = new User
            {
                Email = createUserDto.Email,
                Password = createUserDto.Password,
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                RoleId = role.Id // Assign RoleId based on the Role entity
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return new UserDTO
            {
                Id = newUser.Id.ToString(), // Convert int to string if DTO expects string
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                Role = role.Name // Return the role name for the DTO
            };
        }

        public async Task<bool> UpdateUserAsync(int id, UpdateUserDTO updateUserDto)
        {
            var existingUser = await _context.Users
                .Include(u => u.Role) // Include Role if needed
                .FirstOrDefaultAsync(u => u.Id == id);

            if (existingUser == null)
            {
                return false;
            }

            existingUser.FirstName = updateUserDto.FirstName;
            existingUser.LastName = updateUserDto.LastName;
            existingUser.Email = updateUserDto.Email;

            var role = await _context.Roles
                .FirstOrDefaultAsync(r => r.Name == updateUserDto.Role);

            if (role == null)
            {
                // Handle the case where the role does not exist
                return false;
            }

            existingUser.RoleId = role.Id; // Update RoleId based on the Role entity

            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}




