# Update Processor Lambda for AWS CQRS Pattern

This folder contains the C# code for the **Update Processor Lambda**. This function listens to events from **Amazon SNS** and updates both the **Command DB** and **Query DB**.

## 📑 Files

- **`UpdateProcessor.csproj`**: C# project file for the Update Processor Lambda function.
- **`UpdateProcessor.cs`**: Main code for the Update Processor Lambda function.
- **`deploy-update-processor.yml`**: GitHub Action workflow to automate the deployment of the Update Processor Lambda function.

## 🚀 How to Deploy the Update Processor Lambda

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
   - Push your changes to the `main` branch or manually trigger the **Deploy AWS Lambda - Update Processor** workflow from the **Actions** tab.

3. **Monitor the Deployment**:
   - Go to the **Actions** tab in your GitHub repository.
   - Select the **Deploy AWS Lambda - Update Processor** workflow to monitor the deployment progress.

### 📝 How It Works

1. The **Update Processor Lambda** is triggered by an event from **Amazon SNS**.
2. It receives the event payload, which contains data to be synchronized.
3. It updates the **Command DB** if necessary and ensures the **Query DB** is kept in sync by inserting or updating the data.

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](../LICENSE) file for details.
