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