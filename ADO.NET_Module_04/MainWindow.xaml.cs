using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
namespace ADO.NET_Module_04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _connectionString = "";
        public MainWindow()
        {
            InitializeComponent();
            _connectionString = "Data Source=192.168.111.154; Initial Catalog=hMalServer; User ID=sa; Password=Mc123456;";

        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            var tt = "";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = _connectionString;
            SqlDataAdapter da = new SqlDataAdapter("select * from AT_Users", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataTable table in ds.Tables)
            {
                DtColumns.ItemsSource = table.Columns;
                foreach (DataRow Row in table.Rows)
                {
                    var rows = Row.ItemArray;


                    foreach (object cell in rows)
                    {
                        tt = cell.ToString();
                    }
                }
            }

            con.Dispose();
        }

        private void CreateTableButton_Click(object sender, RoutedEventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable tbl = new DataTable("AT_Users_New");

            DataColumn col = tbl.Columns.Add("UserID", typeof(int));
            col.AllowDBNull = false;
            col.AutoIncrement = true;
            col.AutoIncrementSeed = 0;
            col.AutoIncrementStep = 1;
            col.ReadOnly = true;
           

            col.Unique = true;
            tbl.PrimaryKey = new DataColumn[]
            {
                tbl.Columns["UserID"]
            };
            //Добавление новой строки
            DataRow dr = ds.Tables["AT_Users"].NewRow();
            dr["UserLogin"] = "Test";
            dr["UserPassword"] = "123";
            dr["UserAge"] = DBNull.Value;

            //Удаление Row
            DataRow ddr = ds.Tables["AT_Users"].Rows.Find(2);
            ds.Tables["AT_Users"].Rows.Remove(ddr);
           
            ds.Tables.Add(tbl);

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    var st=row.RowState;
                }
            
                foreach (var item in table.Rows)
                {

                }
            }






            //SqlConnection con = new SqlConnection(_connectionString);
            //con.Open();
            //SqlDataAdapter da = new SqlDataAdapter("", con);
            //da.Update(ds);
            //con.Close();
        }
    }
}
namespace ADO.NET.Structure
{
    struct WorkWithDataSetStruct
    {


    }
}