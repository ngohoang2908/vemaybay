using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using Model.EF;
using MVC4.PROJECT.Filters;
using MVC4.PROJECT.Models;
using WebMatrix.WebData;

namespace MVC4.PROJECT.Controllers
{
    //[Authorize]
    //[InitializeSimpleMembership]
    public class AccountController : BaseController
    {
        MVCDbContext db = new MVCDbContext();
        //
        // GET: /Account/Login
        #region "login & logout & register"
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (HttpContext.Request.UrlReferrer != null)
            {
                ViewBag.ReturnUrl = HttpContext.Request.UrlReferrer.PathAndQuery;
            }
            else
                ViewBag.ReturnUrl = "/";
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            {
                return RedirectToLocal(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng !");
            return View(model);
        }
        #endregion
        //
        // POST: /Account/LogOff

        [COMMOM.ClientAuthorize]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return Redirect(HttpContext.Request.UrlReferrer.PathAndQuery);
        }
        [ChildActionOnly]
        public PartialViewResult _RegisterModule()
        {
            return PartialView();
        }
        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public JsonResult Register(RegisterCustomersModel model)
        {
            string[] roles = { "customer" };
            var respone = new { flag = 0 };
            //nhóm khách hàng mặc định
            var cusgroup = db.CW_CustomerGroups.Where(x => x.IsDefault).FirstOrDefault();
            var temp = (from p in db.Set<UserProfile>()
                        where p.UserName.Equals(model.CW_Customers.UserNameCustomer, StringComparison.OrdinalIgnoreCase)
                        select p).FirstOrDefault();
            if (temp != null)//tài khoản đã tồn tại
            {
                ModelState.AddModelError("", "Tài khoản này đã tồn tại. vui lòng nhập tài khoản khác !");
                respone = new { flag = 0 };
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

                var userProfile = db.UserProfiles.FirstOrDefault(u => u.UserName == model.CW_Customers.UserNameCustomer);
                if (userProfile != null)
                {
                    var users = new CW_Customers
                    {
                        UserProfile = userProfile,
                        UserNameCustomer = model.CW_Customers.UserNameCustomer,
                        NickYahoo = model.CW_Customers.NickYahoo,
                        NickSkype = model.CW_Customers.NickSkype,
                        Facebook = model.CW_Customers.Facebook,
                        CustomerGroupsID = cusgroup.CustomerGroupsID,
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
                respone = new { flag = 1 };
            }
            return Json(respone, JsonRequestBehavior.AllowGet);
        }
        public ActionResult RegisterComplete()
        {
            return View();
        }
        #region "Change & reset password"

        [COMMOM.ClientAuthorize]
        public ActionResult ChangePass()
        {
            return View();
        }

        [ChildActionOnly]
        [COMMOM.ClientAuthorize]
        public PartialViewResult _ChangePass()
        {
            return PartialView();
        }

        [HttpPost]
        [COMMOM.ClientAuthorize]
        public PartialViewResult _ChangePass([Bind(Exclude = "")]LocalPasswordModel model)
        {
            WebSecurity.ChangePassword(WebSecurity.CurrentUserName, model.OldPassword, model.NewPassword);
            return PartialView();
        }

        [AllowAnonymous]
        public ActionResult SendPassword()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult _SendPassword()
        {
            return PartialView();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public JsonResult _SendPassword(string UserName)
        {
            var respone = new { flag = 0 };
            //generate password token
            var token = WebSecurity.GeneratePasswordResetToken(UserName);
            //create url with above token
            var resetLink = "<a href='" + Url.Action("ResetPassword", "Account", new { un = UserName, rt = token }, "http") + "'>Reset Password</a>";

            string body = "<b>Hãy nhấn vào link dưới đây để lấy lại mật khẩu của bạn: </b><br/>" + resetLink; //edit it
            try
            {
                var user = db.CW_Customers.Where(x => x.UserNameCustomer.Equals(UserName)).FirstOrDefault();
                if (user != null)
                {
                    COMMOM.Interface.Helper.SendMail("HoangTan", "Cấp lại mật khẩu : " + UserName, body, user.UserNameCustomer);
                    respone = new { flag = 1 };
                }
                else
                    respone = new { flag = 0 };
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error occured while sending email." + ex.Message;
            }

            return Json(respone, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        [COMMOM.ClientAuthorize]
        public ActionResult ResetPassword(string un, string rt)
        {
            //MVCDbContext db = new MVCDbContext();
            //TODO: Check the un and rt matching and then perform following
            //get userid of received username
            var userid = (from i in db.UserProfiles
                          where i.UserName == un
                          select i.UserId).FirstOrDefault();
            //check userid and token matches
            bool any = (from j in db.webpages_Memberships
                        where (j.UserId == userid)
                        && (j.PasswordVerificationToken == rt)
                        //&& (j.PasswordVerificationTokenExpirationDate < DateTime.Now)
                        select j).Any();

            if (any == true)
            {
                //generate random password
                string newpassword = COMMOM.Extends.GenerateRandomPassword(8);
                //reset password
                bool response = WebSecurity.ResetPassword(rt, newpassword);
                if (response == true)
                {
                    //get user emailid to send password
                    var emailid = (from i in db.UserProfiles
                                   where i.UserName == un
                                   select i.Email).FirstOrDefault();
                    //send email
                    string subject = "Gửi mật khẩu mới";
                    string body = "<b>Dưới đây là mật khẩu mới của bạn, hãy lưu trữ và đăng nhập bằng mật khẩu này</b><br/>" + newpassword; //edit it
                    try
                    {

                        COMMOM.Interface.Helper.SendMail("HoangTan", subject, body, emailid);
                        TempData["Message"] = "Mail đã được gửi.";
                    }
                    catch (Exception ex)
                    {
                        TempData["Message"] = "Có lỗi xảy ra trong khi gửi mail." + ex.Message;
                    }

                    //display message
                    TempData["Message"] = "Thành công! Mail mới của bạn là  " + newpassword;
                }
                else
                {
                    TempData["Message"] = "Không tạo được mật khẩu tự động.";
                }
            }
            else
            {
                TempData["Message"] = "Tài khoản hoặc mã không chính xác";
            }

            return View();
        }

        #endregion

        #region "profile"

        [COMMOM.ClientAuthorize]
        public ActionResult ProfileUser()
        {
            return View();
        }

        [ChildActionOnly]
        [COMMOM.ClientAuthorize]
        public PartialViewResult _ProfileUser()
        {
            var user = db.CW_Customers.Where(x => x.UserNameCustomer == WebSecurity.CurrentUserName).FirstOrDefault();
            return PartialView(user);
        }

        [HttpPost]
        [COMMOM.ClientAuthorize]
        public PartialViewResult _ProfileUser(CW_Customers user)
        {
            user.CreatedDate = DateTime.Now;
            db.Entry(user).State = EntityState.Modified;
            db.Entry(user.UserProfile).State = EntityState.Modified;
            db.SaveChanges();
            var users = db.CW_Customers.Where(x => x.UserNameCustomer == WebSecurity.CurrentUserName).FirstOrDefault();
            return PartialView("_ProfileUser", users);
        }

        #endregion

        #region "lịch sử đơn hàng"

      


        #endregion
        //
        // POST: /Account/Disassociate

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Disassociate(string provider, string providerUserId)
        {
            string ownerAccount = OAuthWebSecurity.GetUserName(provider, providerUserId);
            ManageMessageId? message = null;

            // Only disassociate the account if the currently logged in user is the owner
            if (ownerAccount == User.Identity.Name)
            {
                // Use a transaction to prevent the user from deleting their last login credential
                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {
                    bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
                    if (hasLocalAccount || OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name).Count > 1)
                    {
                        OAuthWebSecurity.DeleteAccount(provider, providerUserId);
                        scope.Complete();
                        message = ManageMessageId.RemoveLoginSuccess;
                    }
                }
            }

            return RedirectToAction("Manage", new { Message = message });
        }

        //
        // GET: /Account/Manage

        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : "";
            ViewBag.HasLocalPassword = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //
        // POST: /Account/Manage

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(LocalPasswordModel model)
        {
            bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.HasLocalPassword = hasLocalAccount;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasLocalAccount)
            {
                if (ModelState.IsValid)
                {
                    // ChangePassword will throw an exception rather than return false in certain failure scenarios.
                    bool changePasswordSucceeded;
                    try
                    {
                        changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
                    }
                    catch (Exception)
                    {
                        changePasswordSucceeded = false;
                    }

                    if (changePasswordSucceeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                    }
                }
            }
            else
            {
                // User does not have a local password so remove any validation errors caused by a missing
                // OldPassword field
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        WebSecurity.CreateAccount(User.Identity.Name, model.NewPassword);
                        return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("", String.Format("Unable to create local account. An account with the name \"{0}\" may already exist.", User.Identity.Name));
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/ExternalLogin

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback

        [AllowAnonymous]
        public ActionResult ExternalLoginCallback(string returnUrl)
        {
            AuthenticationResult result = OAuthWebSecurity.VerifyAuthentication(Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
            if (!result.IsSuccessful)
            {
                return RedirectToAction("ExternalLoginFailure");
            }

            if (OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, createPersistentCookie: false))
            {
                return RedirectToLocal(returnUrl);
            }

            if (User.Identity.IsAuthenticated)
            {
                // If the current user is logged in add the new account
                OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, User.Identity.Name);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                // User is new, ask for their desired membership name
                string loginData = OAuthWebSecurity.SerializeProviderUserId(result.Provider, result.ProviderUserId);
                ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(result.Provider).DisplayName;
                ViewBag.ReturnUrl = returnUrl;
                return View("ExternalLoginConfirmation", new RegisterExternalLoginModel { UserName = result.UserName, ExternalLoginData = loginData });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLoginConfirmation(RegisterExternalLoginModel model, string returnUrl)
        {
            string provider = null;
            string providerUserId = null;

            if (User.Identity.IsAuthenticated || !OAuthWebSecurity.TryDeserializeProviderUserId(model.ExternalLoginData, out provider, out providerUserId))
            {
                return RedirectToAction("Manage");
            }

            if (ModelState.IsValid)
            {
                // Insert a new user into the database
                using (MVCDbContext db = new MVCDbContext())
                {
                    UserProfile user = db.UserProfiles.FirstOrDefault(u => u.UserName.ToLower() == model.UserName.ToLower());
                    // Check if user already exists
                    if (user == null)
                    {
                        // Insert name into the profile table
                        db.UserProfiles.Add(new UserProfile { UserName = model.UserName });
                        db.SaveChanges();

                        OAuthWebSecurity.CreateOrUpdateAccount(provider, providerUserId, model.UserName);
                        OAuthWebSecurity.Login(provider, providerUserId, createPersistentCookie: false);

                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", "User name already exists. Please enter a different user name.");
                    }
                }
            }

            ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(provider).DisplayName;
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // GET: /Account/ExternalLoginFailure

        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult ExternalLoginsList(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return PartialView("_ExternalLoginsListPartial", OAuthWebSecurity.RegisteredClientData);
        }

        [ChildActionOnly]
        public ActionResult RemoveExternalLogins()
        {
            ICollection<OAuthAccount> accounts = OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name);
            List<ExternalLogin> externalLogins = new List<ExternalLogin>();
            foreach (OAuthAccount account in accounts)
            {
                AuthenticationClientData clientData = OAuthWebSecurity.GetOAuthClientData(account.Provider);

                externalLogins.Add(new ExternalLogin
                {
                    Provider = account.Provider,
                    ProviderDisplayName = clientData.DisplayName,
                    ProviderUserId = account.ProviderUserId,
                });
            }

            ViewBag.ShowRemoveButton = externalLogins.Count > 1 || OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            return PartialView("_RemoveExternalLoginsPartial", externalLogins);
        }

        #region Helpers
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

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }

        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
            }
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
