using AdminPanelNetCore.BusinessLayer.Services.AbstractServices;
using AdminPanelNetCore.EntityLayer;
using AdminPanelNetCore.EntityLayer.BaseRepository;
using AdminPanelNetCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdminPanelNetCore.BusinessLayer.Services
{
    public class BranchService : EntityBaseRepository<Branch>, IBranchService
    {
        public BranchService(AppDbContextFactory context) : base(context)
        {
        }
    }
}
