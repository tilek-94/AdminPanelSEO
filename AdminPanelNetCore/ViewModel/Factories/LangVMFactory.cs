using AdminPanelNetCore.BusinessLayer.Services.AbstractServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelNetCore.ViewModel.Factories
{
    public class LangVMFactory : IElectronSystemViewModelFactory<LangVM>
    {
       private readonly ILangService _service;

        public LangVMFactory(ILangService service)
        {
            _service = service;
        }

        public LangVM CreateViewModel()
        {
            return new LangVM(_service);
        }

        
    }
}
