using AdminPanelNetCore.BusinessLayer.Services.AbstractServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelNetCore.ViewModel.Factories
{
    public class TerminalServiceVMFactory : IElectronSystemViewModelFactory<TerminalServiceVM>
    {
        private readonly ILangService _service;
        private readonly IServiceService _serviceService;
        private readonly IAlphabetService _alphabetService;
        private readonly IServiceLang _serviceLang;

        public TerminalServiceVMFactory(ILangService service, IServiceService serviceService, IAlphabetService alphabetService, IServiceLang serviceLang)
        {
            _service = service;
            _serviceService = serviceService;
            _alphabetService = alphabetService;
            _serviceLang = serviceLang;
        }

        public TerminalServiceVM CreateViewModel()
        {
            return new TerminalServiceVM(_service, _serviceService, _alphabetService, _serviceLang);
        }


    }
}