﻿using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WpfFrameDemo_BasePage
{
    /// <summary>
    /// Interaction logic for SimpleChat.xaml
    /// </summary>
    public partial class SimpleChat : BasePage
    {
        public SimpleChat()
        {
            InitializeComponent();
        }

        private void btnCall_Click(object sender, RoutedEventArgs e)
        {
            string param = txtParam.Text;
            ParentWindow.CallFromChild(param);
        }
    }
}
