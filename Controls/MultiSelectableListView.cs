using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MVVMFilterableList.Controls
{
    class MultiSelectableListView : ListView
    {
        public MultiSelectableListView()
        {
            this.SelectionChanged += CustomDataGrid_SelectionChanged;
        }

        void CustomDataGrid_SelectionChanged (object sender, SelectionChangedEventArgs e)
        {
            this.SelectedItemsList = this.SelectedItems;
        }

        #region SelectedItemsList
        public IList SelectedItemsList
        {
            get { return (IList)GetValue (SelectedItemsListProperty); }
            set { SetValue (SelectedItemsListProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemsListProperty =
                DependencyProperty
                    .Register("SelectedItemsList", 
                                typeof(IList), 
                                typeof(MultiSelectableListView),
                                new FrameworkPropertyMetadata((IList)null));
        #endregion
    }
}
