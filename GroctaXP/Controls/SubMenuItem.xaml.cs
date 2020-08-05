using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GroctaXP.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubMenuItem : ContentView
    {
        #region Property Title
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(SubMenuItem), "Title",
                BindingMode.TwoWay, propertyChanged: OnTitlePropertyChanged);
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        #endregion

        #region Property Icon
        public static readonly BindableProperty IconProperty =
            BindableProperty.Create("Icon", typeof(string), typeof(SubMenuItem), default(string),
                BindingMode.TwoWay, propertyChanged: OnIconPropertyChanged);
        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
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
            BindableProperty.Create("CommandParameter", typeof(object), typeof(SubMenuItem), null,
                BindingMode.TwoWay, propertyChanged: OnCommandParameterPropertyChanged);
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        #endregion

        public SubMenuItem()
        {
            InitializeComponent();
        }

        #region On Properties Changed Event Handlers
        private static void OnTitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            SubMenuItem menu = (SubMenuItem)bindable;
            if (menu != null)
                menu.LabelTitle.Text = (string)newValue;
        }

        private static void OnIconPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            SubMenuItem menu = (SubMenuItem)bindable;
            if (menu != null)
                menu.IconMenu.Source = (string)newValue;
        }

        private static void OnCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            SubMenuItem menu = (SubMenuItem)bindable;

            if (menu != null)
                TouchEffect.TouchEff.SetCommand(menu.ViewSubMenu, (ICommand)newValue);
        }

        private static void OnCommandParameterPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            SubMenuItem menu = (SubMenuItem)bindable;

            if (menu != null)
                TouchEffect.TouchEff.SetCommandParameter(menu.ViewSubMenu, newValue);
        }
        #endregion
    }
}