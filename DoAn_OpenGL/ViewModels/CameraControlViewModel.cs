using DoAn_OpenGL.Assets;
using System;
using System.Windows.Input;

namespace DoAn_OpenGL.ViewModels
{
    public class CameraControlViewModel : BaseViewModel
    {
        #region Properties
        private const double xeye = 0;
        private const double yeye = -25.0;
        private const double zeye = 25.0;
        private const double xcenter = 0.0;
        private const double ycenter = 0.0;
        private const double zcenter = 0.0;
        private MainWindowViewModel mainVM;


        public double XEye
        {
            get { return mainVM.xEye; }
            set
            {
                mainVM.xEye = value;
                OnPropertyChanged("XEye");
            }
        }

        public double YEye
        {
            get { return mainVM.yEye; }
            set
            {
                mainVM.yEye = value;
                OnPropertyChanged("YEye");
            }
        }


        public double ZEye
        {
            get { return mainVM.zEye; }
            set
            {
                mainVM.zEye = value;
                OnPropertyChanged("ZEye");
            }
        }

        public double XCenter
        {
            get { return mainVM.xCenter; }
            set
            {
                mainVM.xCenter = value;
                OnPropertyChanged("XCenter");
            }
        }

        public double YCenter
        {
            get { return mainVM.yCenter; }
            set
            {
                mainVM.yCenter = value;
                OnPropertyChanged("YCenter");
            }
        }


        public double ZCenter
        {
            get { return mainVM.zCenter; }
            set
            {
                mainVM.zCenter = value;
                OnPropertyChanged("ZCenter");
            }
        }

        public ICommand ResetCommand { set; get; }
        #endregion
        #region Contruction
        public CameraControlViewModel(MainWindowViewModel vm)
        {
            mainVM = vm;
            ResetCommand = new RelayCommand(_ => {
                XEye = xeye;
                YEye = yeye;
                ZEye = zeye;
                XCenter = xcenter;
                YCenter = ycenter;
                ZCenter = zcenter;
            });
        }

        public void Update()
        {
            OnPropertyChanged("ZCenter");
            OnPropertyChanged("YCenter");
            OnPropertyChanged("XCenter");
            OnPropertyChanged("XEye");
            OnPropertyChanged("YEye");
            OnPropertyChanged("ZEye");
        }
        #endregion
    }
}
