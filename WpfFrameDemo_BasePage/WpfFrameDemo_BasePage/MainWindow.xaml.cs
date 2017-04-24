using System;
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
using System.Reflection;

namespace WpfFrameDemo_BasePage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Navigate("Home");
        }

        #region Page Navigate
        private void btnNav_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Navigate(btn.Tag.ToString());
        }
        private void Navigate(string path)
        {
            string uri = "WpfFrameDemo_BasePage." + path;
            Type type = Type.GetType(uri);
            if (type != null)
            {
                //实例化Page页
                object obj = type.Assembly.CreateInstance(uri);
                UserControl control = obj as UserControl;
                this.frmMain.Content = control;
                PropertyInfo[] infos = type.GetProperties();
                foreach (PropertyInfo info in infos)
                {
                    //将MainWindow设为page页的ParentWin
                    if (info.Name == "ParentWindow")
                    {
                        info.SetValue(control, this, null);
                        break;
                    }
                }
            }
        }

        #endregion

        //公共方法
        public void CallFromChild(string name)
        {
            MessageBox.Show("Hello," + name + "!");
        }
    }
}
