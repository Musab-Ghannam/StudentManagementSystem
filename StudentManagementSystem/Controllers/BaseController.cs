
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Mvc;

public class BaseController : Controller
{
    [NonAction]
    protected void ShowAlertPopup(string message, string title, string icon, string returnUrl = null)
    {
        var data = new
        {
            swal_message = message,
            title = title,
            icon = icon,
            returnUrl = returnUrl
        };

        string jsonData = JsonConvert.SerializeObject(data);
        // Create a new notification cookie
        var cookieOptions = new CookieOptions
        {
            Expires = DateTime.Now.AddMinutes(30) 
        };

        HttpCookie cookie = new HttpCookie("notification", jsonData);
        cookie.Expires = ((DateTimeOffset)cookieOptions.Expires).DateTime;
        HttpContext.Response.Cookies.Add(cookie);
    }

    protected void ShowSuccessMessage(string message)
    {
        ShowAlertPopup(message, "Success", "success");
    }

    protected void ShowErrorMessage(string message)
    {
        ShowAlertPopup(message, "Error", "error");
    }



}