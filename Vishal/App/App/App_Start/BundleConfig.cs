using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace App
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-3.3.1.slim.min.js",
                        "~/Scripts/popper.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/jquery.multiselect.filter.js",
                        "~/Scripts/jquery.multiselect.js",
                        "~/Scripts/jquery.toast.min.js",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js",
                        "~/Scripts/jquery-1.10.2.min.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js",
                        "~/Scripts/common.js"
                    ));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/config")
                        .IncludeDirectory("~/Content/DynamicJs", "*.js", true));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/style.css",
                      "~/Content/fontawesome.min.css",
                      "~/Content/jquery.toast.min.css",
                      "~/Content/jquery.multiselect.filter.css",
                      "~/Content/jquery.multiselect.css"
                      ));
        }
    }
}