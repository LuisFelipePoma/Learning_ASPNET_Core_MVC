namespace Catalog.Settings
{
	public class MongoDbSettings
	{
		public required string Host { get; set; }
		public int Port { get; set; }
		public string ConnectionString => $"mongodb://{Host}:{Port}";
	}
}