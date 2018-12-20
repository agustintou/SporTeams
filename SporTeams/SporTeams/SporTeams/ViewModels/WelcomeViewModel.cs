using SporTeams.Views;
using Xamarin.Forms;

namespace SporTeams.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        #region Attributes
        private int _height { get; set; }
        public int Height
        {
            get
            {
                return this._height;
            }
            set
            {
                if (value != _height)
                {
                    _height = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _width { get; set; }
        public int Width
        {
            get
            {
                return this._width;
            }
            set
            {
                if(value != _width)
                {
                    _width = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Properties

        #endregion

        #region Builders
        public WelcomeViewModel()
        {
            InitialData();
        }
        #endregion

        #region Commands

        #endregion

        #region Methods
        void InitialData()
        {
            //if(Application.Current.MainPage == null)
            //{
            //    Application.Current.MainPage = new WelcomePage();
            //}

            //Width = (int)Application.Current.MainPage.Width;
            //Height = (int)Application.Current.MainPage.Height;
        }
        #endregion
    }
}
