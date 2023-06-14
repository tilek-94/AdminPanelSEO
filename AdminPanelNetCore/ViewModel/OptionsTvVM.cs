using AdminPanelNetCore.BusinessLayer.Services.AbstractServices;
using AdminPanelNetCore.Commands;
using AdminPanelNetCore.Model;
using AdminPanelNetCore.ViewModel.BaseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace AdminPanelNetCore.ViewModel
{
    public class OptionsTvVM : BaseView
    {
        private readonly IOptionsService _optionsService;
        private readonly ILangService _langService;
        private readonly ITvTablosService _tvTablosService;
        public ICommand SaveLangCommand { get; }
        public ICommand SaveTvTablosCommand { get; }
        public ICommand AddCustumerCommand { get; }
        public ICommand AddPaperSizeCommand { get; }
        private bool CommandExecute(object arg) => true;
        #region Properties

       
        private int _selectedIndex ;
        public  int SelectedIndex
        {
            get { return _selectedIndex; }
            set { Set(ref _selectedIndex, value); }
        }
        private string? _LangText=String.Empty;
        public string? LangText
        {
            get { return _LangText; }
            set { Set(ref _LangText, value); }
        }
        private TvTablosTickers? _TvTablosText;
        public TvTablosTickers? TvTablosText
        {
            get { return _TvTablosText; }
            set { Set(ref _TvTablosText, value); }
        }

        private Langs? _selectedLang;
        public Langs? SelectedLang
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

        public OptionsTvVM(IOptionsService optionsService, ILangService langService, ITvTablosService tvTablosService)
        {

            _optionsService = optionsService;
            _langService = langService;
            _tvTablosService = tvTablosService;
            SaveLangCommand = new Command(SaveLangCommandExecuted, CommandExecute);
            SaveTvTablosCommand = new Command(SelectedCallCommandExecuted, CommandExecute);
            AddCustumerCommand = new Command(AddCustumerCommandExecuted, CommandExecute);
            AddPaperSizeCommand = new Command(AddPaperSizeCommandExecuted, CommandExecute);
            LoadDataMethod();
        }

        private  void AddPaperSizeCommandExecuted(object obj)
        {
            /*var data = await _optionsService.GetFirstAsync(x => x.Key == "PaperSize");
            if (PaperSize != String.Empty && data != null)
            {
                double size = Convert.ToDouble(PaperSize) * 100;
                data.Value = size.ToString();
                await _optionsService.UpdateAsync(data.Id, data);
                PaperSizeText = PaperSize;
                PaperSize = "";
            }*/
        }

        private void AddCustumerCommandExecuted(object obj)
        {
           /* var data = await _optionsService.GetFirstAsync(x => x.Key == "CustomerCall");
            if (CustomerText != String.Empty && data != null)
            {
                data.Value = CustomerText;
                await _optionsService.UpdateAsync(data.Id, data);
                //CustomerCall = CustomerText;
                CustomerText = "";
            }*/
        }

        private async void SelectedCallCommandExecuted(object obj)
        {
            var data = await _tvTablosService.GetFirstTickersAsync();
            if (TvTablosText != null)
            {
                if (data != null)
                {
                    data.MarqueeText = TvTablosText.MarqueeText;
                    await _tvTablosService.UpdateAsync(data.Id,data);
                }
                else
                {
                    TvTablosTickers tvTablosTickers = new TvTablosTickers()
                    {
                        MarqueeText = TvTablosText.MarqueeText,
                    };
                    await _tvTablosService.AddAsync(tvTablosTickers);
                }

            }
        }

        private async void SaveLangCommandExecuted(object obj)
        {
            var data = await _optionsService.GetFirstAsync(x => x.Key == "SoundVoice");
            if (data != null && SelectedIndex >0)
            {
                
                if(SelectedIndex==2)
                data.Value = "ALL";
                else if(SelectedIndex == 3)
                data.Value = "SOUND";
                else if (SelectedIndex == 1)
                {
                    if (SelectedLang != null)
                    {
                        data.Value = SelectedLang.Locale;
                    }
                }
                   
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
            LangList = await _langService.GetAllAsync();
            var data = await _optionsService.GetFirstAsync(x=>x.Key== "SoundVoice");
            LangText=data.Value;
            TvTablosText = await _tvTablosService.GetFirstTickersAsync();
          

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

