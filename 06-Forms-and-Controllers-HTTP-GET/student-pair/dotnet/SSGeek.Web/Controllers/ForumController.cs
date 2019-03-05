using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SSGeek.Web.DAL;
using SSGeek.Web.Models;

namespace SSGeek.Web.Controllers
{
    public class ForumController : Controller
    {
        private ForumPostSqlDAL _fpDAL;
        public ForumController(ForumPostSqlDAL fpDAL)
        {
            _fpDAL = fpDAL;
        }

        // GET: Forum/Index
        [HttpGet]
        public ActionResult Index()
        {
            List<ForumPost> posts = _fpDAL.GetAllPosts();

            return View(posts);
        }


        // GET: Forum/NewPost
        [HttpGet]
        public ActionResult NewPost()
        {
            ForumPost fp = new ForumPost();
            return View(fp);
        }

        [HttpPost]
        public ActionResult NewPost(ForumPost fp)
        {
            _fpDAL.SaveNewPost(fp);

            //return RedirectToAction("");

            return RedirectToAction("Index");
        }
    }
}