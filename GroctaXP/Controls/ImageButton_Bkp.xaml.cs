using GroctaXP.Extensions.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GroctaXP.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageButton_Bkp : ContentView
    {
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(ImageButton), default(string));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public event EventHandler Clicked;

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(ImageButton), null);
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParamsProperty =
            BindableProperty.Create("CommandParams", typeof(object), typeof(ImageButton), null);
        public object CommandParams
        {
            get { return (object)GetValue(CommandParamsProperty); }
            set { SetValue(CommandParamsProperty, value); }
        }

        public static readonly BindableProperty SvgSourceProperty =
            BindableProperty.Create("SourceSvg", typeof(ImageSource), typeof(ImageButton), default(ImageSource),
                BindingMode.TwoWay, propertyChanged: OnSvgSourceChanged);
        public ImageSource SourceSvg
        {
            get { return (ImageSource)GetValue(SvgSourceProperty); }
            set { SetValue(SvgSourceProperty, value); }
        }

        public static readonly BindableProperty ImageSourceProperty =
            BindableProperty.Create("SourcePng", typeof(ImageSource), typeof(ImageButton), default(ImageSource), 
                BindingMode.TwoWay, propertyChanged: OnPngSourceChanged);
        public ImageSource SourcePng
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly BindableProperty TintColorProperty =
            BindableProperty.Create("TintColor", typeof(Color), typeof(Color), Color.Black,
                BindingMode.TwoWay, propertyChanged: OnTintColorChanged);
        public Color TintColor
        {
            get { return (Color)GetValue(TintColorProperty); }
            set { SetValue(TintColorProperty, value); }
        }

        public ImageButton_Bkp()
        {
            InitializeComponent();

            ButtonText.SetBinding(Label.TextProperty, new Binding("Text", source: this));
            ButtonIconPng.SetBinding(Image.SourceProperty, new Binding("SourcePng", source: this));
            ButtonIconSvg.SetBinding(SvgImage.SourceProperty, new Binding("SourceSvg", source: this));

            this.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Clicked?.Invoke(this, EventArgs.Empty);

                    if (Command != null)
                    {
                        if (Command.CanExecute(CommandParams))
                            Command.Execute(CommandParams);
                    }
                })
            });
        }

        private static void OnPngSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ImageButton control = (ImageButton)bindable;
            control.ButtonIconPng.IsVisible = true;
        }

        private static void OnSvgSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ImageButton control = (ImageButton)bindable;
            control.ButtonIconSvg.IsVisible = true;
        }

        private static void OnTintColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ImageButton control = (ImageButton)bindable;

            if (control.ButtonIconSvg.IsVisible)
                control.ButtonIconSvg.Color = (Color)newValue;
            else if (control.ButtonIconPng.IsVisible)
            {
                //control.ButtonIconPng.Effects.Add(Effect.Resolve(
                //    $"{ImageTint.GroupName}.{nameof(ImageTint)}"));

                ImageTint effect = (ImageTint)control.ButtonIconPng.Effects.FirstOrDefault(
                    e => e is ImageTint);
                effect.TintColor = (Color)newValue;
            }
        }
    }
}