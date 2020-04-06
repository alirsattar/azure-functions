using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using System.Net;
using System.Net.Http.Headers;
using OpenHtmlToPdf;

using System.Text;

namespace Company.Function
{
  public static class pdf_convert_test_function
  {
    [FunctionName("pdf_convert_test_function")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
        ILogger log)
    {

      log.LogInformation("Processing PDF Request");

      string html = await new StreamReader(req.Body).ReadToEndAsync();

      var pdf = Pdf
          .From(html)
          .Content();

      log.LogInformation($"PDF Generated. Length={pdf.Length}");

      // byte[] filebytes = Encoding.UTF8.GetBytes(null, 0, pdf);

      return new FileContentResult(pdf, "application/pdf") {
        FileDownloadName = "Export.pdf"
      };

      // var res = new HttpResponseMessage(HttpStatusCode.OK);
      //     res.Content = new ByteArrayContent(pdf);
      //     res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
      //     res.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline");

      // return res;

      // log.LogInformation("C# HTTP trigger function processed a request.");

      // string name = req.Query["name"];

      // string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
      // dynamic data = JsonConvert.DeserializeObject(requestBody);
      // name = name ?? data?.name;

      // string responseMessage = string.IsNullOrEmpty(name)
      //     ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
      //     : $"Hello, {name}. This HTTP triggered function executed successfully.";

      // return new OkObjectResult(responseMessage);

    }
  }
}
