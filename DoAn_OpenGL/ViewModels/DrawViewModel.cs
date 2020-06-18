using System;

namespace DoAn_OpenGL.ViewModels
{
    public class DrawViewModel : BaseViewModel
    {
        #region Properties
        private MainWindowViewModel mainmodel;
        private bool drawByPoint = true;

        public bool DrawByPoint
        {
            get { return drawByPoint; }
            set { 
                if(value)
                {
                    mainmodel.DrawMode = Assets.DrawMode.Point;
                }
                drawByPoint = value;
                OnPropertyChanged("DrawByPoint"); }
        }

        private bool drawByLines;

        public bool DrawByLines
        {
            get { return drawByLines; }
            set
            {
                if (value)
                {
                    mainmodel.DrawMode = Assets.DrawMode.Lines;
                }
                drawByLines = value;
                OnPropertyChanged("DrawByLines");
            }
        }
        private bool drawBySolid;

        public bool DrawBySolid
        {
            get { return drawBySolid; }
            set
            {
                if (value)
                {
                    mainmodel.DrawMode = Assets.DrawMode.Solid;
                }
                drawBySolid = value;
                OnPropertyChanged("DrawBySolid");
            }
        }


        public bool DrawCoodinate
        {
            get {
                return ( (mainmodel==null) ? false : mainmodel.drawCoodinate); 
            }
            set { 
                mainmodel.drawCoodinate = value;
                OnPropertyChanged("DrawCoodinate"); }
        }

        #endregion
        #region Contruction
        public DrawViewModel(MainWindowViewModel _mainmodel)
        {
            this.mainmodel = _mainmodel;
            DrawCoodinate = true;
        }
        #endregion
        #region Contruction
        #endregion
    }
}
