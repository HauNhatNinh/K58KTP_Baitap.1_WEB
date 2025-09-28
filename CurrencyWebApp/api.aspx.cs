
using System;
using System.Web;
using CurrencyDLL;
using System.Globalization;

public partial class api : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        try
        {
            string amountStr = Request.QueryString["amount"];
            string from = Request.QueryString["from"];
            string to = Request.QueryString["to"];

            if (string.IsNullOrEmpty(amountStr) || string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
                throw new Exception("Thiếu tham số đầu vào.");

            decimal amount;
            if (!decimal.TryParse(amountStr, NumberStyles.Any, CultureInfo.InvariantCulture, out amount))
                throw new Exception("Số tiền không hợp lệ.");

            CurrencyConverter converter = new CurrencyConverter();
            string result = converter.Convert(amount, from, to);

            string json = "{\"result\":\"" + EscapeJson(result) + "\"}";
            Response.ContentType = "application/json";
            Response.Write(json);
        }
        catch (Exception ex)
        {
            string errorJson = "{\"error\":\"" + EscapeJson(ex.Message) + "\"}";
            Response.ContentType = "application/json";
            Response.Write(errorJson);
        }
        finally
        {
            Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }

    private string EscapeJson(string s)
    {
        if (string.IsNullOrEmpty(s)) return "";
        return s.Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\r", "\\r")
                .Replace("\n", "\\n");
    }
}

