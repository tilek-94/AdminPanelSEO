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
    public interface IPosotionService: IEntityBaseRepository<Position>
    {
        Task<IEnumerable<PositionDto>> GetPositionServiceAsync(int PositionId);
    }
}
