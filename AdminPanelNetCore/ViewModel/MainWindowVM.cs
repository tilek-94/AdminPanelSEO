using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AdminPanelNetCore.Commands;
using AdminPanelNetCore.State;
using AdminPanelNetCore.ViewModel.BaseViewModel;
using AdminPanelNetCore.ViewModel.Factories;

namespace AdminPanelNetCore.ViewModel
{
    public class MainWindowVM : BaseView
    {
        private readonly IElectronSystemViewModelFactory<BranchesVM> _branchesVMFactory;
        private readonly IElectronSystemViewModelFactory<LangVM> _langVMFactory;
        private readonly IElectronSystemViewModelFactory<DepartamentVM> _departamentVMFactory;
        private readonly IElectronSystemViewModelFactory<UsersControlVM> _usersControlVMFactory;
        private readonly IElectronSystemViewModelFactory<OptionsControlVM> _optionsControlVMFactory;
        private readonly IElectronSystemViewModelFactory<OptionsTvVM> _optionsTvVMVMFactory;
        private readonly IElectronSystemViewModelFactory<TerminalServiceVM> _terminalServiceVMFactory;
        public ICommand SelectedUserControlCommand { get; }
        private bool CommandExecute(object arg) => true;
        public MainWindowVM(IElectronSystemViewModelFactory<BranchesVM> branchesVMFactory,
            IElectronSystemViewModelFactory<LangVM> langVMFactory,
            IElectronSystemViewModelFactory<DepartamentVM> departamentVMFactory,
            IElectronSystemViewModelFactory<UsersControlVM> usersControlVMFactory,
            IElectronSystemViewModelFactory<OptionsControlVM> optionsControlVMFactory,
            IElectronSystemViewModelFactory<OptionsTvVM> optionsTvVMVMFactory,
            IElectronSystemViewModelFactory<TerminalServiceVM> terminalServiceVMFactory)
        {
            _branchesVMFactory = branchesVMFactory;
            _langVMFactory = langVMFactory;
            _departamentVMFactory = departamentVMFactory;
            _usersControlVMFactory = usersControlVMFactory;
            _optionsControlVMFactory = optionsControlVMFactory;
            _optionsTvVMVMFactory = optionsTvVMVMFactory;
            _terminalServiceVMFactory = terminalServiceVMFactory;
            SelectedUserControlCommand = new Command(CreateCurrTimeCommandExecuted, CommandExecute);
            CurrentPage = _langVMFactory.CreateViewModel();
        }

        private void CreateCurrTimeCommandExecuted(object parameter)
        {
            if (parameter is ViewType viewType)
            {
                switch (viewType)
                {
                    case ViewType.Branchs:
                        CurrentPage = _branchesVMFactory.CreateViewModel();
                        break;
                    case ViewType.Lang:
                        CurrentPage = _langVMFactory.CreateViewModel();
                        break;
                    case ViewType.Department:
                        CurrentPage = _departamentVMFactory.CreateViewModel();
                        break;
                    case ViewType.UsersControl:
                        CurrentPage = _usersControlVMFactory.CreateViewModel();
                        break;
                    case ViewType.OptionControl:
                        CurrentPage = _optionsControlVMFactory.CreateViewModel();
                        break;
                    case ViewType.OptionTV:
                        CurrentPage = _optionsTvVMVMFactory.CreateViewModel();
                        break;
                    case ViewType.TerminalService:
                        CurrentPage = _terminalServiceVMFactory.CreateViewModel();
                        break;


                }

            }
        }
    }
}
