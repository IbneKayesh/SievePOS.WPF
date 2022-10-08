using SievePOS.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Xml.Linq;

namespace SievePOS.Models
{
    public class ProductRecord : ViewModelBase, IDataErrorInfo
    {

        private int _ID;
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
                OnPropertyChanged("ID");
            }
        }

        private string _BAR_CODE;
        public string BAR_CODE
        {
            get
            {
                return _BAR_CODE;
            }
            set
            {
                _BAR_CODE = value;
                OnPropertyChanged("BAR_CODE");
            }
        }


        private string _PRODUCT_NAME;
        public string PRODUCT_NAME
        {
            get
            {
                return _PRODUCT_NAME;
            }
            set
            {
                _PRODUCT_NAME = value;
                OnPropertyChanged("PRODUCT_NAME");
            }
        }


        private decimal _LAST_PRATE;
        public decimal LAST_PRATE
        {
            get
            {
                return _LAST_PRATE;
            }
            set
            {
                _LAST_PRATE = value;
                OnPropertyChanged("LAST_PRATE");
            }
        }


        private decimal _AVG_RATE;
        public decimal AVG_RATE
        {
            get
            {
                return _AVG_RATE;
            }
            set
            {
                _AVG_RATE = value;
                OnPropertyChanged("AVG_RATE");
            }
        }


        private decimal _MRP_RATE;
        public decimal MRP_RATE
        {
            get
            {
                return _MRP_RATE;
            }
            set
            {
                _MRP_RATE = value;
                OnPropertyChanged("MRP_RATE");
            }
        }


        private decimal _STOCK_QTY;
        public decimal STOCK_QTY
        {
            get
            {
                return _STOCK_QTY;
            }
            set
            {
                _STOCK_QTY = value;
                OnPropertyChanged("STOCK_QTY");
            }
        }



        private ObservableCollection<ProductRecord> _ProductRecords;
        public ObservableCollection<ProductRecord> ProductRecords
        {
            get
            {
                return _ProductRecords;
            }
            set
            {
                _ProductRecords = value;
                OnPropertyChanged("ProductRecords");
            }
        }
        public string this[string name]
        {
            get
            {
                validateForm();

                string result = null;

                switch (name)
                {
                    case "BAR_CODE":
                        if (string.IsNullOrWhiteSpace(BAR_CODE))
                        {
                            result = "Barcode cannot be empty";
                        }
                        else if (BAR_CODE.Length < 4)
                        {
                            result = $"Barcode must be a minimum of 4 characters.";
                        }
                        break;

                    case "PRODUCT_NAME":
                        if (string.IsNullOrWhiteSpace(PRODUCT_NAME))
                        {
                            result = "Product name cannot be empty";
                        }
                        else if (PRODUCT_NAME.Length < 3)
                        {
                            result = $"Product name must be a minimum of 3 characters.";
                        }
                        break;

                    case "LAST_PRATE":
                        if (LAST_PRATE < 0)
                        {
                            result = "Last Purchase rate should not be negetive";
                        }
                        else if (LAST_PRATE > int.MaxValue)
                        {
                            result = $"Last purchase rate maximum value is {int.MaxValue}.";
                        }
                        break;

                    case "AVG_RATE":
                        if (AVG_RATE != 0)
                        {
                            result = "Average rate should be zero";
                        }
                        break;

                    case "MRP_RATE":
                        if (MRP_RATE < 0)
                        {
                            result = "MRP rate should not be negetive";
                        }
                        else if (MRP_RATE > int.MaxValue)
                        {
                        }
                        break;

                    case "STOCK_QTY":
                        if (STOCK_QTY < 0)
                        {
                            result = "Stock should not be negetive";
                        }
                        else if (STOCK_QTY > int.MaxValue)
                        {
                            result = $"Stock maximum value is {int.MaxValue}.";
                        }
                        break;
                }

                if (ErrorCollection.ContainsKey(name))
                    ErrorCollection[name] = result;
                else if (result != null)
                    ErrorCollection.Add(name, result);

                OnPropertyChanged("ErrorCollection");
                return result;
            }
        }


        private bool _formIsValid;
        public bool formIsValid
        {
            get
            {
                return _formIsValid;
            }
            set
            {
                _formIsValid = value;
                OnPropertyChanged("formIsValid");
            }
        }
        private void validateForm()
        {
            formIsValid = true;
            if (string.IsNullOrWhiteSpace(BAR_CODE))
            {
                formIsValid = false;
            }
            else if (BAR_CODE.Length < 4)
            {
                formIsValid = false;
            }
            if (string.IsNullOrWhiteSpace(PRODUCT_NAME))
            {
                formIsValid = false;
            }
            else if (PRODUCT_NAME.Length < 3)
            {
                formIsValid = false;
            }
            if (LAST_PRATE < 0)
            {
                formIsValid = false;
            }
            else if (LAST_PRATE > int.MaxValue)
            {
                formIsValid = false;
            }

            if (AVG_RATE != 0)
            {
                formIsValid = false;
            }
            if (MRP_RATE < 0)
            {
                formIsValid = false;
            }
            else if (MRP_RATE > int.MaxValue)
            {
                formIsValid = false;
            }
            if (STOCK_QTY < 0)
            {
                formIsValid = false;
            }
            else if (STOCK_QTY > int.MaxValue)
            {
                formIsValid = false;
            }
        }




    }
}
