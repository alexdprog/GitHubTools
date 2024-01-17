using GitHubTools.CoreApplication.Enums;

namespace GitHubTools.App.Controls
{
    /// <summary>
    /// виджет нотификации внутри чего-то (не попап сам по себе)
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InlineNotification : ContentView
    {
        /// <summary>
        /// тип нотификации
        /// </summary>
        public static readonly BindableProperty NotificationTypeProperty = BindableProperty.Create(
            propertyName: "NotificationType",
            returnType: typeof(NotificationType),
            declaringType: typeof(InlineNotification),
            defaultValue: NotificationType.Information,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: NotificationTypePropertyChanged);

        /// <summary>
        /// текст
        /// </summary>
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: "Text",
            returnType: typeof(string),
            declaringType: typeof(InlineNotification),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: TextPropertyChanged);

        private static void TextPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var control = (InlineNotification)bindable;
            control.Text = Convert.ToString(newvalue);
        }

        private NotificationType _notificationType;

        private static void NotificationTypePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var control = (InlineNotification)bindable;
            control.NotificationType = (NotificationType)newvalue;
        }

        /// <summary>
        /// конструктор
        /// </summary>
        public InlineNotification()
        {
            InitializeComponent();
            NotificationType = NotificationType.Information;
        }

        /// <summary>
        /// тип нотификации
        /// </summary>
        public NotificationType NotificationType
        {
            get { return _notificationType; }
            set
            {
                if (_notificationType != value)
                {
                    _notificationType = value;
                    AdjustColors();
                }
            }
        }

        /// <summary>
        /// текст
        /// </summary>
        public string Text
        {
            get { return NotificationText.Text; }
            set
            {
                NotificationText.Text = value;
            }
        }

        private static Color _warningBackgroundColor = Color.FromHex("#F2BEBE");
        private static Color _infoBackgroundColor = Color.FromHex("#B0D7EF");
        private static Color _successBackgroundColor = Color.FromHex("#97d691");

        private void AdjustColors()
        {
            switch (NotificationType)
            {
                case NotificationType.Information:
                    NotificationContainer.BackgroundColor = _infoBackgroundColor;
                    break;
                case NotificationType.Success:
                    NotificationContainer.BackgroundColor = _successBackgroundColor;
                    break;
                case NotificationType.Warning:
                    NotificationContainer.BackgroundColor = _warningBackgroundColor;
                    break;
            }
        }
    }
}