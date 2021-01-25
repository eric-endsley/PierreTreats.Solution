# Pierre's Treats

#### A website for Pierre's Bakery to securely list & manage it's ingredients and their flavors , 1/24/21

#### By Eric Endsley

## Description

This is a simple MVC website meant for a bakery to list its baked goods (treats) and their associated flavors. The splash page lists all treats and flavors, and each item in these lists links to a details page associated with that treat or flavor. The splash page also provides links to pages which list only treats or flavors and provide the additional functionality to add a new treat/flavor. The details page for flavors provides a link to add an associated treat. The details page for treats provides the same, and additionally the options to rename or delete the respective treat. The website also includes a navigation bar from which a user can return to the home page, the treats page, the flavors page, or the account page.

The account page utilizes Identity to allow users to register, login & logout. Only users who are logged in may utilize any of the site's functionality beyond merely reading the existing information -- that is, users must log in to create, edit or delete information on the site. If a user is not logged in, the account page will offer a link to register an account (using email & password) or a link to login to an existing account. If a user is logged in the account page will allow the user to log out. If a user who is not logged in attempts an unauthorized action (e.g. creating a flavor), the user will be automatically redirected to the account page and asked to login or register.

## Setup

### Install .NET Core

1. This program is written in C# and requires the .NET Core to run. For PC users click [this link](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-2.2.203-windows-x64-installer) and follow the installation instructions. For Mac users click [this link](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-2.2.106-macos-x64-installer) and follow the installation instructions.

2. Install dotnet script by entering the following command in your terminal: "dotnet tool install -g dotnet-script"

### Install MySQL

1. This program uses MySQL to store and manage data. Navigate to [this link](https://dev.mysql.com/downloads/file/?id=484919) and follow the installation instructions to install MySQL and MySQL Workbench.

2. Be sure to make note of the password you create during the installation process, you will need to use this later on in the setup.

### Clone The Repository

1.  Open the [Factory Database website](https://github.com/eric-endsley/PierreTreats.Solution.git) by clicking the link or copy/pasting "https://github.com/eric-endsley/PierreTreats.Solution" in the navigator bar of a web browser application.

2.  Click the green Code button in the upper-right part of the window and then EITHER:

3.  a. Copy the HTTPS URL for the repo and use it in the git clone command in git-bash or another git terminal by inputting: "git clone https://github.com/eric-endsley/PierreTreats.Solution"<br>
    OR b. Click "Download Zip" and unzip the file to an accessible location on your machine.

4.  Right click on the project directory and open it with VS Code or another code editor.

### Setup MySQL Database with Entity

#### Option 1: Create Data Structure Code First From the Terminal:

1. Navigate to the appsettings.json file within the /PierreTreats subdirectory. Locate the line of code that states "pwd=epicodus" and overwrite epicodus with the password you created during installation of MySQL

2. In your terminal, type the command "dotnet restore" followed by the command "dotnet ef database update". You have now created the data structure for this application.

#### Option 2: Import Data Structure Using MySQL Workbench GUI:

1. Open the program MySQL Workbench which you installed earlier and enter the password that you setup during installation.

2. Using the navigation bar select Server > Data Import.

3. When prompted, select the option to "Import From Self Contained File" and select the file "eric_endsley_Db_export.sql" in the Factory.Solution folder.

4. In the dropdown labelled "Default Target Schema:", select "eric_endsley" or whatever you named your database in appsettings.json. Select all of the schema objects. Then click the "Start Import" button. You have now imported the data structure.

### Open the Webpage!

1. In the terminal, type the command "dotnet run".

2. If your browser does not automatically open the page, open your preferred browser and enter "http://localhost:5000" in the navigation bar. If this does not work, look for the phrase "Now listening on:" written in your terminal a few lines after your "dotnet run" command. Navigate to the url written there.

3. At this point you are free to browse the existing data on the website. In order to modify the data, you must first register & login. Navigate to the "account" link in the navbar, and click the "Register" link. Enter an email & password; the email does not need to be functional and there are no requirements for the password. Now click the "Log in" link and enter the information you just registered with. You are now able to use all of the site's functionality!

## Technologies Used

C#, .NET Core 2.2, ASP.NET Core MVC, MySQL, Entity Framework Core, Identity, Razor, Bootstrap, VS Code

## Known Bugs

None

## Contact Information

To ask questions or report a bug, contact [Eric Endsley](mailto:eric.endsley4@gmail.com)

## Legal

This software is licensed under the MIT license.
