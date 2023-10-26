using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kendo.DynamicLinq;
using System.Web.Mvc;
using AMKO.Models;

namespace AMKO.Controllers
{
    public class HistoriController : MenuController
    {
        private DC_AMKODataContext ctx_db;

        // GET: Histori
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
                    ViewData["asset_no"] = Request.QueryString["asset_no"];
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
        }

        public JsonResult AjaxRead(string s_str_assetNumber, int take, int skip, IEnumerable<Kendo.DynamicLinq.Sort> sort, Kendo.DynamicLinq.Filter filter)
        {
            try
            {
                ctx_db = new DC_AMKODataContext();

                IQueryable<VW_HISTORY> vw_history = ctx_db.VW_HISTORies
                                                                      .Where(f=> f.ASSET_NUMBER == s_str_assetNumber)
                                                                      .OrderBy(f=> f.HISTORY_DATE);

                return Json(vw_history.ToDataSourceResult(take, skip, sort, filter));

            }
            catch (Exception e)
            {
                return this.Json(new { status = 0, error = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ReadHistory(string s_str_assetNumber)
        {
            try
            {
                ctx_db = new DC_AMKODataContext();

                IQueryable<VW_HISTORY_API> vw_history = ctx_db.VW_HISTORY_APIs
                                                                      .Where(f => f.ASSET_NUMBER == s_str_assetNumber)
                                                                      .OrderBy(f =>f.HISTORY_DATE);

                return Json(new { status = true, data = vw_history }, JsonRequestBehavior.AllowGet );

            }
            catch (Exception e)
            {
                return this.Json(new { status = false, error = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}