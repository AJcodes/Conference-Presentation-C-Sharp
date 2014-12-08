﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Clara.ClientForms
{
    /// <summary>
    /// Interaction logic for ButtonMemo.xaml
    /// </summary>
    public partial class ButtonMemo : UserControl
    {
        private Memo memo;

        public ButtonMemo()
        {
            InitializeComponent();
        }

        private void UserControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            memo = new Memo();
            memo.Show();
        }
    }
}
