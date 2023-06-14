using AdminPanelNetCore.BusinessLayer.Services.AbstractServices;
using AdminPanelNetCore.EntityLayer;
using AdminPanelNetCore.EntityLayer.BaseRepository;
using AdminPanelNetCore.Model;
using AdminPanelNetCore.Model.DtoModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelNetCore.BusinessLayer.Services
{
    public class PosotionServices : EntityBaseRepository<Position>, IPosotionService
    {
        AppDbContextFactory _contextFactory;
        public PosotionServices(AppDbContextFactory contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<PositionDto>> GetPositionServiceAsync(int PositionId)
        {
            using AppDbContext _context = _contextFactory.CreateDbContext();
            var result = await (from s in _context.Services
                         join ps in _context.PositionService.Where(x=>x.PositionId== PositionId) on s.Id equals ps.ServiceId into joined
                         from j in joined.DefaultIfEmpty()
                         orderby s.Id
                         select new
                         {
                             Id = s.Id,
                             ServiceName = s.ServiceName,
                             Flag = j.PositionId == PositionId ? true : false

                         }).ToListAsync();

            var res = JsonConvert.SerializeObject(result);
            IEnumerable<PositionDto> ServiceList = JsonConvert.DeserializeObject<IEnumerable<PositionDto>>(res);

            return ServiceList;
        }
    }
}
