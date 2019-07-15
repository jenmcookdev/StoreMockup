using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uStoreMVC.Domain;

namespace uStoreMVC.Data.ADO
{
    public class ProductsDAL
    {
        public string GetProductNames()
        {
            string productName = "";
            //Create a SQLConnection object
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=uStore;Integrated Security=true";

            //Open the connections to the DB
            conn.Open();

            //Create a SQL Command object
            SqlCommand cmdGetProducts = new SqlCommand("Select * from Products", conn);

            //Execute the command
            SqlDataReader rdrProducts = cmdGetProducts.ExecuteReader();

            //Process the DataReader (if data is to be returned)
            while (rdrProducts.Read())
            {
                productName += (string)rdrProducts["Name"] + " ";
            }
            //Close the connection to the DB ( !!!! THIS IS CRITICAL !!!! )
            rdrProducts.Close();
            conn.Close();

            return productName;
        }//GetProductNames()

        public List<ProductModel> GetProducts()
        {
            List<ProductModel> product = new List<ProductModel>();

            using (SqlConnection prodlist = new SqlConnection())
            {
                prodlist.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=uStore;Integrated Security=true";

                prodlist.Open();

                SqlCommand cmdGetProducts = new SqlCommand("Select * from Products", prodlist);

                SqlDataReader rdrProducts = cmdGetProducts.ExecuteReader();

                while (rdrProducts.Read())
                {
                    ProductModel products = new ProductModel()
                    {
                        ProductID = (int)rdrProducts["ProductID"],//primary key
                        Name = (string)rdrProducts["Name"],
                        Description = (rdrProducts["Description"] is DBNull) ? "N/A" : (string)rdrProducts["Description"],
                        Price = (rdrProducts["Price"] is DBNull) ? 0 : (decimal)rdrProducts["Price"],
                        UnitsInStock = (short)rdrProducts["UnitsInStock"],
                        ProductImage = (rdrProducts["ProductImage"] is DBNull) ? "N/A" : (string)rdrProducts["ProductImage"],
                        StatusID = (int)rdrProducts["StatusID"], //foreign key
                        CategoryID = (rdrProducts["CategoryID"] is DBNull) ? 0 : (int)rdrProducts["CategoryID"], //foreign key
                        Notes = (rdrProducts["Notes"] is DBNull) ? "N/A" : (string)rdrProducts["Notes"],
                        ReferenceURL = (rdrProducts["ReferenceURL"] is DBNull) ? "N/A" : (string)rdrProducts["ReferenceURL"],
                    };//ProductModel()

                    product.Add(products);

                }//while

                rdrProducts.Close();

            }//using

            return product;

        }//GetProducts()

