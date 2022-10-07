using SievePOS.Models;
using SievePOS.Services.Db;
using SievePOS.ViewPages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SievePOS.Services.POS
{
    public class ProductService
    {
        public void AddProducts(PRODUCTS products)
        {
            const string query = @"INSERT INTO PRODUCTS(ID,BAR_CODE,PRODUCT_NAME,LAST_PRATE,AVG_RATE,MRP_RATE,STOCK_QTY) 
                                   VALUES(@ID,@BAR_CODE,@PRODUCT_NAME,@LAST_PRATE,@AVG_RATE,@MRP_RATE,@STOCK_QTY)";

            var args = new Dictionary<string, object>
             {
                 {"@ID", dalCommon.NextTableMaxNumber("ID",$"{nameof(PRODUCTS)}")},
                 {"@BAR_CODE", products.BAR_CODE},
                 {"@PRODUCT_NAME", products.PRODUCT_NAME},
                 {"@LAST_PRATE", products.LAST_PRATE},
                 {"@AVG_RATE", products.AVG_RATE},
                 {"@MRP_RATE", products.MRP_RATE},
                 {"@STOCK_QTY", products.STOCK_QTY}
             };

            DatabaseSQLite.ExecuteWrite(query, args);
        }

        public void UpdateProducts(PRODUCTS products)
        {
            const string query = "UPDATE PRODUCTS SET BAR_CODE=@BAR_CODE,PRODUCT_NAME=@PRODUCT_NAME,LAST_PRATE=@LAST_PRATE,AVG_RATE=@AVG_RATE,MRP_RATE=@MRP_RATE,STOCK_QTY=@STOCK_QTY WHERE ID = @ID";

            var args = new Dictionary<string, object>
             {
                 {"@ID", products.ID},
                 {"@BAR_CODE", products.BAR_CODE},
                 {"@PRODUCT_NAME", products.PRODUCT_NAME},
                 {"@LAST_PRATE", products.LAST_PRATE},
                 {"@AVG_RATE", products.AVG_RATE},
                 {"@MRP_RATE", products.MRP_RATE},
                 {"@STOCK_QTY", products.STOCK_QTY}
             };

            DatabaseSQLite.ExecuteWrite(query, args);
        }
        public void UpdateProductsStock(PRODUCTS products)
        {
            const string query = "UPDATE PRODUCTS SET STOCK_QTY=@STOCK_QTY WHERE ID = @ID";

            var args = new Dictionary<string, object>
             {
                 {"@ID", products.ID},
                 {"@STOCK_QTY", products.STOCK_QTY}
             };

            DatabaseSQLite.ExecuteWrite(query, args);
        }
        public void RemoveProducts(int id)//PRODUCTS products)
        {
            const string query = "Delete from PRODUCTS WHERE ID = @ID";

            var args = new Dictionary<string, object>
             {
                // {"@ID", products.ID}
                 {"@ID", id}
             };

            DatabaseSQLite.ExecuteWrite(query, args);
        }

        public PRODUCTS Get(int id)
        {
            var products = new PRODUCTS();

            var query = "SELECT * FROM PRODUCTS WHERE ID = @ID";

            var args = new Dictionary<string, object>
             {
               //  {"@ID", products.ID}

                  {"@ID",id}
             };

            DataTable dt = DatabaseSQLite.Execute(query, args);

            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }

            products = new PRODUCTS
            {
                ID = Convert.ToInt32(dt.Rows[0]["ID"]),
                BAR_CODE = Convert.ToString(dt.Rows[0]["BAR_CODE"]),
                PRODUCT_NAME = Convert.ToString(dt.Rows[0]["PRODUCT_NAME"]),
                LAST_PRATE = Convert.ToDecimal(dt.Rows[0]["LAST_PRATE"]),
                AVG_RATE = Convert.ToDecimal(dt.Rows[0]["AVG_RATE"]),
                MRP_RATE = Convert.ToDecimal(dt.Rows[0]["MRP_RATE"]),
                STOCK_QTY = Convert.ToDecimal(dt.Rows[0]["STOCK_QTY"])
            };

            return products;
        }

        public List<PRODUCTS> GetAll()
        {
            var student = new PRODUCTS();
            var studentList = new List<PRODUCTS>();

            var query = "SELECT * FROM PRODUCTS";

            var args = new Dictionary<string, object>
             {
               //  {"@stdId", student.stdId}
             };

            DataTable dt = DatabaseSQLite.Execute(query, args);

            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }

            foreach (DataRow row in dt.Rows)
            {
                student = new PRODUCTS
                {
                    ID = Convert.ToInt32(row["ID"]),
                    BAR_CODE = Convert.ToString(row["BAR_CODE"]),
                    PRODUCT_NAME = Convert.ToString(row["PRODUCT_NAME"]),
                    LAST_PRATE = Convert.ToDecimal(row["LAST_PRATE"]),
                    AVG_RATE = Convert.ToDecimal(row["AVG_RATE"]),
                    MRP_RATE = Convert.ToDecimal(row["MRP_RATE"]),
                    STOCK_QTY = Convert.ToDecimal(row["STOCK_QTY"])
                };
                studentList.Add(student);
            }
            return studentList.ToList();
        }
    }
}
