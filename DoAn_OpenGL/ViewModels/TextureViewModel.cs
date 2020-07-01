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
                return mainVM?.SeletedGraphic;
            }
            set
            {
                mainVM.SeletedGraphic = value;
                if (value != null && value.Style == SharpGL.SceneGraph.Quadrics.DrawStyle.Fill)
                {
                    IsPanelEnable = true;
                }
                else
                {
                    IsPanelEnable = false;
                }

                OnPropertyChanged("RemoveIsEnable");
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
            set { textuteImage = value; 
                OnPropertyChanged("TextuteImage");
                OnPropertyChanged("TextureIsEnable");
            }
        }


        public bool TextureIsEnable
        {
            get { return textuteImage != null; }
        }

        public bool RemoveIsEnable
        {
            get { return SelectedGraphic?.Texture != null; }
        }

        public ICommand BrowserCommand { set; get; }
        public ICommand TextuteCommand { set; get; }
        public ICommand RemoveCommand { set; get; }
        private string texturePart;
        #endregion
        #region Contruction
        public TextureViewModel(MainWindowViewModel vm)
        {
            mainVM = vm;
            BrowserCommand = new RelayCommand(_ => {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Bitmap Image files (*.bmp) | *.bmp";
                if (openFileDialog.ShowDialog() == true)
                {
                    TextuteImage = new BitmapImage(new Uri(openFileDialog.FileName));
                    texturePart = openFileDialog.FileName;
                }
            });
            TextuteCommand = new RelayCommand(_ => {
                SelectedGraphic.Texture = new System.Drawing.Bitmap(texturePart);
                TextuteImage = null;
            });
            RemoveCommand = new RelayCommand(_ => {
                SelectedGraphic.Texture = null;
                TextuteImage = null;
            });

        }

        internal void Update()
        {
            if (SelectedGraphic != null && SelectedGraphic.Style == SharpGL.SceneGraph.Quadrics.DrawStyle.Fill)
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
