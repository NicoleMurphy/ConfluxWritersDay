﻿using ConfluxWritersDay.Web.Repositories;
using ConfluxWritersDay.Web.ViewModels.Home;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using Nancy.Validation;

namespace ConfluxWritersDay.Web.Modules
{
    public class HomeModule : BaseModule
    {
        public HomeModule(
            IMarkdownRepository markdownRepository,
            IMembershipOrganisationRepository membershipOrganisationRepository,
            IPaymentMethodRepository paymentMethodRepository,
            RegistrationViewModel registrationViewModel,
            IRootPathProvider rootPathProvider
        )
        {
            // todo: do I really need / and /{page}?
            Get["/"] = parameters =>
                {
                    return PageView(markdownRepository.GetMarkdown("home"));
                };

            Get["/registration"] = parameters =>
                {
                    var isDeveloperMachine = rootPathProvider.GetRootPath().StartsWith(@"C:\Users\Tim\Code\");

                    return View["registration", new { isDeveloperMachine }];
                };

            Post["/registration"] = parameters =>
                {
                    this.BindTo(registrationViewModel);
                    var validation = this.Validate(registrationViewModel);

                    if (!validation.IsValid)
                    {
                        return View["registration", registrationViewModel];
                    }

                    throw new System.NotImplementedException("post valid viewmodel");
                };

            Get["/{page}", ctx => markdownRepository.MarkdownExists(ctx.Request.Path)] = parameters =>
                {
                    return PageView(markdownRepository.GetMarkdown(parameters.page));
                };
        }

        private Negotiator PageView(string markdown)
        {
            return View["Markdown", new MarkdownViewModel(markdown)];
        }
    }
}