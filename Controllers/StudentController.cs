using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApiDemo.Utility;
using WebApi.Models;
using AutoMapper;
using WebApiDemo.ViewModal;

namespace WebApiDemo.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student


        protected JsonHelper JsonHelper = new JsonHelper();
        private string BaseUrl = "http://localhost/WebApi/api/StudentWebApi/";

        // GET: Products

        public ActionResult Index1()
        {
            return View();
        }
        public async Task<ActionResult> Index()
        {
            string apiUrl = BaseUrl + "GetAllStudent";

            var data = await JsonHelper.GetAllRequst<Student>(apiUrl);
            var NewData = Mapper.Map<List<Student>, List<StudentViewModal>>(data);


            return View(NewData);

        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new StudentViewModal());
        }
        [HttpPost]
        public async Task<ActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                string apiUrl = BaseUrl + "CreateStudent";

                var data = await JsonHelper.PostRequst(apiUrl, student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        #endregion

        #region Edit

        [HttpGet]
        public async Task<ActionResult> Edit(int ID)
        {
            string apiUrl = BaseUrl + "Edit?ID="+ID;

           var data= await JsonHelper.GetRequst<Student>(apiUrl);
            //  Mapper.CreateMap<>();
            var NewData= Mapper.Map<Student,StudentViewModal>(data);

            return View(NewData);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                string apiUrl = BaseUrl + "Edit";

                var data = await JsonHelper.PostRequst<Student>(apiUrl, student);
                return RedirectToAction("Index");
            }
            return View(student);
        }


        #endregion


        #region Delete
        [HttpPost]
        public async Task<ActionResult> Delete(int ID)
        {
            string apiUrl =BaseUrl + "RemoveStudent?ID=" + ID;
            await JsonHelper.DeleteRequst(apiUrl);
            return RedirectToAction("Index");
        }
        #endregion


    }
}