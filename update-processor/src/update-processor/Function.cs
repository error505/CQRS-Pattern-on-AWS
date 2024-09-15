using System;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Lambda.SNSEvents;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

public class UpdateProcessor
{
    private readonly AmazonDynamoDBClient _dynamoDbClient;
    private readonly string _commandTableName = Environment.GetEnvironmentVariable("COMMAND_DYNAMODB_TABLE_NAME");
    private readonly string _queryTableName = Environment.GetEnvironmentVariable("QUERY_DYNAMODB_TABLE_NAME");

    public UpdateProcessor()
    {
        _dynamoDbClient = new AmazonDynamoDBClient();
    }

    public async Task FunctionHandler(SNSEvent snsEvent, ILambdaContext context)
    {
        foreach (var record in snsEvent.Records)
        {
            var message = record.Sns.Message;
            var eventPayload = JsonSerializer.Deserialize<EventPayload>(message);

            if (eventPayload == null)
            {
                context.Logger.LogError("Invalid event payload received.");
                continue;
            }

            // Update Command DB if necessary
            var commandTable = Table.LoadTable(_dynamoDbClient, _commandTableName);
            var commandDocument = new Document { ["id"] = eventPayload.Id, ["data"] = eventPayload.Data };
            await commandTable.PutItemAsync(commandDocument);

            // Update Query DB to keep it in sync
            var queryTable = Table.LoadTable(_dynamoDbClient, _queryTableName);
            var queryDocument = new Document { ["id"] = eventPayload.Id, ["data"] = eventPayload.Data };
            await queryTable.PutItemAsync(queryDocument);

            context.Logger.LogInformation($"Updated both Command DB and Query DB for ID: {eventPayload.Id}");
        }
    }

    public class EventPayload
    {
        public string Id { get; set; }
        public string Data { get; set; }
    }
}
