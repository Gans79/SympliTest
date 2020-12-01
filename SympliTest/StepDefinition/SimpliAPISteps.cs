using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SimpliTest.StepDefinition
{
    [Binding]
    class SimpliAPISteps
    {
        HttpClient client;
        HttpResponseMessage response = new HttpResponseMessage();
        

        [Given(@"I create a client with an endpoint")]
        public void GivenICreateAClientWithAnEndpoint()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://api.github.com/repos");
        }

        [Given(@"I add the headers to the request")]
        public void GivenIAddTheHeadersToTheRequest()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Chrome/77.0.3865.90");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer b712c9c1b5a396c4446a355bfe7c992ecc949a09");
        }

        [When(@"I execute the '(.*)' request")]
        public async Task WhenIExecuteTheRequestAsync(string httpmethod)
        {
            if (httpmethod == "Get")
            {
                response = await client.GetAsync("/simplitest/QA-CC-V1-OperaHouse/pulls");
                var result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine($"Result is {result}");
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        [Then(@"I validate the '(.*)' status code")]
        public void ThenIValidateTheStatusCode(string expectedStatusCode)
        {
            Assert.IsTrue(response.StatusCode.ToString() == "OK", $"Test case failed as the actual status code is {response.StatusCode} but expected is {expectedStatusCode}");
        }

    }
}
