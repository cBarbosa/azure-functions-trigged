using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using functions.Services.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace AllService.Function
{
    public class HttpTriggerCSharp1
    {
        private readonly IMailService _mailService;

        public HttpTriggerCSharp1(IMailService mailService)
        {
            _mailService = mailService;
        }

        [Function("HttpTriggerCSharp1")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("HttpTriggerCSharp1");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            await _mailService.SendInvitation("teste01@spam.com");

            return response;
        }
    }
}