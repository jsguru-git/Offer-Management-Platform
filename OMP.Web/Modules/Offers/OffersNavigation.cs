﻿using Serenity.Navigation;
using MyPages = OMP.Offers.Pages;

[assembly: NavigationLink(int.MaxValue, "Offers/Countries", typeof(MyPages.CountriesController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "Offers/Cities", typeof(MyPages.CitiesController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "Offers/Accounts", typeof(MyPages.AccountsController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "Offers/Companies", typeof(MyPages.CompaniesController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "Offers/Offer Statuses", typeof(MyPages.OfferStatusesController), icon: null)]