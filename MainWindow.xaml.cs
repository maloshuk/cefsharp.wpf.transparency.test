using CefSharp;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCefTransparency
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
          //  InitializeCef();
            InitializeComponent();

            var b = new CefSharp.Wpf.ChromiumWebBrowser(); 

            ChrWb.Loaded += (e, a) =>
            {
                var addr = string.Format("file://{0}/transptest/index.html", System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                ChrWb.Address = addr;
            };
            ChrWb2.Loaded += (e, a) =>
            {
                var addr = string.Format("file://{0}/transptest/semitransparent.png", System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                ChrWb2.Address = addr;
            };

            ChrWb3.Loaded += (e, a) =>
            {
                var addr = string.Format("file://{0}/transptest/gradient.html", System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                ChrWb3.Address = addr;
            };

        }

        public static void InitializeCef()
        {
            if (Cef.IsInitialized)
                return;
            var set = new CefSettings();
            set.SetOffScreenRenderingBestPerformanceArgs();
            set.BackgroundColor = Cef.ColorSetARGB(0, 255, 255, 255);
            Cef.Initialize(set, performDependencyCheck: true, browserProcessHandler: null);
        }
    }
}
