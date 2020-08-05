using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TouchEffect;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GroctaXP.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecentOrderView : ContentView
    {
        #region Property Order Number
        public static readonly BindableProperty OrderNumberProperty =
            BindableProperty.Create("OrderNumber", typeof(string), typeof(RecentOrderView), string.Empty,
                BindingMode.TwoWay, propertyChanged: OnOrderNumberPropertyChanged);
        public string OrderNumber
        {
            get { return (string)GetValue(OrderNumberProperty); }
            set { SetValue(OrderNumberProperty, value); }
        }
        #endregion

        #region Property Date
        public static readonly BindableProperty DateProperty =
            BindableProperty.Create("Date", typeof(string), typeof(RecentOrderView), string.Empty,
                BindingMode.TwoWay, propertyChanged: OnDatePropertyChanged);
        public string Date
        {
            get { return (string)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }
        #endregion

        #region Property Status
        public static readonly BindableProperty StatusProperty =
            BindableProperty.Create("OrderStatus", typeof(string), typeof(RecentOrderView), string.Empty,
                BindingMode.TwoWay, propertyChanged: OnStatusPropertyChanged);
        public string Status
        {
            get { return (string)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }
        #endregion

        #region Property Quantities
        public static readonly BindableProperty QuantitiesProperty =
            BindableProperty.Create("Quantities", typeof(string), typeof(RecentOrderView), string.Empty,
                BindingMode.TwoWay, propertyChanged: OnQuantitiesPropertyChanged);
        public string Quantities
        {
            get { return (string)GetValue(QuantitiesProperty); }
            set { SetValue(QuantitiesProperty, value); }
        }
        #endregion

        #region Property Amount
        public static readonly BindableProperty AmountProperty =
            BindableProperty.Create("Amount", typeof(string), typeof(RecentOrderView), string.Empty,
                BindingMode.TwoWay, propertyChanged: OnAmountPropertyChanged);
        public string Amount
        {
            get { return (string)GetValue(AmountProperty); }
            set { SetValue(AmountProperty, value); }
        }
        #endregion

        #region Property Is Last In List
        public static readonly BindableProperty IsLastInListProperty =
            BindableProperty.Create("IsLastInList", typeof(bool), typeof(RecentOrderView), false,
                BindingMode.TwoWay, propertyChanged: OnIsLastInListPropertyChanged);
        public bool IsLastInList
        {
            get { return (bool)GetValue(IsLastInListProperty); }
            set { SetValue(IsLastInListProperty, value); }
        }
        #endregion

        #region Property Order Details Command
        public static readonly BindableProperty OrderDetailsCommandProperty =
            BindableProperty.Create("OrderDetailsCommand", typeof(ICommand), typeof(RecentOrderView), default(ICommand),
                BindingMode.TwoWay, propertyChanged: OnOrderDetailsCommandPropertyChanged);
        public ICommand OrderDetailsCommand
        {
            get { return (ICommand)GetValue(OrderDetailsCommandProperty); }
            set { SetValue(OrderDetailsCommandProperty, value); }
        }
        #endregion

        #region Property Order Details Command Params
        public static readonly BindableProperty OrderDetailsCommandParameterProperty =
            BindableProperty.Create("OrderDetailsCommandParameter", typeof(object), typeof(RecentOrderView), null,
                BindingMode.TwoWay, propertyChanged: OnOrderDetailsCommandParameterPropertyChanged);
        public object OrderDetailsCommandParameter
        {
            get { return (object)GetValue(OrderDetailsCommandParameterProperty); }
            set { SetValue(OrderDetailsCommandParameterProperty, value); }
        }
        #endregion

        #region Property Order Support Command
        public static readonly BindableProperty OrderSupportCommandProperty =
            BindableProperty.Create("OrderSupportCommand", typeof(ICommand), typeof(RecentOrderView), default(ICommand),
                BindingMode.TwoWay, propertyChanged: OnOrderSupportCommandPropertyChanged);
        public ICommand OrderSupportCommand
        {
            get { return (ICommand)GetValue(OrderSupportCommandProperty); }
            set { SetValue(OrderSupportCommandProperty, value); }
        }
        #endregion

        #region Property Order Support Command Params
        public static readonly BindableProperty OrderSupportCommandParameterProperty =
            BindableProperty.Create("OrderSupportCommandParameter", typeof(object), typeof(RecentOrderView), null,
                BindingMode.TwoWay, propertyChanged: OnOrderSupportCommandParameterPropertyChanged);
        public object OrderSupportCommandParameter
        {
            get { return (object)GetValue(OrderSupportCommandParameterProperty); }
            set { SetValue(OrderSupportCommandParameterProperty, value); }
        }
        #endregion
        
        public RecentOrderView()
        {
            InitializeComponent();
        }

        #region On Properties Changed Event Handlers
        private static void OnOrderNumberPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            RecentOrderView view = (RecentOrderView)bindable;
            if (view != null)
                view.LabelOrderNumber.Text = (string)newValue;
        }

        private static void OnDatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            RecentOrderView view = (RecentOrderView)bindable;
            if (view != null)
                view.LabelOrderDate.Text = (string)newValue;
        }

        private static void OnStatusPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            RecentOrderView view = (RecentOrderView)bindable;
            if (view != null)
                view.LabelOrderStatus.Text = ((string)newValue).ToUpper();
        }

        private static void OnQuantitiesPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            RecentOrderView view = (RecentOrderView)bindable;
            if (view != null)
                view.LabelQuantities.Text = "Quantities: " + (string)newValue;
        }

        private static void OnAmountPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            RecentOrderView view = (RecentOrderView)bindable;
            if (view != null)
                view.LabelAmount.Text = "Amount: ₹ " + (string)newValue + "/-";
        }

        private static void OnIsLastInListPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            RecentOrderView view = (RecentOrderView)bindable;
            if (view != null)
                view.ViewSeparator.IsVisible = !(bool)newValue;
        }

        private static void OnOrderDetailsCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            RecentOrderView view = (RecentOrderView)bindable;

            if (view != null)
                view.ButtonOrderDetails.Command = (ICommand)newValue;
        }

        private static void OnOrderDetailsCommandParameterPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            RecentOrderView view = (RecentOrderView)bindable;

            if (view != null)
                view.ButtonOrderDetails.CommandParameter = newValue;
        }

        private static void OnOrderSupportCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            RecentOrderView view = (RecentOrderView)bindable;

            if (view != null)
                view.ButtonOrderSupport.Command = (ICommand)newValue;
        }

        private static void OnOrderSupportCommandParameterPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            RecentOrderView view = (RecentOrderView)bindable;

            if (view != null)
                view.ButtonOrderSupport.CommandParameter = newValue;
        }
        #endregion
    }
}