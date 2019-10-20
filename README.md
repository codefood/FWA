# FWA
 
I tried to have a bit more fun with this rather than produce a complete solution here.

## Endpoints

````
GET /api/movie/setup
````
Seeds the database with some random data

````
GET /api/movie/{title}
GET /api/movie/{year}
POST /api/movie
````
Search endpoints for movies.

```
GET /api/top/
GET /api/top/{userId}
````
Returns a top 5 list of movies, optionally rated by a single user

## Rounding
The rounding doesn't work as specified! 

## Nullable Reference Types
I decided to turn this on because I think it's a good idea for C#, I agree with the argument that null is over-used as a concept, null reference exceptions are a problem and with tools like Nullable Reference Types we can try and detect them at compile time.

## EF 3.0 Changes
I had issues writing a good LINQ statement to query `TopByRating` in FWA.Data\Repositories\RatingRepository.cs, it does do 2 DB hits, and should probably be done in one, but I can't quite get it working right now, due to changes in how EF 3.0 handles client-side evaluation, this means that it is not doing an ".OrderBy(rating).ThenBy(title)", which is one of the requirements. I'm not a fan of this! I think there are other better solutions but they would depend on a lot of questions about this app and the environment it would run in.

## Tests
I haven't written nearly enough, I would generally create some integration tests to cover the endpoints themselves, and to ensure that the correct responses are returned for the endpoints. I have added some quick unit tests for the bits of important business logic.

## SearchBuilder
I have obviously built this with extensibility in mind, but we need to consider performance of this as we add more and more filters.

## Other Tools
It would be good to implement a tool like Redis to cache Movies, their aggregated Ratings or both. Simirlarly, the SearchBuilder is unlikely to scale well and a solution like ElasticSearch could be used in its place.

## API D
I have run out of time to complete this, but I've demonstrated adding items to the database, these need an API endpoint and some validation to make it work.