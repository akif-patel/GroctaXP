using GroctaXP.Models;
using GroctaXP.Utils;
using System.Windows.Input;
using TouchEffect;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GroctaRes = GroctaXP.Resources;

namespace GroctaXP.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlatButton : ContentView
    {
        #region Property Text
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(FlatButton), default(string),
                BindingMode.TwoWay, propertyChanged: OnTitlePropertyChanged);
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        #endregion

        #region Property Theme
        public static readonly BindableProperty ThemeProperty =
            BindableProperty.Create("Theme", typeof(ControlTheme), typeof(FlatButton), ControlTheme.None,
                BindingMode.TwoWay, propertyChanged: OnThemePropertyChanged);
        public ControlTheme Theme
        {
            get { return (ControlTheme)GetValue(ThemeProperty); }
            set { SetValue(ThemeProperty, value); }
        }
        #endregion

        #region Property Command
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(FlatButton), default(ICommand),
                BindingMode.TwoWay, propertyChanged: OnCommandPropertyChanged);
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        #endregion

        #region Property Command Params
        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create("CommandParameter", typeof(object), typeof(FlatButton), null,
                BindingMode.TwoWay, propertyChanged: OnCommandParameterPropertyChanged);
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        #endregion

        public FlatButton()
        {
            InitializeComponent();

            this.Text = GroctaRes.Resources.FlatButtonText;
            this.Theme = ControlTheme.Light;
        }

        #region On Properties Changed Event Handlers
        private static void OnTitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            FlatButton button = (FlatButton)bindable;
            if (button != null)
                button.LabelTitle.Text = (string)newValue;
        }

        private static void OnThemePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            FlatButton button = (FlatButton)bindable;

            if (button != null)
            {
                if (button.Theme == ControlTheme.Dark)
                    button.LabelTitle.TextColor = Color.White;
                else if (button.Theme == ControlTheme.Light)
                    button.LabelTitle.TextColor = Utility.GetColorFromAppResources(GroctaRes.Resources.ColorPrimary);
            }
        }

        private static void OnCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            FlatButton button = (FlatButton)bindable;

            if (button != null)
                TouchEffect.TouchEff.SetCommand(button.ButtonFrame, (ICommand)newValue);
        }
        
        private static void OnCommandParameterPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            FlatButton button = (FlatButton)bindable;

            if (button != null)
                TouchEffect.TouchEff.SetCommandParameter(button.ButtonFrame, newValue);
        }
        #endregion
    }
}