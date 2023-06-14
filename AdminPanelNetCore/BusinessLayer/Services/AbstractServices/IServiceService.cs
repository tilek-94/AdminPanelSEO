using AdminPanelNetCore.EntityLayer.BaseRepository;
using AdminPanelNetCore.Model;
using AdminPanelNetCore.Model.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelNetCore.BusinessLayer.Services.AbstractServices
{
    public interface IServiceService : IEntityBaseRepository<Service>
    {
        //Task<IEnumerable<object>> GetServiceByLangAsync(int langId, int parenId);
        Task<Service> GetLastServiceAsync();
        Task<IEnumerable<ServiceDto>> GetAllServiceAsync();
        Task<IEnumerable<ServiceLangDto>> GetAllServiceToDtoAsync();
    }
}
