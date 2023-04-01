using AutoMapper;
using AutoMapper.QueryableExtensions;
using back.DTOs;
using back.Interfaces;
using DatingProject.Data;
using DatingProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace back.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MemberDto> GetMemberAsync(string username)
        {
            return await _context.Users
            .Where(x => x.UserName == username)
            .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
            
        }
        

        public Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            // return await _context.Users.SingleOrDefaultAsync(x => x.UserName == username);
            return await _context.Users.Include(p => p.Photos).SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _context.Users.Include(p => p.Photos).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}