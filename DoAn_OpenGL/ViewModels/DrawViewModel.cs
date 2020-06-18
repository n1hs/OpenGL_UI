using DoAn_OpenGL.Assets;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

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
                    mainmodel.drawMode =  SharpGL.SceneGraph.Quadrics.DrawStyle.Point;
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
                    mainmodel.drawMode = SharpGL.SceneGraph.Quadrics.DrawStyle.Line;
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
                    mainmodel.drawMode = SharpGL.SceneGraph.Quadrics.DrawStyle.Fill;
                }
                drawBySolid = value;
                OnPropertyChanged("DrawBySolid");
            }
        }


        public bool ShowXYPlane
        {
            get {
                return ( (mainmodel==null) ? false : mainmodel.showXYPlane); 
            }
            set { 
                mainmodel.showXYPlane = value;
                OnPropertyChanged("DrawCoodinate"); }
        }


        public ObservableCollection<Graphics3D.Graphic3D> ListObject
        {
            get { return mainmodel?.listObject; }
            set
            {
                mainmodel.listObject = value;
                OnPropertyChanged("ListObject");
            }
        }

        public ICommand ChoseGraphicCommand { get; set; }
        #endregion
        #region Contruction
        public DrawViewModel(MainWindowViewModel _mainmodel)
        {
            this.mainmodel = _mainmodel;
            ShowXYPlane = true;
            ChoseGraphicCommand = new RelayCommand<DrawGraphic>(
                (i) => true,
                (i) =>
                {
                    mainmodel.isDrawMode = true;
                    mainmodel.SetStatus( string.Format("DrawMode: {0}.", mainmodel.isDrawMode));
                    mainmodel.drawGraphic = i;
                });
        }
        #endregion

        #region Methods


        #endregion
    }
}
