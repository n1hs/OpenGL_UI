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
        private MainWindowViewModel mainVM;
        private bool drawByPoint = true;

        public bool DrawByPoint
        {
            get { return drawByPoint; }
            set { 
                if(value)
                {
                    mainVM.drawMode =  SharpGL.SceneGraph.Quadrics.DrawStyle.Point;
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
                    mainVM.drawMode = SharpGL.SceneGraph.Quadrics.DrawStyle.Line;
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
                    mainVM.drawMode = SharpGL.SceneGraph.Quadrics.DrawStyle.Fill;
                    UpdateGraphic();
                }
                drawBySolid = value;
                OnPropertyChanged("DrawBySolid");
            }
        }


        public bool ShowXYPlane
        {
            get {
                return ( (mainVM==null) ? false : mainVM.showXYPlane); 
            }
            set { 
                mainVM.showXYPlane = value;
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
            get { return mainVM?.listObject; }
            set
            {
                mainVM.listObject = value;
                OnPropertyChanged("ListObject");
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
            }
        }

        public ICommand ChoseGraphicCommand { get; set; }
        public ICommand ChoseColorCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private double r = 1, g, b;
        #endregion
        #region Contruction
        public DrawViewModel(MainWindowViewModel _mainmodel)
        {
            this.mainVM = _mainmodel;
            ShowXYPlane = true;
            ChoseGraphicCommand = new RelayCommand<DrawGraphic>(
                (i) => true,
                (i) =>
                {
                    mainVM.isDrawMode = true;
                    ResetDraw = false;
                    mainVM.SetStatus( string.Format("DrawMode: {0}.", mainVM.isDrawMode));
                    mainVM.drawGraphic = i;
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
            DeleteCommand = new RelayCommand(_=> {
                if (SelectedGraphic is null)
                    return;
                ListObject.Remove(SelectedGraphic);
            });
        }


        #endregion

        #region Methods
        private void UpdateGraphic()
        {
            if (mainVM.isDrawMode)
                switch (mainVM.drawGraphic)
                {
                    case DrawGraphic.Cone:
                        mainVM.temp = new Cone(mainVM.drawMode, 2, 2, r, g, b);
                        break;
                    case DrawGraphic.Cube:
                        mainVM.temp = new Cube(mainVM.drawMode, 4, 4, 4, r, g, b);
                        break;
                    case DrawGraphic.Cylinder:
                        mainVM.temp = new Cylinder(mainVM.drawMode, 2, 3, r, g, b);
                        break;
                    case DrawGraphic.FrustumShape:
                        mainVM.temp = new FrustumShape(mainVM.drawMode, 2, 1, 2, r, g, b);
                        break;
                    case DrawGraphic.Teapot:
                        mainVM.temp = new Teapot(mainVM.drawMode, 20, 2, r, g, b);
                        break;
                    case DrawGraphic.Pyramid:
                        mainVM.temp = new Pyramid(mainVM.drawMode, 2, 2, r, g, b);
                        break;
                    case DrawGraphic.Sphere:
                        mainVM.temp = new Sphere(mainVM.drawMode, 2, r, g, b);
                        break;
                    case DrawGraphic.TruncatedCone:
                        mainVM.temp = new TruncatedCone(mainVM.drawMode, 2, 1, 2, r, g, b);
                        break;
                }
        }

        #endregion
    }
}
