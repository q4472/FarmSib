﻿using System.Web;
using System.Web.Optimization;

namespace FarmSib.AreasAgrs
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery-ui-{version}.js",
                "~/Scripts/jquery.unobtrusive*", // от этого зависит Ajax - можно убрать только в паре
                "~/Scripts/jquery.validate*"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryfu").Include(
                "~/Scripts/jquery.fileupload.js"
                //"~/Scripts/jquery.iframe-transport.js"
                //"~/Scripts/vendor/jquery.ui.widget.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/nskd").Include(
                "~/Scripts/Nskd/Client.js",
                "~/Scripts/Nskd/Convert.js",
                "~/Scripts/Nskd/Data.js",
                "~/Scripts/Nskd/Http.js",
                //"~/Scripts/Nskd/Crypt.js",
                //"~/Scripts/Nskd/Dmf.js",
                //"~/Scripts/Nskd/Dom.js",
                //"~/Scripts/Nskd/Expl.js",
                "~/Scripts/Nskd/Js.js",
                "~/Scripts/Nskd/Json.js",
                "~/Scripts/Nskd/Menu.js",
                "~/Scripts/Nskd/Server.js",
                "~/Scripts/Nskd/Utility.js"
                ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Reset.css",
                "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                "~/Content/themes/base/accordion.css",
                "~/Content/themes/base/autocomplete.css",
                "~/Content/themes/base/button.css",
                "~/Content/themes/base/core.css",
                "~/Content/themes/base/datepicker.css",
                "~/Content/themes/base/dialog.css",
                "~/Content/themes/base/progressbar.css",
                "~/Content/themes/base/resizable.css",
                "~/Content/themes/base/selectable.css",
                "~/Content/themes/base/slider.css",
                "~/Content/themes/base/tabs.css",
                "~/Content/themes/base/theme.css"));
        }
    }
}