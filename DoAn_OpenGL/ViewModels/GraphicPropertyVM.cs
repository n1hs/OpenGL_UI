using DoAn_OpenGL.Assets;
using DoAn_OpenGL.Graphics3D;
using System;
using System.Collections.ObjectModel;
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
                return mainVM?.seletedGraphic;
            }
            set
            {
                mainVM.seletedGraphic = value;
                if(value!= null)
                {
                    CheckColor(value.ColorR, value.ColorG, value.ColorB);
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
                            mainVM.seletedGraphic.ColorR = mainVM.seletedGraphic.ColorG = mainVM.seletedGraphic.ColorB = 0.0;
                            break;
                        case "Red":
                            mainVM.seletedGraphic.ColorG = mainVM.seletedGraphic.ColorB = 0.0;
                            mainVM.seletedGraphic.ColorR = 1.0;
                            break;
                        case "Yellow":
                            mainVM.seletedGraphic.ColorR = mainVM.seletedGraphic.ColorG = 1.0;
                            mainVM.seletedGraphic.ColorB = 0.0;
                            break;
                        case "Green":
                            mainVM.seletedGraphic.ColorR = mainVM.seletedGraphic.ColorB = 0.0;
                            mainVM.seletedGraphic.ColorG = 1.0;
                            break;
                        case "Cyan":
                            mainVM.seletedGraphic.ColorR = 0;
                            mainVM.seletedGraphic.ColorG = mainVM.seletedGraphic.ColorB = 1.0;
                            break;
                        case "Blue":
                            mainVM.seletedGraphic.ColorR = mainVM.seletedGraphic.ColorG = 0.0;
                            mainVM.seletedGraphic.ColorB = 1.0;
                            break;
                        case "Magenta":
                            mainVM.seletedGraphic.ColorR = mainVM.seletedGraphic.ColorB = 1.0;
                            mainVM.seletedGraphic.ColorG = 0.0;
                            break;
                        case "Gray":
                            mainVM.seletedGraphic.ColorR = mainVM.seletedGraphic.ColorG = mainVM.seletedGraphic.ColorB = 0.5;
                            break;
                        default:
                            mainVM.seletedGraphic.ColorR = mainVM.seletedGraphic.ColorG = mainVM.seletedGraphic.ColorB = 1.0;
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
           if(mainVM.seletedGraphic.ColorR ==0)
            {
                if(mainVM.seletedGraphic.ColorG ==0)
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
                    if (mainVM.seletedGraphic.ColorB == 0)
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
                if (mainVM.seletedGraphic.ColorG == 0)
                {
                    if (mainVM.seletedGraphic.ColorB == 0)
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
                    if (mainVM.seletedGraphic.ColorB == 0)
                    {
                        SetColor(7);
                    }
                    else
                    {
                        if (mainVM.seletedGraphic.ColorB == 1)
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
