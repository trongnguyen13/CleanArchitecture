using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var tangoApi = builder.AddProject<TangoAPI>("tangoApi").WithExternalHttpEndpoints();
builder.AddProject<PublicAPI>("publicApi");
builder.AddProject<HangfireServer>("hangfireServer");

builder.AddNpmApp("vue", "../UIs/tango-ui")
    .WithReference(tangoApi)
    .WaitFor(tangoApi)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints();

builder.Build().Run();
