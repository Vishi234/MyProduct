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
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js",
                        "~/Scripts/jquery.toast.min.js",
                        "~/Scripts/common.js",
                        "~/Scripts/jquery.sumoselect.min.js",
                        "~/Scripts/custom.js",
                        "~/Scripts/axios.min.js",
                        "~/Scripts/fontawesome/all.js"));
            bundles.Add(new ScriptBundle("~/bundles/react").Include(
                         "~/Scripts/react.development.js",
                        "~/Scripts/react-dom.development.js",
                        "~/Scripts/remarkable.min.js",
                        "~/Scripts/prop-types.js"));
            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/default.css",
                      "~/Content/fontawesome-all.css",
                      "~/Content/jquery.toast.min.css",
                      "~/Content/sumoselect.min.css"));
        }
    }
}