using System;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Internal.WinApi;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using DevExpress.Mvvm;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.Native;
using DevExpress.Xpf.Editors.Flyout;
using DevExpress.Xpf.WindowsUI;
using DevExpress.Xpf.WindowsUI.Navigation;

namespace Beverage_Inventory_Management_System.Views
{
    /// <summary>
    /// Interaction logic for newItemView.xaml
    /// </summary>
    public partial class NewItemView : UserControl
    {
        private string itemCode;
        private string itemBrand;
        private string itemName;
        private string itemBarCode;
        private string itemSize;
        private string itemActualPrice;
        private string itemSalePrice;
        private string itemDescription;
        public MessageBoxResult msgBoxResult;

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        public NewItemView()
        {
            InitializeComponent();

        }
        protected IDocumentOwner DocumentOwner { get; private set; }

        private void SetConnection()
        {
            sql_con = new SQLiteConnection("Data Source=|DataDirectory|Inventory_Management_DB.db;Version=3;New=False;Compress=True;");
        }
        private void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }
        private void barcodeTextEdit_EditValueChanging(object sender, DevExpress.Xpf.Editors.EditValueChangingEventArgs e)
        {
            BarcodeEdit.EditValue = ItemBarcodeTextEdit.Text;
        }

        private void simpleButton_Click(object sender, RoutedEventArgs e)
        {
            flyoutControl.IsOpen = true;
            flyoutControl.PlacementTarget = sender as UIElement;
            
        }

        private void flyoutButton_Click(object sender, RoutedEventArgs e)
        {
            flyoutControl.IsOpen = false;
            ItemSizeComboBox.Items.Add(newItemSizeUnitTextEdit.Text+" "+newItemSizeComboBox.SelectedItemValue);
            ItemSizeComboBox.RefreshData();}

        private void cancelNewItemSizeButton_Click(object sender, RoutedEventArgs e)
        {
            flyoutControl.IsOpen = false;
        }

        private void ItemSaveButton_Click(object sender, RoutedEventArgs e)
        {

            WinUIMessageBox.Show("Are you sure you want to cancel without save?",
                                     "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        }


        private void ItemCancelButton_Click(object sender, RoutedEventArgs e)
        {
            
        
                        msgBoxResult = WinUIMessageBox.Show("Are you sure you want to cancel without save?",
                                     "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (msgBoxResult == MessageBoxResult.Yes)
            {
                
                //NewItemNavigationFrame.Navigate("ItemsView");
                //NewItemNavigationFrame.Navigate(new ItemsView());
                //DocumentOwner.close();
                //                 NavigationFrame frame = LayoutHelper.FindParentObject<NavigationFrame>((DependencyObject)sender);
                //                 JournalEntryStack f = ((IJournal)frame.Journal).BackStack as JournalEntryStack;
                //                 f.Clear();

                //                 var ownerFrame = LayoutHelper.FindLayoutOrVisualParentObject<NavigationFrame>(sender as DependencyObject, false);
                //                 ownerFrame.Journal.GoBack(); 
                //NewItemNavigationFrame.ClearCache();
                
                //                 var backStack = LayoutHelper.FindParentObject<INavigationFrame>(this).Journal.BackStack;
                //                 var backStackType = backStack.GetType();
                //                 var PopMethodInfo = backStackType.GetMethod("Pop", BindingFlags.Instance | BindingFlags.Public);
                //                 PopMethodInfo.Invoke(backStack, new Object[] {});

            }

            
        }
    }

    public interface IDocumentOwner
    {
        //
        // Summary:
        //     Closes the specified document.
        //
        // Parameters:
        //   documentContent:
        //     An DevExpress.Mvvm.IDocument implementation to be closed.
        //
        //   force:
        //     true, to disable the confirmation logic; otherwise, false.
        
    }
}
