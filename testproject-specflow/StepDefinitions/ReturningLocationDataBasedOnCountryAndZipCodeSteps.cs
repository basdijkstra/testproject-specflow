using TechTalk.SpecFlow;
using RestSharp;
using NUnit.Framework;
using testproject_specflow.DataEntities;
using RestSharp.Serialization.Json;

namespace testproject_specflow.StepDefinitions
{
    [Binding]
    public class ReturningLocationDataBasedOnCountryAndZipCodeSteps
    {
        RestClient client;
        RestRequest request;
        IRestResponse response;

        [Given(@"the country code (.*) and zip code (.*)")]
        public void GivenTheCountryCodeAndZipCode(string countryCode, string zipCode)
        {
            client = new RestClient("http://api.zippopotam.us");
            request = new RestRequest($"{countryCode}/{zipCode}", Method.GET);
        }

        [When(@"I request the locations corresponding to these codes")]
        public void WhenIRequestTheLocationsCorrespondingToTheseCodes()
        {
            response = client.Execute(request);
        }
        
        [Then(@"the response contains the place name (.*)")]
        public void ThenTheResponseContainsThePlaceName(string expectedPlaceName)
        {
            LocationResponse locationResponse =
                new JsonDeserializer().
                Deserialize<LocationResponse>(response);

            Assert.That(locationResponse.Places[0].PlaceName, Is.EqualTo(expectedPlaceName));
        }
        
        [Then(@"the response contains exactly (\d+) location")]
        public void ThenTheResponseContainsExactlyLocation(int expectedNumberOfPlacesReturned)
        {
            LocationResponse locationResponse =
                new JsonDeserializer().
                Deserialize<LocationResponse>(response);

            Assert.That(locationResponse.Places.Count, Is.EqualTo(expectedNumberOfPlacesReturned));
        }
        
        [Then(@"the response has status code (\d+)")]
        public void ThenTheResponseHasStatusCode(int expectedStatusCode)
        {
            Assert.That((int)response.StatusCode, Is.EqualTo(expectedStatusCode));
        }
    }
}
