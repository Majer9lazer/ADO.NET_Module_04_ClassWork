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
using System.Diagnostics;
using System.Data.Common;

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
            _connectionString = "Data Source=192.168.111.107; Initial Catalog=MCS; User ID=sa; Password=Mc123456;";

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
                    var st = row.RowState;
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
        private void CreateTrackEveluation_Click(object sender, RoutedEventArgs e)
        {
            DataTable tbl = new DataTable("TrackEvaluationPart");
            DataColumn intEvauationPartId = tbl.Columns.Add("intEvauationPartId", typeof(int));
            DataColumn intEvaluationId = tbl.Columns.Add("intEvaluationId", typeof(int));
            DataColumn intMasterPartId = tbl.Columns.Add("intMasterPartId", typeof(int));
            DataColumn strAvailability = tbl.Columns.Add("strAvailability", typeof(string));
            DataColumn strDescription= tbl.Columns.Add("strDescription", typeof(string));
            intEvauationPartId.AllowDBNull = false;
            intEvauationPartId.AutoIncrement = true;
            intEvauationPartId.AutoIncrementSeed = 1 ;
            intEvauationPartId.AutoIncrementStep = 1;
            intEvauationPartId.ReadOnly = true;
            intEvauationPartId.Unique = true;
            tbl.PrimaryKey = new DataColumn[]
            {
                tbl.Columns["UserID"]
            };
            
        }
        private void GetUserS_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            SqlDataAdapter da = new SqlDataAdapter("Select * from AT_Users", con);
            DataSet ds = new DataSet();


            UsersList.ItemsSource = ds.Tables["AT_Users"].Columns;
            DataTableMapping tblMap;
            DataColumnMapping colMap;
            tblMap = da.TableMappings.Add("Table", "AT_Users");
            colMap = tblMap.ColumnMappings.Add("UserId", "UserID");
            colMap = tblMap.ColumnMappings.Add("Login", "UserLogin");



        }

        private void UpdateUsers_Click(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM AT_Users";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow newRow = dt.NewRow();
                newRow["UserLogin"] = "EgorBest";
                newRow["UserPassword"] = "SomePass";
                newRow["UserAddress"] = "Турксибский";
                newRow["UserName"] = "pngName";
                newRow["UserRoleID"] = 1;
                newRow["UserPhoneNum"] = "+77054673211";
                newRow["UserAge"] = 18;
                newRow["UserGender"] = 0;

                dt.Rows.Add(newRow);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds);
            }
        }


    }
}
namespace ADO.NET.Structure
{
    struct WorkWithDataSetStruct
    {


    }
}