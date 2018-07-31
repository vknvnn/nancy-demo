using Nancy;
using Nancy.ModelBinding;

namespace NancyDemo
{
    public sealed class HomeModule : NancyModule
    {
        public HomeModule(IAppConfiguration appConfig)
        {
            Get("/", args => "Hello from Nancy running on CoreCLR");

            Get("/conneg/{name}", args => new Person { Name = args.name });

            Get("/smtp", args => new
            {
                appConfig.Smtp.Server,
                appConfig.Smtp.User,
                appConfig.Smtp.Pass,
                appConfig.Smtp.Port
            });

            Post("/", args =>
            {
                var person = this.BindAndValidate<Person>();

                if (!ModelValidationResult.IsValid)
                {
                    return 422;
                }

                return person;
            });
        }
    }
}
