
var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServerContainer("sql",password:"ESAFq23ghA4#$$WhbzE$b4yhn4E",port:14420).AddDatabase("sqldata");

builder.AddProject<Projects.CarRental_EndPoint_Admin_Web>("admin").WithReference(sql);

builder.AddProject<Projects.CarRental_EndPoint_Renter_Web>("renter").WithReference(sql);

builder.AddProject<Projects.CarRenter_EndPoint_Rentor_Web>("rentor").WithReference(sql);

builder.AddProject<Projects.CarRental_Persistence>("sqlapp").WithReference(sql);

builder.Build().Run();
