using DoAn_OpenGL.Graphics3D;
using System;
using System.Collections.ObjectModel;

namespace DoAn_OpenGL.ViewModels
{
    public class LightingViewModel: BaseViewModel
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
                OnPropertyChanged("XEye");
                OnPropertyChanged("YEye");
                OnPropertyChanged("ZEye");
                OnPropertyChanged("LNONE");
                OnPropertyChanged("LAMBIENT");
                OnPropertyChanged("LDIFFUSE");
                OnPropertyChanged("LSHADOW");
            }
        }
        private bool isPanelEnable;

        public bool IsPanelEnable
        {
            get { return isPanelEnable; }
            set
            {
                isPanelEnable = value;
                OnPropertyChanged("IsPanelEnable");
            }
        }


        public bool LNONE
        {
            get { return SelectedGraphic?.LightingMode == Assets.Lighting.NONE; }
            set {
                if(value)
                SelectedGraphic.LightingMode = Assets.Lighting.NONE; 
            }
        }
        public bool LAMBIENT
        {
            get { return SelectedGraphic?.LightingMode == Assets.Lighting.AMBIENT;  }
            set
            {
                if (value)
                    SelectedGraphic.LightingMode = Assets.Lighting.AMBIENT;
            }
        }
        public bool LDIFFUSE
        {
            get { return SelectedGraphic?.LightingMode == Assets.Lighting.POSITION;  }
            set
            {
                if (value)
                {
                    SelectedGraphic.LightingMode = Assets.Lighting.POSITION;
                    SelectedGraphic.LightSourceX = mainVM.xEye;
                    SelectedGraphic.LightSourceY = mainVM.yEye;
                    SelectedGraphic.LightSourceZ = mainVM.zEye;
                    OnPropertyChanged("XEye");
                    OnPropertyChanged("YEye");
                    OnPropertyChanged("ZEye");
                }
            }
        }
        public bool LSHADOW
        {
            get { return SelectedGraphic?.LightingMode == Assets.Lighting.SHADOW;  }
            set
            {
                if (value)
                    SelectedGraphic.LightingMode = Assets.Lighting.SHADOW;
                else
                    SelectedGraphic.LightingMode = Assets.Lighting.POSITION;
            }
        }

        public double XEye {
            get
            {
                return SelectedGraphic is null ? 0 : SelectedGraphic.LightSourceX; 
            }
            set
            {
                SelectedGraphic.LightSourceX = value;
            }

        }
        public double YEye
        {
            get
            {
                return SelectedGraphic is null ? 0 : SelectedGraphic.LightSourceY;
            }
            set
            {
                SelectedGraphic.LightSourceY = value;
            }

        }

        public double ZEye
        {
            get
            {
                return SelectedGraphic is null ? 0 : SelectedGraphic.LightSourceZ;
            }
            set
            {
                SelectedGraphic.LightSourceZ = value;
            }

        }


        #endregion
        #region Contruction
        public LightingViewModel(MainWindowViewModel vm)
        {
            mainVM = vm;
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
