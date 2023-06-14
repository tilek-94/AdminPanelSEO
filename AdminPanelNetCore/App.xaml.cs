using AdminPanelNetCore.BusinessLayer.Services.AbstractServices;
using AdminPanelNetCore.BusinessLayer.Services;
using AdminPanelNetCore.EntityLayer;
using AdminPanelNetCore.ViewModel.Factories;
using AdminPanelNetCore.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using AdminPanelNetCore.ViewModel.Classes;

namespace AdminPanelNetCore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();
            var MyIni1 = new IniFile("Settings_IP.ini");
            var IP = MyIni1.Read("DefaultVolume");
            StaticClass.IpAddress = IP;
            Window window = new MainWindow();
            window.DataContext = serviceProvider.GetRequiredService<MainWindowVM>();
            window.Show();
        }
        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<AppDbContextFactory>();
            services.AddSingleton<IServiceService, ServiceService>();
            services.AddSingleton<ITurnsService, TurnsService>();
            services.AddSingleton<IServiceLang, ServiceLang>();
            services.AddSingleton<ILangService, LangsService>();
            services.AddSingleton<IOptionsService, OptionsService>();
            services.AddSingleton<IBranchService, BranchService>();
            services.AddSingleton<IPosotionService, PosotionServices>();
            services.AddSingleton<IPosService, PosService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<ITvTablosService, TvTablosService>();
            services.AddSingleton<IAlphabetService, AlphabetService>();

             services.AddSingleton<IElectronSystemViewModelFactory<BranchesVM>, BranchesVMFactory>();
             services.AddSingleton<IElectronSystemViewModelFactory<LangVM>, LangVMFactory>();
             services.AddSingleton<IElectronSystemViewModelFactory<DepartamentVM>, DepartmentVMFactory>();
             services.AddSingleton<IElectronSystemViewModelFactory<UsersControlVM>, UsersControlVMFactory>();
             services.AddSingleton<IElectronSystemViewModelFactory<OptionsControlVM>, OptionsControlVMFactory>();
             services.AddSingleton<IElectronSystemViewModelFactory<OptionsTvVM>, OptionsTvVMFactory>();
             services.AddSingleton<IElectronSystemViewModelFactory<TerminalServiceVM>, TerminalServiceVMFactory>();
 
            services.AddScoped<MainWindowVM>();
            return services.BuildServiceProvider();
        }
    }
}
