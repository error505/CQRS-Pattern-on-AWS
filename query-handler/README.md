# Query Handler Lambda for AWS CQRS Pattern

This folder contains the C# code for the **Query Handler Lambda**. This function handles data retrieval (query) operations by accessing the **Query DB**.

## 📑 Files

- **`QueryHandler.csproj`**: C# project file for the Query Handler Lambda function.
- **`QueryHandler.cs`**: Main code for the Query Handler Lambda function.
- **`deploy-query-handler.yml`**: GitHub Action workflow to automate the deployment of the Query Handler Lambda function.

## 🚀 How to Deploy the Query Handler Lambda

### Prerequisites

1. **AWS Account**: You need an active AWS account.
2. **AWS CLI**: Installed and configured.
3. **S3 Bucket**: A bucket to store Lambda deployment packages.
4. **GitHub Secrets Configuration**:
   - **`AWS_ACCESS_KEY_ID`**: AWS access key ID.
   - **`AWS_SECRET_ACCESS_KEY`**: AWS secret access key.

### Steps to Deploy

1. **Add Required Secrets to GitHub**:
   - Go to your repository's **Settings > Secrets and variables > Actions > New repository secret**.
   - Add the following secrets:
     - **`AWS_ACCESS_KEY_ID`**: Your AWS access key ID.
     - **`AWS_SECRET_ACCESS_KEY`**: Your AWS secret access key.

2. **Run the GitHub Action**:
   - Push your changes to the `main` branch or manually trigger the **Deploy AWS Lambda - Query Handler** workflow from the **Actions** tab.

3. **Monitor the Deployment**:
   - Go to the **Actions** tab in your GitHub repository.
   - Select the **Deploy AWS Lambda - Query Handler** workflow to monitor the deployment progress.

### 📝 How It Works

- The **Query Handler Lambda** listens for HTTP GET requests.
- It retrieves the requested data from the **Query DB** (Amazon DynamoDB) and returns the result.

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](../LICENSE) file for details.
