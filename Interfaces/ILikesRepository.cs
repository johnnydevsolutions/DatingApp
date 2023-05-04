using back.DTOs;
using back.Entities;
using back.Helpers;
using DatingProject.Entities;

namespace back.Interfaces
{
    public interface ILikesRepository
    {
        Task<UserLike> GetUserLike(int sourceUserId, int TargetUserId);
        Task<AppUser> GetUserWithLikes(int userId);
        Task<PageList<LikeDto>> GetUserLikes(LikesParams likesParams);
    }
}