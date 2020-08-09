using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TouchEffect;
using GroctaXP.Models;
using GroctaXP.Utils;
using GroctaRes = GroctaXP.Resources;

namespace GroctaXP.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SvgIconButton : ContentView
    {
        #region Property Source
        public static readonly BindableProperty SourceProperty =
            BindableProperty.Create("Source", typeof(string), typeof(SvgIconButton), string.Empty,
                BindingMode.TwoWay, propertyChanged: OnSourcePropertyChanged);
        public string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }
        #endregion

        #region Property Theme
        public static readonly BindableProperty ThemeProperty =
            BindableProperty.Create("Theme", typeof(ControlTheme), typeof(SvgIconButton), ControlTheme.None,
                BindingMode.TwoWay, propertyChanged: OnThemePropertyChanged);
        public ControlTheme Theme
        {
            get { return (ControlTheme)GetValue(ThemeProperty); }
            set { SetValue(ThemeProperty, value); }
        }
        #endregion

        #region Property Command
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(SvgIconButton), default(ICommand),
                BindingMode.TwoWay, propertyChanged: OnCommandPropertyChanged);
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        #endregion

        public SvgIconButton()
        {
            InitializeComponent();
            this.Theme = ControlTheme.Light;
        }

        #region On Properties Changed Event Handlers
        private static void OnSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            SvgIconButton button = (SvgIconButton)bindable;
            if (button != null)
                button.ButtonIcon.Source = (string)newValue;
        }

        private static void OnThemePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            SvgIconButton button = (SvgIconButton)bindable;
            
            if (button != null)
            {
                if(button.Theme == ControlTheme.Dark)
                    button.ButtonIcon.Color = Color.White;
                else if (button.Theme == ControlTheme.Light)
                    button.ButtonIcon.Color = Utility.GetColorFromAppResources(GroctaRes.Resources.ColorPrimary);
            }
        }

        private static void OnCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            SvgIconButton button = (SvgIconButton)bindable;

            if (button != null)
                TouchEff.SetCommand(button.ButtonFrame, newValue as ICommand);
        }
        #endregion
    }
}