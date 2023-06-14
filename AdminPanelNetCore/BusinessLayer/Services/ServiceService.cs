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
    public class ServiceService : EntityBaseRepository<Service>, IServiceService
    {
        private readonly AppDbContextFactory _contextFactory;
        public ServiceService(AppDbContextFactory context) : base(context)
        {
            _contextFactory = context;
        }

        public async Task<IEnumerable<ServiceDto>> GetAllServiceAsync()
        {
            using AppDbContext _context = _contextFactory.CreateDbContext();
            var result = await( from s in _context.Services 
                         join s1 in _context.Services on s.ParentId equals s1.Id into joined
                         from j in joined.DefaultIfEmpty()
                         join s2 in _context.Services on j.ParentId equals s2.Id into joined2
                         from j2 in joined2.DefaultIfEmpty()
                         join s3 in _context.Services on j2.ParentId equals s3.Id into joined3
                         from j3 in joined3.DefaultIfEmpty()
                         select new
                         {
                             Id = s.Id,
                             Latter=s.Latter,
                             Colum = s.ServiceName,
                             Colum1 = j.ServiceName,
                             Colum2 = j2.ServiceName,
                             Colum3 = j3.ServiceName,
                         }).ToListAsync();
            var res = JsonConvert.SerializeObject(result);
            IEnumerable<ServiceDto> ServiceList = JsonConvert.DeserializeObject<IEnumerable<ServiceDto>>(res);

            return ServiceList;
        }

        public async Task<IEnumerable<ServiceLangDto>> GetAllServiceToDtoAsync()
        {
            using AppDbContext _context = _contextFactory.CreateDbContext();
            var result = await _context.Services
                .Select(x => new { Id=x.Id, ServiceName = x.ServiceName  }).ToListAsync();
            var res = JsonConvert.SerializeObject(result);
            IEnumerable<ServiceLangDto> ServiceList = JsonConvert.DeserializeObject<IEnumerable<ServiceLangDto>>(res);
            return ServiceList;
        }

        public async Task<Service> GetLastServiceAsync()
        {
            using AppDbContext _context = _contextFactory.CreateDbContext();
            Service service = await _context.Services.OrderBy(x => x.Id).LastOrDefaultAsync();
            return service;
        }

        
    }
}
