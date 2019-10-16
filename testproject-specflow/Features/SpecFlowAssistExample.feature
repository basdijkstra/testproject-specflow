Feature: SpecFlow.Assist example
	As a consumer of the Zippopotam.us API
	I want to receive location data matching the country code and zip code I supply
	So I can use this data to auto-complete forms on my web site

	Scenario: Country code us and zip code 90210 yields the expected place
		Given the country code us and zip code 90210
		When I request the locations corresponding to these codes
		Then the response contains the following place
		| PlaceName     | Longitude | Latitude | State      | StateAbbreviation |
		| Beverly Hills | -118.4065 | 34.0901  | California | CA                |
	   
	Scenario: Country code de and zip code 24848 yields the expected places
		Given the country code de and zip code 24848
		When I request the locations corresponding to these codes
		Then the response contains the following places
		| PlaceName      | Longitude | Latitude |
		| Alt Bennebek   | 9.4333    | 54.3833  |
		| Kropp          | 9.5087    | 54.4111  |
		| Klein Rheide   | 9.4833    | 54.45    |
		| Klein Bennebek | 9.45      | 54.4     |

