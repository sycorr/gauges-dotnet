# Guag.es API #

Gauges C# client library is a simple strongly typed wrapper using [System.Net.Http](http://msdn.microsoft.com/en-us/library/system.net.http.aspx)

## Installation ##

	install-package Gauges-dotnet

## Usage ##

	var service = new Referrers(Your_Gauges_API_Token);
	var gaugeQuery = new GaugeQuery { id = "A_Valid_Gauge_Id" };
	ReferrerCollection referrers = service.GetReferrers(gaugeQuery);


----------

## Your Information ##

[http://get.gaug.es/documentation/reference-listing/your-information/](http://get.gaug.es/documentation/reference-listing/your-information/)

	✔ Get Your Information (GET)
	✔ Update Your Information (PUT)

## API Clients ##

[http://get.gaug.es/documentation/reference-listing/clients/](http://get.gaug.es/documentation/reference-listing/clients/)

	✔ API Client List (GET)
	✔ Creating an API Client (POST)
	✔ Delete an API Client (DELETE)

## Gauges ##

[http://get.gaug.es/documentation/reference-listing/gauges/](http://get.gaug.es/documentation/reference-listing/gauges/)

	✔ Gauges List (GET)
	✔ Create a New Gauge (POST)
	✔ Gauge Detail (GET)
	✔ Update a Gauge (PUT)
	✔ Delete a Gauge (DELETE)

## Sharing  ##
***this feature requires Small account or better plan**

[http://get.gaug.es/documentation/reference-listing/sharing/](http://get.gaug.es/documentation/reference-listing/sharing/)

	✔ List Shares (GET)
	✔ Share Gauge (POST)
	✔ Un-share Gauge (DELETE)

## Content ##

[http://get.gaug.es/documentation/reference-listing/content/](http://get.gaug.es/documentation/reference-listing/content/)

	✔ Top Content (GET)

## Referrers ##

[http://get.gaug.es/documentation/reference-listing/referrers/](http://get.gaug.es/documentation/reference-listing/referrers/)

	✔ Top Referrers (GET)

## Traffic ##

[http://get.gaug.es/documentation/reference-listing/traffic/](http://get.gaug.es/documentation/reference-listing/traffic/)

	✔ Traffic (GET)

## Resolutions ##

[http://get.gaug.es/documentation/reference-listing/resolutions/](http://get.gaug.es/documentation/reference-listing/resolutions/)

	✔ Browser Resolutions (GET)

## Technology ##

[http://get.gaug.es/documentation/reference-listing/technology/](http://get.gaug.es/documentation/reference-listing/technology/)

	✔ Technology (GET)

## Search Terms ##

[http://get.gaug.es/documentation/reference-listing/terms/](http://get.gaug.es/documentation/reference-listing/terms/)

	✔ Search Terms (GET)

## Search Engines ##

[http://get.gaug.es/documentation/reference-listing/search-engines/](http://get.gaug.es/documentation/reference-listing/search-engines/)

	✔ Search Engines (GET)

## Locations ##

[http://get.gaug.es/documentation/reference-listing/locations/](http://get.gaug.es/documentation/reference-listing/locations/)

	✔ Locations (GET)


----------
## Testing Setup ##

Please make sure to update the **ConfigurationContext** before running the test suite.  Since these are integration tests they require real credentials to the gaug.es service.