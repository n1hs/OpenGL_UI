using DoAn_OpenGL.Assets;
using SharpGL;
using DoAn_OpenGL.Graphics3D;
using SharpGL.SceneGraph.Quadrics;
using SharpGL.WPF;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;


namespace DoAn_OpenGL.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region UI
        private MainWindow mainWindow;
        private CameraControlViewModel cameraVM;
        private DrawViewModel drawmodel;
        private GraphicPropertyVM graphicPropertyvm;
        private AnimationViewModel animationVM;
        private TextureViewModel textureVM;
        private LightingViewModel lightingVM;
        private Graphic3D seletedGraphic;
        internal Graphic3D SeletedGraphic
        {
            get
            {
                return seletedGraphic;
            }
            set
            {
                if (seletedGraphic != null)
                    seletedGraphic.IsSelected = false;
                if (value != null)
                {
                    seletedGraphic = value;
                    seletedGraphic.IsSelected = true;
                }    
            }
        }

        internal bool showXYPlane;
        internal bool isDrawMode;
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
            listObject = new ObservableCollection<Graphic3D>();
            cameraVM = new CameraControlViewModel(this);
            graphicPropertyvm = new GraphicPropertyVM(this);
            animationVM = new AnimationViewModel(this);
            textureVM = new TextureViewModel(this);
            lightingVM = new LightingViewModel(this);
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
                    SeletedGraphic = null;
                });

            RegisterFormCommand = new RelayCommand<MainWindow>(
                (w) => w != null,
                (w) => {
                    mainWindow = w;
                    mainWindow.OpenGLControl.OpenGLDraw += OpenGLControl_OpenGLDraw;
                    mainWindow.OpenGLControl.OpenGLInitialized += OpenGLControl_OpenGLInitialized;
                    mainWindow.OpenGLControl.MouseMove += OpenGLControl_MouseMove;
                    mainWindow.OpenGLControl.MouseLeave += OpenGLControl_MouseLeave;
                    mainWindow.OpenGLControl.MouseLeftButtonUp += OpenGLControl_MouseLeftButtonUp;
                    mainWindow.OpenGLControl.MouseEnter += OpenGLControl_MouseEnter;
                    mainWindow.OpenGLControl.MouseWheel += OpenGLControl_MouseWheel;
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
                    dialogContent.DataContext = cameraVM;
                    DialogTitle = "Camera Control";
                    break;
                case 3:
                    DialogContent = new UserControls.GraphicProperties();
                    DialogContent.DataContext = graphicPropertyvm;
                    graphicPropertyvm.Update();
                    DialogTitle = "Thuộc tính";
                    break;
                case 4:
                    DialogContent = new UserControls.Animation();
                    DialogContent.DataContext = animationVM;
                    animationVM.Update();
                    DialogTitle = "Animation";
                    break;
                case 5:
                    DialogContent = new UserControls.Texture();
                    DialogContent.DataContext = textureVM;
                    textureVM.Update();
                    DialogTitle = "Texture";
                    break;
                case 6:
                    DialogContent = new UserControls.Lighting();
                    DialogContent.DataContext = lightingVM;
                    lightingVM.Update();
                    DialogTitle = "Lighting";
                    break;

            }
            if (dialogContent != null)
            {
                ShowDialog = true;
            }
        }
        #endregion UI



        #region OpenGL
        OpenGL gl;
        private bool isMouseEnter;
        internal DrawStyle drawMode = DrawStyle.Point;
        internal DrawGraphic drawGraphic;
        double pointX, pointY = 0;
        internal Graphic3D temp;


        internal double xEye = 0;
        internal double yEye = -25.0;
        internal double zEye = 25.0;
        internal double xCenter = 0.0;
        internal double yCenter = 0.0;
        internal double zCenter = 0.0;
        private const double xup = 0.0;
        private const double yup = 0.0;
        private const double zup = 1.0;

        internal ObservableCollection<Graphics3D.Graphic3D> listObject;



        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            gl = args.OpenGL;

            // Clear The Screen And The Depth Buffer
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.ClearColor(0, 0, 0, 0);
            // Move Left And Into The Screen
            gl.LoadIdentity();

            gl.LookAt(xEye, yEye, zEye, xCenter, yCenter, zCenter, xup, yup, zup);
            gl.PushMatrix();
            DrawXYPlane();
            gl.ClearColor(0, 0, 0, 0);

            gl.PopMatrix();


            ///Vẽ lại hình dã luu trong listObject
           
            if (listObject!=null)
            {
                foreach(Graphic3D g in listObject)
                {
                    g.Draw(gl);
                }
            }


            ///// Vẽ hình đang chọn
            if (isMouseEnter && isDrawMode && temp != null)
            {
                gl.PushMatrix();
                temp.Draw(gl);
                gl.PopMatrix();
            }
            gl.Flush();

            
        }

        private void OpenGLControl_OpenGLInitialized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            args.OpenGL.Enable(OpenGL.GL_DEPTH_TEST);
        }

        private void OpenGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseEnter)
            {
                OpenGLControl openGLControl = sender as OpenGLControl;

                int[] viewport = new int[4];
                gl.GetInteger(OpenGL.GL_VIEWPORT, viewport);

                double[] modelview = new double[16];
                gl.GetDouble(SharpGL.Enumerations.GetTarget.ModelviewMatix, modelview);

                double[] projection = new double[16];
                gl.GetDouble(SharpGL.Enumerations.GetTarget.ProjectionMatrix, projection);

                double winX = e.GetPosition(openGLControl).X;
                double winY = e.GetPosition(openGLControl).Y;
                winY = (double)viewport[3] - winY;
                double posX, posY, posZ;
                posX = posY = posZ = 0;
                gl.UnProject(winX, winY, 0, modelview, projection, viewport, ref posX, ref posY, ref posZ);
             
                double pos1X, pos1Y, pos1Z;
                pos1X = pos1Y = pos1Z = 0;
                gl.UnProject(winX, winY, 1, modelview, projection, viewport, ref pos1X, ref pos1Y, ref pos1Z);

                double t = - posZ / (pos1Z - posZ);
                pointX = t * (pos1X - posX) + posX;
                pointY = t * (pos1Y - posY) + posY;
                SetStatus( string.Format("DrawMode: {0} . Point x = {1} y = {2}.",isDrawMode, pointX, pointY));
                if(temp != null)
                {
                    temp.LocationX = pointX;
                    temp.LocationY = pointY;
                }
            }
        }

        private void OpenGLControl_MouseLeave(object sender, MouseEventArgs e)
        {
            SetStatus(string.Format("DrawMode: {0}.", isDrawMode));
            isMouseEnter = false;
        }

        private void OpenGLControl_MouseEnter(object sender, MouseEventArgs e)
        {
            if (isMouseEnter == false)
                isMouseEnter = true;
        }

        private void OpenGLControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(isMouseEnter)
            {
                if(isDrawMode && temp!= null)
                {
                    temp.Name += string.Format(".{0}.{1}", temp.Style.ToString(), DateTime.Now.ToShortTimeString());
                    drawmodel.ListObject.Add(temp);
                    drawmodel.ResetDraw = true;
                    isDrawMode = false;
                    temp = null;
                }
            }
            
        }


        private void OpenGLControl_MouseWheel(object sender, MouseWheelEventArgs e)
        {           
            double a = xEye - xCenter;
            double b = yEye - yCenter;
            double c = zEye - zCenter;
            double t, tx,ty,tz, min,max;
            if (e.Delta>0 && a <1 && b<1 && c<1)
            {
                return;
            }
            if (a == 0 && b == 0 && c == 0)
            {
                System.Windows.MessageBox.Show("Vui lòng chọn tọa độ camera view khác tọa đọ tham chiếu.");
                return;
            }  

            else
            {
                if(a!= 0)
                {
                    t = xEye / a;
                }
                else
                {
                    if (b != 0)
                    {
                        t = yEye / b;
                    }
                    else
                    {
                        t = zEye / c;
                    }
                }
            }

            t -= (double)e.Delta*0.1/120;

            tx = xCenter + a * t;
            ty = yCenter + b * t;
            tz = zCenter + c * t;
            max = Math.Max(tx, Math.Max(ty, tz));
            min = Math.Min(tx, Math.Min(ty, tz));
            if(min <= -50 || max >= 50.0)
            {
                System.Windows.MessageBox.Show("Giới hạn tọa độ chỉ từ -50 đến 50.");
                return;
            }    
            xEye = tx;
            yEye = ty;
            zEye = tz;
            cameraVM.Update();
        }

        internal void SetStatus(string text)
        {
            mainWindow.lblStatus.Text = text;
        }

        /// <summary>
        ///  Vẽ mặt phẳng OXY 
        /// </summary>
        private void DrawXYPlane(double size = 15, double distanceBetweenLines = 1.0)
        {
            if (!showXYPlane)
                return;
            //gl.Color(0.9, 0.9, 0.9);
            //gl.Begin(OpenGL.GL_QUADS);

            //gl.TexCoord(1.0f, 0.0f); gl.Vertex(-size, -size, 0);    // Bottom Right Of The Texture and Quad
            //gl.TexCoord(1.0f, 1.0f); gl.Vertex(-size, size, 0); // Top Right Of The Texture and Quad
            //gl.TexCoord(0.0f, 1.0f); gl.Vertex(size, size, 0);  // Top Left Of The Texture and Quad
            //gl.TexCoord(0.0f, 0.0f); gl.Vertex(size, -size, 0); // Bottom Left Of The Texture and Quad

            //gl.End();

            gl.Color(0.5, 0.5, 0.5);

            for (double x = -size; x <= size; x += 1)
            {

                gl.Begin(SharpGL.Enumerations.BeginMode.Lines);
                gl.Vertex(x, -(size * distanceBetweenLines), 0.0);
                gl.Vertex(x, (size * distanceBetweenLines), 0.0);
                gl.End();
            };
            for (double y = -size; y <= size; y += 1)
            {
                gl.Begin(SharpGL.Enumerations.BeginMode.Lines);
                gl.Vertex(-(size * distanceBetweenLines), y, 0.0);
                gl.Vertex(size * distanceBetweenLines, y, 0.0);
                gl.End();
            }

        }





        #endregion
    }
}
