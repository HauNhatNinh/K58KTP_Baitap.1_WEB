using System;
using System.Web;
using CurrencyDLL;

namespace CurrencyWebApp
{
    public partial class api : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/json";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            try
            {
                // Lấy tham số từ query string
                string amountStr = Request.QueryString["amount"];
                string from = Request.QueryString["from"];
                string to = Request.QueryString["to"];

                if (string.IsNullOrEmpty(amountStr) || string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
                {
                    WriteJson("{\"error\":\"Thiếu tham số.\"}");
                    return;
                }

                decimal amount;
                if (!decimal.TryParse(amountStr, out amount))
                {
                    WriteJson("{\"error\":\"Số tiền không hợp lệ.\"}");
                    return;
                }

                // Gọi DLL để xử lý
                CurrencyConverter converter = new CurrencyConverter();
                string resultMsg = converter.Convert(amount, from.ToUpper(), to.ToUpper());

                // Xuất JSON
                string json = "{\"result\":\"" + EscapeJson(resultMsg) + "\"}";
                WriteJson(json);
            }
            catch (Exception ex)
            {
                WriteJson("{\"error\":\"" + EscapeJson(ex.Message) + "\"}");
            }
            finally
            {
                Response.End();
            }
        }

        private void WriteJson(string json)
        {
            Response.Write(json);
        }

        private string EscapeJson(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            return s.Replace("\\", "\\\\")
                    .Replace("\"", "\\\"")
                    .Replace("\r", "")
                    .Replace("\n", "");
        }
    }
}
