using Gridview_TestApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Gridview_TestApp.ViewModel
{
    public class UserViewModel : ViewmodelBase
    {
        public static UserViewModel _userViewModel;
        public static UserViewModel GetInstanse()
        {
            if (_userViewModel == null)
                _userViewModel = new UserViewModel();
            return _userViewModel;
        }
        private ObservableCollection<User> listUsers;
        public ObservableCollection<User> ListUsers
        {
            set { listUsers = value; RaisePropertyChanged("ListUsers"); }

            get { return listUsers; }
        }
        public void GetItems()
        {
            if (ListUsers == null)
                ListUsers = new ObservableCollection<User>();
            ListUsers.Add(new User() { InputAmount = 1, OutputAmount = 20, Minimum = 0, Maximum = 100, ProgressValue = 5 ,Tag = 0});
            ListUsers.Add(new User() { InputAmount = 2, OutputAmount = 20, Minimum = 0, Maximum = 100, ProgressValue = 10, Tag = 1 });
            ListUsers.Add(new User() { InputAmount = 3, OutputAmount = 20, Minimum = 0, Maximum = 100, ProgressValue = 15, Tag = 2 });
            ListUsers.Add(new User() { InputAmount = 4, OutputAmount = 20, Minimum = 0, Maximum = 100, ProgressValue = 20, Tag = 3 });
        }
        public void RefreshListItems(int input)
        {
            foreach(User item in ListUsers)
            {
                item.InputAmount = item.InputAmount + 1;
                item.OutputAmount = item.OutputAmount + input;
                item.ProgressValue = item.ProgressValue + 5;
            }
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            RefreshData(sender);
        }
        public void RefreshData(object sender)
        {
            {
                try
                {
                    Gridview_TestApp.Model.User _User = null;
                    string inputvalue = (sender as TextBox).Text;
                    if (inputvalue == "")
                    {
                        _User = ((sender as TextBox).Parent as StackPanel).DataContext as Gridview_TestApp.Model.User;
                        UserViewModel.GetInstanse().RefreshListItems(0);
                    }
                    else
                    {
                        _User = ((sender as TextBox).Parent as StackPanel).DataContext as Gridview_TestApp.Model.User;
                        UserViewModel.GetInstanse().RefreshListItems(Convert.ToInt32(inputvalue));
                    }
                }
                catch (Exception ex) { }
            }
        }

        public void AddItems()
        {
            if (ListUsers == null)
                ListUsers = new ObservableCollection<User>();
            ListUsers.Add(new User() { InputAmount = 0, Operator = "ITEM " + ListUsers.Count, OutputAmount = 0 });
        }
    }
}
