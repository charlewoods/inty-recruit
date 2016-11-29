using System;
using System.Net;
using System.Net.Http;

namespace IntyRecruit
{
    public class RecruitmentServiceManipulator
    {
        private static readonly HttpClient Client = new HttpClient();

        public void PerformRecruitmentSteps()
        {
            var optionsUri = new Uri("https://recruitment.inty.com/api/options");
            var applyUri = new Uri("https://recruitment.inty.com/api/apply");
            var applyWithUrlUri = new Uri(applyUri.ToString() + "?url=https://digitalshrubbey.azurewebsites.net/api/greetings");
            makeRequestAndWriteResponse(optionsUri, HttpMethod.Get);
            makeRequestAndWriteResponse(optionsUri, HttpMethod.Options);
            makeRequestAndWriteResponse(optionsUri, HttpMethod.Options, "en-AU");
            makeRequestAndWriteResponse(applyUri, HttpMethod.Get);
            makeRequestAndWriteResponse(applyWithUrlUri, HttpMethod.Post);
            makeRequestAndWriteResponse(new Uri("https://recruitment.inty.com/api/submit"),HttpMethod.Get);

        }

        private static void makeRequestAndWriteResponse(Uri uri, HttpMethod method, string language = null)
        {
            var request = new HttpRequestMessage
            {
                Method = method,
                RequestUri = uri,
            };
            if (language != null)
            {
                request.Headers.Add("Accept-language", language);
            }

            var result = Client.SendAsync(request);

            Console.WriteLine(result.Result.ToString());
            Console.WriteLine(result.Result.Content.ReadAsStringAsync().Result);

        }

       
    }
}