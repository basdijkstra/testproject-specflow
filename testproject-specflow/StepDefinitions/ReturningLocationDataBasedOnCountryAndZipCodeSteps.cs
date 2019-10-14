using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using RestSharp;
using NUnit.Framework;
using testproject_specflow.DataEntities;
using RestSharp.Serialization.Json;
using System.Collections.Generic;

namespace testproject_specflow.StepDefinitions
{
    [Binding]
    public class ReturningLocationDataBasedOnCountryAndZipCodeSteps
    {
        RestClient client;
        RestRequest request;
        IRestResponse response;
        IEnumerable<Place> places;

        [Given(@"the country code (.*) and zip code (.*)")]
        public void GivenTheCountryCodeAndZipCode(string countryCode, string zipCode)
        {
            client = new RestClient("http://api.zippopotam.us");
            request = new RestRequest($"{countryCode}/{zipCode}", Method.GET);
        }

        [Given(@"the following places")]
        public void GivenTheFollowingPlaces(Table table)
        {
            places = table.CreateSet<Place>();
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
        
        [Then(@"the response contains exactly (\d+) locations?")]
        public void ThenTheResponseContainsExactlyLocation(int expectedNumberOfPlacesReturned)
        {
            LocationResponse locationResponse =
                new JsonDeserializer().
                Deserialize<LocationResponse>(response);

            Assert.That(locationResponse.Places.Count, Is.EqualTo(expectedNumberOfPlacesReturned));
        }
        
        [Then(@"the response has status code (200|404|500)")]
        public void ThenTheResponseHasStatusCode(int expectedStatusCode)
        {
            Assert.That((int)response.StatusCode, Is.EqualTo(expectedStatusCode));
        }

        [Then(@"all places are listed in the response")]
        public void ThenAllPlacesAreListedInTheResponse()
        {
            LocationResponse locationResponse =
                new JsonDeserializer().
                Deserialize<LocationResponse>(response);

            Assert.AreEqual(places, locationResponse.Places);
        }

        [Then(@"the response contains the following place")]
        public void ThenTheResponseContainsTheFollowingPlace(Table table)
        {
            LocationResponse locationResponse =
                new JsonDeserializer().
                Deserialize<LocationResponse>(response);

            table.CompareToInstance<Place>(locationResponse.Places[0]);
        }

        [Then(@"the response contains the following places")]
        public void ThenTheResponseContainsTheFollowingPlaces(Table table)
        {
            LocationResponse locationResponse =
                new JsonDeserializer().
                Deserialize<LocationResponse>(response);

            table.CompareToSet<Place>(locationResponse.Places);
        }
    }
}
