using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using Clara.Base;

namespace Clara
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            App.Current.DispatcherUnhandledException +=
                new System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(ApplicationDispatcherUnhandledException);

            AppDomain.CurrentDomain.UnhandledException +=
                      new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            E.Init();
        }

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            iFr.CommandLineArgumentsParser comm = new iFr.CommandLineArgumentsParser(e.Args);


            //if (comm["mwi"] != null) WidgetPackage.UnpackWidget(comm["mwi"]);

            StartupUri = new Uri("Windows/MainWindow.xaml", UriKind.Relative);

            //WindowManager = new WindowManager();
            //WidgetManager = new WidgetManager();
            //WidgetManager.FindWidgets();

            //if (Settings.LoadedWidgets.Count == 0) Settings.LoadedWidgets.Add(new LoadedWidget() { Name = "Clock" });
        }

        private void ApplicationExit(object sender, ExitEventArgs e)
        {
            //if (WindowManager == null) return;

            //foreach (var widget in WidgetManager.Widgets)
            //{ if (widget.IsLoaded) widget.Unload(); }

        }


        private void ApplicationDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            E.Play(new Uri("Cache\\Sounds\\Windows Error.wav", UriKind.RelativeOrAbsolute));

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine();
                sb.AppendLine("----------------------------------------------------------------");
                sb.AppendLine(DateTime.Now.ToString());
                sb.AppendLine("----------------------------------------------------------------");
                sb.AppendLine(e.Exception.Message);
                if (e.Exception.StackTrace != null)
                {
                    sb.AppendLine();
                    sb.AppendLine(e.Exception.StackTrace);
                    sb.AppendLine();
                }
                if (e.Exception.InnerException != null && e.Exception.InnerException.Message != null)
                {
                    sb.AppendLine();
                    sb.AppendLine(e.Exception.InnerException.Message);
                    sb.AppendLine();
                }
                sb.AppendLine("----------------------------------------------------------------");

                File.AppendAllText(E.ErrorLog, sb.ToString());

            }
            catch { }

            e.Handled = true;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            E.Play(new Uri("Cache\\Sounds\\Windows Error.wav", UriKind.RelativeOrAbsolute));

            try
            {
                Exception ex = e.ExceptionObject as Exception; StringBuilder sb = new StringBuilder();
                sb.AppendLine();
                sb.AppendLine("----------------------------------------------------------------");
                sb.AppendLine(DateTime.Now.ToString());
                sb.AppendLine("----------------------------------------------------------------");
                sb.AppendLine(ex.Message);
                if (ex.StackTrace != null)
                {
                    sb.AppendLine();
                    sb.AppendLine(ex.StackTrace);
                    sb.AppendLine();
                }
                if (ex.InnerException != null && ex.InnerException.Message != null)
                {
                    sb.AppendLine();
                    sb.AppendLine(ex.InnerException.Message);
                    sb.AppendLine();
                }
                sb.AppendLine("----------------------------------------------------------------");

                File.AppendAllText(E.ErrorLog, sb.ToString());

            }
            catch { }
        }

    }
}
