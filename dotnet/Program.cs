using MongoDB.Driver;
using MongoDB.Bson;

var connectionString = "mongodb+srv://admin:admin@demo.uskpz.mongodb.net/test?retryWrites=true&w=majority";
//var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");

var settings = MongoClientSettings.FromConnectionString(connectionString);

//settings.ServerApi = new ServerApi(ServerApiVersion.V1);
//APIStrictError
//settings.ServerApi = new ServerApi(ServerApiVersion.V1, strict: true);

//APIDeprecationError
settings.ServerApi = new ServerApi(ServerApiVersion.V1, strict: true, deprecationErrors: true);

var client = new MongoClient(settings);

Console.WriteLine("=============================");
var collection = client.GetDatabase("sample_mflix").GetCollection<BsonDocument>("movies");

var filter = Builders<BsonDocument>.Filter.Eq("title", "Back to the Future");

var document = collection.Find(filter).First();

Console.WriteLine(document);
Console.WriteLine("=============================");


var linqCollection = client.GetDatabase("sample_mflix").GetCollection<Movie>("movies");

var linqDocument = linqCollection.AsQueryable()
    .Where(r => r.Title == "Back to the Future")
    .Select(r => new { r.Title, r.Plot, r.Genres }).First();

Console.WriteLine(linqDocument);
Console.WriteLine("=============================");

var command = new BsonDocumentCommand<BsonDocument>(
                    new BsonDocument() { { "replSetGetStatus", 1 } });

var res = await client.GetDatabase("admin").RunCommandAsync<BsonDocument>(command);
Console.WriteLine(res);

Console.WriteLine("=============================");
var c2 = new BsonDocumentCommand<BsonDocument>(
                    new BsonDocument() { { "find", "movies" }, { "showRecordId", true } });

Console.WriteLine(await client.GetDatabase("sample_mflix").RunCommandAsync<BsonDocument>(c2));

//TODO: check BI connector compatibility