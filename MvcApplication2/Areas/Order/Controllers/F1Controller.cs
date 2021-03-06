﻿using FarmSib.Base.Models;
using MvcApplication2.Areas.Order.Models;
using Nskd;
using System;
using System.Data;
using System.IO;
using System.Web.Mvc;

namespace MvcApplication2.Areas.Order.Controllers
{
    public class F1Controller : Controller
    {
        public Object Index()
        {
            Object result = null;
            RequestPackage rqp = RequestPackage.ParseRequest(Request.InputStream, Request.ContentEncoding);
            if(rqp != null &&
                Int32.TryParse(rqp["specId"] as String, out Int32 specId))
            {
                F1Model m = new F1Model(rqp.SessionId, specId, Request.Url); 
                result = PartialView("~/Areas/Order/Views/F1/Index.cshtml", m);
            }
            return result;
        }
        public Object SaveTableV2()
        {
            RequestPackage rqp = RequestPackage.ParseRequest(Request.InputStream, Request.ContentEncoding);
            String msg = F1Model.SaveTableV2(rqp);
            return msg;// "Для проверки сохранения надо презагрузить таблицу.";
        }
        public FileContentResult DownloadExcelFile(Guid sessionId, Int32 specId)
        {
            F1Model m = new F1Model(sessionId, specId);
            Byte[] buff = NskdExcel.ToExcel(sessionId, m.Table_dt, m.Head_dt);
            String fileName = null;
            try
            {
                fileName = (String)m.Head_dt.Rows[0]["номер_извещения_аукциона"];
            }
            catch (Exception) { }
            if (String.IsNullOrWhiteSpace(fileName)) fileName = specId.ToString();
            if (String.IsNullOrWhiteSpace(fileName)) fileName = DateTime.Now.Date.ToString("yyyy-MM-dd HH:mm");
            fileName += ".xlsx";
            FileContentResult f = File(buff, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            return f;
        }
        private static String cnString = @"Data Source=SRV-SAP;Initial Catalog=Pharm-Sib;Integrated Security=True";
        public FileContentResult DownloadWordFile(Guid sessionId, Int32 specId)
        {
            F1Model m = new F1Model(sessionId, specId);

            //DataTable dt = TestWord.Db.ПолучитьТабличнуюЧастьСпецификации(cnString, specId);
            //using (FileStream file = File.Create(@"C:\Temp\TestWord.docx"))
            //{
                MemoryStream ms = new TestWord.GeneratedClass().CreatePackage(m.Table_dt);
                ms.Position = 0;
            //ms.CopyTo(file);
            //}
            Byte[] buff = ms.ToArray();

            String fileName = null;
            try
            {
                fileName = (String)m.Head_dt.Rows[0]["номер_извещения_аукциона"];
            }
            catch (Exception) { }
            if (String.IsNullOrWhiteSpace(fileName)) fileName = specId.ToString();
            if (String.IsNullOrWhiteSpace(fileName)) fileName = DateTime.Now.Date.ToString("yyyy-MM-dd HH:mm");
            fileName += ".docx";
            FileContentResult f = File(buff, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName);
            return f;
        }
        public String SaveShedule()
        {
            F1Model.SaveShedule(Request.Form);
            return "Сохранено";
        }
    }
}
