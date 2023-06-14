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
    public class TvTablosService : EntityBaseRepository<TvTablosTickers>, ITvTablosService
    {
       private readonly AppDbContextFactory _contextFactory;
        public TvTablosService(AppDbContextFactory contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<TvTablosTickers> GetFirstTickersAsync()
        {
            using AppDbContext db = _contextFactory.CreateDbContext();
            return await db.TvTablosTickers.FirstOrDefaultAsync();
        }
    }
}
