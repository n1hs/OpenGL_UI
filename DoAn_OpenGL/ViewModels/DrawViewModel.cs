using DoAn_OpenGL.Assets;
using DoAn_OpenGL.Graphics3D;
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
                    UpdateGraphic();
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
                    UpdateGraphic();
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
                    UpdateGraphic();
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

        private bool resetDraw;

        public bool ResetDraw
        {
            get { return resetDraw; }
            set { resetDraw = value;
                OnPropertyChanged("ResetDraw");
            }
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
        public ICommand ChoseColorCommand { get; set; }

        private double r = 1, g, b;
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
                    ResetDraw = false;
                    mainmodel.SetStatus( string.Format("DrawMode: {0}.", mainmodel.isDrawMode));
                    mainmodel.drawGraphic = i;
                    UpdateGraphic();
                });
            ChoseColorCommand = new RelayCommand<string>(
                (i) => !string.IsNullOrEmpty(i),
                (i) => { 
                    switch(i)
                    {
                        case "Black":
                            r = g = b = 0.0;
                            break;
                        case "Red":
                            g = b = 0.0;
                            r = 1.0;
                            break;
                        case "Yellow":
                            r = g = 1.0;
                            b = 0.0;
                            break;
                        case "Green":
                            r = b = 0.0;
                            g = 1.0;
                            break;
                        case "Cyan":
                            r = 0;
                            g = b = 1.0;
                            break;
                        case "Blue":
                            r = g = 0.0;
                            b = 1.0;
                            break;
                        case "Magenta":
                            r = b =1.0;
                            g = 0.0;
                            break;
                        case "Gray":
                            r = g = b = 0.5;
                            break;
                        default:
                            r = g = b = 1.0;
                            break;
                    }
                    UpdateGraphic();
                });
        }

        private void UpdateGraphic()
        {
            if(mainmodel.isDrawMode)
            switch (mainmodel.drawGraphic)
            {
                case DrawGraphic.Cone:
                    mainmodel.temp = new Cone(mainmodel.drawMode, 2, 2, r, g, b);
                    break;
                case DrawGraphic.Cube:
                    mainmodel.temp = new Cube(mainmodel.drawMode, 2, 2, 2, r, g, b);
                    break;
                case DrawGraphic.Cylinder:
                    mainmodel.temp = new Cylinder(mainmodel.drawMode, 2, 3, r, g, b);
                    break;
                case DrawGraphic.FrustumShape:
                    mainmodel.temp = new FrustumShape(mainmodel.drawMode, 2, 2,  r, g, b);
                    break;
                case DrawGraphic.Octagon:
                    mainmodel.temp = new Octagon(mainmodel.drawMode, 2, 2, r, g, b);
                    break;
                case DrawGraphic.Pyramid:
                    mainmodel.temp = new Pyramid(mainmodel.drawMode, 2, 2,  r, g, b);
                    break;
                case DrawGraphic.Sphere:
                    mainmodel.temp = new Sphere(mainmodel.drawMode, 2, 2,  r, g, b);
                    break;
                case DrawGraphic.TruncatedCone:
                    mainmodel.temp = new TruncatedCone(mainmodel.drawMode, 2, 1, 2, r, g, b);
                    break;
            }
        }
        #endregion

        #region Methods


        #endregion
    }
}
