using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using MVCwithADO.NET.Models.DALs;

namespace MVCwithADO.NET.Controllers
{
    public class AdoController : Controller
    {
        
        // GET: Ado
        public ActionResult Index()
        {         
            // 使用SqlDataAdapter
            string conn = WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString.ToString();
            using (SqlDataAdapter adapter = new SqlDataAdapter("select * from Products", conn))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return View(dt);
            }
        }

        public ActionResult FromDAL()
        {
            // 使用DataRow
            ProductDal p = new ProductDal();
            IEnumerable<DataRow> table = p.Get();
            ViewBag.Table = table;
            return View();
        }
    }
}