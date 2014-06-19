using System;
using System.IO;
using System.Linq;
using ConfluxWritersDay.Infrastructure;
using ConfluxWritersDay.Infrastructure.Logging;
using ConfluxWritersDay.Repositories;
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
            IRegistrationRepository registrationRepository,
            ISettings settings
        )
        {

            // todo: do I really need / and /{page}?
            Get["/"] = parameters =>
                {
                    return PageView(markdownRepository.GetMarkdown("home"));
                };

            Get["/registration"] = parameters =>
                {
                    return View["registration", new RegistrationViewModel(settings)];
                };

            Post["/registration"] = parameters =>
                {
                    var log = new Logger(string.Format("{0} {1}", Request.Method, Request.Url.Path));
                    var viewModel = this.Bind<RegistrationViewModel>();
                    var validation = this.Validate(viewModel);

                    log.Debug("form {0} valid", validation.IsValid ? "is" : "is not");

                    if (!validation.IsValid)
                    {
                        return InvalidForm(validation);
                    }

                    var model = viewModel.ToModel();

                    registrationRepository.Add(model);

                    return new Response {StatusCode = HttpStatusCode.OK};
                };

            Get["/{page}", ctx => markdownRepository.MarkdownExists(ctx.Request.Path)] = parameters =>
                {
                    return PageView(markdownRepository.GetMarkdown(parameters.page));
                };
        }

        private Response InvalidForm(ModelValidationResult validation)
        {

            return new Response
            {
                StatusCode = HttpStatusCode.BadRequest,
                ContentType = "text/plain",
                Contents = stream => (new StreamWriter(stream) {AutoFlush = true}).Write(ModelValidationResultAsString(validation))
            };
        }

        private string ModelValidationResultAsString(ModelValidationResult validation)
        {
            return string.Join(
                Environment.NewLine,
                validation.Errors.Select(error => error.GetMessage(error.MemberNames.First()))
                );
        }

        private Negotiator PageView(string markdown)
        {
            return View["Markdown", new MarkdownViewModel(markdown)];
        }
    }
}