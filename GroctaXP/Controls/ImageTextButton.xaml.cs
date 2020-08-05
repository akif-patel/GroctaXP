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
    public partial class ImageTextButton : ContentView
    {
        #region Property Title
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(ImageTextButton), string.Empty,
                BindingMode.TwoWay, propertyChanged: OnTitlePropertyChanged);
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        #endregion

        #region Property Source
        public static readonly BindableProperty ImageSourceProperty =
            BindableProperty.Create("Image", typeof(string), typeof(ImageTextButton), string.Empty,
                BindingMode.TwoWay, propertyChanged: OnSourcePropertyChanged);
        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        #endregion

        #region Property Theme
        public static readonly BindableProperty ThemeProperty =
            BindableProperty.Create("Theme", typeof(ControlTheme), typeof(ImageTextButton), ControlTheme.None,
                BindingMode.TwoWay, propertyChanged: OnThemePropertyChanged);
        public ControlTheme Theme
        {
            get { return (ControlTheme)GetValue(ThemeProperty); }
            set { SetValue(ThemeProperty, value); }
        }
        #endregion

        #region Property Command
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(ImageTextButton), default(ICommand),
                BindingMode.TwoWay, propertyChanged: OnCommandPropertyChanged);
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        #endregion

        #region Property Command Params
        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create("CommandParameter", typeof(object), typeof(ImageTextButton), null,
                BindingMode.TwoWay, propertyChanged: OnCommandParameterPropertyChanged);
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        #endregion

        #region Property Hide Image
        public static readonly BindableProperty HideImageProperty =
            BindableProperty.Create("HideImage", typeof(bool), typeof(ImageTextButton), false,
                BindingMode.TwoWay, propertyChanged: OnHideImagePropertyChanged);
        public bool HideImage
        {
            get { return (bool)GetValue(HideImageProperty); }
            set { SetValue(HideImageProperty, value); }
        }
        #endregion

        #region Property Text Color
        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create("TextColor", typeof(Color), typeof(ImageTextButton), null,
                BindingMode.TwoWay, propertyChanged: OnTextColorPropertyChanged);
        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }
        #endregion

        #region Property Icon Size
        public static readonly BindableProperty IconSizeProperty =
            BindableProperty.Create("IconSize", typeof(int), typeof(ImageTextButton), default(int),
                BindingMode.TwoWay, propertyChanged: OnIconSizePropertyChanged);
        public int IconSize
        {
            get { return (int)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }
        #endregion

        #region Property Tint Color
        public static readonly BindableProperty TintColorProperty =
            BindableProperty.Create("TintColor", typeof(Color), typeof(ImageTextButton), null,
                BindingMode.TwoWay, propertyChanged: OnTintColorPropertyChanged);
        public Color TintColor
        {
            get { return (Color)GetValue(TintColorProperty); }
            set { SetValue(TintColorProperty, value); }
        }
        #endregion

        #region Property Border Color
        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create("BorderColor", typeof(Color), typeof(ImageTextButton), null,
                BindingMode.TwoWay, propertyChanged: OnBorderColorPropertyChanged);
        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }
        #endregion

        public ImageTextButton()
        {
            InitializeComponent();
            this.Theme = ControlTheme.None;
            this.HideImage = false;
            this.IconSize = 26;
            this.TintColor = Utility.GetColorFromAppResources(GroctaRes.Resources.ColorGray);
            this.TextColor = Utility.GetColorFromAppResources(GroctaRes.Resources.ColorGray);
            this.BorderColor = Utility.GetColorFromAppResources(GroctaRes.Resources.ColorGray); 
        }

        #region On Properties Changed Event Handlers
        private static void OnTitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ImageTextButton button = (ImageTextButton)bindable;
            if (button != null)
                button.LableTitle.Text = (string)newValue;
        }

        private static void OnSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ImageTextButton button = (ImageTextButton)bindable;
            if (button != null)
                button.ButtonIcon.Source = (string)newValue;
        }

        private static void OnIconSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ImageTextButton button = (ImageTextButton)bindable;
            if (button != null)
            {
                button.ButtonIcon.HeightRequest = (int)newValue;
                button.ButtonIcon.WidthRequest = (int)newValue;
            }
        }

        private static void OnTintColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ImageTextButton button = (ImageTextButton)bindable;
            if (button != null)
                button.ButtonIcon.Color = (Color)newValue;
        }

        private static void OnHideImagePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ImageTextButton button = (ImageTextButton)bindable;
            bool hide = !(bool)newValue;

            if (button != null)
            {
                button.ButtonIcon.IsVisible = hide;
                button.ButtonSeparator.IsVisible = hide;

                if(hide)
                    button.LableTitle.Margin = new Thickness(0);
                else
                    button.LableTitle.Margin = new Thickness(-6, 0, 0, 0);
            }
        }

        private static void OnTextColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ImageTextButton button = (ImageTextButton)bindable;
            if (button != null)
                button.LableTitle.TextColor = (Color)newValue;
        }

        private static void OnBorderColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ImageTextButton button = (ImageTextButton)bindable;
            if (button != null)
            {
                button.ButtonFrame.BorderColor = (Color)newValue;
                button.ButtonSeparator.BackgroundColor = (Color)newValue;
            }
        }

        private static void OnThemePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ImageTextButton button = (ImageTextButton)bindable;
            ControlTheme newTheme = (ControlTheme)newValue;
            
            if (button != null)
            {
                if (newTheme == ControlTheme.Light)
                {
                    button.TintColor = Utility.GetColorFromAppResources(GroctaRes.Resources.ColorPrimary);
                    button.TextColor = Utility.GetColorFromAppResources(GroctaRes.Resources.ColorPrimary);
                    button.BorderColor = Utility.GetColorFromAppResources(GroctaRes.Resources.ColorPrimaryDark);
                    //button.ButtonFrame.HasShadow = false;
                }
                else if (newTheme == ControlTheme.Dark)
                {
                    button.TintColor = Color.White;
                    button.TextColor = Color.White;
                    button.BorderColor = Color.White;
                    button.ButtonFrame.BackgroundColor = Utility.GetColorFromAppResources(GroctaRes.Resources.ColorPrimary);
                    //button.ButtonFrame.HasShadow = false;
                }
            }
        }

        private static void OnCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ImageTextButton button = (ImageTextButton)bindable;

            if (button != null)
                TouchEff.SetCommand(button.ButtonFrame, newValue as ICommand);
        }

        private static void OnCommandParameterPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ImageTextButton button = (ImageTextButton)bindable;

            if (button != null)
                TouchEffect.TouchEff.SetCommandParameter(button.ButtonFrame, newValue);
        }
        #endregion
    }
}