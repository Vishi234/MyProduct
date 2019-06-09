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
                        "~/Scripts/jquery.toast.min.js",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js",
                        "~/Scripts/jquery-1.10.2.min.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js",
                        "~/Scripts/fontawesome/all.js",
                        "~/Scripts/jquery-2.2.4.min.js",
                        "~/Scripts/jquery-1.12.1-ui.min.js",
                        "~/Scripts/widget.min.js",
                        "~/Scripts/prettify.js",
                        "~/Scripts/common.js",
                        "~/Scripts/sammy-0.7.4.min.js",
                        "~/Scripts/routing.js"
                    ));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/config")
                        .IncludeDirectory("~/Content/DynamicJs", "*.js", true));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/style.css",
                       "~/Content/fontawesome-all.css",
                      "~/Content/jquery.toast.min.css",
                      "~/Content/jquery-ui.css",
                      "~/Content/jquery.multiselect.css",
                       "~/Content/jquery.multiselect.filter.css",
                      "~/Content/loading.less"
                      ));
        }
    }
}