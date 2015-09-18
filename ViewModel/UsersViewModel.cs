using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMVVM.ViewModelBase;
using MVVMFilterableList.Model;


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

        private User _selectedUser;
        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                if (value == _selectedUser) return;
                
                _selectedUser = value;
                Notify("SelectedUser");
                _parents.Clear();
                
                if (_selectedUser.Parents != null) _selectedUser.Parents.ForEach(x => _parents.Add(x));

                UpdateFilter();
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
