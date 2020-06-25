using DoAn_OpenGL.Assets;
using DoAn_OpenGL.Graphics3D;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DoAn_OpenGL.ViewModels
{
    public class TextureViewModel : BaseViewModel
    {
        #region Properties
        private MainWindowViewModel mainVM;
        public ObservableCollection<Graphic3D> ListObject
        {
            get
            {
                return mainVM?.listObject;
            }
        }
        public Graphic3D SelectedGraphic
        {
            get
            {
                return mainVM?.seletedGraphic;
            }
            set
            {
                mainVM.seletedGraphic = value;
                if (value != null)
                {
                    IsPanelEnable = true;
                }
                else
                {
                    IsPanelEnable = false;
                }

            }
        }
        private bool isPanelEnable;

        public bool IsPanelEnable
        {
            get { return isPanelEnable; }
            set { isPanelEnable = value; OnPropertyChanged("IsPanelEnable"); }
        }
        private ImageSource textuteImage;

        public ImageSource TextuteImage
        {
            get { return textuteImage; }
            set { textuteImage = value; OnPropertyChanged("TextuteImage"); }
        }


        public ICommand BrowserCommand { set; get; }
        #endregion
        #region Contruction
        public TextureViewModel(MainWindowViewModel vm)
        {
            mainVM = vm;
            BrowserCommand = new RelayCommand(_ => {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if (openFileDialog.ShowDialog() == true)
                    TextuteImage = new BitmapImage(new Uri(openFileDialog.FileName));
            });
        }

        internal void Update()
        {
            if (SelectedGraphic != null)
            {
                IsPanelEnable = true;
            }
            else
            {
                IsPanelEnable = false;
            }
        }
        #endregion
    }
}
