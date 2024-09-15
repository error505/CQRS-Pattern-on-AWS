# Command Handler Lambda for AWS CQRS Pattern

This folder contains the C# code for the **Command Handler Lambda**. This Lambda function handles the insertion of data by publishing events to **Amazon SNS** and updating the **Command DB**.

## 📑 Files

- **`CommandHandler.csproj`**: C# project file for the Command Handler Lambda function.
- **`CommandHandler.cs`**: Main code for the Command Handler Lambda function.
- **`deploy-command-handler.yml`**: GitHub Action workflow to automate the deployment of the Command Handler Lambda function.

## 🚀 How to Deploy the Command Handler Lambda

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
   - Push your changes to the `main` branch or manually trigger the **Deploy AWS Lambda - Command Handler** workflow from the **Actions** tab.

3. **Monitor the Deployment**:
   - Go to the **Actions** tab in your GitHub repository.
   - Select the **Deploy AWS Lambda - Command Handler** workflow to monitor the deployment progress.

### 📝 How It Works

1. The **Command Handler Lambda** receives an HTTP request via **API Gateway**.
2. It inserts the received data into the **Command DB** (Amazon DynamoDB).
3. It publishes an event to **Amazon SNS** to notify other components of the change.
4. The **Update Processor Lambda** listens to the SNS topic and updates both the **Command DB** and **Query DB** accordingly.

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](../LICENSE) file for details.
