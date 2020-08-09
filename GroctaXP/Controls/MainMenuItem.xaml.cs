using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GroctaXP.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenuItem : ContentView
    {
        private const string PATH_ICON_ARROW_UP = "resource://GroctaXP.Resources.Icons.ai_arrow_up.svg";
        private const string PATH_ICON_ARROW_DOWN = "resource://GroctaXP.Resources.Icons.ai_arrow_down.svg";

        #region Property Title
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(MainMenuItem), "Title",
                BindingMode.TwoWay, propertyChanged: OnTitlePropertyChanged);
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        #endregion

        #region Property Description
        public static readonly BindableProperty DescriptionProperty =
            BindableProperty.Create("Description", typeof(string), typeof(MainMenuItem), "Description",
                BindingMode.TwoWay, propertyChanged: OnDescriptionPropertyChanged);
        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }
        #endregion

        #region Property State
        public static readonly BindableProperty StateProperty =
            BindableProperty.Create("State", typeof(MenuState), typeof(MainMenuItem), MenuState.Collapsed,
                BindingMode.TwoWay, propertyChanged: OnStatePropertyChanged);
        public MenuState State
        {
            get { return (MenuState)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }
        #endregion

        #region Property Command
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(MainMenuItem), default(ICommand),
                BindingMode.TwoWay, propertyChanged: OnCommandPropertyChanged);
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        #endregion

        #region Property Command Params
        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create("CommandParameter", typeof(object), typeof(MainMenuItem), null,
                BindingMode.TwoWay, propertyChanged: OnCommandParameterPropertyChanged);
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        #endregion

        public MainMenuItem()
        {
            InitializeComponent();
            this.State = MenuState.Collapsed;
            this.IconMenuState.Source = PATH_ICON_ARROW_DOWN;
        }

        #region On Properties Changed Event Handlers
        private static void OnTitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            MainMenuItem menu = (MainMenuItem)bindable;
            if (menu != null)
                menu.LableTitle.Text = (string)newValue;
        }

        private static void OnDescriptionPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            MainMenuItem menu = (MainMenuItem)bindable;
            if (menu != null)
                menu.LableDescription.Text = (string)newValue;
        }

        private static void OnStatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {

        }

        private static void OnCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            MainMenuItem menu = (MainMenuItem)bindable;

            if (menu != null) 
                TouchEffect.TouchEff.SetCommand(menu.ViewMainMenu, (ICommand)newValue);
        }

        private static void OnCommandParameterPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            MainMenuItem menu = (MainMenuItem)bindable;

            if (menu != null)
                TouchEffect.TouchEff.SetCommandParameter(menu.ViewMainMenu, newValue);
        }
        #endregion

        #region Events and Methods
        private void TouchEff_Completed(VisualElement sender, TouchEffect.EventArgs.TouchCompletedEventArgs args)
        {
            if (this.Command != null)
            {
                if (this.State == MenuState.Expanded)
                    this.Collapse();
                else if (this.State == MenuState.Collapsed)
                    this.Expand();
            }
        }

        public void Expand()
        {
            this.State = MenuState.Expanded;
            this.LableDescription.IsVisible = false;
            this.IconMenuState.Source = PATH_ICON_ARROW_UP;
        }

        public void Collapse()
        {
            this.State = MenuState.Collapsed;
            this.LableDescription.IsVisible = true;
            this.IconMenuState.Source = PATH_ICON_ARROW_DOWN;
        }
        #endregion

        public enum MenuState
        {
            Collapsed,
            Expanded
        }
    }
}