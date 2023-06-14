using AdminPanelNetCore.BusinessLayer.Services.AbstractServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelNetCore.ViewModel.Factories
{
    public class BranchesVMFactory : IElectronSystemViewModelFactory<BranchesVM>
    {
        private readonly ILangService _langService;
        private readonly IBranchService _branchService;

        public BranchesVMFactory(ILangService langService, IBranchService branchService)
        {
            _langService = langService;
            _branchService = branchService;
        }

        public BranchesVM CreateViewModel()
        {
            return new BranchesVM(_langService, _branchService);
        }
    }
}
