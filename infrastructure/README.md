# Infrastructure Deployment for AWS CQRS Pattern

This folder contains the **CloudFormation** template for deploying the required AWS resources for the **CQRS Pattern**. The resources include AWS API Gateway, AWS Lambda functions, Amazon SNS, and Amazon DynamoDB for both Command and Query databases.

## 📑 Files

- **`cloudformation-template.yml`**: CloudFormation template file that defines all the necessary AWS resources.
- **`deploy-cloudformation.yml`**: GitHub Action workflow file to automate the deployment of the AWS infrastructure.

## 🚀 How to Deploy the Infrastructure

### Prerequisites

1. **AWS Account**: You need an active AWS account.
2. **AWS CLI**: Installed and configured.
3. **GitHub Secrets Configuration**:
   - **`AWS_ACCESS_KEY_ID`**: AWS access key ID.
   - **`AWS_SECRET_ACCESS_KEY`**: AWS secret access key.

### Steps to Deploy

1. **Add Required Secrets to GitHub**:
   - Go to your repository's **Settings > Secrets and variables > Actions > New repository secret**.
   - Add the following secrets:
     - **`AWS_ACCESS_KEY_ID`**: Your AWS access key ID.
     - **`AWS_SECRET_ACCESS_KEY`**: Your AWS secret access key.

2. **Run the GitHub Action**:
   - Push your changes to the `main` branch or manually trigger the **Deploy AWS Infrastructure with CloudFormation** workflow from the **Actions** tab.

3. **Monitor the Deployment**:
   - Go to the **Actions** tab in your GitHub repository.
   - Select the **Deploy AWS Infrastructure with CloudFormation** workflow to monitor the deployment progress.

### 📊 What Happens After Deployment

- The CloudFormation template will create the following resources:
  - **API Gateway**: Acts as the main entry point for handling command and query operations.
  - **Amazon SNS**: Acts as the message broker, managing event distribution.
  - **Amazon DynamoDB**: Used for both command (write) and query (read) operations.
  - **AWS Lambda Functions**: Hosts the Command Handler, Update Processor, and Query Handler functions.
  - **Amazon CloudWatch**: Monitors logs, metrics, and telemetry data from all the services.

### 💡 Next Steps

Once the infrastructure is deployed, proceed to deploy each of the AWS Lambda functions (Command Handler, Update Processor, and Query Handler) and the API Gateway using their respective GitHub Actions.

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](../LICENSE) file for details.
