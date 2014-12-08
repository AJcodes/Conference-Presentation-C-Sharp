using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Ink;

namespace Clara.HostForms
{
    /// <summary>
    /// Interaction logic for DrawScreen.xaml
    /// </summary>
    public partial class DrawScreen : Window
    {
        public DrawScreen()
        {
            InitializeComponent();
            this.Top = 0;
            this.Left = 0;
            this.Width = SystemParameters.PrimaryScreenWidth;
            this.Height = SystemParameters.PrimaryScreenHeight;
        }

        private void Close_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Erase_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DrawingPad.EditingMode = InkCanvasEditingMode.EraseByPoint;
            DrawingPad.EraserShape = new EllipseStylusShape(50, 50);
        }

        private void Draw_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DrawingPad.EditingMode = InkCanvasEditingMode.Ink;
        }
    }
}
