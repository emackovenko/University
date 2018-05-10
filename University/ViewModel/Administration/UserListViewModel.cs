using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.University;

namespace University.ViewModel.Administration
{
    public class UserListViewModel: ViewModelBase
    {
        public ObservableCollection<User> Users
        {
            get => new ObservableCollection<User>(Session.Data.Users);
        }

        public User SelectedUser { get; set; }
    }
}
