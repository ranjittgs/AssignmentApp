using Gridview_TestApp.Model;
using Gridview_TestApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AssignmentApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int user_tagged_element = 0;
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;

        }
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            UserViewModel.GetInstanse().GetItems();
            this.DataContext = UserViewModel.GetInstanse();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string input = tblInput.Text;
            UserViewModel.GetInstanse().RefreshListItems(Convert.ToInt32(input));
        }

        private void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            //Debug.WriteLine("TextBox_KeyDown");
            //RefreshData(sender);
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("TextBox_LostFocus");
            //RefreshData(sender);
        }
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            Debug.WriteLine("TextBox_TextChanged_1");
            //if (string.IsNullOrEmpty((sender as TextBox).Text))
            //{
            //    RefreshData(sender);
            //}
        }
        public void RefreshData(object sender)
        {
            {
                try
                {
                    Gridview_TestApp.Model.User _User = null;
                    _User = ((sender as TextBox).Parent as StackPanel).DataContext as Gridview_TestApp.Model.User;
                    string inputvalue = (sender as TextBox).Text;
                    if (string.IsNullOrEmpty(inputvalue))
                        _User.InputAmount = 0;
                    else
                        _User.InputAmount = Convert.ToInt32(inputvalue);
                    if (inputvalue == "")
                    {
                        UserViewModel.GetInstanse().RefreshListItems(0);
                    }
                    else
                    {
                        UserViewModel.GetInstanse().RefreshListItems(Convert.ToInt32(inputvalue));
                        //user_tagged_element = _User.Tag;
                    }
                }
                catch (Exception ex) { }
            }
        }
        private void tblPermanant_GotFocus(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("tblPermanant_GotFocus");
            StackPanel sp = (sender as TextBox).Parent as StackPanel;
            sp.Children[1].Visibility = Visibility.Visible;
            sp.Children[0].Visibility = Visibility.Collapsed;
            Gridview_TestApp.Model.User _User = null;
            _User = ((sender as TextBox).Parent as StackPanel).DataContext as Gridview_TestApp.Model.User;
            _User.TempAmount = _User.InputAmount;
        }
        private void tblTemp_LostFocus(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("tblTemp_LostFocus");
            StackPanel sp = (sender as TextBox).Parent as StackPanel;
            sp.Children[1].Visibility = Visibility.Collapsed;
            sp.Children[0].Visibility = Visibility.Visible;

            Gridview_TestApp.Model.User _User = null;
            _User = ((sender as TextBox).Parent as StackPanel).DataContext as Gridview_TestApp.Model.User;
            _User.InputAmount = _User.TempAmount;
        }
        private void TextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            Debug.WriteLine("TextBox_KeyUp");
            if (e.Key == VirtualKey.Number0 || e.Key == VirtualKey.Number1 || e.Key == VirtualKey.Number2 || e.Key == VirtualKey.Number3
                || e.Key == VirtualKey.Number4 || e.Key == VirtualKey.Number5 || e.Key == VirtualKey.Number6 || e.Key == VirtualKey.Number7
                || e.Key == VirtualKey.Number8 || e.Key == VirtualKey.Number9 || e.Key.ToString() == "190" || e.Key == VirtualKey.Back
                || e.Key == VirtualKey.Delete)
                RefreshData(sender);
        }
    }
}
