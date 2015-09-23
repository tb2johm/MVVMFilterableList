using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMVVM.ViewModelBase;
using MVVMFilterableList.Model;
using System.Collections;


namespace MVVMFilterableList.ViewModel
{
    public class UsersViewModel : ViewModelBase
    {
        public UsersViewModel()
        {
            AllUsers = new ObservableCollection<User>();
            FilteredParents = new ObservableCollection<User>();
            UserRepository.GetUsers().ForEach(x => AllUsers.Add(x));
        }

        private List<User> _selectedUsers;
        public IList SelectedUsers
        {
            get { return _selectedUsers; }
            set
            {
                if (value == null) 
                    return;

                try
                {
                    var theValue = value.Cast<User>().ToList();
                    if (theValue == _selectedUsers) return;

                    _selectedUsers = theValue;
                    Notify("SelectedUsers");
                    _parents.Clear();

                    var parents = _selectedUsers.SelectMany(x => x.Parents);
                    parents.ToList().ForEach(x => _parents.Add(x));

                    UpdateFilter();
                }
                catch (Exception)
                {                    
                }
            }
        }

        private string _filterText;
        public string FilterText
        {
            get { return _filterText; }
            set
            {
                if (value == _filterText) return;

                _filterText = value;
                Notify("FilterText");
                UpdateFilter();
            }
        }

        private void UpdateFilter()
        {
            FilteredParents.Clear();
            if (!String.IsNullOrEmpty(FilterText))
            {
                _parents.Where(x => x.UserName.Contains(FilterText)).ToList().ForEach(x => FilteredParents.Add(x));
            }
            else
            {
                _parents.ForEach(x => FilteredParents.Add(x));
            }
        }

        public ObservableCollection<User> AllUsers { get; set; }
        
        private readonly List<User> _parents = new List<User>(); 
        public ObservableCollection<User> FilteredParents { get; set; }
    }
}
