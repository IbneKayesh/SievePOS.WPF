using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using SievePOS.Services.POS;
using SievePOS.Models;
using System.Threading.Tasks;

namespace SievePOS.ViewModels
{
    public class ProductsViewModel
    {
       
        public string Title = "Products";
        private ICommand _saveCommand;
        private ICommand _resetCommand;
        private ICommand _editCommand;
        private ICommand _deleteCommand;
        private ProductService _repository;
        private PRODUCTS? _productsEntity = null;
        public ProductRecord ProductRecord { get; set; }

        public ICommand ResetCommand
        {
            get
            {
                if (_resetCommand == null)
                    _resetCommand = new RelayCommand(param => ResetData(), null);

                return _resetCommand;
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new RelayCommand(param => SaveData(), null);

                return _saveCommand;
            }
        }

        public ICommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                    _editCommand = new RelayCommand(param => EditData((int)param), null);
                return _editCommand;
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                    _deleteCommand = new RelayCommand(param => DeleteStudent((int)param), null);

                return _deleteCommand;
            }
        }

        public ProductsViewModel()
        {
            _productsEntity = new PRODUCTS();
            _repository = new ProductService();
            ProductRecord = new ProductRecord();
            GetAll();
        }

        public void ResetData()
        {
            ProductRecord.ID = 0;
            ProductRecord.BAR_CODE = string.Empty;
            ProductRecord.PRODUCT_NAME = string.Empty;
            ProductRecord.LAST_PRATE = 0;
            ProductRecord.AVG_RATE = 0;
            ProductRecord.MRP_RATE = 0;
            ProductRecord.STOCK_QTY = 0;

            GetAll();
        }

        public void DeleteStudent(int id)
        {
            if (MessagesBox.DeleteConfirm(Title) == MessageBoxResult.Yes)
            {
                try
                {
                    _repository.RemoveProducts(id);
                    MessagesBox.Deleted(Title);
                }
                catch (Exception ex)
                {
                    MessagesBox.Exception(ex.Message == string.Empty ? ex.InnerException.Message : ex.Message, Title);
                }
                finally
                {
                    GetAll();
                }
            }
        }

        public void SaveData()
        {
            if (ProductRecord != null)
            {
                _productsEntity.ID = ProductRecord.ID;
                _productsEntity.BAR_CODE = ProductRecord.BAR_CODE;
                _productsEntity.PRODUCT_NAME = ProductRecord.PRODUCT_NAME;
                _productsEntity.LAST_PRATE = ProductRecord.LAST_PRATE;
                _productsEntity.AVG_RATE = ProductRecord.AVG_RATE;
                _productsEntity.MRP_RATE = ProductRecord.MRP_RATE;
                _productsEntity.STOCK_QTY = ProductRecord.STOCK_QTY;

                try
                {
                    if (ProductRecord.ID <= 0)
                    {
                        _repository.AddProducts(_productsEntity);
                        MessagesBox.Saved(Title);
                    }
                    else
                    {
                        _productsEntity.ID = ProductRecord.ID;
                        _repository.UpdateProducts(_productsEntity);
                        MessagesBox.Updated(Title);
                    }
                }
                catch (Exception ex)
                {
                    MessagesBox.Exception(ex.Message == string.Empty ? ex.InnerException.Message : ex.Message, Title);
                }
                finally
                {
                    GetAll();
                    ResetData();
                }
            }
        }

        public void EditData(int id)
        {
            PRODUCTS model = _repository.Get(id);

            ProductRecord.ID = model.ID;
            ProductRecord.BAR_CODE = model.BAR_CODE;
            ProductRecord.PRODUCT_NAME = model.PRODUCT_NAME;
            ProductRecord.LAST_PRATE = model.LAST_PRATE;
            ProductRecord.AVG_RATE = model.AVG_RATE;
            ProductRecord.MRP_RATE = model.MRP_RATE;
            ProductRecord.STOCK_QTY = model.STOCK_QTY;
        }

        public void GetAll()
        {
            ProductRecord.ProductRecords = new ObservableCollection<ProductRecord>();
            _repository.GetAll().ForEach(data => ProductRecord.ProductRecords.Add(new ProductRecord()
            {
                ID = data.ID,
                BAR_CODE = data.BAR_CODE,
                PRODUCT_NAME = data.PRODUCT_NAME,
                LAST_PRATE = data.LAST_PRATE,
                AVG_RATE = data.AVG_RATE,
                MRP_RATE = data.MRP_RATE,
                STOCK_QTY = data.STOCK_QTY
            }));
        }
    }
}
