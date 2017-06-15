namespace Profane
{
    using Nancy;
    using Profane.Core.Transpile;
    using Nancy.Extensions;
    using Nancy.IO;

    public class ProfaneModule : NancyModule
    {
        public ProfaneModule()
        {
            Get("/", args => View["index"]);
            Post("/", async (args) =>
            {
                var code = RequestStream.FromStream(Request.Body).AsString();
                var transpiler = new ProfaneTranspiler();
                var result = await transpiler.RunAsync(code);
                return Response.AsJson(result);
            });
        }
    }
}
