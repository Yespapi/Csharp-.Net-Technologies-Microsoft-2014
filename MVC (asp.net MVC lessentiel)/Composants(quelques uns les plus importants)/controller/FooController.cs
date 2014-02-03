using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson04.Controllers
{
    public class FooController : Controller
    {
        //
        // GET: /Foo/

        public string Index()
        {
            return "This is index";
        }

        public string Bar()
        {
            return "This is bar";
        }

        public string baz(string id)
        {
            return "This is baz " + id;
        }

    }
}
