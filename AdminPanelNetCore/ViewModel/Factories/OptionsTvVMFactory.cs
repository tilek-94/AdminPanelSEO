using AdminPanelNetCore.BusinessLayer.Services.AbstractServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelNetCore.ViewModel.Factories
{
    public class OptionsTvVMFactory : IElectronSystemViewModelFactory<OptionsTvVM>
    {
        private readonly IOptionsService _optionsService;
        private readonly ILangService _langService;
        private readonly ITvTablosService _tvTablosService;

        public OptionsTvVMFactory(IOptionsService optionsService, ILangService langService, ITvTablosService tvTablosService)
        {
            _optionsService = optionsService;
            _langService = langService;
            _tvTablosService = tvTablosService;
        }
        public OptionsTvVM CreateViewModel()
        {
            return new OptionsTvVM(_optionsService, _langService, _tvTablosService);
        }
    }
}
