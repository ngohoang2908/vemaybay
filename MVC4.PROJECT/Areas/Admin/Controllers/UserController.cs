using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using COMMOM.Interface;
using MVC4.PROJECT.Models;
using WebMatrix.WebData;
using CW_Customers = Model.EF.CW_Customers;
using MVCDbContext = Model.EF.MVCDbContext;
using UserProfile = Model.EF.UserProfile;
using WebRole = Model.EF.WebRole;

namespace MVC4.PROJECT.Areas.Admin.Controllers
{
    [Authorize(Roles = "administrator, codeadmin")]
    public class UserController : BaseController
    {
        //
        // GET: /Admin/User/
        #region "Danh cho tai khoan Quản trị"

        public ActionResult Index()
        {
            var usernames = Roles.GetUsersInRole("administrator");
            IEnumerable<UserProfile> users;
            users = db.UserProfiles.Where(x => usernames.Contains(x.UserName)).OrderByDescending(x => x.UserId);
            return View(users);
        }

        public ActionResult Add()
        {
            var roles = from x in db.WebRoles where !x.RoleName.Equals("codeadmin") select x;
            ViewBag.Roles = roles;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Exclude = "")]RegisterModel model, string[] roles, HttpPostedFileBase image)
        {

            ModelState.Remove("UserProfile.UserName");
            model.UserProfile.UserName = model.UserName;
            if (ModelState.IsValid)
            {
                //using (PortalContext db = new PortalContext())
                //{
                var temp = (from p in db.Set<UserProfile>()
                            where p.UserName.Equals(model.UserName, StringComparison.OrdinalIgnoreCase)
                            select p).FirstOrDefault();
                if (temp != null)
                {
                    ModelState.AddModelError("", "Tài khoản này đã tồn tại. Vui lòng nhập tài khoản khác !");
                    MVCDbContext dbs = new MVCDbContext();
                    var rolesss = from x in dbs.WebRoles where !x.RoleName.Equals("codeadmin") select x;
                    ViewBag.Roles = rolesss;
                    return View(model);
                }
                else
                {
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password, new
                    {
                        FullName = model.UserProfile.FullName,
                        Email = model.UserProfile.Email,
                        Address = model.UserProfile.Address,
                        Mobile = model.UserProfile.Mobile,
                        IsLock = model.UserProfile.IsLock
                    }, false);
                    try
                    {
                        Roles.AddUserToRoles(model.UserName, roles);
                    }
                    catch (Exception)
                    { }
                    return RedirectToAction("Index");
                }
            }
            //}
            else
            {
                return View(model);
            }
        }

        public ActionResult Edit(int id)
        {
            var user = db.Set<UserProfile>().Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.cUserName = user.UserName;
            IEnumerable<WebRole> roles = from x in db.WebRoles where !x.RoleName.Equals("codeadmin") select x;
            string[] lsroles = Roles.GetRolesForUser(user.UserName);
            var selectedItems = new List<SelectListItem>();
            foreach (string obj in lsroles)
            {
                foreach (var item in roles)
                {
                    if (item.RoleName.Equals(obj))
                    {
                        selectedItems.Add(new SelectListItem() { Text = item.RoleName, Value = item.RoleName, Selected = true });
                    }
                    else
                        selectedItems.Add(new SelectListItem() { Text = item.RoleName, Value = item.RoleName, Selected = false });
                }
            }
            ViewBag.SelectList = selectedItems;
            return View("Edit", user);
        }
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "")]UserProfile model, string cUserName, string[] roles)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Roles = roles;
                db.UserProfiles.Attach(model);
                db.Entry(model).Property(a => a.UserName).IsModified = false;
                db.Entry(model).Property(a => a.FullName).IsModified = true;
                db.Entry(model).Property(a => a.Email).IsModified = true;
                db.Entry(model).Property(a => a.Mobile).IsModified = true;
                db.Entry(model).Property(a => a.Address).IsModified = true;
                db.Entry(model).Property(a => a.IsLock).IsModified = true;
                db.SaveChanges();
                try
                {
                    foreach (var role in Roles.GetRolesForUser(model.UserName))
                    {
                        Roles.RemoveUserFromRole(model.UserName, role);
                    }
                    Roles.AddUserToRoles(model.UserName, roles);
                }
                catch (Exception)
                { }
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }

        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var user = db.Set<UserProfile>().Find(id);
            try
            {
                if (Roles.GetRolesForUser(user.UserName).Count() > 0)
                {
                    Roles.RemoveUserFromRoles(user.UserName, Roles.GetRolesForUser(user.UserName));
                }
                ((SimpleMembershipProvider)Membership.Provider).DeleteAccount(user.UserName);
                ((SimpleMembershipProvider)Membership.Provider).DeleteUser(user.UserName, true);
                return Json("Index", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(user);
            }
        }

        #endregion
        #region "Dành cho thành viên"
        /// <summary>
        /// Danh sách khách hàng
        /// </summary>
        /// <returns></returns>
        public ActionResult Customer()
        {
            var usernames = Roles.GetUsersInRole("customer");
            IEnumerable<CW_Customers> users;
            users = db.CW_Customers.Where(x => usernames.Contains(x.UserNameCustomer)).OrderByDescending(x => x.UserId);
            return View(users);
        }
        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <returns></returns>
        public ActionResult AddCustomer()
        {
            var customergroup = db.CW_CustomerGroups.OrderByDescending(x => x.CreatedDate);
            ViewBag.CustomerGroup = new SelectList(customergroup, "CustomerGroupsID", "CustomerGroupName");
            return View();
        }
        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCustomer([Bind(Exclude = "")]RegisterCustomersModel model)
        {
            ModelState.Remove("UserProfile.UserName");
            string[] roles = { "customer" };
            if (ModelState.IsValid)
            {
                var temp = (from x in db.Set<UserProfile>()
                            where x.UserName.Equals(model.CW_Customers.UserNameCustomer, StringComparison.OrdinalIgnoreCase)
                            select x).FirstOrDefault();
                if (temp != null)
                {
                    ModelState.AddModelError("", "Tài khoản đã tồn tại");
                    return View(model);
                }
                else
                {
                    WebSecurity.CreateUserAndAccount(model.CW_Customers.UserNameCustomer, model.Password,
                        new
                        {
                            FullName = model.CW_Customers.UserProfile.FullName,
                            Email = model.CW_Customers.UserNameCustomer,
                            Address = model.CW_Customers.UserProfile.Address,
                            Mobile = model.CW_Customers.UserProfile.Mobile,
                            IsLock = model.CW_Customers.UserProfile.IsLock
                        }, false);

                    var userProfile = db.UserProfiles.FirstOrDefault(x => x.UserName == model.CW_Customers.UserNameCustomer);
                    if (userProfile != null)
                    {
                        var users = new CW_Customers
                        {
                            UserProfile = userProfile,
                            UserNameCustomer = model.CW_Customers.UserNameCustomer,
                            NickYahoo = model.CW_Customers.NickYahoo,
                            NickSkype = model.CW_Customers.NickSkype,
                            Facebook = model.CW_Customers.Facebook,
                            CustomerGroupsID = model.CW_Customers.CustomerGroupsID,
                            CreatedDate = DateTime.Now
                        };
                        db.CW_Customers.Add(users);
                        db.SaveChanges();
                    }
                    try
                    {
                        Roles.AddUserToRoles(model.CW_Customers.UserNameCustomer, roles);
                    }
                    catch (Exception)
                    { }
                    return RedirectToAction("Customer");
                }
            }
            else
            {
                return View(model);
            }

        }

        public ActionResult EditCustomer(int id)
        {
            var customergroup = db.CW_CustomerGroups.OrderByDescending(x => x.CreatedDate);
            ViewBag.CustomerGroup = new SelectList(customergroup, "CustomerGroupsID", "CustomerGroupName");

            var customer = db.CW_Customers.Find(id);
            return View(customer);
        }
        /// <summary>
        /// Sửa khách hàng
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer([Bind(Exclude = "")]CW_Customers model)
        {
            if (ModelState.IsValid)
            {
                //CW_Customers obj = new CW_Customers();
                model.CreatedDate = DateTime.Now;
                //db.CW_Customers.Attach(model);
                //db.Entry(model).Property(x => x.UserNameCustomer).IsModified = false;
                //db.Entry(model).Property(x => x.UserProfile.FullName).IsModified = true;
                //db.Entry(model).Property(x => x.UserProfile.Email).IsModified = true;
                //db.Entry(model).Property(x => x.UserProfile.Address).IsModified = true;
                //db.Entry(model).Property(x => x.UserProfile.Email).IsModified = true;
                //db.Entry(model).Property(x => x.UserProfile.Mobile).IsModified = true;
                //db.Entry(model).Property(x => x.UserProfile.IsLock).IsModified = false;
                //db.Entry(model).Property(x => x.NickYahoo).IsModified = true;
                //db.Entry(model).Property(x => x.NickSkype).IsModified = true;
                //db.Entry(model).Property(x => x.Facebook).IsModified = true;
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Customer");
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult resetpassword(string id)
        {
            ViewBag.Username = id;
            return View();
        }

        [HttpPost]
        public ActionResult resetpassword(string username, string newpass)
        {
            var token = WebSecurity.GeneratePasswordResetToken(username);
            WebSecurity.ResetPassword(token, newpass);
            return RedirectToAction("Customer");
        }
      
        public ActionResult ResetPasswordCustomer(string id)
        {
            ViewBag.Username = id;
            return View();
        }
        /// <summary>
        /// Reset lại mật khẩu của khách hàng
        /// </summary>
        /// <param name="username"></param>
        /// <param name="newpass"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPasswordCustomer(string username, string newpass)
        {
            var token = WebSecurity.GeneratePasswordResetToken(username);
            WebSecurity.ResetPassword(token, newpass);
            return RedirectToAction("Customer");
        }
        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CusDelete(int id)
        {
            var userpro = db.Set<UserProfile>().Find(id);
            var user = db.Set<CW_Customers>().Find(id);
            try
            {
                var catedelte = db.CW_Customers.Attach(user);
                db.Set<CW_Customers>().Remove(catedelte);
                db.SaveChanges();
                if (Roles.GetRolesForUser(userpro.UserName).Count() > 0)
                {
                    Roles.RemoveUserFromRoles(userpro.UserName, Roles.GetRolesForUser(userpro.UserName));
                }
                ((SimpleMembershipProvider)Membership.Provider).DeleteAccount(userpro.UserName);
                ((SimpleMembershipProvider)Membership.Provider).DeleteUser(userpro.UserName, true);
                return Json("Index", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(user);
            }
        }
        #endregion
        #region "đăng nhập, đăng xuất"
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            //var lang = db.CW_Language.OrderByDescending(x => x.LanguageCode);
            //ViewBag.Language = new SelectList(lang, "LanguageCode", "Title");
            //ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            {
                //SessionManager.CurrentCulture = model.LanguageCode;
                //Session["language"] = model.LanguageCode;
                Session["IsAuthenticated"] = true;
                return RedirectToLocal(returnUrl);
            }
            //var lang = db.CW_Language.OrderByDescending(x => x.LanguageCode);
            //ViewBag.Language = new SelectList(lang, "LanguageCode", "Title");
            ModelState.AddModelError("", "Tài khoản hoặc mật khẩu bạn nhập không chính xác.");
            return View(model);
        }

        public ActionResult LogOff()
        {
            Session.Abandon();
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }
        #endregion
        #region "helper"

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        #endregion

        #region "Profile"

        public ActionResult ViewProfile()
        {
            return View();
        }
        /// <summary>
        /// Thông tin cá nhân
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public PartialViewResult _ViewProfile()
        {
            var user = db.UserProfiles.Where(x => x.UserName == WebSecurity.CurrentUserName).First();
            return PartialView(user);
        }
        /// <summary>
        /// Thay doi thông tin cấ nhân
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult _ViewProfile(UserProfile user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return PartialView("_ViewProfile");
        }

        public ActionResult ChangePassCurrentUserName()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult _ChangePassCurrentUserName()
        {
            return PartialView();
        }
        /// <summary>
        /// Thay doi mat khau
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult _ChangePassCurrentUserName([Bind(Exclude = "")]LocalPasswordModel model)
        {
            WebSecurity.ChangePassword(WebSecurity.CurrentUserName, model.OldPassword, model.NewPassword);
            return PartialView("_ChangePassCurrentUserName");
        }
        #endregion
        MVCDbContext db = new MVCDbContext();
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
