using System;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Win32;
using ShadeGameLevelEditor.Models;
using ShadeGameLevelEditor.Utils;

namespace ShadeGameLevelEditor.ViewModel
{
    public class EditorViewModel : ViewModelBase
    {
        #region Fields

        private LevelViewModel _levelViewModel;
        private RelayCommand _openLevelCommand, _saveLevelCommand, _createNewCommand;
        private double _zoomLevel;
        private const double _zoomScale = .5;
        private const double _maxZoom = 10.0;
        #endregion

        #region Properties
        public string LevelBackgroundImageSource
        {
            get
            {
                if (_levelViewModel != null)
                {
                   return _levelViewModel.LevelBackground;
                }

                return String.Empty;
            }
            set
            {
                _levelViewModel.LevelBackground = value;
                OnPropertyChanged();
            }
        }

        public string LevelForegroundImageSource
        {
            get 
            {
                if (_levelViewModel != null)
                {
                  return  _levelViewModel.LevelForeground;
                }
                return string.Empty;
            }
            set
            {
                _levelViewModel.LevelForeground = value;
                OnPropertyChanged();
            }
        }

        public double ZoomLevel
        {
            get { return _zoomLevel; }
            set
            {
                _zoomLevel = value;
                OnPropertyChanged();
            }
        }

        public LevelViewModel LevelViewModel
        {
            get { return _levelViewModel; }
            set { SetAndNotify(ref _levelViewModel, value);}
        }

        public RelayCommand OpenCommand
        {
            get { return _openLevelCommand ?? (_openLevelCommand = new RelayCommand(Open)); }
        }

        public RelayCommand SaveCommand
        {
            get { return _saveLevelCommand ?? (_saveLevelCommand = new RelayCommand(Save, CanSave)); }
        }

        public RelayCommand CreateNewLevelCommand
        {
            get { return _createNewCommand ?? (_createNewCommand = new RelayCommand(CreateNewLevel)); }
        }

        #endregion

        #region Constructor

        public EditorViewModel()
        {
            _zoomLevel = 1;
        }

        #endregion

        #region Methods

        public void Open(object obj)
        {
           OpenFileDialog fileDlg = new OpenFileDialog();
           fileDlg.Title = "Select Level File";
           fileDlg.Filter = "Level files (*.lvl) | *.lvl";
           var gotFile = fileDlg.ShowDialog();

            if (gotFile != null && gotFile.Value)
            {
                var filePath = fileDlg.FileName;
                XmlSerializer serializer = new XmlSerializer(typeof(Level));
                FileStream fs = new FileStream(filePath,FileMode.Open);
                Level level = null;
                level = (Level)serializer.Deserialize(fs);
                if (level != null)
                {
                    LevelViewModel = new LevelViewModel(level);
                    OnPropertyChanged("LevelBackgroundImageSource");
                    OnPropertyChanged("LevelForegroundImageSource");
                }
            }
        }

        public void Save(object obj)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Title = "Save Level";
            saveDlg.Filter = "Level files (*.lvl) | *.lvl";
            var gotDirectory = saveDlg.ShowDialog();
            if (gotDirectory != null && gotDirectory.Value)
            {
                var saveFile = saveDlg.FileName;
                XmlSerializer serializer = new XmlSerializer(typeof(Level));
                TextWriter writer = new StreamWriter(saveFile);
                serializer.Serialize(writer,LevelViewModel.CurrentLevel);
                writer.Close();
            }
        }

        public void Zoom(int direction)
        {
            if (direction > 0 && _zoomLevel < _maxZoom)
            {
                ZoomLevel += _zoomScale;
            }
            else if (_zoomLevel > 1)
            {
                ZoomLevel -= _zoomScale;
            }
        }

        public void CreateNewLevel(object obj)
        {
           OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.Title = "Select Level Background";
            fileDlg.Filter = "PNG Image files (*.png) | *.png";
           var gotFile = fileDlg.ShowDialog();

            if (gotFile != null && gotFile.Value)
            {
                var bgImage = fileDlg.FileName;

                OpenFileDialog foreDlg = new OpenFileDialog();
                foreDlg.Title = "Select Level Foreground";
                foreDlg.Filter = "PNG Image files (*.png) | *.png";
                var gotFore = foreDlg.ShowDialog();

                if (gotFore != null && gotFore.HasValue)
                {
                    var fgImage = foreDlg.FileName;
                    LevelViewModel = new LevelViewModel(bgImage,fgImage);
                    OnPropertyChanged("LevelBackgroundImageSource");
                    OnPropertyChanged("LevelForegroundImageSource");
                }


            }
        }

        private bool CanSave(object obj)
        {
            return _levelViewModel != null;
        }

        public void AddNewPlatform(double x, double y, double width, double height)
        {
            _levelViewModel.BuildNewLevelPlatform(x,y,width,height);
        }

        #endregion

        #region Events

        #endregion
    }
}