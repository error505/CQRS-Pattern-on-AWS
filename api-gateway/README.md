# API Gateway for CQRS Pattern

This folder contains the OpenAPI specification file for deploying the **AWS API Gateway** to support the **CQRS Pattern** on AWS. The API Gateway serves as the main entry point for handling command and query operations.

## 📑 Files

- **`ApiSpec.yaml`**: OpenAPI specification file defining the API endpoints, methods, and integration with AWS Lambda.
- **`deploy-api-gateway.yml`**: GitHub Action workflow to automate the deployment of the API Gateway.

## 🚀 How to Deploy the API Gateway

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
   - Push your changes to the `main` branch or manually trigger the **Deploy API Gateway** workflow from the **Actions** tab.

3. **Monitor the Deployment**:
   - Go to the **Actions** tab in your GitHub repository.
   - Select the **Deploy API Gateway** workflow to monitor the deployment progress.

### 📝 API Endpoints

1. **Insert Data**:
   - Send a POST request to `/command/insert` with a JSON body containing the data to insert.
   - Example:

     ```json
     {
       "data": "Sample data to insert"
     }
     ```

2. **Query Data**:
   - Send a GET request to `/query/get?id={your_id}` to retrieve data by ID.

### 📄 License

This project is licensed under the MIT License - see the [LICENSE](../LICENSE) file for details.
