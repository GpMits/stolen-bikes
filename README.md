# Stolen Bikes API
This API was built to consume the Bike Index API. In it, there are three open endpoints:
- GET /
  - Retrieves the list of previously fetched stolen bikes count per city.
- POST /{cityName}
  - Saves the city in the database (in memory) with its number of stolen bikes. The stolen bikes number will be retrieved base on {cityName}
- POST /
  - Saves the city in the database (in memory) with its number of stolen bikes. The stolen bikes number will be retrieved base on the city object passed in the payload.

## Notes
- There is a swagger UI included. If you run the project using the port 5000 it is [here](http://localhost:5000/swagger/index.html)
- The in memory database comes preloaded with the following cities: 
`{"Amsterdam", "Berlin", "Copenhagen", "Brussels", "Milan", "London", "Paris"}`
