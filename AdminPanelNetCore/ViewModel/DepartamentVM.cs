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
using AdminPanelNetCore.Model.DtoModels;
using Newtonsoft.Json.Linq;
using System.Windows.Controls;

namespace AdminPanelNetCore.ViewModel
{
    public class DepartamentVM : BaseView
    {
        private readonly IPosotionService _posotionService;
        private readonly IPosService _posService;
        public ICommand AddDataCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand CheckedCommand { get; }
        private bool CommandExecute(object arg) => true;
        #region Properties
        private string? _NamePosition = String.Empty;
        public string? NamePosition
        {
            get { return _NamePosition; }
            set { Set(ref _NamePosition, value); }
        }
        private string? isActive = String.Empty;
        public string? IsActive
        {
            get { return isActive; }
            set { Set(ref isActive, value); }
        }
        private Position? _selectedData;
        public Position? SelectedData
        {
            get { return _selectedData; }
            set
            {
                if(value != null)
                {
                    _ = SelectedSeerviceAsync(value.Id);
                }
                Set(ref _selectedData, value);

            }
        }
        private PositionDto? _selectedService;
        public PositionDto? SelectedService
        {
            get { return _selectedService; }
            set
            {
                Set(ref _selectedService, value);

            }
        }

        private IEnumerable<Position>? _PositionList;
        public IEnumerable<Position>? PositionList
        {
            get { return _PositionList; }
            set { Set(ref _PositionList, value); }
        }
        private IEnumerable<PositionDto>? _PositionDtos;
        public IEnumerable<PositionDto>? PositionDtos
        {
            get { return _PositionDtos; }
            set { Set(ref _PositionDtos, value); }
        }
        #endregion Properties


        public DepartamentVM(IPosotionService posotionService, IPosService posService)
        {
            _posotionService = posotionService;
            _posService = posService;
            AddDataCommand = new Command(AddDataCommandExecuted, CommandExecute);
            DeleteCommand = new Command(DeleteCommandExecuted, CommandExecute);
            CheckedCommand = new Command(CheckedCommandExecuted, CommandExecute);
            LoadDataMethod();
        }

        private async void CheckedCommandExecuted(object obj)
        {
            CheckBox checkBox = (CheckBox)obj;
            if (checkBox.IsChecked.Value)
            {
                if (SelectedService != null && SelectedData!=null)
                {
                    PositionService positionService = new PositionService()
                    {
                        PositionId = SelectedData.Id,
                        ServiceId = SelectedService.Id
                    };
                    await _posService.AddAsync(positionService);
                }

            }
            else
            {
                if (SelectedService != null && SelectedData != null)
                {
                   var data= await _posService.GetFirstAsync(x => x.ServiceId == SelectedService.Id 
                    && x.PositionId== SelectedData.Id);
                    if (data != null)
                    {
                        await _posService.DeleteAsync(data.Id);
                    }
                }
            }
            
        }

        private async Task SelectedSeerviceAsync(int Id)
        {
            PositionDtos = await _posotionService.GetPositionServiceAsync(Id);
        }
        

        private async void DeleteCommandExecuted(object obj)
        {
            if (MessageBox.Show("Вы уверено хотите удалить?", "Сообщение",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (SelectedData != null)
                {
                    await _posotionService.DeleteAsync(SelectedData.Id);
                    LoadDataMethod();
                }
            }
        }

        private async void LoadDataMethod()
        {
            PositionList = await _posotionService.GetAllAsync();
           
        }
        private async void AddDataCommandExecuted(object obj)
        {
            if (NamePosition != String.Empty )
            {
                Position position = new Position()
                {
                    NamePosition=NamePosition
                };
                await _posotionService.AddAsync(position);
                NamePosition = "";
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
