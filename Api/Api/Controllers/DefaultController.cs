using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Web.Hosting;
using Api.Clases;
using Api.Models.ViewModels;

namespace Api.Controllers
{
    public class DefaultController : ApiController
    {
        private ClDb.Cls_Coneccion CONN = new ClDb.Cls_Coneccion();

        [HttpPost]
        public KeyValuePair<bool, string> UploadFile()
        {
            try
            {
                if (HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];
                    if (httpPostedFile != null)
                    {
                        httpPostedFile.SaveAs(HttpContext.Current.Server.MapPath("~/Upload") + "\\" + httpPostedFile.FileName);
                        return new KeyValuePair<bool, string>(true, "File uploaded successfully.");
                    }
                    return new KeyValuePair<bool, string>(true, "Could not get the uploaded file.");
                }
                return new KeyValuePair<bool, string>(true, "No file found to upload.");
            }
            catch (Exception ex)
            {
                return new KeyValuePair<bool, string>(false, "An error occurred while uploading the file. Error Message: " + ex.Message);
            }
        }

        [HttpGet]
        public Object Login([FromBody] VMAccess Param)
        {
            try
            {
                //using (Api.Models.BdCoinsaContext BdCoinsa = new Api.Models.BdCoinsaContext())
                //{
                //    var lst = BdCoinsa.TblUsuarios.Where(d =>d.Usuario==Param.Usuario && );
                //}


                CONN.SetCommand("Usuarios.SpLogin");
                CONN.CreateParameter("@Usuario", Param.Usuario);
                CONN.CreateParameter("@Contraseña", Param.Contraseña);
                CONN.CreateParameter("@Token", Guid.NewGuid().ToString());
                DataTable Login;
                Login = CONN.getDataTable();
                return Login;
            }
            catch (Exception ex)
            {
                return new { ErrMensaje = ex.Message };
            }
        }
    }
}
