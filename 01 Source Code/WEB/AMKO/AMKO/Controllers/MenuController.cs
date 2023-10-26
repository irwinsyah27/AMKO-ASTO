using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMKO.Models;

namespace AMKO.Controllers
{
    public class MenuController : Controller
    {
        DB_APPSDataContext db;
        public string menu_url;

        // GET: Menu
        protected override void OnActionExecuting(ActionExecutingContext filterContext)

        {
            string s_str_username = Convert.ToString(Session["username"]);
            string s_str_gpid = Convert.ToString(Session["gpid"]);
            int s_int_gpidcode = Convert.ToInt32(Session["gpidcode"]);
            string s_str_gpiddesc = Convert.ToString(Session["gpiddesc"]);

            menu_url = Request.Url.AbsolutePath.ToString();

            ViewBag.myAccount = pb_cust_GetDetailProfile(s_str_username, s_str_gpid, s_int_gpidcode, s_str_gpiddesc);

            if (ViewBag.myAccount == null)
            {
                ViewBag.isValidAccount = "0";
            }
            else
            {
                ViewBag.isValidAccount = "1";
            }
            base.OnActionExecuting(filterContext);
        }

        public List<cusp_GetProfileMenuResult> BuildMenu(string s_str_gp_id, string s_str_nrp)
        {
            db = new DB_APPSDataContext();
            List<cusp_GetProfileMenuResult> a = db.cusp_GetProfileMenu(s_str_gp_id, s_str_nrp).OrderBy(f => f.SORT_ORDER).ToList();
            db.Dispose();
            return a;
        }

        public LoginViewModel pb_cust_GetDetailProfile(string s_str_username, string s_str_gpid, int s_int_gpidcode, string s_str_gpiddesc)
        {

            LoginViewModel myAccount = new LoginViewModel();
            db = new DB_APPSDataContext();

            cusp_GetDetailProfileResult profile = db.cusp_GetDetailProfile(s_str_username, s_str_gpid, s_int_gpidcode, s_str_gpiddesc).FirstOrDefault();

            if (menu_url != null)
            {
                if (menu_url != "/")
                {
                    if (menu_url != "/Home/Index")
                    {
                        if (menu_url == "/Asset/TransaksiAsset")
                        {
                            menu_url = "/Asset/Index";
                        }
                        if (menu_url == "/Histori/index")
                        {
                            menu_url = "/Asset/Index";
                        }

                        var iTbl = db.cusp_GetAccessMenu(menu_url, Convert.ToString(Session["gpid"])).FirstOrDefault();

                        if (iTbl != null)
                        {
                            myAccount.CREATE_ACCESS = iTbl.C.ToString();
                            myAccount.READ_ACCESS = iTbl.R.ToString();
                            myAccount.UPDATE_ACCESS = iTbl.U.ToString();
                            myAccount.DELETE_ACCESS = iTbl.D.ToString();
                            myAccount.VALID_ACCESS = true;
                        }
                        else
                        {
                            if (Request.UrlReferrer != null)
                            {
                                if (Request.UrlReferrer.AbsolutePath.ToString() == "/Home/Index")
                                {
                                    menu_url = Request.Url.AbsolutePath.ToString();
                                }
                                else
                                {
                                    menu_url = Request.UrlReferrer.AbsolutePath.ToString();
                                }
                            }

                            var iTbl2 = db.cusp_GetAccessMenu(menu_url, Convert.ToString(Session["gpid"])).FirstOrDefault();

                            if (iTbl2 != null)
                            {
                                myAccount.CREATE_ACCESS = iTbl2.C.ToString();
                                myAccount.READ_ACCESS = iTbl2.R.ToString();
                                myAccount.UPDATE_ACCESS = iTbl2.U.ToString();
                                myAccount.DELETE_ACCESS = iTbl2.D.ToString();
                                myAccount.VALID_ACCESS = true;
                            }
                            else
                            {
                                myAccount.CREATE_ACCESS = "False";
                                myAccount.READ_ACCESS = "False";
                                myAccount.UPDATE_ACCESS = "False";
                                myAccount.DELETE_ACCESS = "False";
                                myAccount.VALID_ACCESS = false;
                            }
                        }
                    }
                    else
                    {
                        myAccount.VALID_ACCESS = true;
                    }
                }
                else
                {
                    myAccount.VALID_ACCESS = true;
                }
            }

            if (profile != null)
            {
                myAccount.NRP = profile.EMPLOYEE_ID;
                myAccount.EMPLOYEEID = profile.EMPLOYEE_ID;
                myAccount.NAME = profile.NAME;
                myAccount.GPID = profile.GPID;
                myAccount.GPID_CODE = Convert.ToInt32(profile.GPID_CODE);
                myAccount.GPID_DESC = profile.GPID_DESC;
                myAccount.WEB_APP_PATH = System.Configuration.ConfigurationManager.AppSettings["WebApp_Path"].ToString();
                myAccount.REPORT_SERVER_PATH = System.Configuration.ConfigurationManager.AppSettings["report_server_url"].ToString();
                myAccount.REPORT_URL_PATH = System.Configuration.ConfigurationManager.AppSettings["report_path"].ToString();
                myAccount.POST_DESC = profile.POS_TITLE;
                myAccount.DEPT_DESC = profile.DEPT;
                myAccount.DISTRICT_CODE = profile.DSTRCT_CODE;
                myAccount.MENU = BuildMenu(profile.GPID, profile.EMPLOYEE_ID);
            }
            else
            {
               
               return null;
                
            }

            db.Dispose();
            return myAccount;
        }

        public void pb_cust_resetAccount()
        {
            Session.RemoveAll();
        }
    }
}