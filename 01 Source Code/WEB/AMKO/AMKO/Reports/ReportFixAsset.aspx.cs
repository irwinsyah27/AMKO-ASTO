using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMKO.Reports
{
    public partial class ReportFixAsset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pv_cust_generateReport(Request.QueryString["ST_FROM"], Request.QueryString["ST_TO"]);
            }
        }

        private void pv_cust_generateReport(string s_str_from, string s_str_to)
        {
            Microsoft.Reporting.WebForms.ReportParameter[] i_cls_rParam = new Microsoft.Reporting.WebForms.ReportParameter[2];
            i_cls_rParam[0] = new Microsoft.Reporting.WebForms.ReportParameter("ST_FROM", s_str_from);
            i_cls_rParam[1] = new Microsoft.Reporting.WebForms.ReportParameter("ST_TO", s_str_to);

            string i_str_rpt = "Fixed_Asset_Consolidation_Report";

            ReportFixAssetViewer.ServerReport.ReportServerUrl = new Uri(System.Configuration.ConfigurationManager.AppSettings["report_server_url"].ToString());
            ReportFixAssetViewer.ServerReport.ReportPath = System.Configuration.ConfigurationManager.AppSettings["report_path"].ToString() + i_str_rpt;
            ReportFixAssetViewer.ServerReport.SetParameters(i_cls_rParam);
            ReportFixAssetViewer.ServerReport.Refresh();
        }
    }
}