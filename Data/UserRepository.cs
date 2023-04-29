using AutoMapper;
using AutoMapper.QueryableExtensions;
using back.DTOs;
using back.Extensions;
using back.Helpers;
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
        

        public async Task<PageList<MemberDto>> GetMembersAsync(UserParams userParams)
        {
            var query = _context.Users
                        .Where(u => u.UserName != userParams.CurrentUsername)
                        .Where(u => u.Gender == userParams.Gender);
                        // .ProjectTo<MemberDto>(_mapper.ConfigurationProvider);

                        var minDob = DateOnly.FromDateTime(DateTime.Today.AddYears(-userParams.MaxAge - 1));
                        var maxDob = DateOnly.FromDateTime(DateTime.Today.AddYears(-userParams.MinAge));

                        query = query.Where(u => u.DateOfBirth >= minDob && u.DateOfBirth <= maxDob);

                        return await PageList<MemberDto>.CreateAsync(
                            query.AsNoTracking().ProjectTo<MemberDto>(_mapper.ConfigurationProvider),
                            userParams.PageNumber, userParams.PageSize);
                        
                        
           /*  return await PageList<MemberDto>.CreateAsync(query, userParams.PageNumber, userParams.PageSize); */
        }
        // var minDob = DateTime.Today.AddYears(-userParams.MaxAge - 1);
        // var maxDob = DateTime.Today.AddYears(-userParams.MinAge);



        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            // return await _context.Users.SingleOrDefaultAsync(x => x.UserName == username);
            return await _context.Users
            .Include(p => p.Photos)
            .SingleOrDefaultAsync(x => x.UserName == username);
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