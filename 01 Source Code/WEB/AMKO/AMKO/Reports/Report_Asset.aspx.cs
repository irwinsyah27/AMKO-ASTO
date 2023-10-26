using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMKO.Reports
{
    public partial class ReportAsset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pv_cust_generateReport(Request.QueryString["PIC"], Request.QueryString["LOKASI"], Request.QueryString["KONDISI"], Request.QueryString["ST_FROM"], Request.QueryString["ST_TO"], Request.QueryString["TYPE_CODE"]);
            }
        }

        private void pv_cust_generateReport(string s_str_pic, string s_str_lokasi, string s_str_kondisi, string s_str_from, string s_str_to, string s_str_type_code)
        {
            Microsoft.Reporting.WebForms.ReportParameter[] i_cls_rParam = new Microsoft.Reporting.WebForms.ReportParameter[6];
            i_cls_rParam[0] = new Microsoft.Reporting.WebForms.ReportParameter("LOKASI", s_str_lokasi);
            i_cls_rParam[1] = new Microsoft.Reporting.WebForms.ReportParameter("ST_FROM", s_str_from);
            i_cls_rParam[2] = new Microsoft.Reporting.WebForms.ReportParameter("KONDISI", s_str_kondisi);
            i_cls_rParam[3] = new Microsoft.Reporting.WebForms.ReportParameter("PIC", s_str_pic);
            i_cls_rParam[4] = new Microsoft.Reporting.WebForms.ReportParameter("ST_TO", s_str_to);
            i_cls_rParam[5] = new Microsoft.Reporting.WebForms.ReportParameter("TYPE_CODE", s_str_type_code);

            string i_str_rpt = "Rpt_Extracomp";

            Report_AssetViewer.ServerReport.ReportServerUrl = new Uri(System.Configuration.ConfigurationManager.AppSettings["report_server_url"].ToString());
            Report_AssetViewer.ServerReport.ReportPath = System.Configuration.ConfigurationManager.AppSettings["report_path"].ToString() + i_str_rpt;
            Report_AssetViewer.ServerReport.SetParameters(i_cls_rParam);
            Report_AssetViewer.ServerReport.Refresh();
        }
    }
}