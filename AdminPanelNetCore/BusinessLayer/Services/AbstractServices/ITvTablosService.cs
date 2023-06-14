using AdminPanelNetCore.EntityLayer.BaseRepository;
using AdminPanelNetCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelNetCore.BusinessLayer.Services.AbstractServices
{
    public interface ITvTablosService : IEntityBaseRepository<TvTablosTickers>
    {
        Task<TvTablosTickers> GetFirstTickersAsync();
    }
}
