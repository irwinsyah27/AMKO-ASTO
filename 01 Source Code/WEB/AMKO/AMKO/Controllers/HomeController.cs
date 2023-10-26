using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.DynamicLinq;
using AMKO.Models;

namespace AMKO.Controllers
{
    public class HomeController : MenuController
    {
        private DC_AMKODataContext ctx_db;

        public ActionResult Index()
        {
            if (ViewBag.myAccount == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                if (ViewBag.myAccount.VALID_ACCESS == true)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
        }

        public JsonResult ReadGrid(string s_str_tahun, int take, int skip, IEnumerable<Kendo.DynamicLinq.Sort> sort, Kendo.DynamicLinq.Filter filter)
        {
            try
            {
                ctx_db = new DC_AMKODataContext();

                IQueryable<VW_DASHBOARD> vw_dashboard = ctx_db.VW_DASHBOARDs
                                                            .Where(f=>f.TAHUN == s_str_tahun)
                                                            .OrderBy(f=> f.BULAN_DESC); ;
                return Json(vw_dashboard.ToDataSourceResult(take, skip, sort, filter));

            }
            catch (Exception e)
            {
                return this.Json(new { status = 0, error = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ReadChart(string s_str_tahun)
        {
            List<string> lst_bulan = new List<string>();
            List<string> lst_amount = new List<string>();

            try
            {
                ctx_db = new DC_AMKODataContext();
                IEnumerable<VW_DASHBOARD> vw_dashboard = ctx_db.VW_DASHBOARDs
                                                            .Where(f => f.TAHUN == s_str_tahun)
                                                            .OrderBy(f => f.BULAN);

                foreach (VW_DASHBOARD x in vw_dashboard)
                {
                    lst_bulan.Add(x.BULAN_DESC.ToString());
                    lst_amount.Add(x.TOTAL_AMOUNT.ToString());
                }

                return Json(new { status = true, bulan = lst_bulan, amount = lst_amount }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { status = false, error = e.Message }, JsonRequestBehavior.AllowGet);
            }

        }

    }
}