        public void CreateProducts(ProductModel product)
        {
            using (SqlConnection prod = new SqlConnection())
            {
                prod.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=uStore;Integrated Security=true";

                prod.Open();

                SqlCommand cmdInsertProduct = new SqlCommand(
                    @"Insert into Products
                    (Name, Description, Price, UnitsInStock, StatusID, CategoryID, ProductImage, Notes, ReferenceURL)
                     Values(@Name, @Description, @Price, @UnitsInStock, @StatusID, @CategoryID, @ProductImage, @Notes, @ReferenceURL)", prod);
                //Set up Parameters - Name & UnitsInStock won't allow null
                cmdInsertProduct.Parameters.AddWithValue
                    ("Name", product.Name);

                if (product.Description != null)
                {
                    cmdInsertProduct.Parameters.AddWithValue
                    ("Description", product.Description);
                }//if
                else
                {
                    cmdInsertProduct.Parameters.AddWithValue
                    ("Description", DBNull.Value);
                }//else

                if (product.Price != 0)

                {
                    cmdInsertProduct.Parameters.AddWithValue
                    ("Price", product.Price);
                }//if
                else
                {
                    cmdInsertProduct.Parameters.AddWithValue
                    ("Price", DBNull.Value);
                }//else
                //won't allow for null
                cmdInsertProduct.Parameters.AddWithValue
                    ("UnitsInStock", product.UnitsInStock);

                cmdInsertProduct.Parameters.AddWithValue
                    ("StatusID", product.StatusID);

                if (product.CategoryID != 0)
                {
                    cmdInsertProduct.Parameters.AddWithValue
                    ("CategoryID", product.CategoryID);
                }//if
                else
                {
                    cmdInsertProduct.Parameters.AddWithValue
                    ("CategoryID", DBNull.Value);
                }//else

                if (product.ProductImage != null)
                {
                    cmdInsertProduct.Parameters.AddWithValue
                    ("ProductImage", product.ProductImage);
                }//if
                else
                {
                    cmdInsertProduct.Parameters.AddWithValue
                    ("ProductImage", DBNull.Value);
                }//else

                if (product.Notes != null)
                {
                    cmdInsertProduct.Parameters.AddWithValue
                    ("Notes", product.Notes);
                }//if
                else
                {
                    cmdInsertProduct.Parameters.AddWithValue
                    ("Notes", DBNull.Value);
                }//else

                if (product.ReferenceURL != null)
                {
                    cmdInsertProduct.Parameters.AddWithValue
                    ("ReferenceURL", product.ReferenceURL);
                }//if
                else
                {
                    cmdInsertProduct.Parameters.AddWithValue
                    ("ReferenceURL", DBNull.Value);
                }//else

                cmdInsertProduct.ExecuteNonQuery();

            }//using

        }//CreateProducts(ProductModel product)

        public void DeleteProduct(int id)
        {
            using (SqlConnection delprod = new SqlConnection())
            {
                delprod.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=uStore;Integrated Security=true";

                delprod.Open();

                SqlCommand cmdDeleteProduct = new SqlCommand("Delete from Products where ProductID = @ProductID", delprod);

                cmdDeleteProduct.Parameters.AddWithValue("ProductID", id);

                cmdDeleteProduct.ExecuteNonQuery();

            }//using
        }//DeleteProducts(int id)

        public ProductModel GetThatProduct(int id)
        {
            ProductModel product = null;

            using (SqlConnection thatprod = new SqlConnection())
            {
                thatprod.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=ustore;Integrated Security=true";

                thatprod.Open();

                SqlCommand cmdGetThatProduct = new SqlCommand("Select * from products where productID = @productID", thatprod);

                cmdGetThatProduct.Parameters.AddWithValue("productID", id);

                SqlDataReader rdrThatproduct = cmdGetThatProduct.ExecuteReader();

                if (rdrThatproduct.Read())
                {
                    product = new ProductModel() //Object Initialization Syntax:
                    {
                        ProductID = (int)rdrThatproduct["productID"],
                        Name = (string)rdrThatproduct["Name"],
                        Description = (rdrThatproduct["Description"] is DBNull) ? "" : (string)rdrThatproduct["Description"],
                        Price = (rdrThatproduct["Price"] is DBNull) ? 0 : (decimal)rdrThatproduct["Price"],
                        UnitsInStock = (rdrThatproduct["UnitsInStock"] is DBNull) ? 0 : (short)rdrThatproduct["UnitsInStock"],
                        ProductImage = (rdrThatproduct["ProductImage"] is DBNull) ? "" : (string)rdrThatproduct["ProductImage"],
                        Notes = (rdrThatproduct["Notes"] is DBNull) ? "" : (string)rdrThatproduct["Notes"],
                        ReferenceURL = (rdrThatproduct["ReferenceURL"] is DBNull) ? "" : (string)rdrThatproduct["ReferenceURL"],
                    };
                }//if
                rdrThatproduct.Close();
            }//using
            return product;
        }//GetThatProduct(int id)

        public void UpdateProduct(ProductModel product)
        {
            using (SqlConnection uprod = new SqlConnection())
            {
                uprod.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=uStore;Integrated Security=true";

                uprod.Open();

                SqlCommand cmdUpdateProduct = new SqlCommand(
                    @"Update Products set
                        Name = @Name,
                        Description = @Description,
                        Price = @Price
                        UnitsInStock = @UnitsInStock,
                        ProductImage = @ProductImage,
                        Notes = @Notes,
                        ReferenceURL = @ReferenceURL
                        Where ProductID = @ProductID", uprod);

                cmdUpdateProduct.Parameters.AddWithValue("ProductID", product.ProductID);
                cmdUpdateProduct.Parameters.AddWithValue("Name", product.Name);

                if (product.Description != null)
                {
                    cmdUpdateProduct.Parameters.AddWithValue("Description", product.Description);
                }//if
                else
                {
                    cmdUpdateProduct.Parameters.AddWithValue("Description", DBNull.Value);
                }//else
                if (product.Price != 0)
                {
                    cmdUpdateProduct.Parameters.AddWithValue("Price", product.Price);
                }//if
                else
                {
                    cmdUpdateProduct.Parameters.AddWithValue("Price", DBNull.Value);
                }//else

                cmdUpdateProduct.Parameters.AddWithValue("UnitsInStock", product.UnitsInStock);

                if (product.ProductImage != null)
                {
                    cmdUpdateProduct.Parameters.AddWithValue("ProductImage", product.ProductImage);
                }//if
                else
                {
                    cmdUpdateProduct.Parameters.AddWithValue("ProductImage", DBNull.Value);
                }//else

                if (product.Notes != null)
                {
                    cmdUpdateProduct.Parameters.AddWithValue("Notes", product.Notes);
                }//if
                else
                {
                    cmdUpdateProduct.Parameters.AddWithValue("Notes", DBNull.Value);
                }//else

                if (product.ReferenceURL != null)
                {
                    cmdUpdateProduct.Parameters.AddWithValue("ReferenceURL", product.ReferenceURL);
                }//if
                else
                {
                    cmdUpdateProduct.Parameters.AddWithValue("ReferenceURL", DBNull.Value);
                }//else

                cmdUpdateProduct.ExecuteNonQuery();
            }//using
        }//UpdateProduct(ProductModel product)


    }//end class
}//end namespace
