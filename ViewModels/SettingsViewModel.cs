using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using BlackHawk.Models.Entities;
using BlackHawk.Services.Database;

namespace BlackHawk.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private UserSettings _userSettings;
        private readonly DatabaseService _databaseService;

        public UserSettings UserSettings
        {
            get => _userSettings;
            set => SetProperty(ref _userSettings, value);
        }

        public Command SaveSettingsCommand { get; }
        public Command LoadSettingsCommand { get; }

        public SettingsViewModel()
        {
            _databaseService = new DatabaseService();
            SaveSettingsCommand = new Command(async () => await ExecuteSaveSettings());
            LoadSettingsCommand = new Command(async () => await ExecuteLoadSettings());

            Title = "Ayarlar";
        }

        private async Task ExecuteLoadSettings()
        {
            UserSettings = await _databaseService.GetSettingsAsync();
        }

        private async Task ExecuteSaveSettings()
        {
            IsBusy = true;

            try
            {
                await _databaseService.UpdateSettingsAsync(UserSettings);
                Message = "Ayarlar kaydedildi";
            }
            catch (Exception ex)
            {
                Message = $"Hata: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
