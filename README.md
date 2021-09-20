# Before compile this project
## You have to change ConnectionStrings in the project.
- ServerName
- DatabaseName
- IdName
- PasswordName

### This project work with Microsoft SQL Server

#### In AuthOption section you need to change the password of the token

## This project the libraries
- EntityFrameworkCore.SqlServer to implement MSSql database
- EntityFrameworkCore to work with the database
- EntityFrameworkCore.Design to generate migration
- Authentication.JwtBearer to use JTW for authentication
- Swashbuckle.AspNetCore to use Swagger UI in the project
