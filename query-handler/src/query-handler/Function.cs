using System;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Lambda.APIGatewayEvents;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

public class QueryHandler
{
    private readonly AmazonDynamoDBClient _dynamoDbClient;
    private readonly string _tableName = Environment.GetEnvironmentVariable("DYNAMODB_TABLE_NAME");

    public QueryHandler()
    {
        _dynamoDbClient = new AmazonDynamoDBClient();
    }

    public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
    {
        var id = request.QueryStringParameters["id"];
        if (string.IsNullOrEmpty(id))
        {
            return new APIGatewayProxyResponse { StatusCode = 400, Body = "Invalid ID." };
        }

        var table = Table.LoadTable(_dynamoDbClient, _tableName);
        var document = await table.GetItemAsync(id);

        if (document == null)
        {
            return new APIGatewayProxyResponse { StatusCode = 404, Body = "Data not found." };
        }

        return new APIGatewayProxyResponse { StatusCode = 200, Body = document.ToJson() };
    }
}