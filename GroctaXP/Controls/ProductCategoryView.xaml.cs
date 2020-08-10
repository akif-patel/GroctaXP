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
    public partial class ProductCategoryView : ContentView
    {
        #region Property Category Name
        public static readonly BindableProperty CategoryNameProperty =
            BindableProperty.Create("CategoryName", typeof(string), typeof(ProductCategoryView), "CategoryName",
                BindingMode.TwoWay, propertyChanged: OnCategoryNamePropertyChanged);
        public string CategoryName
        {
            get { return (string)GetValue(CategoryNameProperty); }
            set { SetValue(CategoryNameProperty, value); }
        }
        #endregion

        #region Property Image
        public static readonly BindableProperty ImageProperty =
            BindableProperty.Create("Image", typeof(string), typeof(ProductCategoryView), default(string),
                BindingMode.TwoWay, propertyChanged: OnImagePropertyChanged);
        public string Image
        {
            get { return (string)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
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

        public ProductCategoryView()
        {
            InitializeComponent();
        }

        #region On Properties Changed Event Handlers
        private static void OnCategoryNamePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ProductCategoryView view = (ProductCategoryView)bindable;
            if (view != null)
                view.LableCategoryName.Text = (string)newValue;
        }

        private static void OnImagePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ProductCategoryView view = (ProductCategoryView)bindable;
            if (view != null)
                view.ImageCategory.Source = (string)newValue;
        }

        private static void OnCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ProductCategoryView view = (ProductCategoryView)bindable;

            if (view != null)
                TouchEffect.TouchEff.SetCommand(view.FrameCategoryView, (ICommand)newValue);
        }

        private static void OnCommandParameterPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ProductCategoryView view = (ProductCategoryView)bindable;

            if (view != null)
                TouchEffect.TouchEff.SetCommandParameter(view.FrameCategoryView, newValue);
        }
        #endregion
    }
}