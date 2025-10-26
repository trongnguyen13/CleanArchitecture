var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.CarBookings>("carbookings");

builder.Build().Run();
