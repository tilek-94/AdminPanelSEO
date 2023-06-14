using AdminPanelNetCore.BusinessLayer.Services.AbstractServices;
using AdminPanelNetCore.EntityLayer;
using AdminPanelNetCore.EntityLayer.BaseRepository;
using AdminPanelNetCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdminPanelNetCore.BusinessLayer.Services
{
    public class TurnsService : EntityBaseRepository<Turns>, ITurnsService
    {
      private readonly AppDbContextFactory _contextFactory;
        public TurnsService(AppDbContextFactory context) : base(context)
        {
            _contextFactory = context;
        }

        public async Task DeleteRangeAsync()
        {
            using AppDbContext db = _contextFactory.CreateDbContext();
            DateTime date = DateTime.Now.Date;
            IEnumerable<Turns> entity = await db.Turns.Where(x => x.CreateDate.Date < date).ToListAsync();
            db.Turns.RemoveRange(entity);
            await db.SaveChangesAsync();

        }
    }
}
