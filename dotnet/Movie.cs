using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Movie
{
    public ObjectId Id { get; set; }

    [BsonElement("title")]
    [BsonIgnoreIfNull] 
    public string? Title { get; set; }

    [BsonElement("plot")]
    [BsonIgnoreIfNull] 
    public string? Plot { get; set; }

    [BsonElement("genres")]
    [BsonIgnoreIfNull]
    public List<string>? Genres { get; set; }
}