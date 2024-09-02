# Migration Training Day 2

## Tasks

The following are the tasks given for the day:

## Task 1:

Develop and execute a solution to migrate the data from an Excel file into an Azure SQL Server database with the help of Azure Data Factory (ADF) and Azure Storage Account. Please migrate only the mentioned columns, with the correct data type.

It seems you are looking to migrate specific columns from the Excel file (`emp_history.xlsx`) into an Azure SQL Database using Azure Data Factory (ADF). Since you want to migrate only the columns `EmpID`, `Emp_Last_Name`, and `Salary`, with specific data types (`INTEGER` for `EmpID` and `Salary`, `VARCHAR` for `Emp_Last_Name`), here's how you can achieve that step-by-step:

### **Step-by-Step Solution**

#### **Step 1: Upload Excel File to Azure Storage**

1. **Upload the Excel File:**
   - Go to the Azure Portal and navigate to your Storage Account.
   - Upload `emp_history.xlsx` to a Blob Container in your Storage Account.

#### **Step 2: Create the Target Table in Azure SQL Database**

1. **Create Table in SQL Database:**
   - Connect to your Azure SQL Database using SQL Server Management Studio (SSMS), Azure Data Studio, or directly via the Azure Portal’s Query Editor.
   - Execute the following SQL script to create the target table:

     ```sql
     CREATE TABLE EmployeeHistory (
         EmpID INT,
         Emp_Last_Name VARCHAR(100),
         Salary INT
     );
     ```

#### **Step 3: Set Up Azure Data Factory**

1. **Create a Linked Service for Azure Storage Account:**
   - Go to Azure Data Factory (ADF) in the Azure Portal.
   - Navigate to **Manage** > **Linked Services** > **New**.
   - Select **Azure Blob Storage**, then configure it with your Storage Account details.

2. **Create a Linked Service for Azure SQL Database:**
   - Similarly, create a new Linked Service for your Azure SQL Database.
   - Input the server name, database name, and authentication method (SQL Authentication or Managed Identity).

3. **Create Datasets:**
   - **Dataset for Excel File:**
     - Navigate to **Author** > **Datasets** > **New Dataset**.
     - Choose **Azure Blob Storage** as the connection, and select **Excel** as the format.
     - Point to the Excel file (`emp_history.xlsx`) and specify the worksheet containing the data.
     - Ensure that the first row is recognized as headers.
   - **Dataset for SQL Table:**
     - Create another dataset for your Azure SQL Database.
     - Point it to the `EmployeeHistory` table.

4. **Create a Data Pipeline:**
   - Create a new pipeline by navigating to **Author** > **Pipelines** > **New Pipeline**.
   - Drag a **Copy Data** activity onto the pipeline canvas.

5. **Configure the Copy Data Activity:**
   - **Source Configuration:**
     - Set the source to the Excel dataset.
     - In the **Mapping** section, select only the columns `EmpID`, `Emp_Last_Name`, and `Salary`.
   - **Sink Configuration:**
     - Set the sink to the SQL dataset pointing to the `EmployeeHistory` table.
     - Use the **Mapping** section to map:
       - `EmpID` (Excel) to `EmpID` (SQL) with the data type `INT`.
       - `Emp_Last_Name` (Excel) to `Emp_Last_Name` (SQL) with the data type `VARCHAR`.
       - `Salary` (Excel) to `Salary` (SQL) with the data type `INT`.

6. **Adjust Data Types:**
   - Ensure the mappings respect the data type constraints (`INT` for `EmpID` and `Salary`, `VARCHAR` for `Emp_Last_Name`).
   - Use data type conversion in ADF if necessary (e.g., to cast or format data).

#### **Step 4: Execute and Monitor the Pipeline**

1. **Validate and Run:**
   - Validate the pipeline configuration.
   - Run the pipeline manually to start the data transfer.

2. **Monitor the Pipeline Execution:**
   - Use ADF's monitoring feature to observe the pipeline's execution.
   - Ensure the data is transferred correctly without errors.

3. **Verify Data in SQL Database:**
   - Query the `EmployeeHistory` table in the SQL Database to ensure data integrity and correctness.

### **Sample SQL Query to Verify Data**

```sql
SELECT * FROM EmployeeHistory;
```

---


## Task 2:

What does Azure Migrate do? Perform a hands-on database assessment using Azure Migrate and migrate databases from a VM to a SQL Managed Instance.

### **Step-by-Step Solution**

#### **Step 1: Assess the Database Using Data Migration Assistant (DMA)**

1. **Download and Install DMA**:
   - Download the Data Migration Assistant from [Microsoft's official website](https://www.microsoft.com/en-us/download/details.aspx?id=53595).
   - Install it on your local machine or a server that has network access to the SQL Server VM.

2. **Run DMA Assessment**:
   - Open DMA and click on **New** to create a new project.
   - Set the project type to **Assessment**.
   - Choose **SQL Server** as the source and **Azure SQL Managed Instance** as the target.
   - Connect to the source SQL Server instance using appropriate credentials.
   - Select the databases you wish to assess for migration.
   - Run the assessment to identify potential compatibility issues and unsupported features.

3. **Review the Assessment Results**:
   - Review the DMA assessment results for any blocking issues or unsupported features that need to be addressed before migration.

#### **Step 2: Migrate the Database Using Data Migration Assistant (DMA)

1. **Create a New Migration Project in DMA**:
   - Open the Data Migration Assistant (DMA).
   - Click on **New** to create a new project.
   - Set the project type to **Migration** and choose **SQL Server** as the source and **Azure SQL Managed Instance** as the target.
   - Enter a project name and click **Create**.

2. **Configure the Migration Source and Target**:
   - **Source Configuration**: 
     - Connect to the source SQL Server instance by providing the server name, authentication type, and credentials.
     - Select the databases you want to migrate.
   - **Target Configuration**:
     - Provide the details for the Azure SQL Managed Instance, including the server name, authentication type, and credentials.
     - Choose the target database names or let DMA create new databases with the same names as the source.

3. **Select Objects to Migrate**:
   - Choose the objects you want to migrate, such as tables, stored procedures, functions, etc.
   - Click **Next** to proceed to the migration settings.

4. **Start the Migration**:
   - Review the migration summary and ensure all settings are correct.
   - Click **Start Migration** to begin the migration process.
   - Monitor the progress in the DMA interface. The tool will display real-time status updates as the migration proceeds.

5. **Monitor and Validate Migration**:
   - Once the migration completes, DMA will provide a summary of the migration results, including any issues encountered.
   - Validate that all data and schema objects have been migrated correctly.
   - Perform application testing to ensure compatibility and functionality with the Azure SQL Managed Instance.

6. **Cutover and Update Application Connections**:
   - Plan a downtime window for the final cutover.
   - Update the application's connection strings to point to the new Azure SQL Managed Instance.
   - Verify that all applications are functioning correctly with the new database.

7. **Finalize Migration**:
   - Perform any final performance optimizations and apply necessary configurations on the Azure SQL Managed Instance.
   - Monitor the performance and make adjustments as needed.