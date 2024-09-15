using System;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

public class CommandHandler
{
    private readonly AmazonSimpleNotificationServiceClient _snsClient;
    private readonly string _snsTopicArn = Environment.GetEnvironmentVariable("SNS_TOPIC_ARN");
    private readonly AmazonDynamoDBClient _dynamoDbClient;
    private readonly string _commandTableName = "CommandDB";

    public CommandHandler()
    {
        _snsClient = new AmazonSimpleNotificationServiceClient();
        _dynamoDbClient = new AmazonDynamoDBClient();
    }

    [Obsolete]
    public async Task FunctionHandler(InsertRequest request, ILambdaContext context)
    {
        if (string.IsNullOrEmpty(request.Data))
        {
            throw new ArgumentException("Data is required.");
        }

        // Insert data into Command DB (DynamoDB)
        var table = Table.LoadTable(_dynamoDbClient, _commandTableName);
        var itemId = Guid.NewGuid().ToString();
        var doc = new Document { ["id"] = itemId, ["data"] = request.Data };
        await table.PutItemAsync(doc);

        // Publish an event to SNS
        var eventPayload = new EventPayload
        {
            Id = itemId,
            Data = request.Data
        };

        var publishRequest = new PublishRequest
        {
            TopicArn = _snsTopicArn,
            Message = JsonSerializer.Serialize(eventPayload)
        };
        await _snsClient.PublishAsync(publishRequest);
    }

    public class InsertRequest
    {
        public required string Data { get; set; }
    }

    public class EventPayload
    {
        public required string Id { get; set; }
        public required string Data { get; set; }
    }
}
