using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using Omu.ValueInjecter;
using System.Data.Entity.Validation;

namespace MVC5Course.Controllers
{
    [RoutePrefix("clients")]
    public class ClientsController : BaseController
    {
        ClientRepository repo;
        OccupationRepository occuRepo;

        public ClientsController()
        {
            repo = RepositoryHelper.GetClientRepository();
            occuRepo = RepositoryHelper.GetOccupationRepository(repo.UnitOfWork);
        }
        [Route("Search")]
        [HttpPost]
        public ActionResult Search(string keyword)
        {
            var client = repo.Search(keyword);
            return View("Index", client);
        }


        [HttpPost]
        [Route("BatchUpdate")]
        [HandleError(ExceptionType = typeof(DbEntityValidationException), View = "Error_DbEntityValidationException")]
        public ActionResult BatchUpdate(IList<ClientBatchViewModel> data, string keyword)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in data)
                {
                    var client = repo.Find(item.ClientId);
                    client.FirstName = item.FirstName;
                    client.MiddleName = item.MiddleName;
                    client.LastName = item.LastName;
                    client.DateOfBirth = item.DateOfBirth;
                }

                repo.UnitOfWork.Commit();
                TempData["message"] = "修改成功";
                if (String.IsNullOrEmpty(keyword))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData.Model = repo.Search(keyword);
                    return View("Index");
                }

            }

            //ViewData.Model = repo.All().OrderByDescending(p => p.ClientId).Take(10);
            ViewData.Model = repo.Search(keyword);

            return View("Index");
        }


        // GET: Clients
        public ActionResult Index()
        {
            var data = repo.All();
            return View(data.OrderByDescending(p => p.ClientId).Take(10));
        }



        [Route("{id}/Details")]

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = repo.Find(id.Value);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        [Route("{id}/orders")]
        [ChildActionOnly]

        public ActionResult Details_OrderList(int id)
        {
            ViewData.Model = repo.Find(id).Order.ToList();
            return PartialView();
        }

        // GET: Clients/Create
        public ActionResult Create()
        {

            ViewBag.OccupationId = new SelectList(occuRepo.All(), "OccupationId", "OccupationName");
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientId,FirstName,MiddleName,LastName,Gender,DateOfBirth,CreditRating,XCode,OccupationId,TelephoneNumber,Street1,Street2,City,ZipCode,Longitude,Latitude,Notes,Idnumber,IsDelete")] Client client)
        {
            if (ModelState.IsValid)
            {
                repo.Add(client);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.OccupationId = new SelectList(occuRepo.All(), "OccupationId", "OccupationName", client.OccupationId);
            return View(client);
        }
        //[ActionFilter練習]
        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = repo.Find(id.Value);
            //ClientsViewModel View_Client = new ClientsViewModel();
            //View_Client.InjectFrom(client);

            if (client == null)
            {
                return HttpNotFound();
            }



            ViewBag.OccupationId = new SelectList(occuRepo.All(), "OccupationId", "OccupationName", client.OccupationId);
            return View(client);
        }




        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection form)
        {
            var client = repo.Find(id);
            if (TryUpdateModel(client, null, null, new string[] { "FirstName" }))
            {
                //var db = repo.UnitOfWork.Context;
                //db.Entry(client).State = EntityState.Modified;
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            //ModelState.Remove("Latitude");

            Client C = repo.Find(client.ClientId);


            ViewBag.OccupationId = new SelectList(occuRepo.All(), "OccupationId", "OccupationName", client.OccupationId);
            return View(C);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ClientId,FirstName,MiddleName,LastName,Gender,DateOfBirth,CreditRating,XCode,OccupationId,TelephoneNumber,Street1,Street2,City,ZipCode,Longitude,Latitude,Notes,Idnumber,IsDelete")] Client client)
        //{
        //    #region 寫得很爛，這樣會造成不可被編輯的欄位也被更新了
        //    if (ModelState.IsValid)
        //    {
        //        var db = repo.UnitOfWork.Context;
        //        db.Entry(client).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    #endregion
        //    //ModelState.Remove("Latitude");

        //    Client C = repo.Find(client.ClientId);


        //    ViewBag.OccupationId = new SelectList(occuRepo.All(), "OccupationId", "OccupationName", client.OccupationId);
        //    return View(C);
        //}

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = repo.Find(id.Value);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = repo.Find(id);
            repo.Delete(client);
            repo.UnitOfWork.Context.Configuration.ValidateOnSaveEnabled = false; //取消輸入驗證與模型驗證
            repo.UnitOfWork.Commit();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
