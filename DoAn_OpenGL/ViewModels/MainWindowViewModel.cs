using DoAn_OpenGL.Assets;
using SharpGL;
using SharpGL.SceneGraph.Primitives;
using SharpGL.WPF;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace DoAn_OpenGL.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region UI
        private MainWindow mainWindow;
        internal DrawMode DrawMode;
        internal bool drawCoodinate;
        private DrawViewModel drawmodel ;
        private bool showDialog;

        public bool ShowDialog
        {
            get { return showDialog; }
            set {
                if (showDialog != value)
                {
                    showDialog = value;
                    OnPropertyChanged("ShowDialog");
                }
            }
        }

        private string dialogTilte;

        public string DialogTitle
        {
            get { return dialogTilte; }
            set { dialogTilte = value; 
                OnPropertyChanged("DialogTitle"); }
        }


        private UserControl dialogContent;

        public UserControl DialogContent
        {
            get { return dialogContent; }
            set { dialogContent = value;
                OnPropertyChanged("DialogContent");
            }
        }


        public ICommand ShowDialogCommand { set; get; }
        public ICommand HideDialogCommand { set; get; }
        public ICommand RegisterFormCommand { set; get; }


        public MainWindowViewModel()
        {
            showDialog = true;
            DialogContent = new UserControls.DrawControl();
            drawmodel = new DrawViewModel(this);
            DialogContent.DataContext = drawmodel;
            DialogTitle = "Main";
            ShowDialogCommand = new RelayCommand<string>(
                (i) => true,
                (i) => ShowDialogControl(i));

            HideDialogCommand = new RelayCommand(
                (i) =>
                {
                        ShowDialog = false;
                });

            RegisterFormCommand = new RelayCommand<MainWindow>(
                (w) => w != null,
                (w) => {
                    mainWindow = w;
                    mainWindow.OpenGLControl.OpenGLDraw += OpenGLControl_OpenGLDraw;
                    mainWindow.OpenGLControl.OpenGLInitialized += OpenGLControl_OpenGLInitialized;
                    mainWindow.OpenGLControl.MouseMove += OpenGLControl_MouseMove;
                    mainWindow.OpenGLControl.MouseLeave += OpenGLControl_MouseLeave;
                    mainWindow.OpenGLControl.MouseLeftButtonDown += OpenGLControl_MouseLeftButtonDown;
                    mainWindow.OpenGLControl.MouseLeftButtonUp += OpenGLControl_MouseLeftButtonUp;
                    });
        }

       

        private void ShowDialogControl(string key)
        {
            showDialog = false;
            int num = 0;
            if (int.TryParse(key, out num) == false)
                return;
            switch(num)
            {
                case 1:
                    DialogContent = new UserControls.DrawControl();
                    DialogContent.DataContext = drawmodel;
                    DialogTitle = "Main";
                    break;
                case 2:
                    DialogContent = new UserControls.CameraControl();
                    DialogTitle = "Camera Control";
                    break;

            }
            if (dialogContent != null)
            {
                ShowDialog = true;
            }
        }
        #endregion UI


        #region CameraControl
        private double xEye = 5.0;

        public double XEye
        {
            get { return xEye; }
            set { xEye = value;
                OnPropertyChanged("XEye");
            }
        }
        private double yEye = 5.0;

        public double YEye
        {
            get { return yEye; }
            set
            {
                yEye = value;
                OnPropertyChanged("YEye");
            }
        }

        private double zEye = 15.0;

        public double ZEye
        {
            get { return zEye; }
            set
            {
                zEye = value;
                OnPropertyChanged("ZEye");
            }
        }

        #endregion

        #region OpenGL
        OpenGL gl;
        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            gl = args.OpenGL;

            // Clear The Screen And The Depth Buffer
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            // Move Left And Into The Screen
            gl.LoadIdentity();

            gl.LookAt(xEye, YEye, ZEye, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);

            DrawCoodinate();
            
            //test ham ve hinh tru voi 2 diem x1, y1 va x2,y2
            DrawCylinder(gl, 10, 10, 15, 15);

            //test ham ve hinh non voi 2 diem x1, y1 va x2,y2
            DrawCone(gl, 10, 10, 30, 30);
            
            

            gl.Translate(0.0f, 0.0f, -6.0f);


            gl.Rotate(rotation, 0.0f, 1.0f, 0.0f);

            Teapot tp = new Teapot();
            tp.Draw(gl, 14, 3, OpenGL.GL_FILL);


            rotation += 3.0f;
        }
        float rotation = 0;

        private void OpenGLControl_OpenGLInitialized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            args.OpenGL.Enable(OpenGL.GL_DEPTH_TEST);
        }

        private void OpenGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            OpenGLControl openGLControl = sender as OpenGLControl;
            mainWindow.lblStatus.Text = string.Format("Point x = {0} y = {1}.", e.GetPosition(openGLControl).X, e.GetPosition(openGLControl).Y);
        }

        private void OpenGLControl_MouseLeave(object sender, MouseEventArgs e)
        {
            mainWindow.lblStatus.Text = string.Empty;
        }

        private void OpenGLControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            
        }

        private void OpenGLControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }


        private void DrawCoodinate()
        {
            if (!drawCoodinate)
                return;
            gl.Begin(SharpGL.Enumerations.BeginMode.Lines);
            gl.Color(1.0, 0.0, 0.0); // red X
            gl.Vertex(0.0, 0.0, 0.0);
            gl.Vertex(10.0, 0.0, 0.0);
            gl.End();

            gl.Begin(SharpGL.Enumerations.BeginMode.Lines);
            gl.Color(0.0, 1.0, 0.0); //Green X
            gl.Vertex(0.0, 0.0, 0.0);
            gl.Vertex(0.0, 10.0, 0.0);
            gl.End();

            gl.Begin(SharpGL.Enumerations.BeginMode.Lines);
            gl.Color(0.0, 0.0, 1.0); //Blue Z
            gl.Vertex(0.0, 0.0, 0.0);
            gl.Vertex(0.0, 0.0, 10.0);
            gl.End();
        }
        
        //ham ve hinh tru
        private void DrawCylinder(OpenGL gl, int x1, int y1, int x2, int y2)
        {
            Cylinder cylinder = new Cylinder();
            cylinder.TopRadius = 0.1 * Math.Abs(x2 - x1);
            cylinder.BaseRadius = 0.1*Math.Abs(x2 - x1);
            cylinder.Height = 0.1*Math.Abs(y2 - y1);
            cylinder.Slices = 100;
            cylinder.Stacks = 100;

            cylinder.CreateInContext(gl);
            cylinder.PushObjectSpace(gl);
            cylinder.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            cylinder.PopObjectSpace(gl);
            cylinder.DestroyInContext(gl);
        }

        //ham ve hinh non
        private void DrawCone(OpenGL gl, int x1, int y1, int x2, int y2)
        {
            Cylinder cone = new Cylinder();
            cone.TopRadius = 0;
            cone.BaseRadius = 0.1 * Math.Abs(x2 - x1);
            cone.Height = 0.1 * Math.Abs(y2 - y1);
            cone.Slices = 100;
            cone.Stacks = 100;

            cone.CreateInContext(gl);
            cone.PushObjectSpace(gl);
            cone.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            cone.PopObjectSpace(gl);
            cone.DestroyInContext(gl);
        }

        private void Draw()
        {
            Teapot teapot = new Teapot();
            teapot.Draw(gl, 14, 1, OpenGL.GLU_FILL);
        }
        #endregion
    }
}
