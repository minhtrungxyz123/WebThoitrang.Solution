using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebThoitrang.Web.Models
{
    public class OrderViewModel
    {
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string CustomerName { set; get; }

        [Required]
        [MaxLength(256)]
        public string CustomerAddress { set; get; }

        [Required]
        [MaxLength(256)]
        public string CustomerEmail { set; get; }

        [Required]
        [MaxLength(50)]
        public string CustomerMobile { set; get; }

        [Required]
        [MaxLength(256)]
        public string CustomerMessage { set; get; }

        [MaxLength(256)]
        public string PaymentMethod { set; get; }

        public DateTime? CreatedDate { set; get; }
        public string CreatedBy { set; get; }
        public string PaymentStatus { set; get; }
        public bool Status { set; get; }

        [MaxLength(128)]
        public string CustomerId { set; get; }

        public string BankCode { set; get; }

        public IEnumerable<OrderDetailViewModel> OrderDetails { set; get; }
    }

    class OrderList
    {
        DBConnection db;
        public OrderList()
        {
            db = new DBConnection();
        }
        // Viết phương thức lấy Dữ liệu Order từ CSDL:
        public List<OrderViewModel> getOrderViewModels(string ID)
        {
            string sql;
            if (string.IsNullOrEmpty(ID))
            {
                sql = "SELECT * FROM Orders";
            }
            else
            {
                sql = "SELECT * FROM Orders WHERE ID=" + ID;
            }
            List<OrderViewModel> strList = new List<OrderViewModel>();
            SqlConnection con = db.getConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();

            //mở kết nối
            con.Open();
            cmd.Fill(dt);


            //đóng kết nốt

            cmd.Dispose();
            con.Close();

            OrderViewModel strBH;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strBH = new OrderViewModel();
                strBH.ID = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                strBH.CustomerName = dt.Rows[i]["CustomerName"].ToString();
                strBH.CustomerAddress = dt.Rows[i]["CustomerAddress"].ToString();
                strBH.CustomerEmail = dt.Rows[i]["CustomerEmail"].ToString();
                strBH.CustomerMobile = dt.Rows[i]["CustomerMobile"].ToString();
                strBH.CustomerMessage = dt.Rows[i]["CustomerMessage"].ToString();
                strBH.PaymentMethod = dt.Rows[i]["PaymentMethod"].ToString();
                strBH.CreatedBy = dt.Rows[i]["CreatedBy"].ToString();
                strBH.CustomerId = dt.Rows[i]["CustomerId"].ToString();
                strList.Add(strBH);
            }
            return strList;
        }
    }
}