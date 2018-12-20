namespace SporTeams.ViewModels
{
    public class MainViewModel
    {
        #region Properties
        public WelcomeViewModel WelcomeVM { get; set; }
        #endregion

        #region Builders
        public MainViewModel()
        {
            WelcomeVM = new WelcomeViewModel();
        }
        #endregion
    }
}
