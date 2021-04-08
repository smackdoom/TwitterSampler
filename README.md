# TwitterSampler

A sample Twitter Application used for streaming Tweets and gathering statistics.

## Application Setup

To run the application, replace the following settings in the appsettings.Development.json file. This will allow you access to the Twitter Streaming V2 Service.

- ConsumerKey
- ConsumerSecret
- BearerToken

## General Information

The application uses a hosted background service "StreamingService" that automatically runs on startup.  The Twitter client lives in the Streaming Service and uses an in-memory database to save tweets to.

Also, there's a Swagger page that exposes API Endpoints used for gathering various statistics.  This can be used directly or called via Postman (or whatever tool you wish to use) to run various statistics about the tweets received.

**Statistics Controller**

- GET /totalnumberoftweets
- GET /averagenumberoftweetsperhour
- GET /averagenumberoftweetsperminute
- GET /averagenumberoftweetspersecond
- GET /topemojisintweets
- GET /percentageoftweetswithemojis
- GET /percentageoftweetswithurls
- GET /percentageoftweetswithphotos
- GET /tophashtagintweets
- GET /topurlsintweets
