Feature: Returning location data based on country and zip code
	As a consumer of the Zippopotam.us API
	I want to receive location data matching the country code and zip code I supply
	So I can use this data to auto-complete forms on my web site

	Scenario: An existing country and zip code yields the correct place name
		Given the country code us and zip code 90210
		When I request the locations corresponding to these codes
		Then the response contains the place name Beverly Hills

	Scenario: An existing country and zip code yields the right number of results
		Given the country code us and zip code 90210
		When I request the locations corresponding to these codes
		Then the response contains exactly 1 location

	Scenario: An existing country and zip code yields the right HTTP status code
		Given the country code us and zip code 90210
		When I request the locations corresponding to these codes
		Then the response has status code 200