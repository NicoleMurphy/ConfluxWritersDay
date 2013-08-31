using System.IO;
using ConfluxWritersDay.Web.Repositories;
using ConfluxWritersDay.Web.ViewModels.Home;
using Nancy;
using Nancy.Responses.Negotiation;
using OpenMagic;

namespace ConfluxWritersDay.Web.Modules
{
    public class HomeModule : BaseModule
    {
        // todo: repository injection
        public HomeModule(IRootPathProvider rootPathProvider)
            : this(new MarkdownRepository(Path.Combine(rootPathProvider.GetRootPath(), "Markdown")), new MembershipOrganisationRepository(), new PaymentMethodRepository())
        {
        }

        public HomeModule(IMarkdownRepository markdownRepository, IMembershipOrganisationRepository membershipOrganisationRepository, IPaymentMethodRepository paymentMethodRepository)
        {
            markdownRepository.MustNotBeNull("markdownRepository");
            membershipOrganisationRepository.MustNotBeNull("membershipOrganisationRepository");
            paymentMethodRepository.MustNotBeNull("paymentMethodRepository");

            // todo: do I really need / and /{page}?
            Get["/"] = parameters =>
            {
                return PageView(markdownRepository.GetMarkdown("home"));
            };

            Get["/registration"] = parameters =>
            {
                return View["registration.cshtml", new RegistrationViewModel(membershipOrganisationRepository, paymentMethodRepository)];
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