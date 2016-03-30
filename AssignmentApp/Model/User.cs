using Gridview_TestApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gridview_TestApp.Model
{
    public class User : ViewmodelBase
    {
        //  private string input;
        private double _InputAmount;
        public double InputAmount
        {
            set { _InputAmount = value; RaisePropertyChanged("InputAmount"); }
            get { return _InputAmount; }
        }
        private double _temp;
        public double TempAmount
        {
            set { _temp = value; RaisePropertyChanged("TempAmount"); }
            get { return _temp; }
        }
        //{
        //    set { input = value; RaisePropertyChanged("Input"); }
        //    get { return input; }
        //}
        public string Operator { set; get; }
        private double _Output;
        public double OutputAmount
        {
            set { _Output = value; RaisePropertyChanged("OutputAmount"); }
            get { return _Output; }
        }
        private double _Minimum;
        public double Minimum
        {
            set { _Minimum = value; RaisePropertyChanged("Minimum"); }
            get { return _Minimum; }
        }
        private double _Maximum;
        public double Maximum
        {
            set { _Maximum = value; RaisePropertyChanged("Maximum"); }
            get { return _Maximum; }
        }
        private double _Value;
        public double ProgressValue
        {
            set { _Value = value; RaisePropertyChanged("ProgressValue"); }
            get { return _Value; }
        }
        private int _Tag;
        public int Tag
        {
            set { _Tag = value; RaisePropertyChanged("Tag"); }
            get { return _Tag; }
        }
    }

}
