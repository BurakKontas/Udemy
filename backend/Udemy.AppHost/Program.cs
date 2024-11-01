var builder = DistributedApplication.CreateBuilder(args);

builder.AddNpmApp("frontend", @"C:\Users\abura\OneDrive\Desktop\Udemy\frontend", "dev")
    .WithHttpEndpoint(3000, 5173)
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
