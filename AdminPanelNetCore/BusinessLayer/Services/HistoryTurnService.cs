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
    public class HistoryTurnService : EntityBaseRepository<HistoryTurn>, IHistoryTurnService
    {
        AppDbContextFactory _contextFactory;
        public HistoryTurnService(AppDbContextFactory context) : base(context)
        {
            _contextFactory = context;
        }

        public async Task DeleteRangeAsync()
        {
            DateTime dateTime = DateTime.Now;
            dateTime = dateTime.AddMonths(3);
            using AppDbContext db = _contextFactory.CreateDbContext();
            var entity = await db.HistoryTurns.Where(x=>x.StartDate.Date> dateTime.Date).ToListAsync();
            db.HistoryTurns.RemoveRange(entity);
            await db.SaveChangesAsync();

        }
    }
}
