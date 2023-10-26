using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.DynamicLinq;
using AMKO.Models;


namespace AMKO.Controllers
{
    public class TypeAssetController : MenuController
    {
             
        private DC_AMKODataContext ctx_db;
        // GET: TypeAsset
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

        [HttpPost]
        public JsonResult AjaxRead(int take, int skip, IEnumerable<Kendo.DynamicLinq.Sort> sort, Kendo.DynamicLinq.Filter filter)
        {
            try
            {
                ctx_db = new DC_AMKODataContext();

                IQueryable<TBL_R_TYPE_ASSET> tbl_r_type_asset = ctx_db.TBL_R_TYPE_ASSETs;
                return Json(tbl_r_type_asset.ToDataSourceResult(take, skip, sort, filter));

            }
            catch (Exception e)
            {
                return this.Json(new { status = 0, error = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AjaxInsert(TBL_R_TYPE_ASSET sTBL_R_TYPE_ASSET)
        {
            ctx_db = new DC_AMKODataContext();
            string i_str_remarks = "";

            try
            {
                ctx_db.TBL_R_TYPE_ASSETs.InsertOnSubmit(sTBL_R_TYPE_ASSET);
                ctx_db.SubmitChanges();

                i_str_remarks = "Data berhasil disimpan !";

                return Json(new { status = true, remarks = i_str_remarks }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return this.Json(new { status = false, error = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult AjaxUpdate(TBL_R_TYPE_ASSET sTBL_R_TYPE_ASSET)
        {
            ctx_db = new DC_AMKODataContext();
            string i_str_remarks = "";


            try
            {
                TBL_R_TYPE_ASSET s_obj_type = ctx_db.TBL_R_TYPE_ASSETs.Where(f => f.TYPE_CODE == sTBL_R_TYPE_ASSET.TYPE_CODE).FirstOrDefault();
                s_obj_type.TYPE_NAME = sTBL_R_TYPE_ASSET.TYPE_NAME;
                ctx_db.SubmitChanges();

                i_str_remarks = "Data berhasil diupdate !";

                return Json(new { status = true, remarks = i_str_remarks }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return this.Json(new { status = false, error = e.Message }, JsonRequestBehavior.AllowGet);
            }


        }

        [HttpPost]
        public JsonResult AjaxDelete(TBL_R_TYPE_ASSET sTBL_R_TYPE_ASSET)
        {
            ctx_db = new DC_AMKODataContext();
            string i_str_remarks = "";


            try
            {
                TBL_R_TYPE_ASSET s_obj_type = ctx_db.TBL_R_TYPE_ASSETs.Where(f => f.TYPE_CODE == sTBL_R_TYPE_ASSET.TYPE_CODE).FirstOrDefault();

                ctx_db.TBL_R_TYPE_ASSETs.DeleteOnSubmit(s_obj_type);
                ctx_db.SubmitChanges();

                i_str_remarks = "Data berhasil dihapus !";

                return Json(new { status = true, remarks = i_str_remarks }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return this.Json(new { status = false, error = e.ToString() }, JsonRequestBehavior.AllowGet);
            }


        }
    }
}