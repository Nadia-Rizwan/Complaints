using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UserApplication.Models;
using UserApplication.ViewModels;


namespace UserApplication.Controllers
{
    public class UsersController : Controller
    {

        private ApplicationSignInManager _signInManager;

        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _appRoleManager;


        public UsersController()
        {

        }

        public UsersController(ApplicationUserManager userManager, ApplicationRoleManager appRoleManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            AppRoleManager = appRoleManager;
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }


        protected ApplicationRoleManager AppRoleManager
        {
            get
            {
                return _appRoleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
            private set
            {
                _appRoleManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: User
        public ActionResult Index()
        {

            try { 
           
                var  usersWithRoles = (from user in db.Users
                                  from userRole in user.Roles
                                  join role in db.Roles on userRole.RoleId equals
                                  role.Id
                                  select new UserViewModel()
                                  {
                                      FirstName = user.FirstName,
                                      LastName = user.LastName,
                                      UserName = user.UserName,
                                      Email = user.Email,
                                      Role = role.Name,
                                       CNIC = user.CNIC,
                                      PhoneNumber = user.PhoneNumber,
                                      Id=user.Id,
                                      
                                  }).ToList();

               

                var model = new ManageUserViewModel();
                model.Users = usersWithRoles;
                return View(model);
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        [HttpGet]
        public ActionResult Registeruser()
        {
            try { 
            
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var role in db.Roles)
                list.Add(new SelectListItem() { Value = role.Name, Text = role.Name });
            ViewBag.Roles = list;
        
            return View();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registeruser(RoleViewModel model)
        {
            try { 

            if (ModelState.IsValid)
            {
               
         
                var user = new Models.ApplicationUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName=model.UserName,
                    CNIC=model.CNIC,
                    PhoneNumber=model.PhoneNumber,
                    Email=model.Email,
                    EmailConfirmed=true,
             

                };
                var result = await UserManager.CreateAsync(user, model.Password);

               
                if (result.Succeeded)
                {
                   
                    var result1 = await UserManager.AddToRoleAsync(user.Id, model.UserRole);
                    
                    db.SaveChanges();

                    if (result1.Succeeded)
                    {
                        return RedirectToAction("Index", "Users");
                    }
                   
                }
                    AddErrors(result);

            }
          
            return View(model);
            }

            catch (Exception ex)
            {
                throw;
            }

        }









        [AllowAnonymous]

        public ActionResult Login(string returnUrl)
        {
            try
            {
                ViewBag.ReturnUrl = returnUrl;
                return View();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]

        public async Task<ActionResult> Login(LoginUserViewModel LoginUser, string returnUrl)
        {

            try
            {

                if (!ModelState.IsValid)
                { return View(LoginUser); }


                var result = await SignInManager.PasswordSignInAsync(LoginUser.Username, LoginUser.Password, LoginUser.RememberMe, shouldLockout: false);

                switch (result)
                {

                    case SignInStatus.Success:
                        {
                            var user = UserManager.FindByName(LoginUser.Username);
                            if (user != null)
                            {
                                Session["UserName"] = user.FirstName;
                            }

                            if (string.IsNullOrEmpty(returnUrl) || returnUrl == "/")
                            {
                                var rUser = new System.Security.Claims.ClaimsPrincipal(AuthenticationManager.AuthenticationResponseGrant.Identity);
                                var SessionUserId = User.Identity.GetUserId();

                                if (rUser.IsInRole("Admin"))
                                    return RedirectToAction("Index", "Complaints");
                                else
                                    return RedirectToAction("Index", "Complaints");

                            }

                            return RedirectToLocal(returnUrl);
                        }

                    case SignInStatus.LockedOut:
                        return View("Lockout");
                    case SignInStatus.RequiresVerification:
                        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = LoginUser.RememberMe });
                    case SignInStatus.Failure:
                    default:
                        ModelState.AddModelError("", "Invalid login attempt.");
                        return View(LoginUser);


                }
            }

            catch (FormatException)
            {
                return RedirectToAction("Error", "Home");
            }
            catch (Exception)
            {
                throw;
            }




        }


        [HttpGet]
        public ActionResult Edit(ForgotPasswordViewModels FPVM)
        {
            try { 

          var editUserViewModel = new EditUserViewModel();
         
            if (ModelState.IsValid)
            {
                var U = UserManager.FindByName(FPVM.Username);

                var Finduser = (from user in db.Users
                                from userRole in user.Roles
                                join role in db.Roles on userRole.RoleId equals
                                role.Id
                                where user.Id == U.Id
                                select new UserViewModel()
                                {
                                    FirstName = user.FirstName,
                                    LastName = user.LastName,
                                    UserName = user.UserName,
                                    Email = user.Email,
                                    Role = role.Name,
                                    CNIC = user.CNIC,
                                    PhoneNumber = user.PhoneNumber,
                                    Id= user.Id,
                                }).ToList();

                if (Finduser == null)
                {
                    return HttpNotFound();

                }
                if (Finduser.Count() > 0)
                {
                    editUserViewModel.UserId = Finduser[0].Id;
                    editUserViewModel.FirstName = Finduser[0].FirstName;
                    editUserViewModel.LastName = Finduser[0].LastName;
                    editUserViewModel.UserName = Finduser[0].UserName;
                    editUserViewModel.Email = Finduser[0].Email;
                    editUserViewModel.CNIC = Finduser[0].CNIC;
                    editUserViewModel.PhoneNumber = Finduser[0].PhoneNumber;
                    editUserViewModel.RoleId = U.Roles.SingleOrDefault().RoleId;

                    List<SelectListItem> list = new List<SelectListItem>();
                    foreach (var role in db.Roles)
                        list.Add(new SelectListItem() { Value = role.Id, Text = role.Name });
                    // var roles = this.AppRoleManager.Roles;
                    ViewBag.RoleId = new SelectList(list,"Value","Text",editUserViewModel.RoleId);

                }
            }



            return View(editUserViewModel);
            }
            catch (Exception ex)
            {
                throw;
            }
     


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            try
            {
                AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                Session["UserName"] = string.Empty;
                return RedirectToAction("Login", "Users");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
         [ValidateAntiForgeryToken]

        public async  Task<ActionResult> Edit(EditUserViewModel editUserViewModel)
        {
            try { 
            List<SelectListItem> Rolelist = new List<SelectListItem>();
            foreach (var role in db.Roles)
                Rolelist.Add(new SelectListItem() { Value = role.Id, Text = role.Name });
            if (ModelState.IsValid)
            {

               
               

                ViewBag.Role = new SelectList(Rolelist, "Value", "Text", editUserViewModel.RoleId);
         



                var user = UserManager.FindByName(editUserViewModel.UserName);
                if (user != null)
                {
                    user.FirstName = editUserViewModel.FirstName;
                    user.LastName = editUserViewModel.LastName;
                    user.UserName = editUserViewModel.UserName;
                    user.Email = editUserViewModel.Email;
                    user.CNIC = editUserViewModel.CNIC;
                    user.PhoneNumber = editUserViewModel.PhoneNumber;
                    user.EmailConfirmed = true;


                }
                var result = await UserManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    var oldRoleId = user.Roles.SingleOrDefault().RoleId;
                    var oldRoleName = Rolelist.SingleOrDefault(r => r.Value == oldRoleId).Text;
                    var newRoleName = Rolelist.SingleOrDefault(r => r.Value == editUserViewModel.RoleId).Text;
                    if(oldRoleId != editUserViewModel.RoleId)
                    {

                        UserManager.RemoveFromRole(user.Id, oldRoleName);
                        var result1 = await UserManager.AddToRoleAsync(user.Id, newRoleName );

                      
                    }
                    db.SaveChanges();
                    return RedirectToAction("Index", "Users");

                }

            }
            ViewBag.RoleId = new SelectList(Rolelist, "Value", "Text", editUserViewModel.RoleId);
            


            return View(editUserViewModel);
            }

            catch (Exception)
            {
                throw;
            }

        }


      //  [ActionName("Details")]
        public ActionResult Details(ForgotPasswordViewModels FPVM)
        {
            try
            {
              

                DetailUserViewModel detailUserViewModel = new DetailUserViewModel();
                var U = UserManager.FindByName(FPVM.Username);
                var Finduser = (from user in db.Users
                                from userRole in user.Roles
                                join role in db.Roles on userRole.RoleId equals
                                role.Id
                                where user.Id == U.Id
                                select new UserViewModel()
                                {
                                    FirstName = user.FirstName,
                                    LastName = user.LastName,
                                    UserName = user.UserName,
                                    Email = user.Email,
                                    Role = role.Name,
                                    CNIC = user.CNIC,
                                    PhoneNumber = user.PhoneNumber,
                                    Id = user.Id,
                                }).ToList();
                if (Finduser == null)
                {
                    return HttpNotFound();

                }
                if (Finduser.Count() > 0)
                {
                    detailUserViewModel.UserId = Finduser[0].Id;
                    detailUserViewModel.FirstName = Finduser[0].FirstName;
                    detailUserViewModel.LastName = Finduser[0].LastName;
                    detailUserViewModel.UserName = Finduser[0].UserName;
                    detailUserViewModel.Email = Finduser[0].Email;
                    detailUserViewModel.CNIC = Finduser[0].CNIC;
                    detailUserViewModel.PhoneNumber = Finduser[0].PhoneNumber;
                    detailUserViewModel.RoleName = Finduser[0].Role;


                }
                return View(detailUserViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }


     

        [HttpPost]
        public async Task<ActionResult> DeleteUser(string Id)
        {
            try { 
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var role in db.Roles)
                list.Add(new SelectListItem() { Value = role.Id, Text = role.Name });
            var SessionUserName = User.Identity.Name;
            string CurrentUserName = Convert.ToString(SessionUserName);
          
            var appUser = UserManager.FindById(Id);
            if (appUser != null)
            {
                IdentityResult result = await UserManager.DeleteAsync(appUser);
                if (result.Succeeded)
                {
                    
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadGateway);



            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadGateway);
            }

            catch (Exception ex)
            {
                throw;
            }
        }
        [AllowAnonymous]
        public ActionResult ResetPassword()
        {
            try
            {
                var SessionUserId = User.Identity.GetUserId();
                ViewBag.UserId = SessionUserId;

                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPost]
        public async Task<JsonResult> ResetPassword(ResetPasswordViewModel model)
        {
            try
            {
                var SessionUserName = User.Identity.Name;
                string CurrentUserName = Convert.ToString(SessionUserName);

                var user = await UserManager.FindAsync(CurrentUserName, model.CurrentPassword);

                //var user = UserManager.FindByIdAsync(model.Id).Result;
                if (user == null)
                    return Json("Current Password Not Matched!");

                var token = UserManager.GeneratePasswordResetTokenAsync(user.Id).Result;

                var result = await UserManager.ResetPasswordAsync(user.Id, token, model.NewPassword);
                if (result.Succeeded)
                {
                    return Json(true);
                }
                else
                    return Json(false);


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion


    }
}