using AdminPanelNetCore.BusinessLayer.Services.AbstractServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelNetCore.ViewModel.Factories
{
    public class OptionsControlVMFactory : IElectronSystemViewModelFactory<OptionsControlVM>
    {
        private readonly IOptionsService _optionsService;
        private readonly ILangService _langService;

        public OptionsControlVMFactory(IOptionsService optionsService, ILangService langService)
        {
            _optionsService = optionsService;
            _langService = langService;
        }

        public OptionsControlVM CreateViewModel()
        {
            return new OptionsControlVM(_optionsService, _langService);
        }
    }
}
