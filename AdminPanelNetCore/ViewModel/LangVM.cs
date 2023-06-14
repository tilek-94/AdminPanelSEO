using AdminPanelNetCore.BusinessLayer.Services.AbstractServices;
using AdminPanelNetCore.Commands;
using AdminPanelNetCore.Model;
using AdminPanelNetCore.View.WindowViews;
using AdminPanelNetCore.ViewModel.BaseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AdminPanelNetCore.ViewModel
{
    public class LangVM : BaseView
    {
        private readonly ILangService _langService;
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
        private Langs? _selectedData;
        public Langs? SelectedData
        {
            get { return _selectedData; }
            set {

                if (value != null)
                {
                    Locale = value.Locale;
                    IsActive = value.IsActive == 1 ? "Активный" : "Скрытый";
                }
                Set(ref _selectedData, value); 
            
            }
        }

        private IEnumerable<Langs>? _langList;
        public IEnumerable<Langs>? LangList
        {
            get { return _langList; }
            set { Set(ref _langList, value); }
        }
        #endregion Properties

        public LangVM(ILangService langService)
        {
            _langService = langService;
            AddDataCommand = new Command(AddDataCommandExecuted, CommandExecute);
            DeleteCommand = new Command(DeleteCommandExecuted, CommandExecute);
            EditCommand = new Command(EditCommandExecuted, CommandExecute);
            LoadDataMethod();
        }

        private async void EditCommandExecuted(object obj)
        {
            if (SelectedData != null)
            {
                Langs langs = new Langs()
                {
                    Locale = Locale,
                    IsActive = IsActive == "Скрытый" ? 0 : 1
                };
                await _langService.UpdateAsync(SelectedData.Id, langs);
                Locale = "";
                IsActive = "";
                LoadDataMethod();
            }
        }

        private async void DeleteCommandExecuted(object obj)
        {
            if (MessageBox.Show("Вы уверено хотите удалить?", "Сообщение",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (SelectedData != null)
                {
                    await _langService.DeleteAsync(SelectedData.Id);
                    LoadDataMethod();
                }
            }
        }

        private async void LoadDataMethod()
        {
            LangList = await _langService.GetAllAsync();
        }
        private async void AddDataCommandExecuted(object obj)
        {
            if (Locale != String.Empty && IsActive != String.Empty)
            {
                Langs langs = new Langs()
                {
                    Locale = Locale,
                    IsActive = IsActive == "Скрытый" ? 0 : 1
                };
                await _langService.AddAsync(langs);
                Locale = "";
                IsActive = "";
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
