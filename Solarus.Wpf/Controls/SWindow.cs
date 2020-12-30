using Solarus.Wpf.Extensions;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Solarus.Wpf.Controls
{
    [TemplatePart(Name = TitleBarName, Type = typeof(Grid))]
    [TemplatePart(Name = IconName, Type = typeof(Image))]
    public class SWindow : Window
    {
        #region Dependency Properties

        public static readonly DependencyProperty IconSizeProperty = DependencyProperty.Register(
            "IconSize",
            typeof(int),
            typeof(SWindow),
            new PropertyMetadata(20));

        public static readonly DependencyProperty InactiveBorderBrushProperty = DependencyProperty.Register(
             "InactiveBorderBrush",
             typeof(Brush),
             typeof(SWindow),
             new PropertyMetadata(new SolidColorBrush(Colors.Gray)));

        public static readonly DependencyProperty TitleBarHeightProperty = DependencyProperty.Register(
            "TitleBarHeight",
            typeof(int),
            typeof(SWindow),
            new PropertyMetadata(30));

        public static readonly DependencyProperty TitleBarBackgroundBrushProperty = DependencyProperty.Register(
            "TitleBarBackgroundBrush",
            typeof(Brush),
            typeof(SWindow),
            new PropertyMetadata(new SolidColorBrush(Colors.White)));

        public static readonly DependencyProperty TitleBarContentProperty = DependencyProperty.Register(
            "TitleBarContent",
            typeof(object),
            typeof(SWindow),
            new PropertyMetadata(null));

        public static readonly DependencyProperty TitleBarForegroundBrushProperty = DependencyProperty.Register(
            "TitleBarForegroundBrush",
            typeof(Brush),
            typeof(SWindow),
            new PropertyMetadata(new SolidColorBrush(Colors.Black)));

        public static readonly DependencyProperty TitleBarInactiveForegroundBrushProperty = DependencyProperty.Register(
            "TitleBarInactiveForegroundBrush",
            typeof(Brush),
            typeof(SWindow),
            new PropertyMetadata(new SolidColorBrush(Colors.Gray)));

        public static readonly DependencyProperty TitleBarFontFamilyProperty = DependencyProperty.Register(
            "TitleBarFontFamily",
            typeof(FontFamily),
            typeof(SWindow),
            new PropertyMetadata(new FontFamily("Segoe UI")));

        public static readonly DependencyProperty TitleBarFontSizeProperty = DependencyProperty.Register(
            "TitleBarFontSize",
            typeof(double),
            typeof(SWindow),
            new PropertyMetadata(12.0));

        public static readonly DependencyProperty TitleBarButtonWidthProperty = DependencyProperty.Register(
            "TitleBarButtonWidth",
            typeof(double),
            typeof(SWindow),
            new PropertyMetadata(45.0));

        public static readonly DependencyProperty TitleBarButtonPathSizeProperty = DependencyProperty.Register(
            "TitleBarButtonPathSize",
            typeof(double),
            typeof(SWindow),
            new PropertyMetadata(11.0));

        public static readonly DependencyProperty TitleBarButtonMouseOverBackgroundBrushProperty = DependencyProperty.Register(
            "TitleBarButtonMouseOverBackgroundBrush",
            typeof(Brush),
            typeof(SWindow),
            new PropertyMetadata(new SolidColorBrush(Colors.LightGray)));

        public static readonly DependencyProperty TitleBarButtonMouseOverForegroundBrushProperty = DependencyProperty.Register(
            "TitleBarButtonMouseOverForegroundBrush",
            typeof(Brush),
            typeof(SWindow),
            new PropertyMetadata(new SolidColorBrush(Colors.Black)));

        public static readonly DependencyProperty TitleBarButtonPressedBackgroundBrushProperty = DependencyProperty.Register(
            "TitleBarButtonPressedBackgroundBrush",
            typeof(Brush),
            typeof(SWindow),
            new PropertyMetadata(new SolidColorBrush(Colors.DarkGray)));

        public static readonly DependencyProperty TitleBarButtonPressedForegroundBrushProperty = DependencyProperty.Register(
            "TitleBarButtonPressedForegroundBrush",
            typeof(Brush),
            typeof(SWindow),
            new PropertyMetadata(new SolidColorBrush(Colors.Black)));

        public static readonly DependencyProperty MinimizeGeometryProperty = DependencyProperty.Register(
            "MinimizeGeometry",
            typeof(Geometry),
            typeof(SWindow),
            new PropertyMetadata(Geometry.Parse("M 18,15 H 28")));

        public static readonly DependencyProperty MaximizeGeometryProperty = DependencyProperty.Register(
            "MaximizeGeometry",
            typeof(Geometry),
            typeof(SWindow),
            new PropertyMetadata(Geometry.Parse("M 18.5,10.5 H 27.5 V 19.5 H 18.5 Z")));

        public static readonly DependencyProperty RestoreGeometryProperty = DependencyProperty.Register(
            "RestoreGeometry",
            typeof(Geometry),
            typeof(SWindow),
            new PropertyMetadata(Geometry.Parse("M 18.5,12.5 H 25.5 V 19.5 H 18.5 Z M 20.5,12.5 V 10.5 H 27.5 V 17.5 H 25.5")));

        public static readonly DependencyProperty CloseGeometryProperty = DependencyProperty.Register(
            "CloseGeometry",
            typeof(Geometry),
            typeof(SWindow),
            new PropertyMetadata(Geometry.Parse("M 18,11 27,20 M 18,20 27,11")));

        public static readonly DependencyProperty ShowIconProperty = DependencyProperty.Register(
            "ShowIcon",
            typeof(bool),
            typeof(SWindow),
            new PropertyMetadata(true));

        public static readonly DependencyProperty ShowTitleProperty = DependencyProperty.Register(
            "ShowTitle",
            typeof(bool),
            typeof(SWindow),
            new PropertyMetadata(true));

        public static readonly DependencyProperty ShowMinimizeButtonProperty = DependencyProperty.Register(
            "ShowMinimizeButton",
            typeof(bool),
            typeof(SWindow),
            new PropertyMetadata(true));

        public static readonly DependencyProperty ShowMaximizeRestoreButtonProperty = DependencyProperty.Register(
            "ShowMaximizeRestoreButton",
            typeof(bool),
            typeof(SWindow),
            new PropertyMetadata(true));

        public static readonly DependencyProperty ShowCloseButtonProperty = DependencyProperty.Register(
            "ShowCloseButton",
            typeof(bool),
            typeof(SWindow),
            new PropertyMetadata(true));

        #endregion Dependency Properties

        #region Fields

        private const string TitleBarName = "PART_TitleBar";
        private const string IconName = "PART_Icon";

        private Grid _titleBar;
        private Image _icon;

        #endregion Fields

        #region Constructors

        static SWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SWindow),
                new FrameworkPropertyMetadata(typeof(SWindow)));
        }

        public SWindow()
        {
            CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand, OnCloseWindow));
            CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand, OnMaximizeWindow));
            CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand, OnMinimizeWindow));
            CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand, OnRestoreWindow));
        }

        #endregion Constructors

        #region Properties

        public int IconSize
        {
            get { return (int)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }

        public Brush InactiveBorderBrush
        {
            get { return (Brush)GetValue(InactiveBorderBrushProperty); }
            set { SetValue(InactiveBorderBrushProperty, value); }
        }

        public int TitleBarHeight
        {
            get { return (int)GetValue(TitleBarHeightProperty); }
            set { SetValue(TitleBarHeightProperty, value); }
        }

        public Brush TitleBarBackgroundBrush
        {
            get { return (Brush)GetValue(TitleBarBackgroundBrushProperty); }
            set { SetValue(TitleBarBackgroundBrushProperty, value); }
        }

        public Brush TitleBarForegroundBrush
        {
            get { return (Brush)GetValue(TitleBarForegroundBrushProperty); }
            set { SetValue(TitleBarForegroundBrushProperty, value); }
        }

        public Brush TitleBarInactiveForegroundBrush
        {
            get { return (Brush)GetValue(TitleBarInactiveForegroundBrushProperty); }
            set { SetValue(TitleBarInactiveForegroundBrushProperty, value); }
        }

        public FontFamily TitleBarFontFamily
        {
            get { return (FontFamily)GetValue(TitleBarFontFamilyProperty); }
            set { SetValue(TitleBarFontFamilyProperty, value); }
        }

        public double TitleBarFontSize
        {
            get { return (double)GetValue(TitleBarFontSizeProperty); }
            set { SetValue(TitleBarFontSizeProperty, value); }
        }

        public double TitleBarButtonWidth
        {
            get { return (double)GetValue(TitleBarButtonWidthProperty); }
            set { SetValue(TitleBarButtonWidthProperty, value); }
        }

        public double TitleBarButtonPathSize
        {
            get { return (double)GetValue(TitleBarButtonPathSizeProperty); }
            set { SetValue(TitleBarButtonPathSizeProperty, value); }
        }

        public Brush TitleBarButtonMouseOverBackgroundBrush
        {
            get { return (Brush)GetValue(TitleBarButtonMouseOverBackgroundBrushProperty); }
            set { SetValue(TitleBarButtonMouseOverBackgroundBrushProperty, value); }
        }

        public Brush TitleBarButtonMouseOverForegroundBrush
        {
            get { return (Brush)GetValue(TitleBarButtonMouseOverForegroundBrushProperty); }
            set { SetValue(TitleBarButtonMouseOverForegroundBrushProperty, value); }
        }

        public Brush TitleBarButtonPressedBackgroundBrush
        {
            get { return (Brush)GetValue(TitleBarButtonPressedBackgroundBrushProperty); }
            set { SetValue(TitleBarButtonPressedBackgroundBrushProperty, value); }
        }

        public Brush TitleBarButtonPressedForegroundBrush
        {
            get { return (Brush)GetValue(TitleBarButtonPressedForegroundBrushProperty); }
            set { SetValue(TitleBarButtonPressedForegroundBrushProperty, value); }
        }

        public object TitleBarContent
        {
            get { return GetValue(TitleBarContentProperty); }
            set { SetValue(TitleBarContentProperty, value); }
        }

        public Geometry MinimizeGeometry
        {
            get { return (Geometry)GetValue(MinimizeGeometryProperty); }
            set { SetValue(MinimizeGeometryProperty, value); }
        }

        public Geometry MaximizeGeometry
        {
            get { return (Geometry)GetValue(MaximizeGeometryProperty); }
            set { SetValue(MaximizeGeometryProperty, value); }
        }

        public Geometry RestoreGeometry
        {
            get { return (Geometry)GetValue(RestoreGeometryProperty); }
            set { SetValue(RestoreGeometryProperty, value); }
        }

        public Geometry CloseGeometry
        {
            get { return (Geometry)GetValue(CloseGeometryProperty); }
            set { SetValue(CloseGeometryProperty, value); }
        }

        public bool ShowIcon
        {
            get { return (bool)GetValue(ShowIconProperty); }
            set { SetValue(ShowIconProperty, value); }
        }

        public bool ShowTitle
        {
            get { return (bool)GetValue(ShowTitleProperty); }
            set { SetValue(ShowTitleProperty, value); }
        }

        public bool ShowMinimizeButton
        {
            get { return (bool)GetValue(ShowMinimizeButtonProperty); }
            set { SetValue(ShowMinimizeButtonProperty, value); }
        }

        public bool ShowMaximizeRestoreButton
        {
            get { return (bool)GetValue(ShowMaximizeRestoreButtonProperty); }
            set { SetValue(ShowMaximizeRestoreButtonProperty, value); }
        }

        public bool ShowCloseButton
        {
            get { return (bool)GetValue(ShowCloseButtonProperty); }
            set { SetValue(ShowCloseButtonProperty, value); }
        }

        #endregion Properties

        #region Methods

        public override void OnApplyTemplate()
        {
            _titleBar = (Grid)GetTemplateChild(TitleBarName);
            _icon = (Image)GetTemplateChild(IconName);

            _icon?.AddHandler(MouseDownEvent, new MouseButtonEventHandler(OnIconMouseDown));

            base.OnApplyTemplate();
        }

        protected override void OnInitialized(EventArgs e)
        {
            SourceInitialized += OnSourceInitialized;

            base.OnInitialized(e);
        }

        private void OnSourceInitialized(object sender, EventArgs e)
        {
            if (Icon == null)
            {
                SetDefaultIcon();
            }

            InvalidateMeasure();
            SourceInitialized -= OnSourceInitialized;
        }

        private void OnIconMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && e.ClickCount == 2)
            {
                Close();
            }
            else
            {
                ShowSystemMenu();
            }
        }

        private void OnCloseWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }

        private void OnMaximizeWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MaximizeWindow(this);
        }

        private void OnMinimizeWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        private void OnRestoreWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.RestoreWindow(this);
        }

        private void SetDefaultIcon()
        {
            string assembly = Assembly.GetEntryAssembly().Location.Replace(".dll", ".exe");
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(assembly).ToImageSource();
        }

        private void ShowSystemMenu()
        {
            Matrix transform = PresentationSource.FromVisual(this).CompositionTarget.TransformFromDevice;
            Rect r = _titleBar.GetAbsolutePosition(true);
            Point p = transform.Transform(r.BottomLeft);
            p.Y += 6;

            SystemCommands.ShowSystemMenu(this, p);
        }

        #endregion Methods
    }
}
