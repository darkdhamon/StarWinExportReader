using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Desktop_Version.Models;
using Desktop_Version.Properties;
using Newtonsoft.Json;

namespace Desktop_Version
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public LocalSettings LocalSettings { get; set; }
        private static string SettingsFile => "localSettings";

        private void SaveSettings()
        {
            using (var file = new FileStream(SettingsFile,FileMode.OpenOrCreate))
            {
                var writer = new JsonTextWriter(new StreamWriter(file));
                var serializer = new JsonSerializer();
                serializer.Serialize(writer,LocalSettings);
                writer.Flush();
                DataContext = LocalSettings;
            }
        }

        private void LoadSettings()
        {
            using (var file = new FileStream(SettingsFile, FileMode.Open))
            {
                var reader = new JsonTextReader(new StreamReader(file));
                var serializer = new JsonSerializer();
                LocalSettings = serializer.Deserialize<LocalSettings>(reader);
            }
        }


        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(SettingsFile))
            {
                var file = File.Create(SettingsFile);
                file.Close();
            }

            
                try
                {
                    LoadSettings();
                }
                catch (Exception)
                {
                    
                }

            if (LocalSettings == null)
            {
                LocalSettings = new LocalSettings
                {
                    AutoloadLastSectorFiles = false,
                    IsAutoSaveOn = true,
                    IsLocalSave = true,
                    RememberShipPosition = true,
                    RemoteServerAddress = "Not availible",
                    SaveDir = "Sectors\\",
                    CurrentSector = null
                };
                SaveSettings();
            }
                
                
                RefreshSectorLoadList();

            

        }

        private void RefreshSectorLoadList()
        {
            if (!Directory.Exists(LocalSettings.SaveDir))
            {
                Directory.CreateDirectory(LocalSettings.SaveDir);
            }
            var sectors = Directory.EnumerateDirectories(LocalSettings.SaveDir);
            Sectors.ItemsSource = sectors;
        }

        private void RefreshSectorFiles()
        {
            SectorTab.Header = $"Sector {LocalSettings.CurrentSector}";
        }

        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            var newSectorName = SectorName.Text;

            if (newSectorName.Length < 1)
            {
                MessageBox.Show("Must a sector name.", "Save Error", MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }

            if (Directory.Exists($"{LocalSettings.SaveDir}\\{newSectorName}"))
            {
                MessageBox.Show("Sector already exist my that name.","Save Error", MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }

            LocalSettings.CurrentSector = newSectorName;
            Directory.CreateDirectory(LocalSettings.SectorDirectory);
            MessageBox.Show($"Sector {newSectorName} Created", "Success", MessageBoxButton.OK,
                MessageBoxImage.Information);
            RefreshSectorFiles();
        }

        private void Load_OnClick(object sender, RoutedEventArgs e)
        {
            if (Sectors.SelectedItems[0] is string loadSector) LocalSettings.CurrentSector = loadSector.Split('\\').Last();
            MessageBox.Show($"Loaded {LocalSettings.CurrentSector}");
        }

        private void LoadExpander_OnExpanded(object sender, RoutedEventArgs e)
        {
            RefreshSectorLoadList();
        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            SaveSettings();
        }
    }
}
