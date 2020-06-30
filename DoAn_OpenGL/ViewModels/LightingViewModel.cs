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
                return mainVM?.seletedGraphic;
            }
            set
            {
                mainVM.seletedGraphic = value;
                if (value != null && value.Style == SharpGL.SceneGraph.Quadrics.DrawStyle.Fill)
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
            get { return SelectedGraphic?.LightingMode == Assets.Lighting.DIFFUSE;  }
            set
            {
                if (value)
                    SelectedGraphic.LightingMode = Assets.Lighting.DIFFUSE;
            }
        }
        public bool LSHADOW
        {
            get { return SelectedGraphic?.LightingMode == Assets.Lighting.SHADOW;  }
            set
            {
                if (value)
                    SelectedGraphic.LightingMode = Assets.Lighting.SHADOW;
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
