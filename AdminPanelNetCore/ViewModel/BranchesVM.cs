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
using AdminPanelNetCore.View.Pages;

namespace AdminPanelNetCore.ViewModel
{
    public class BranchesVM : BaseView
    {
        
        private readonly ILangService _langService;
        private readonly IBranchService _branchService;
        public ICommand AddDataCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand EditCommand { get; }
        private bool CommandExecute(object arg) => true;
        #region Properties
        private Branch? _branchs=new Branch();
        public Branch? Branchs
        {
            get { return _branchs; }
            set { Set(ref _branchs, value); }
        }
       
        private Langs? _selectedData;
        public Langs? SelectedData
        {
            get { return _selectedData; }
            set
            {
                Set(ref _selectedData, value);

            }
        }
        private Branch? _selectedBranch;
        public Branch? SelectedBranch
        {
            get { return _selectedBranch; }
            set
            {
                if (value != null)
                {
                    Branchs = value;
                    
                }
                Set(ref _selectedBranch, value);

            }
        }

        private IEnumerable<Langs> _langList;
        public IEnumerable<Langs> LangList
        {
            get { return _langList; }
            set { Set(ref _langList, value); }
        }
        private IEnumerable<Branch> _branchsList;
        public IEnumerable<Branch> BranchsList
        {
            get { return _branchsList; }
            set { Set(ref _branchsList, value); }
        }
        #endregion Properties

        public BranchesVM(ILangService langService, IBranchService branchService)
        {
            _langService = langService;
            _branchService = branchService;
            AddDataCommand = new Command(AddDataCommandExecuted, CommandExecute);
            DeleteCommand = new Command(DeleteCommandExecuted, CommandExecute);
            EditCommand = new Command(EditCommandExecuted, CommandExecute);
            LoadDataMethod();
        }

        private async void EditCommandExecuted(object obj)
        {
            if (SelectedBranch != null && SelectedData!=null)
            {
                Branch branch = new Branch()
                {
                    NameBranch = Branchs.NameBranch,
                    Address = Branchs.Address,
                    LangsId = SelectedData.Id
                };
                await _branchService.UpdateAsync(SelectedBranch.Id, branch);
                Branchs = new Branch();
                
                LoadDataMethod();
            }
        }

        private async void DeleteCommandExecuted(object obj)
        {
            if (MessageBox.Show("Вы уверено хотите удалить?", "Сообщение",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (SelectedBranch != null)
                {
                    await _branchService.DeleteAsync(SelectedBranch.Id);
                    LoadDataMethod();
                }
            }
        }

        private async void LoadDataMethod()
        {
            LangList = await _langService.GetAllAsync();
            BranchsList = await _branchService.GetAllAsync(x=>x.langs);
        }
        private async void AddDataCommandExecuted(object obj)
        {
            
            if (Branchs.NameBranch != String.Empty && Branchs.Address != String.Empty && SelectedData!=null)
            {
                Branch branch = new Branch()
                {
                    NameBranch= Branchs.NameBranch,
                    Address=Branchs.Address,
                    LangsId=SelectedData.Id
                };
                await _branchService.AddAsync(branch);
                Branchs = new Branch();
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

 