using SievePOS.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SievePOS.Models
{
    public class ProductRecord : ViewModelBase
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

        [Required(ErrorMessage = "Must not be empty.")]
        public string BAR_CODE
        {
            get
            {
                return _BAR_CODE;
            }
            set
            {
                ValidateProperty(value, "BAR_CODE");
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


        private void ValidateProperty<T>(T value, string name)
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name
            });
        }
    }
}
