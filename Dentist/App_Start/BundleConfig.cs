﻿using System.Web;
using System.Web.Optimization;

namespace Dentist
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/appjquery").Include(
                        "~/Scripts/jquery-{version}.js",
                         "~/Scripts/datatables/jquery.datatables.js",
                        "~/Scripts/datatables/datatables.bootstrap.js",
                        "~/Scripts/datatables/jszip.min.js",
                        "~/Scripts/datatables/buttons.html5.min.js",
                        "~/Scripts/datatables/buttons.print.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootbox.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                
                "~/Content/style.css",
                 "~/Content/font-awesome.min.css",
                      "~/Content/bootstrap-darkly.css",
                       "~/Content/DataTables/css/datatables.bootstrap.css",
                     "~/Content/DataTables/css/jquery.datatables.min.css",
                     
                     "~/Content/site.css"
                     ));
        }
    }
}
