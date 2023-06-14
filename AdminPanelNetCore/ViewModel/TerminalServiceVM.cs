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
using System.Windows.Controls;
using System.Windows.Data;
using Newtonsoft.Json.Linq;

namespace AdminPanelNetCore.ViewModel
{
    public class TerminalServiceVM : BaseView
    {
        private readonly ILangService _langService;
        private readonly IServiceService _serviceService;
        private readonly IAlphabetService _alphabetService;
        private readonly IServiceLang _serviceLang;
        public ICommand AddDataCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand AddLangDataCommand { get; }
        public ICommand DeleteLangDataCommand { get; }
        public ICommand EditLangDataCommand { get; }
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

        private Langs? _Lang;
        public Langs? Lang
        {
            get { return _Lang; }
            set { Set(ref _Lang, value); }
        }
        private Langs? _SelectedLang;
        public Langs? SelectedLang
        {
            get { return _SelectedLang; }
            set {
                if (value != null)
                {
                    LoadServicDataDto(value.Id);
                }
                
                Set(ref _SelectedLang, value); }
        }
        private Service? _selectedService;
        public Service? SelectedService
        {
            get { return _selectedService; }
            set { Set(ref _selectedService, value); }
        }
        private ServiceLangDto? _selectedServiceLangDto;
        public ServiceLangDto? SelectedServiceLangDto
        {
            get { return _selectedServiceLangDto; }
            set { Set(ref _selectedServiceLangDto, value); }
        }
        private ServiceDto? _SelectedDto;
        public ServiceDto? SelectedDto
        {
            get { return _SelectedDto; }
            set
            {
                if (value != null)
                {
                    EditMethod(value.Id);
                }
                Set(ref _SelectedDto, value);
            }
        }
        private Service? _addPropertiesService = new Service();
        public Service? AddPropertiesService
        {
            get { return _addPropertiesService; }
            set { Set(ref _addPropertiesService, value); }
        }


        private IEnumerable<Langs>? _langList;
        public IEnumerable<Langs>? LangList
        {
            get { return _langList; }
            set { Set(ref _langList, value); }
        }
        private IEnumerable<Alphabet>? _AlphabetList;
        public IEnumerable<Alphabet>? AlphabetList
        {
            get { return _AlphabetList; }
            set { Set(ref _AlphabetList, value); }
        }
        private IEnumerable<Service>? _ServiceList;
        public IEnumerable<Service>? ServiceList
        {
            get { return _ServiceList; }
            set { Set(ref _ServiceList, value); }
        }


        private IEnumerable<ServiceDto>? _ServiceDtoList;
        public IEnumerable<ServiceDto>? ServiceDtoList
        {
            get { return _ServiceDtoList; }
            set { Set(ref _ServiceDtoList, value); }
        }
        private IEnumerable<ServiceLangDto>? _ServiceLangDtos;
        public IEnumerable<ServiceLangDto>? ServiceLangDtos
        {
            get { return _ServiceLangDtos; }
            set { Set(ref _ServiceLangDtos, value); }
        }
        #endregion Properties

