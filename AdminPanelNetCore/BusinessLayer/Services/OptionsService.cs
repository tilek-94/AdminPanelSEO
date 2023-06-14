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
    public class OptionsService : EntityBaseRepository<OptionsTerminal>, IOptionsService
    {
        AppDbContextFactory _contextFactory;
        public OptionsService(AppDbContextFactory context) : base(context)
        {
            _contextFactory = context;
        }

        public async Task<OptionsTerminal> GetValue(string key)
        {
            using AppDbContext _context = _contextFactory.CreateDbContext();
            return await _context.Options.FirstOrDefaultAsync(x=>x.Key==key);
        }
    }
}
