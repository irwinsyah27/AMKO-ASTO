using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.DynamicLinq;
using AMKO.Models;
using System.IO;

namespace AMKO.Controllers
{
    public class AssetController : MenuController
    {
        private DC_AMKODataContext ctx_db;
        private const string cons_str_insert = "INSERT";
        private const string cons_str_update = "UPDATE";

        // GET: Asset
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

        public ActionResult TransaksiAsset()
        {

            if (ViewBag.myAccount == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                if (ViewBag.myAccount.VALID_ACCESS == true)
                {
                    ViewData["status"] = Request.QueryString["status"];
                    ViewData["asset_no"] = Request.QueryString["asset_no"];

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

                IQueryable<VW_ASSET_FA> vw_asset_fa = ctx_db.VW_ASSET_FAs.OrderBy(f => f.ASSET_NUMBER);
                return Json(vw_asset_fa.ToDataSourceResult(take, skip, sort, filter));

            }
            catch (Exception e)
            {
                return this.Json(new { status = 0, error = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ReadEmployee(int take, int skip, IEnumerable<Kendo.DynamicLinq.Sort> sort, Kendo.DynamicLinq.Filter filter)
        {
            try
            {
                ctx_db = new DC_AMKODataContext();

                IQueryable<VW_KARYAWAN> vw_karyawan = ctx_db.VW_KARYAWANs.OrderBy(f => f.Nama);
                return Json(vw_karyawan.ToDataSourceResult(take, skip, sort, filter));


            }
            catch (Exception e)
            {
                return this.Json(new { status = 0, error = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult ReadAsset(string s_str_assetNo)
        {
            try
            {
                ctx_db = new DC_AMKODataContext();
                VW_ASSET_FA vw_asset_fa = ctx_db.VW_ASSET_FAs.Where(f => f.ASSET_NUMBER == s_str_assetNo).FirstOrDefault();
                return Json(new { status=true , data = vw_asset_fa }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return this.Json(new { status = false, error = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult ReadAssetMob(string s_str_assetNo)
        {
            try
            {
                ctx_db = new DC_AMKODataContext();
                VW_ASSET_API vw_asset = ctx_db.VW_ASSET_APIs.Where(f => f.ASSET_NUMBER == s_str_assetNo).FirstOrDefault();
                return Json(new { status = true, data = vw_asset }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return this.Json(new { status = false, error = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult UploadImage()
        {
            string i_str_path = "";
            string i_str_path2 = "";
            string fileName = "";
            try
            {
                foreach (string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        fileName = fileContent.FileName.ToString();
                        i_str_path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                        i_str_path2 = Url.Content(string.Format("~/Uploads/{0}", fileName));
                        fileContent.SaveAs(i_str_path);
                    }
                }

                return this.Json(new { status = true, path = i_str_path2 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return this.Json(new { status = false , error = "Kesalahan proses upload !" }, JsonRequestBehavior.AllowGet);
            }
        }



        public JsonResult InsertAsset(TBL_M_ASSET sTBL_M_ASSET)
        {

            try
            {
                ctx_db = new DC_AMKODataContext();
                ctx_db.SP_TRANS_ASSET(sTBL_M_ASSET.ASSET_NUMBER
                                      ,sTBL_M_ASSET.ASSET_NAME
                                      ,sTBL_M_ASSET.ASSET_DATE
                                      ,sTBL_M_ASSET.ST_DATE
                                      ,sTBL_M_ASSET.MERK_CODE
                                      ,sTBL_M_ASSET.SN
                                      ,sTBL_M_ASSET.TYPE_CODE
                                      ,sTBL_M_ASSET.NO_PR
                                      ,sTBL_M_ASSET.PIC
                                      ,sTBL_M_ASSET.DEPT_CODE
                                      ,sTBL_M_ASSET.ORDER_BY
                                      ,sTBL_M_ASSET.AMOUNT
                                      ,sTBL_M_ASSET.COND_CODE
                                      ,sTBL_M_ASSET.LOCATION_CODE
                                      ,sTBL_M_ASSET.REMARK
                                      ,sTBL_M_ASSET.IMG
                                      ,sTBL_M_ASSET.COA_CODE
                                      ,sTBL_M_ASSET.ASSET_CODE
                                      ,sTBL_M_ASSET.SUB_ASSET_CODE
                                      ,sTBL_M_ASSET.NO_PO
                                      ,sTBL_M_ASSET.UE
                                      ,sTBL_M_ASSET.EGI_ID
                                      ,sTBL_M_ASSET.MUTASI_ID
                                      ,cons_str_insert
                                    );
                return this.Json(new { status = true, remark = "Berhasil Disimpan !" }, JsonRequestBehavior.AllowGet);
            
            }
            catch (Exception e)
            {
                return this.Json(new { status = false, error = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult UpdateAsset(TBL_M_ASSET sTBL_M_ASSET)
        {

            try
            {
                ctx_db = new DC_AMKODataContext();
                ctx_db.SP_TRANS_ASSET(sTBL_M_ASSET.ASSET_NUMBER
                                      ,sTBL_M_ASSET.ASSET_NAME
                                      ,sTBL_M_ASSET.ASSET_DATE
                                      ,sTBL_M_ASSET.ST_DATE
                                      ,sTBL_M_ASSET.MERK_CODE
                                      ,sTBL_M_ASSET.SN
                                      ,sTBL_M_ASSET.TYPE_CODE
                                      ,sTBL_M_ASSET.NO_PR
                                      ,sTBL_M_ASSET.PIC
                                      ,sTBL_M_ASSET.DEPT_CODE
                                      ,sTBL_M_ASSET.ORDER_BY
                                      ,sTBL_M_ASSET.AMOUNT
                                      ,sTBL_M_ASSET.COND_CODE
                                      ,sTBL_M_ASSET.LOCATION_CODE
                                      ,sTBL_M_ASSET.REMARK
                                      ,sTBL_M_ASSET.IMG
                                      ,sTBL_M_ASSET.COA_CODE
                                      ,sTBL_M_ASSET.ASSET_CODE
                                      ,sTBL_M_ASSET.SUB_ASSET_CODE
                                      ,sTBL_M_ASSET.NO_PO
                                      ,sTBL_M_ASSET.UE
                                      ,sTBL_M_ASSET.EGI_ID
                                      ,sTBL_M_ASSET.MUTASI_ID
                                      ,cons_str_update
                                    );
                return this.Json(new { status = true, remark = "Berhasil Diupdate !" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                return this.Json(new { status = false, error = e.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AjaxReadDepartemen()
        {
            try
            {
                ctx_db = new DC_AMKODataContext();
                IQueryable<TBL_R_DEPT> tbl_r_dept = ctx_db.TBL_R_DEPTs.OrderBy(f => f.DEPT_NAME);
                return Json(new { Total = tbl_r_dept.Count(), Data = tbl_r_dept });
            }
            catch (Exception e)
            {
                return this.Json(new { error = e.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AjaxReadKondisi()
        {
            try
            {
                ctx_db = new DC_AMKODataContext();
                IQueryable<TBL_R_CONDITION> tbl_r_kondisi = ctx_db.TBL_R_CONDITIONs.OrderBy(f => f.COND_NAME);
                return Json(new { Total = tbl_r_kondisi.Count(), Data = tbl_r_kondisi });
            }
            catch (Exception e)
            {
                return this.Json(new { error = e.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AjaxReadDept()
        {
            try
            {
                ctx_db = new DC_AMKODataContext();
                IQueryable<VW_DEPARTEMEN> vw_departemen = ctx_db.VW_DEPARTEMENs.OrderBy(f => f.DEPARTEMEN);
                return Json(new { Total = vw_departemen.Count(), Data = vw_departemen });
            }
            catch (Exception e)
            {
                return this.Json(new { error = e.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AjaxReadEGI()
        {
            try
            {
                ctx_db = new DC_AMKODataContext();
                IQueryable<TBL_R_EGI> tbl_r_egi = ctx_db.TBL_R_EGIs.OrderBy(f => f.EGI_NAME);
                return Json(new { Total = tbl_r_egi.Count(), Data = tbl_r_egi });
            }
            catch (Exception e)
            {
                return this.Json(new { error = e.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AjaxReadSubAsset()
        {
            try
            {
                ctx_db = new DC_AMKODataContext();
                IQueryable<TBL_R_SUB_ASSET> tbl_r_sub_asset = ctx_db.TBL_R_SUB_ASSETs.OrderBy(f => f.SUB_ASSET_NAME);
                return Json(new { Total = tbl_r_sub_asset.Count(), Data = tbl_r_sub_asset });
            }
            catch (Exception e)
            {
                return this.Json(new { error = e.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AjaxReadCoa()
        {
            try
            {
                ctx_db = new DC_AMKODataContext();
                IQueryable<TBL_R_COA> tbl_r_coa = ctx_db.TBL_R_COAs.OrderBy(f => f.COA_NAME);
                return Json(new { Total = tbl_r_coa.Count(), Data = tbl_r_coa });
            }
            catch (Exception e)
            {
                return this.Json(new { error = e.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }
        

        [HttpPost]
        public JsonResult AjaxReadJenisAsset()
        {
            try
            {
                ctx_db = new DC_AMKODataContext();
                IQueryable<TBL_R_TYPE_ASSET> tbl_r_type_asset = ctx_db.TBL_R_TYPE_ASSETs.OrderBy(f => f.TYPE_NAME);
                return Json(new { Total = tbl_r_type_asset.Count(), Data = tbl_r_type_asset });
            }
            catch (Exception e)
            {
                return this.Json(new { error = e.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AjaxReadLokasi()
        {
            try
            {
                ctx_db = new DC_AMKODataContext();
                IQueryable<TBL_R_LOCATION> tbl_r_location = ctx_db.TBL_R_LOCATIONs.OrderBy(f => f.LOCATION_NAME);
                return Json(new { Total = tbl_r_location.Count(), Data = tbl_r_location });
            }
            catch (Exception e)
            {
                return this.Json(new { error = e.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AjaxReadMutasi()
        {
            try
            {
                ctx_db = new DC_AMKODataContext();
                IQueryable<TBL_R_MUTASI> tbl_r_mutasi = ctx_db.TBL_R_MUTASIs.OrderBy(f => f.MUTASI_NAME);
                return Json(new { Total = tbl_r_mutasi.Count(), Data = tbl_r_mutasi });
            }
            catch (Exception e)
            {
                return this.Json(new { error = e.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult AjaxReadMerk()
        {
            try
            {
                ctx_db = new DC_AMKODataContext();
                IQueryable<TBL_R_MERK> tbl_m_merk = ctx_db.TBL_R_MERKs.OrderBy(f=>f.MERK_NAME);
                return Json(new { Total = tbl_m_merk.Count(), Data = tbl_m_merk });
            }
            catch (Exception e)
            {
                return this.Json(new { error = e.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AjaxReadPIC()
        {
            string[] arr_str = { "sanken", "philips" };
            try
            {
                ctx_db = new DC_AMKODataContext();
               // var arr_r_merk = ["sanken", "president"];
                return Json(arr_str);
            }
            catch (Exception e)
            {
                return this.Json(new { error = e.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AjaxDelete(VW_ASSET sVW_ASSET)
        {
            ctx_db = new DC_AMKODataContext();
            string i_str_remarks = "";

            try
            {
                ctx_db.SP_DELETE_ASSET(sVW_ASSET.ASSET_NUMBER);

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