using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class FileUpController : Controller
    {
        //
        // GET: /FileUp/
        public string Index()
        {
            string upfile = Request.Form["name"]; //取得上传的对象名称
            HttpPostedFileBase pstFile = Request.Files["file"];
            UploadFiles upFiles = new UploadFiles();
            string msg = upFiles.fileSaveAs(pstFile, upfile);
            return msg;
             
        }
	}
}