        public TerminalServiceVM(ILangService langService, IServiceService serviceService, IAlphabetService alphabetService, IServiceLang serviceLang)
        {
            _langService = langService;
            _serviceService = serviceService;
            _alphabetService = alphabetService;
            AddDataCommand = new Command(AddDataCommandExecuted, CommandExecute);
            DeleteCommand = new Command(DeleteCommandExecuted, CommandExecute);
            EditCommand = new Command(EditCommandExecuted, CommandExecute);

            AddLangDataCommand = new Command(AddLangDataCommandExecuted, CommandExecute);
            DeleteLangDataCommand = new Command(DeleteLangDataCommandExecuted, CommandExecute);
            EditLangDataCommand = new Command(EditLangDataCommandExecuted, CommandExecute);
            LoadDataMethod();
            _serviceLang = serviceLang;
        }
        private async void LoadServicDataDto(int LangId)
        {
            ServiceLangDtos = await _serviceLang.GetAllServiceToDtoAsync(LangId);
        }
        private async void EditLangDataCommandExecuted(object obj)
        {
           if(SelectedServiceLangDto != null && SelectedLang!=null)
            {
                ServiseLangs serviseLangs = await _serviceLang.GetFirstAsync(x=>x.LangsId==SelectedLang.Id 
                && x.ServiceId== SelectedServiceLangDto.Id);
                if (serviseLangs != null)
                {
                    serviseLangs.Name = SelectedServiceLangDto.NewService;
                    await _serviceLang.UpdateAsync(serviseLangs.Id, serviseLangs);
                }
                else
                {
                    ServiseLangs sl = new ServiseLangs()
                    {
                        Name= SelectedServiceLangDto.NewService,
                        ServiceId= SelectedServiceLangDto.Id,
                        LangsId= SelectedLang.Id
                    };
                    await _serviceLang.AddAsync(sl);
                }
                LoadServicDataDto(SelectedLang.Id);
            } 
        }

