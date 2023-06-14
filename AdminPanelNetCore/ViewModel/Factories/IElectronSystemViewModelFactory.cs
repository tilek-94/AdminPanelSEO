using AdminPanelNetCore.ViewModel.BaseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelNetCore.ViewModel.Factories
{
    public interface IElectronSystemViewModelFactory<T> where T : BaseView
    {
        T CreateViewModel();
    }
}
