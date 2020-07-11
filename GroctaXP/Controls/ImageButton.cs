using GroctaXP.Utils;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using GroctaRes = GroctaXP.Resources;

namespace GroctaXP.Controls
{
    public partial class ImageButton : View
    {
        #region Property Text
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(ImageButton), default(string));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        #endregion

        #region Property Text Color
        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create("TextColor", typeof(Color), typeof(ImageButton));
        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }
        #endregion

        #region Property Icon Size
        public static readonly BindableProperty IconSizeProperty =
            BindableProperty.Create("IconSize", typeof(int), typeof(ImageButton));
        public int IconSize
        {
            get { return (int)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }
        #endregion

        #region Property Command
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(ImageButton), null,
                BindingMode.TwoWay, propertyChanged: OnCommandChanged);
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public event EventHandler Clicked;

        private static void OnCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (ImageButton)bindable;

            // this gesture recognizer will inovke the command event whereever it is used
            control.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = (Command)newValue,
                CommandParameter = control.CommandParams
            });
        }
        #endregion

        #region Property Command Params
        public static readonly BindableProperty CommandParamsProperty =
            BindableProperty.Create("CommandParams", typeof(object), typeof(ImageButton), null);
        public object CommandParams
        {
            get { return (object)GetValue(CommandParamsProperty); }
            set { SetValue(CommandParamsProperty, value); }
        }
        #endregion

        #region Property Source
        public static readonly BindableProperty ImageSourceProperty =
           BindableProperty.Create("Source", typeof(ImageSource), typeof(ImageButton), default(ImageSource));
        public ImageSource Source
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        #endregion

        #region Property Tint Color
        public static readonly BindableProperty TintColorProperty =
            BindableProperty.Create("TintColor", typeof(Color), typeof(ImageButton));
        public Color TintColor
        {
            get { return (Color)GetValue(TintColorProperty); }
            set { SetValue(TintColorProperty, value); }
        }
        #endregion

        #region Property Inner Padding
        public static readonly BindableProperty InnerPaddingProperty =
            BindableProperty.Create("InnerPadding", typeof(int), typeof(ImageButton), default(int));
        public int InnerPadding
        {
            get { return (int)GetValue(InnerPaddingProperty); }
            set { SetValue(InnerPaddingProperty, value); }
        }
        #endregion

        public ImageButton()
        {
            this.Text = GroctaRes.Resources.ImageButtonText;
            this.InnerPadding = 10;
            this.IconSize = 26; 
            this.TintColor = Color.Transparent;
            this.TextColor = Utility.GetColorFromAppResources(GroctaRes.Resources.ColorPrimary);
        }

        public void RaiseCommand()
        {
            Clicked?.Invoke(this, EventArgs.Empty);

            if (Command != null && Command.CanExecute(CommandParams))
                Command.Execute(CommandParams);
        }
    }
}