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
using Microsoft.Extensions.Options;
using System.Windows.Controls.Primitives;

namespace AdminPanelNetCore.ViewModel
{
    public class OptionsControlVM : BaseView
    {
        private readonly IOptionsService _optionsService;
        private readonly ILangService _langService;
        public ICommand SaveLangCommand { get; }
        public ICommand SelectedCallCommand { get; }
        public ICommand AddCustumerCommand { get; }
        public ICommand AddPaperSizeCommand { get; }
        private bool CommandExecute(object arg) => true;
        #region Properties

        private bool _isCheck;
        public bool IsCheck
        {
            get { return _isCheck; }
            set { Set(ref _isCheck, value); }
        }
        private string? _stateCheck = String.Empty;
        public string? StateCheck
        {
            get { return _stateCheck; }
            set { Set(ref _stateCheck, value); }
        }
         private string? _customerCall = String.Empty;
        public string? CustomerCall
        {
            get { return _customerCall; }
            set { Set(ref _customerCall, value); }
        }
        private string? _customerText = String.Empty;
        public string? CustomerText
        {
            get { return _customerText; }
            set { Set(ref _customerText, value); }
        }

        private string? _paperSize = String.Empty;
        public string? PaperSize
        {
            get { return _paperSize; }
            set { Set(ref _paperSize, value); }
        }
        private string? _paperSizeText = String.Empty;
        public string? PaperSizeText
        {
            get { return _customerText; }
            set { Set(ref _customerText, value); }
        }



        private string? locale = String.Empty;
        public string? Locale
        {
            get { return locale; }
            set { Set(ref locale, value); }
        }

        private Langs? _selectedLang;
        public Langs? SelectedData
        {
            get { return _selectedLang; }
            set { Set(ref _selectedLang, value); }
        }

        private OptionsTerminal? _optionsTerminal;
        public OptionsTerminal? OptionsTerminals
        {
            get { return _optionsTerminal; }
            set { Set(ref _optionsTerminal, value); }
        }
        private IEnumerable<Langs>? _langList;
        public IEnumerable<Langs>? LangList
        {
            get { return _langList; }
            set { Set(ref _langList, value); }
        }
        #endregion Properties

        public OptionsControlVM(IOptionsService optionsService, ILangService langService)
        {

            _optionsService = optionsService;
            _langService = langService;
            SaveLangCommand = new Command(SaveLangCommandExecuted, CommandExecute);
            SelectedCallCommand = new Command(SelectedCallCommandExecuted, CommandExecute);
            AddCustumerCommand = new Command(AddCustumerCommandExecuted, CommandExecute);
            AddPaperSizeCommand = new Command(AddPaperSizeCommandExecuted, CommandExecute);
            LoadDataMethod();
        }

        private async void AddPaperSizeCommandExecuted(object obj)
        {
            var data = await _optionsService.GetFirstAsync(x => x.Key == "PaperSize");
            if (PaperSize != String.Empty && data != null)
            {
                double size = Convert.ToDouble(PaperSize) * 100;
                data.Value = size.ToString();
                await _optionsService.UpdateAsync(data.Id, data);
                PaperSizeText = PaperSize;
                PaperSize = "";
            }
        }

        private async void AddCustumerCommandExecuted(object obj)
        {
            var data = await _optionsService.GetFirstAsync(x => x.Key == "CustomerCall");
            if (CustomerText != String.Empty && data!=null)
            {
                data.Value = CustomerText;
                await _optionsService.UpdateAsync(data.Id, data);
                CustomerCall= CustomerText;
                CustomerText = "";
            }
        }

        private async void SelectedCallCommandExecuted(object obj)
        {
            ToggleButton toggleButton = (ToggleButton)obj;
            var data = await _optionsService.GetFirstAsync(x => x.Key == "SelectCall");
            if (data != null)
                if (toggleButton.IsChecked.Value)
                {
                    data.Value = "1";
                    StateCheck = "ON";
                    await _optionsService.UpdateAsync(data.Id, data);
                }
                else
                {
                    data.Value = "0";
                    StateCheck = "OFF";
                    await _optionsService.UpdateAsync(data.Id, data);
                }
        }

        private async void SaveLangCommandExecuted(object obj)
        {
            var data = await _optionsService.GetFirstAsync(x => x.Key == "StandartLang");
            if (data != null && SelectedData != null)
            {
                data.Value = SelectedData.Locale;
                await _optionsService.UpdateAsync(data.Id, data);
                LoadDataMethod();
            }
        }

        private  void EditCommandExecuted(object obj)
        {
            /*if (SelectedData != null)
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
            }*/
        }

        private  void DeleteCommandExecuted(object obj)
        {
            /*if (MessageBox.Show("Вы уверено хотите удалить?", "Сообщение",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (SelectedData != null)
                {
                    await _langService.DeleteAsync(SelectedData.Id);
                    LoadDataMethod();
                }
            }*/
        }

        private async void LoadDataMethod()
        {
            IEnumerable<OptionsTerminal> optionList = await _optionsService.GetAllAsync();
            LangList = await _langService.GetAllAsync();

            Locale = optionList.FirstOrDefault(x => x.Key == "StandartLang").Value;
            IsCheck = optionList.FirstOrDefault(x => x.Key == "SelectCall").Value == "1" ? true : false;
            StateCheck = IsCheck == true ? "ON" : "OFF";
            CustomerCall= optionList.FirstOrDefault(x => x.Key == "CustomerCall").Value;
            double pSize = Convert.ToDouble(optionList.FirstOrDefault(x => x.Key == "PaperSize").Value);
            PaperSizeText=(pSize/100).ToString();

        }
        private  void AddDataCommandExecuted(object obj)
        {
            /*if (Locale != String.Empty && IsActive != String.Empty)
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
            }*/
        }
    }
}

