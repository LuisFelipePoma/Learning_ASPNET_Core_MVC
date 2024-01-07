# Catalog REST API with .NET ASPNET Core

## How to set up the MongoDB with Docker

1. First we add the package to the project

   ```bash
   dotnet add package MongoDb.Driver
   ```
2. Now we create the container wiht the image of mongodb
   
   ```bash
   sudo docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db mongo
   ```
3. To create a container with enviroment variables for the authentication
   ```bash
   sudo docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=pass123 mongo
   ```
   > Now for the project in .NET
   ```bash
   dotnet user-secrets init
   ```
   > And add the secret value
   ```bash
   dotnet user-secrets set MongoDbSettings:Password pass123
   ```
## How to add health checks endpoints to the service
1. Add the package to the project
   ```bash
   dotnet add package AspNetCore.HealthChecks.MongoDb
   ```