﻿
using System;
using OMP.Offers.Entities;
using Serenity.Data;

namespace OMP.Offers.Pages
{
    using Serenity;
    using Serenity.Web;
    using Microsoft.AspNetCore.Mvc;

    [PageAuthorize(typeof(Entities.OffersRow))]
    public class OffersController : Controller
    {
        [Route("Offers/Offers")]
        public ActionResult Index()
        {
            return View(MVC.Views.Offers.Offers_.OffersIndex);
        }


        [HttpGet]
        [Route("Offers/Offers/[Action]")]
        public ActionResult Header()
        {
            var model = new OfferReportHeaderModel();
            var offerId = Int32.Parse(HttpContext.Request.Query["offerId"]);

            using (var connection = SqlConnections.NewFor<OffersRow>())
            {
                var row = connection.First<OffersRow>(r => r.SelectTableFields()
                    .Where(new Criteria(OffersRow.Fields.OfferId) == offerId && new Criteria(OffersRow.Fields.IsActive) == 1)
                    .OrderBy(OffersRow.Fields.InsertDate, true));
                model.OfferTitle = row.Name;
            }

            return PartialView(MVC.Views.Offers.Offers_.OfferReportHeader, model);

        }

        [HttpGet]
        [Route("Offers/Offers/[Action]")]
        public ActionResult Footer()
        {
            var model = new OfferReportFooterModel();

            using (var connection = SqlConnections.NewFor<UserOfferSettingsRow>())
            {
                var row = connection.First<UserOfferSettingsRow>(r => r.SelectTableFields()
                    .Where(new Criteria(UserOfferSettingsRow.Fields.UserId) == Authorization.UserId && new Criteria(UserOfferSettingsRow.Fields.IsActive) == 1)
                    .OrderBy(UserOfferSettingsRow.Fields.InsertDate, true));

                model.FooterText = row.OfferInvoiceFooterText;
                model.FooterImagePath = row.OfferInvoiceFooterImage;
            }

            return PartialView(MVC.Views.Offers.Offers_.OfferReportFooter, model);

        }

    }
    public class OfferReportHeaderModel
    {
        public string OfferTitle { get; set; }
    }

    public class OfferReportFooterModel
    {
        public string FooterText { get; set; }
        public string FooterImagePath { get; set; }
    }
}