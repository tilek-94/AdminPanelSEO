using AdminPanelNetCore.BusinessLayer.Services.AbstractServices;
using AdminPanelNetCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelNetCore.ViewModel.Factories
{
    public class UsersControlVMFactory : IElectronSystemViewModelFactory<UsersControlVM>
    {
        private readonly IUserService _userService;
        private readonly IPosotionService _posotionService;

        public UsersControlVMFactory(IUserService userService, IPosotionService posotionService)
        {
            _userService = userService;
            _posotionService = posotionService;
        }

        public UsersControlVM CreateViewModel()
        {
           return new UsersControlVM(_userService, _posotionService);
        } 
    }
}
