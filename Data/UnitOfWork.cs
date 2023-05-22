using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using back.Interfaces;
using DatingProject.Data;

namespace back.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IMapper _Mapper;
        public UnitOfWork(DataContext context, IMapper mapper)
        {
            _context = context;
            _Mapper = mapper;
        }
        

        public IUserRepository UserRepository => new UserRepository(_context, _Mapper);

        public IMessageRepository MessageRepository => new MessageRepository(_context, _Mapper);

        public ILikesRepository LikesRepository => new LikesRepository(_context);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}