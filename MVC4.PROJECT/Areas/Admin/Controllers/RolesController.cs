using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Model.EF;

namespace MVC4.PROJECT.Areas.Admin.Controllers
{
    [Authorize(Roles = "administrator, codeadmin")]
    public class RolesController : Controller
    {
        //
        // GET: /Admin/Roles/
        MVCDbContext db = new MVCDbContext();
        public ActionResult Index()
        {
            
            var role = db.WebRoles;
            return View(role);
        }


        public JsonResult GetRoles(string text)
        {
          
            var roles = from x in db.WebRoles select x;
            if (!string.IsNullOrEmpty(text))
            {
                roles = roles.Where(p => p.RoleName.Contains(text));
            }

            return Json(roles, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Exclude = "RoleId")]WebRole model)
        {
            if (ModelState.IsValid)
            {


                var temp = (from p in db.Set<WebRole>()
                            where p.RoleName.Equals(model.RoleName, StringComparison.OrdinalIgnoreCase)
                            select p).FirstOrDefault();
                if (temp != null)
                {
                    ModelState.AddModelError("", "Nhóm đã tồn tại.");
                    return View(model);
                }
                else
                {
                    db.Set<WebRole>().Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            else
            {
                return View(model);
            }
        }
        public ActionResult Edit(int id)
        {

            var role = db.Set<WebRole>().Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            ViewBag.cRoleName = role.RoleName;
            return View("Edit", role);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WebRole model, string cRoleName)
        {
            ViewBag.cRoleName = cRoleName;
            if (ModelState.IsValid)
            {

                try
                {
                    var temp = (from p in db.Set<WebRole>()
                                where p.RoleName.Equals(model.RoleName, StringComparison.OrdinalIgnoreCase) && !p.RoleName.Equals(cRoleName, StringComparison.OrdinalIgnoreCase)
                                select p).FirstOrDefault();
                    if (temp != null)
                    {
                        ModelState.AddModelError("", "Nhóm đã tồn tại.");
                        return View(model);
                    }
                    else
                    {
                        var roleupdate = new WebRole { RoleId = model.RoleId };
                        db.WebRoles.Attach(model);
                        db.Entry(model).Property(a => a.RoleName).IsModified = true;
                        db.Entry(model).Property(a => a.RoleId).IsModified = true;
                        db.Entry(model).Property(a => a.Description).IsModified = true;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", ex.Message);
                    return View(model);
                }
            }

            else
            {
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {

            try
            {
                var role = db.Set<WebRole>().Find(id);
                var user = Roles.GetUsersInRole(role.RoleName);
                if (user != null && user.Count() > 0)
                {
                    Roles.RemoveUsersFromRole(user, role.RoleName);
                    Roles.DeleteRole(role.RoleName);
                }
                else
                    Roles.DeleteRole(role.RoleName);
                return Json("Delete", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
            }

            return Json("Delete", JsonRequestBehavior.AllowGet);
        }

    }
}
