using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Desktop_Version.Annotations;

namespace Desktop_Version.Models
{
    [Serializable]
    public class LocalSettings:INotifyPropertyChanged
    {
        private bool _isAutoSaveOn;
        private bool _isLocalSave;
        private string _remoteServerAddress;
        private bool _autoloadLastSectorFiles;
        private string _saveDir;
        private bool _rememberShipPosition;
        private string _currentSector;

        public bool IsAutoSaveOn
        {
            get => _isAutoSaveOn;
            set
            {
                if (value == _isAutoSaveOn) return;
                _isAutoSaveOn = value;
                OnPropertyChanged();
            }
        }

        public bool IsLocalSave
        {
            get => _isLocalSave;
            set
            {
                if (value == _isLocalSave) return;
                _isLocalSave = value;
                OnPropertyChanged();
            }
        }

        public string RemoteServerAddress
        {
            get => _remoteServerAddress;
            set
            {
                if (value == _remoteServerAddress) return;
                _remoteServerAddress = value;
                OnPropertyChanged();
            }
        }

        public bool AutoloadLastSectorFiles
        {
            get => _autoloadLastSectorFiles;
            set
            {
                if (value == _autoloadLastSectorFiles) return;
                _autoloadLastSectorFiles = value;
                OnPropertyChanged();
            }
        }

        public string SaveDir
        {
            get => _saveDir;
            set
            {
                if (value == _saveDir) return;
                _saveDir = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SectorDirectory));
            }
        }

        public bool RememberShipPosition
        {
            get => _rememberShipPosition;
            set
            {
                if (value == _rememberShipPosition) return;
                _rememberShipPosition = value;
                OnPropertyChanged();
            }
        }

        public string CurrentSector
        {
            get => _currentSector;
            set
            {
                if (value == _currentSector) return;
                _currentSector = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SectorDirectory));
            }
        }

        public string SectorDirectory => $"{SaveDir}\\{CurrentSector}";
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
