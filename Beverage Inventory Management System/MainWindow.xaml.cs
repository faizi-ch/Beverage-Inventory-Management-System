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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.Layout.Core;

namespace Beverage_Inventory_Management_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DXWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NavBarItem_Click(object sender, EventArgs e)
        {
            addItemPanel.Closed = false;
            dockLayoutManager.DockController.Activate(addItemPanel);
            //dockLayoutManager.DockController.AddItem(addItemPanel,layoutGroupRight,DockType.Fill);
            //layoutGroupRight.AllowExpand = true;
            //dockLayoutManager.DockController.CloseAllButThis(addItemPanel);
            //dockLayoutManager.DockController.Dock(addItemPanel, layoutGroupRight, DockType.Fill);
            
        }
    }
}