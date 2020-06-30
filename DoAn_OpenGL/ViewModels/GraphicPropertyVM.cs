using DoAn_OpenGL.Assets;
using DoAn_OpenGL.Graphics3D;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace DoAn_OpenGL.ViewModels
{
    public class GraphicPropertyVM : BaseViewModel
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
        public Graphic3D SelectedGraphic { 
        get
            {
                return mainVM?.SeletedGraphic;
            }
            set
            {
                mainVM.SeletedGraphic = value;
                if(value!= null)
                {
                    CheckColor(value.ColorR, value.ColorG, value.ColorB);
                    IsPanelEnable = true;
                    OnPropertyChanged("SizeXName");
                    OnPropertyChanged("SizeYName");
                    OnPropertyChanged("SizeZName");
                    OnPropertyChanged("ZVisibility");
                    OnPropertyChanged("YVisibility");
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
            set { isPanelEnable = value; OnPropertyChanged("IsPanelEnable"); }
        }

        public ICommand ChoseColorCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        #endregion

        #region Contruction
        public GraphicPropertyVM(MainWindowViewModel vm)
        {
            mainVM = vm;
            ChoseColorCommand = new RelayCommand<string>(
                (i) => !string.IsNullOrEmpty(i),
                (i) => {
                    switch (i)
                    {
                        case "Black":
                            mainVM.SeletedGraphic.ColorR = mainVM.SeletedGraphic.ColorG = mainVM.SeletedGraphic.ColorB = 0.0;
                            break;
                        case "Red":
                            mainVM.SeletedGraphic.ColorG = mainVM.SeletedGraphic.ColorB = 0.0;
                            mainVM.SeletedGraphic.ColorR = 1.0;
                            break;
                        case "Yellow":
                            mainVM.SeletedGraphic.ColorR = mainVM.SeletedGraphic.ColorG = 1.0;
                            mainVM.SeletedGraphic.ColorB = 0.0;
                            break;
                        case "Green":
                            mainVM.SeletedGraphic.ColorR = mainVM.SeletedGraphic.ColorB = 0.0;
                            mainVM.SeletedGraphic.ColorG = 1.0;
                            break;
                        case "Cyan":
                            mainVM.SeletedGraphic.ColorR = 0;
                            mainVM.SeletedGraphic.ColorG = mainVM.SeletedGraphic.ColorB = 1.0;
                            break;
                        case "Blue":
                            mainVM.SeletedGraphic.ColorR = mainVM.SeletedGraphic.ColorG = 0.0;
                            mainVM.SeletedGraphic.ColorB = 1.0;
                            break;
                        case "Magenta":
                            mainVM.SeletedGraphic.ColorR = mainVM.SeletedGraphic.ColorB = 1.0;
                            mainVM.SeletedGraphic.ColorG = 0.0;
                            break;
                        case "Gray":
                            mainVM.SeletedGraphic.ColorR = mainVM.SeletedGraphic.ColorG = mainVM.SeletedGraphic.ColorB = 0.5;
                            break;
                        default:
                            mainVM.SeletedGraphic.ColorR = mainVM.SeletedGraphic.ColorG = mainVM.SeletedGraphic.ColorB = 1.0;
                            break;
                    }
                });
            DeleteCommand= new RelayCommand(_=>
                {
                    if (SelectedGraphic == null)
                    {
                        return;
                    }
                    if (System.Windows.MessageBox.Show(String.Format("Bạn có muốn xóa {0} không? ", SelectedGraphic.Name), "Xác nhận", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Warning) == System.Windows.MessageBoxResult.Yes)
                    {
                        Graphic3D x = SelectedGraphic;
                        if (x != null)
                        {
                            ListObject.Remove(x);
                            SelectedGraphic = null;
                            OnPropertyChanged("SelectedGraphic");
                        }
                    }
                    
            });
        }

        public bool IsBlack { get; set; }
        public bool IsWhite { get; set; }
        public bool IsRed { get; set; }
        public bool IsYellow { get; set; }
        public bool IsGreen { get; set; }
        public bool IsCyan { get; set; }
        public bool IsBlue { get; set; }
        public bool IsMagenta { get; set; }
        public bool IsGray { get; set; }


        public string SizeXName
        {
            get { 
                if(SelectedGraphic is Cube)
                {
                    return "X";
                }
                return "BaseRadius";
            }
        }

        public string SizeYName
        {
            get
            {
                if (SelectedGraphic is Cube)
                {
                    return "Y";
                }
                return "TopRadius";
            }
        }
        public string SizeZName
        {
            get
            {
                return "Height";
            }
        }
        public Visibility ZVisibility
        {
            get
            {
                if (SelectedGraphic is Sphere || SelectedGraphic is Teapot )
                {
                    return Visibility.Collapsed;
                }
                return Visibility.Visible;
            }
        }

        public Visibility YVisibility {
            get
            {
                if(SelectedGraphic is Sphere || SelectedGraphic is Cone || SelectedGraphic is Teapot || SelectedGraphic is Cylinder || SelectedGraphic is Pyramid)
                {
                    return Visibility.Collapsed;
                }
                return Visibility.Visible;
            }
        }
        #endregion
        #region Methods
        private void SetColor(int i)
        {
            switch(i)
            {
                case 1:
                    IsBlack = true;
                    IsWhite = IsRed = IsYellow = IsGreen = IsCyan = IsBlue = IsMagenta = IsGray = false;
                    break;
                case 2:
                    IsBlue = true;
                    IsWhite = IsRed = IsYellow = IsGreen = IsCyan = IsBlack = IsMagenta = IsGray = false;
                    break;
                case 3:
                    IsGreen = true;
                    IsWhite = IsRed = IsYellow = IsBlue = IsCyan = IsBlack = IsMagenta = IsGray = false;
                    break;
                case 4:
                    IsCyan = true;
                    IsWhite = IsRed = IsYellow = IsBlue = IsGreen = IsBlack = IsMagenta = IsGray = false;
                    break;
                case 5:
                    IsRed = true;
                    IsWhite = IsCyan = IsYellow = IsBlue = IsGreen = IsBlack = IsMagenta = IsGray = false;
                    break;
                case 6:
                    IsMagenta = true;
                    IsWhite = IsRed = IsYellow = IsBlue = IsGreen = IsBlack = IsCyan = IsGray = false;
                    break;
                case 7:
                    IsYellow = true;
                    IsWhite = IsRed = IsMagenta = IsBlue = IsGreen = IsBlack = IsMagenta = IsGray = false;
                    break;
                case 8:
                    IsWhite = true;
                    IsCyan = IsRed = IsYellow = IsBlue = IsGreen = IsBlack = IsMagenta = IsGray = false;
                    break;
                default:
                    IsGray = true;
                    IsWhite = IsRed = IsYellow = IsBlue = IsGreen = IsBlack = IsMagenta = IsCyan = false;
                    break;
            }
            OnPropertyChanged("IsGray");
            OnPropertyChanged("IsWhite");
            OnPropertyChanged("IsRed");
            OnPropertyChanged("IsYellow");
            OnPropertyChanged("IsBlue");
            OnPropertyChanged("IsGreen");
            OnPropertyChanged("IsBlack");
            OnPropertyChanged("IsMagenta");
            OnPropertyChanged("IsCyan");
        }
        private void CheckColor(double r, double g, double b)
        {
           if(mainVM.SeletedGraphic.ColorR ==0)
            {
                if(mainVM.SeletedGraphic.ColorG ==0)
                {
                    if(b==0)
                    {
                        SetColor(1);
                    }   
                    else
                    {
                        SetColor(2);
                    }    
                }  
                else
                {
                    if (mainVM.SeletedGraphic.ColorB == 0)
                    {
                        SetColor(3);
                    }
                    else
                    {
                        SetColor(4);
                    }
                }    
            }  
           else
            {
                if (mainVM.SeletedGraphic.ColorG == 0)
                {
                    if (mainVM.SeletedGraphic.ColorB == 0)
                    {
                        SetColor(5);
                    }
                    else
                    {
                        SetColor(6);
                    }
                }
                else
                {
                    if (mainVM.SeletedGraphic.ColorB == 0)
                    {
                        SetColor(7);
                    }
                    else
                    {
                        if (mainVM.SeletedGraphic.ColorB == 1)
                        {
                            SetColor(8);
                        }
                        else
                        {
                            SetColor(0);
                        }
                    }
                }
            }    
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
