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
                    DialogTitle = "Main";
                    break;
                case 2:
                    DialogContent = new UserControls.CameraControl();
                    DialogTitle = "Camera Control";
                    break;

            }
            if (dialogContent != null)
            {
                DialogContent.DataContext = this;
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

            gl.Translate(0.0f, 0.0f, -6.0f);


            gl.Rotate(rotation, 0.0f, 1.0f, 0.0f);

            Teapot tp = new Teapot();
            tp.Draw(gl, 14, 1, OpenGL.GL_FILL);


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
            gl.Begin(SharpGL.Enumerations.BeginMode.Lines);
            gl.Color(1.0, 0.0, 0.0);
            gl.Vertex(0.0, 0.0, 0.0);
            gl.Vertex(10.0, 0.0, 0.0);
            gl.End();

            gl.Begin(SharpGL.Enumerations.BeginMode.Lines);
            gl.Color(0.0, 1.0, 0.0);
            gl.Vertex(0.0, 0.0, 0.0);
            gl.Vertex(0.0, 10.0, 0.0);
            gl.End();

            gl.Begin(SharpGL.Enumerations.BeginMode.Lines);
            gl.Color(0.0, 0.0, 1.0);
            gl.Vertex(0.0, 0.0, 0.0);
            gl.Vertex(0.0, 0.0, 10.0);
            gl.End();
        }

        private void Draw()
        {
            Teapot teapot = new Teapot();
            teapot.Draw(gl, 14, 1, OpenGL.GLU_FILL);
        }
        #endregion
    }
}
