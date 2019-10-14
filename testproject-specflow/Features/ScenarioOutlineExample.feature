Feature: Scenario Outline example
	As a consumer of the Zippopotam.us API
	I want to receive location data matching the country code and zip code I supply
	So I can use this data to auto-complete forms on my web site

	Scenario: Country code us and zip code 90210 yields Beverly Hills
		Given the country code us and zip code 90210
		When I request the locations corresponding to these codes
		Then the response contains the place name Beverly Hills

	Scenario: Country code fi and zip code 99999 yields Korvatunturi
		Given the country code fi and zip code 99999
		When I request the locations corresponding to these codes
		Then the response contains the place name Korvatunturi

	Scenario: Country code ca and zip code B2A yields North Sydney South Central
		Given the country code ca and zip code B2A
		When I request the locations corresponding to these codes
		Then the response contains the place name North Sydney South Central

	Scenario Outline: Country code and zip code combinations yield the expected place names
		Given the country code <countryCode> and zip code <zipCode>
		When I request the locations corresponding to these codes
		Then the response contains the place name <expectedPlaceName>
		Examples:
		| countryCode | zipCode | expectedPlaceName          |
		| us          | 90210   | Beverly Hills              |
		| fi          | 99999   | Korvatunturi               |
		| ca          | B2A     | North Sydney South Central |
