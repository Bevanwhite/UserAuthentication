# UserAuthentication

#### you need to have install these nuget packages 
- Microsoft.AspNetCore.Authentication.JwtBearer -v 3.1.31
- Microsoft.AspNetCore.Identity -v 2.2.0
- Microsoft.AspNetCore.Identity.EntityFrameworkCore -v 3.1.31
- Microsoft.EntityFrameworkCore.Tools -v 3.1.31
- Microsoft.EntityFrameworkCore.SqlServer -v 3.1.31

#### to Models to the database you these commands
- before do that open this tool in 
	- visual studio -> tools -> Nuget Package Manager -> Package Manager Console
- add-migration Initial
- update-database
- make sure that ConnectionString that you have mention in `Startup.cs` and `appsettings.json` have to exactly the same name 