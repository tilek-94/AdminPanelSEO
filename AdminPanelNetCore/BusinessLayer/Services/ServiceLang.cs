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
    public class ServiceLang : EntityBaseRepository<ServiseLangs>, IServiceLang
    {
        private readonly AppDbContextFactory _contextFactory;
        public ServiceLang( AppDbContextFactory contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task AddRangAsync(IEnumerable<ServiseLangs> data)
        {
            using AppDbContext _context = _contextFactory.CreateDbContext();
            _context.ServiseLangs.AddRange(data);
           await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ServiceLangDto>> GetAllServiceToDtoAsync(int LangId)
        {
            using AppDbContext _context = _contextFactory.CreateDbContext();
            var result = await (from service in _context.Services
                         join serviceLang in _context.ServiseLangs.Where(x=>x.LangsId== LangId)
                         on service.Id equals serviceLang.ServiceId into joined
                         from j in joined.DefaultIfEmpty()
                         select new
                         {
                             Id = service.Id,
                             ServiceName = service.ServiceName,
                             NewService = j.Name
                         }).ToListAsync();

            var res = JsonConvert.SerializeObject(result);
            IEnumerable<ServiceLangDto> ServiceList = JsonConvert.DeserializeObject<IEnumerable<ServiceLangDto>>(res);
            return ServiceList;
        }
    }
}
