using AdminPanelNetCore.BusinessLayer.Services.AbstractServices;
using AdminPanelNetCore.EntityLayer;
using AdminPanelNetCore.EntityLayer.BaseRepository;
using AdminPanelNetCore.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelNetCore.BusinessLayer.Services
{
    public class UserService : EntityBaseRepository<User>, IUserService
    {
        AppDbContextFactory _contextFactory;
        public UserService(AppDbContextFactory contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<User>> GetUserWithPositionAll()
        {
            using AppDbContext _context = _contextFactory.CreateDbContext();
            return await _context.Users.Select( x=> new User
                {
                    Id = x.Id,
                    Login=x.Login,
                    AtWork=x.AtWork,
                    Password=x.Password,
                    Position= _context.Position.FirstOrDefault(t => t.Id == x.PositionId),
                    PositionId =x.PositionId,
                    UserName=x.UserName
                }).ToListAsync();
        }
    }
}
