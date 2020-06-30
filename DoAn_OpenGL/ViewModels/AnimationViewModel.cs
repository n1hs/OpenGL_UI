using DoAn_OpenGL.Assets;
using DoAn_OpenGL.Graphics3D;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DoAn_OpenGL.ViewModels
{
    public class AnimationViewModel:BaseViewModel
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
                if (value != null)
                {
                    IsPanelEnable = true;
                }
                else
                {
                    IsPanelEnable = false;
                }
                OnPropertyChanged("ATNone");
                OnPropertyChanged("ATOx");
                OnPropertyChanged("ATOy");
                OnPropertyChanged("ARNone");
                OnPropertyChanged("AROx");
                OnPropertyChanged("AROy");
                OnPropertyChanged("AROz");

            }
        }
        private bool isPanelEnable;

        public bool IsPanelEnable
        {
            get { return isPanelEnable; }
            set { isPanelEnable = value; OnPropertyChanged("IsPanelEnable"); }
        }
        public bool ATNone
        {
            get { return SelectedGraphic?.AnimationTT == Translational.None; }
            set { if (value)
                {
                    SelectedGraphic.AnimationTT = Translational.None;
                }
            }
        }
        public bool ATOx
        {
            get { return SelectedGraphic?.AnimationTT == Translational.Ox; }
            set
            {
                if (value)
                {
                    SelectedGraphic.AnimationTT = Translational.Ox;
                }
            }
        }
        public bool ATOy
        {
            get { return SelectedGraphic?.AnimationTT == Translational.Oy; }
            set
            {
                if (value)
                {
                    SelectedGraphic.AnimationTT = Translational.Oy;
                }
            }
        }

        public bool ARNone
        {
            get { return SelectedGraphic?.AnimationXoay == Rotatory.None; }
            set
            {
                if (value)
                {
                    SelectedGraphic.AnimationXoay = Rotatory.None;
                }
            }
        }
        public bool AROx
        {
            get { return SelectedGraphic?.AnimationXoay == Rotatory.Ox; }
            set
            {
                if (value)
                {
                    SelectedGraphic.AnimationXoay = Rotatory.Ox;
                }
            }
        }
        public bool AROy
        {
            get { return SelectedGraphic?.AnimationXoay == Rotatory.Oy; }
            set
            {
                if (value)
                {
                    SelectedGraphic.AnimationXoay = Rotatory.Oy;
                }
            }
        }
        public bool AROz
        {
            get { return SelectedGraphic?.AnimationXoay == Rotatory.Oz; }
            set
            {
                if (value)
                {
                    SelectedGraphic.AnimationXoay = Rotatory.Oz;
                }
            }
        }

        #endregion
        #region Contruction
        public AnimationViewModel(MainWindowViewModel vm)
        {
            mainVM = vm;
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
