using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace CourseProvider.Functions;

public class Playground
{
    private readonly ILogger<Playground> _logger;

    public Playground(ILogger<Playground> logger)
    {
        _logger = logger;
    }

    [Function("Playground")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "graphql")] HttpRequestData req)
    {
        var response = req.CreateResponse();
        response.Headers.Add("Content-Type", "text/html; charset=utf-8");
        await response.WriteStringAsync(PlaygroundPage());
        return response;
    }
    private string PlaygroundPage()
    {
        return @"
                    <!DOCTYPE html>
                    <html>
                        <head>
                            <title>HotChocolate GraphQL Playground</title>
                            <link rel=""stylesheet"" href=""https://cdn.jsdelivr.net/npm/graphql-playground-react/build/static/css/index.css"" />
                        </head>
                        <body>
                            <div id=""root""></div>
                            <script src=""https://cdn.jsdelivr.net/npm/graphql-playground-react/build/static/js/middleware.js""></script>
                            <script>
                                window.addEventListener('load', function (event) {
                                    GraphQLPlayground.init(document.getElementById('root'));
                                });
                            </script>
                        </body>
                    </html>
                ";
    }
}

//GraphQLPlayground.init(document.getElementById('root'));