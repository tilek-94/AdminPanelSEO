using AdminPanelNetCore.BusinessLayer.Services.AbstractServices;
using AdminPanelNetCore.Model;
using AdminPanelNetCore.View.WindowViews;
using AdminPanelNetCore.ViewModel.BaseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using AdminPanelNetCore.Commands;

namespace AdminPanelNetCore.ViewModel
{
    public class UsersControlVM : BaseView
    {
        private readonly IUserService _userService;
        private readonly IPosotionService _posotionService;
        public ICommand AddDataCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand EditCommand { get; }
        private bool CommandExecute(object arg) => true;
        #region Properties
        private string? locale = String.Empty;
        public string? Locale
        {
            get { return locale; }
            set { Set(ref locale, value); }
        }
        private string? isActive = String.Empty;
        public string? IsActive
        {
            get { return isActive; }
            set { Set(ref isActive, value); }
        }
        private User? _User=new User();
        public User? Users
        {
            get { return _User; }
            set { Set(ref _User, value); }
        }
        private User? _selectedUser;
        public User? SelectedUser
        {
            get { return _selectedUser; } 
            set{
                if (value != null)
                {
                    Users = value;
                }
                Set(ref _selectedUser, value); }
        }
        private Position? _selectedPosition;
        public Position? SelectedPosition
        {
            get { return _selectedPosition; }
            set { Set(ref _selectedPosition, value);}
        }

        private IEnumerable<User> _userList;
        public IEnumerable<User> UserList
        {
            get { return _userList; }
            set { Set(ref _userList, value); }
        }
        private IEnumerable<Position> _positionList;
        public IEnumerable<Position> PositionList
        {
            get { return _positionList; }
            set { Set(ref _positionList, value); }
        }
        #endregion Properties

        public UsersControlVM(IUserService userService, IPosotionService posotionService)
        {
            _userService = userService;
            _posotionService = posotionService;
            AddDataCommand = new Command(AddDataCommandExecuted, CommandExecute);
            DeleteCommand = new Command(DeleteCommandExecuted, CommandExecute);
            EditCommand = new Command(EditCommandExecuted, CommandExecute);
            LoadDataMethod();
            
        }

        private async void EditCommandExecuted(object obj)
        {
            if (SelectedUser != null && SelectedPosition!=null)
            {
                User user = new User()
                {
                    UserName = Users.UserName,
                    PositionId = SelectedPosition.Id,
                    AtWork = 0,
                    Login = Users.Login,
                    Password = Users.Password

                };
                await _userService.UpdateAsync(SelectedUser.Id, user);
                Users = new User();
                LoadDataMethod();
            }
        }

        private async void DeleteCommandExecuted(object obj)
        {
            if (MessageBox.Show("Вы уверено хотите удалить?", "Сообщение",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (SelectedUser != null)
                {
                    await _userService.DeleteAsync(SelectedUser.Id);
                    Users = new User();
                    LoadDataMethod();
                }
            }
        }

        private async void LoadDataMethod()
        {
            UserList = await _userService.GetUserWithPositionAll();
            PositionList = await _posotionService.GetAllAsync();
        }
        private async void AddDataCommandExecuted(object obj)
        {
            if (Users!=null && SelectedPosition!=null)
            {
                User user = new User()
                {
                    UserName = Users.UserName,
                    PositionId = SelectedPosition.Id,
                    AtWork =0,
                    Login=Users.Login,
                    Password=Users.Password
                    
                };
                await _userService.AddAsync(user);
                Users = new User();
                LoadDataMethod();
            }
            else
            {
                MessageOk message = new MessageOk("Заполните все поля!");
                message.Owner = Application.Current.MainWindow;
                message.ShowDialog();
            }
        }
    }
}
