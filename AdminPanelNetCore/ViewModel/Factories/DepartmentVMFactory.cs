using AdminPanelNetCore.BusinessLayer.Services.AbstractServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelNetCore.ViewModel.Factories
{
    public class DepartmentVMFactory : IElectronSystemViewModelFactory<DepartamentVM>
    {
     private readonly   IPosotionService _posotionService;
     private readonly   IPosService _posService;

        public DepartmentVMFactory(IPosotionService posotionService, IPosService posService)
        {
            _posotionService = posotionService;
            _posService = posService;
        }

        public DepartamentVM CreateViewModel()
        {
            return new DepartamentVM(_posotionService, _posService);
        }
    }
}
