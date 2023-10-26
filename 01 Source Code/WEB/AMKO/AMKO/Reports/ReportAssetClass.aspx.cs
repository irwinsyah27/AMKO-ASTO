using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMKO.Reports
{
    public partial class ReportAssetClass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pv_cust_generateReport(Request.QueryString["DEPARTEMEN"], Request.QueryString["COA_CODE"], Request.QueryString["TYPE_CODE"]);
            }
        }

        private void pv_cust_generateReport(string s_str_dept, string i_str_coa, string i_str_jenisAsset)
        {
            Microsoft.Reporting.WebForms.ReportParameter[] i_cls_rParam = new Microsoft.Reporting.WebForms.ReportParameter[3];
            i_cls_rParam[0] = new Microsoft.Reporting.WebForms.ReportParameter("DEPARTEMEN", s_str_dept);
            i_cls_rParam[1] = new Microsoft.Reporting.WebForms.ReportParameter("COA_CODE", i_str_coa);
            i_cls_rParam[2] = new Microsoft.Reporting.WebForms.ReportParameter("TYPE_CODE", i_str_jenisAsset);

            string i_str_rpt = "Rpt_Asset_Class";

            ReportAssetClassViewer.ServerReport.ReportServerUrl = new Uri(System.Configuration.ConfigurationManager.AppSettings["report_server_url"].ToString());
            ReportAssetClassViewer.ServerReport.ReportPath = System.Configuration.ConfigurationManager.AppSettings["report_path"].ToString() + i_str_rpt;
            ReportAssetClassViewer.ServerReport.SetParameters(i_cls_rParam);
            ReportAssetClassViewer.ServerReport.Refresh();
        }
    }
}