        private async void DeleteLangDataCommandExecuted(object obj)
        {
            if (MessageBox.Show("Вы уверено хотите удалить?", "Сообщение",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (SelectedServiceLangDto != null && SelectedLang != null)
                {
                    ServiseLangs serviseLangs = await _serviceLang.GetFirstAsync(x => x.LangsId == SelectedLang.Id
                    && x.ServiceId == SelectedServiceLangDto.Id);
                    if (serviseLangs != null)
                    {
                        await _serviceLang.DeleteAsync(serviseLangs.Id);
                    }
                    LoadServicDataDto(SelectedLang.Id);
                }
            }
        }

        private async void AddLangDataCommandExecuted(object obj)
        {
            if (SelectedLang != null)
            {
                var flag = await _serviceLang.GetFirstAsync(x=>x.LangsId==SelectedLang.Id);
                if (flag == null) { 
                List<ServiseLangs> serviseLangs = new List<ServiseLangs>();
                DataGrid dataGrid = (DataGrid)obj;
                IEnumerable<ServiceLangDto> data = (IEnumerable<ServiceLangDto>)dataGrid.ItemsSource;
                foreach (var item in data)
                {

                    serviseLangs.Add(new ServiseLangs
                    {
                        Name = item.NewService,
                        ServiceId = item.Id,
                        LangsId = SelectedLang.Id
                    });
                }
                await _serviceLang.AddRangAsync(serviseLangs);
                }
                else
                {
                    MessageOk messageOk = new MessageOk("Информация уже добавлен Вы можете только изменить!");
                    messageOk.Owner = Application.Current.MainWindow;
                    messageOk.ShowDialog();
                }
            }
            else
            {
                MessageOk messageOk = new MessageOk("Выберите язык");
                messageOk.Owner = Application.Current.MainWindow;
                messageOk.ShowDialog();
            }
            
        }

        private async void EditMethod(int Id)
        {
            AddPropertiesService = await _serviceService.GetFirstAsync(x => x.Id == Id);
        }
        private async void EditCommandExecuted(object obj)
        {
            //Добовлаеть категорию в таблицу Service
            if (SelectedService != null && AddPropertiesService != null && SelectedDto != null)
            {

                Service service = new Service()
                {
                    ServiceName = AddPropertiesService.ServiceName,
                    ParentId = SelectedService.Id,
                    Latter = AddPropertiesService.Latter,
                    isActive = AddPropertiesService.isActive,
                    Priority = AddPropertiesService.Priority
                };
                await _serviceService.UpdateAsync(SelectedDto.Id, service);


            }
            else if (SelectedService == null && AddPropertiesService != null && SelectedDto != null)
            {
                Service service = new Service()
                {
                    ServiceName = AddPropertiesService.ServiceName,
                    ParentId = 0,
                    Latter = AddPropertiesService.Latter,
                    isActive = AddPropertiesService.isActive,
                    Priority = AddPropertiesService.Priority
                };
                await _serviceService.UpdateAsync(SelectedDto.Id, service);

            }

            //Добавлает данный в таблицу ServiseLangs
            if (AddPropertiesService != null && SelectedDto != null)
            {
                Service service2 = await _serviceService.GetFirstAsync(x => x.Id == SelectedDto.Id);
                ServiseLangs serviseLang = await _serviceLang
                    .GetFirstAsync(x => x.ServiceId == service2.Id && x.LangsId == Lang.Id);
                if (service2 != null && Lang != null && serviseLang != null)
                {
                    serviseLang.Name = service2.ServiceName;
                    serviseLang.ServiceId = service2.Id;
                    await _serviceLang.UpdateAsync(serviseLang.Id, serviseLang);
                }

                AddPropertiesService.ServiceName = String.Empty;
            }
            LoadDataMethod();
        }

        private async void DeleteCommandExecuted(object obj)
        {
            if (MessageBox.Show("Вы уверено хотите удалить?", "Сообщение",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (SelectedDto != null)
                {
                    await _serviceService.DeleteAsync(SelectedDto.Id);

                    Alphabet alphabets = await _alphabetService.GetFirstAsync(x => x.Name == SelectedDto.Latter);
                    if (alphabets != null)
                    {
                        alphabets.Status = 0;
                        await _alphabetService.UpdateAsync(alphabets.Id, alphabets);
                    }
                    LoadDataMethod();
                }
            }
        }

        private async void LoadDataMethod()
        {
            AlphabetList = await _alphabetService.GetAllAsync(x => x.Status == 0);
            ServiceList = await _serviceService.GetAllAsync();
            //ServiceLangDtos = await _serviceService.GetAllServiceToDtoAsync();
            ServiceDtoList = await _serviceService.GetAllServiceAsync();
            LangList = await _langService.GetAllAsync(x=>x.Locale!="RU");
            Lang = await _langService.GetFirstAsync(x => x.Locale == "RU");
        }
        private async void AddDataCommandExecuted(object obj)
        {
            //Добовлаеть категорию в таблицу Service
            if (SelectedService != null && AddPropertiesService != null)
            {

                Service service = new Service()
                {
                    ServiceName = AddPropertiesService.ServiceName,
                    ParentId = SelectedService.Id,
                    Latter = AddPropertiesService.Latter,
                    isActive = AddPropertiesService.isActive,
                    Priority = AddPropertiesService.Priority
                };
                await _serviceService.AddAsync(service);


            }
            else if (SelectedService == null && AddPropertiesService != null)
            {
                Service service = new Service()
                {
                    ServiceName = AddPropertiesService.ServiceName,
                    ParentId = 0,
                    Latter = AddPropertiesService.Latter,
                    isActive = AddPropertiesService.isActive,
                    Priority = AddPropertiesService.Priority
                };
                await _serviceService.AddAsync(service);

            }

            //Добавлает данный в таблицу ServiseLangs
            if (AddPropertiesService != null)
            {
                Service service2 = await _serviceService.GetLastServiceAsync();
                if (service2 != null && Lang != null)
                {
                    ServiseLangs serviseLangs = new ServiseLangs()
                    {
                        Name = AddPropertiesService.ServiceName,
                        ServiceId = service2.Id,
                        LangsId = Lang.Id

                    };
                    await _serviceLang.AddAsync(serviseLangs);
                }
                if (AddPropertiesService.Latter != null)
                {
                    Alphabet alphabets = await _alphabetService.GetFirstAsync(x => x.Name == AddPropertiesService.Latter);
                    alphabets.Status = 1;
                    await _alphabetService.UpdateAsync(alphabets.Id, alphabets);

                }
                AddPropertiesService.ServiceName = String.Empty;
            }
            LoadDataMethod();

        }
    }
}