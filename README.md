# BRILLIANT — Simple Setup Guide

Follow these steps to run the project on your own Windows computer.

## 1. Install these programs (one time only)

1. **Visual Studio 2026** — during installation, select **.NET desktop development**. Make sure the **.NET 10 SDK** is installed.
   - https://visualstudio.microsoft.com/downloads/
2. **MySQL Community Server** — install it and **remember the password you set for the `root` user**. Keep the default port **3306**.
   - https://dev.mysql.com/downloads/mysql/
3. **MySQL Workbench** — use this to connect to MySQL and view the database.
   - https://dev.mysql.com/downloads/workbench/

> **Important:** Install **both MySQL Server and MySQL Workbench**. Workbench alone does not run the database.

## 2. Connect using MySQL Workbench

1. Open **MySQL Workbench**.
2. Under **MySQL Connections**, open your local connection, or click **+** to make one.
3. Use these settings:
   - **Hostname:** `localhost`
   - **Port:** `3306`
   - **Username:** `root`
4. Click **Test Connection**, enter the MySQL password you made during installation, and connect.

If the connection fails, check that **MySQL Server is running** and the password is correct.

## 3. Set your database password in the project

1. Extract the BRILLIANT project ZIP.
2. Open **`appsettings.json`** inside the project folder.
3. Find this line:

```json
"DefaultConnection": "Server=localhost;Port=3306;Database=brilliant_lms;Uid=root;Pwd=root;"
```

4. Replace the password after `Pwd=` with **your own MySQL root password**. Save the file.

**Example:** If your password is `mypassword123`, use `Pwd=mypassword123;` instead of `Pwd=root;`.

## 4. Open and run BRILLIANT

1. Open **Visual Studio**.
2. Select **Open a project or solution**.
3. Choose **`brilliant_lms.slnx`** from the extracted project folder.
4. Let Visual Studio finish loading and restoring the project packages (internet is needed the first time).
5. Press **F5** or click **Start** to run the application.
6. When the BRILLIANT login window appears, **register an account** and sign in.

**Done!** The program automatically creates the `brilliant_lms` database and its tables on first launch. You **do not need to import an SQL file manually**.

## 5. Check the database (optional)

In **MySQL Workbench**, reconnect or click **Refresh** in the **SCHEMAS** panel. You should see the **`brilliant_lms`** database after successfully running the application.

## If it does not run

- **Cannot connect to MySQL / Access denied:** Make sure MySQL Server is running and the password in `appsettings.json` matches your MySQL password.
- **.NET 10 error:** Install the .NET 10 SDK and the Visual Studio **.NET desktop development** workload.
- **Missing packages:** Connect to the internet, then in Visual Studio right-click the solution and select **Restore NuGet Packages**.

> **Reminder:** Do not upload your personal MySQL password in `appsettings.json` to a public repository.
