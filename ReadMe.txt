This inventory control system consists of three core components: an interactive online storefront, 
a delivery driver web portal, and a desktop application for store employees. All components are connected to a live MySQL database.

The online storefront allows customers to place orders from various store locations for in-store pickup. 
It is built using React with TypeScript and styled using Bootstrap. It communicates with the backend via a RESTful API.

Delivery drivers can log in to a dedicated portal to view, track, and manage their delivery assignments in real time.
	
Designed for use by store staff, the desktop application (built with Windows Forms) supports a wide range of features, including:
		Creating and managing store orders
		Transferring stock between stores
		Full CRUD functionality for employees and inventory
		Administrative tools for managing store operations
			
The ASP.NET Core API handles all data routing between the web/desktop clients and the MySQL database.
It serves as the central communication layer for the entire system.

Setup:

1. Create the MySQL Database:

    - Run 2025_Bullseye_DB2025_1.3.sql to create the initial schema.

	- Run RequiredDBAlterations.sql to apply necessary modifications.  	

2. Update Connection Strings:

	- Update the connection strings in both the API project and the desktop application to point to your MySQL server.

3. Start the API:

	- Host the ASP.NET Core API locally (e.g., via Visual Studio or dotnet run).

4. Run the Applications:

	- For the online app: Start the React development server locally.

	- For the desktop app: Run the compiled .exe file.