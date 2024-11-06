using Aspire.Hosting.Dapr;
using Projects;

var builder = DistributedApplication.CreateBuilder(args);

#region Postgres

// PostgreSQL entegrasyonu
var postgres = builder.AddPostgres("postgres");

// PostgreSQL database entegrasyonu
var supportdb = postgres.AddDatabase("support");
var streamingdb = postgres.AddDatabase("streaming");
var notificationdb = postgres.AddDatabase("notification");
var lessondb = postgres.AddDatabase("lesson");
var languagedb = postgres.AddDatabase("language");
var coursedb = postgres.AddDatabase("course");
var certificatedb = postgres.AddDatabase("certificate");
var admindb = postgres.AddDatabase("admin");
var paymentdb = postgres.AddDatabase("payment");
var ratingdb = postgres.AddDatabase("rating");

#endregion

#region Service and Databases

// Keycloak entegrasyonu
var keycloak = builder.AddKeycloak("keycloak", 7070);

// Seq entegrasyonu
var seq = builder.AddSeq("seq")
    .ExcludeFromManifest();

// Elasticsearch entegrasyonu
var elastic = builder.AddElasticsearch("elastic");

// Redis entegrasyonu
var redis = builder.AddRedis("cache")
    .WithRedisCommander();

// Kafka entegrasyonu
var kafka = builder.AddKafka("kafka")
    .WithKafkaUI();

// Azure Storage entegrasyonu
var storage = builder.AddAzureStorage("storage")
    .RunAsEmulator();

var videodb = storage.AddBlobs("blobs");

#endregion

#region User

var user = builder.AddProject<Udemy_User_API>("udemy-user-api")
    .WithReference(kafka)
    .WithReference(redis)
    .WithReference(seq)
    .WithReference(keycloak)
    .WithReference(elastic);

#endregion

#region Support

var support = builder.AddProject<Udemy_Support_API>("udemy-support-api")
    .WithReference(kafka)
    .WithReference(redis)
    .WithReference(seq)
    .WithReference(supportdb);

#endregion

#region Streaming

var streaming = builder.AddProject<Udemy_Streaming_API>("udemy-streaming-api")
    .WithReference(kafka)
    .WithReference(redis)
    .WithReference(seq)
    .WithReference(streamingdb)
    .WithReference(videodb);

#endregion

#region Notification

var notification = builder.AddProject<Udemy_Notification_API>("udemy-notification-api")
    .WithReference(kafka)
    .WithReference(redis)
    .WithReference(seq)
    .WithReference(notificationdb);

#endregion

#region Lesson

var lesson = builder.AddProject<Udemy_Lesson_API>("udemy-lesson-api")
    .WithReference(kafka)
    .WithReference(redis)
    .WithReference(seq)
    .WithReference(lessondb);

#endregion

#region Language

var language = builder.AddProject<Udemy_Language_API>("udemy-language-api")
    .WithReference(kafka)
    .WithReference(redis)
    .WithReference(seq)
    .WithReference(languagedb);

#endregion

#region Course

var course = builder.AddProject<Udemy_Course_API>("udemy-course-api")
    .WithReference(kafka)
    .WithReference(redis)
    .WithReference(seq)
    .WithReference(coursedb)
    .WithReference(videodb)
    .WithReference(elastic);

#endregion

#region Certificate

var certificate = builder.AddProject<Udemy_Certificate_API>("udemy-certificate-api")
    .WithReference(kafka)
    .WithReference(redis)
    .WithReference(seq)
    .WithReference(certificatedb);

#endregion

#region Admin

var admin = builder.AddProject<Udemy_Admin_API>("udemy-admin-api")
    .WithReference(kafka)
    .WithReference(redis)
    .WithReference(seq)
    .WithReference(admindb);

#endregion

#region Payment

var payment = builder.AddProject<Udemy_Payment_API>("udemy-payment-api")
    .WithReference(kafka)
    .WithReference(redis)
    .WithReference(seq)
    .WithReference(paymentdb);

#endregion

#region Rating

builder.AddProject<Udemy_Rating_API>("udemy-rating-api")
    .WithReference(kafka)
    .WithReference(redis)
    .WithReference(seq)
    .WithReference(ratingdb);

#endregion

#region Search

builder.AddProject<Udemy_Search_API>("udemy-search-api")
    .WithReference(kafka)
    .WithReference(redis)
    .WithReference(seq)
    .WithReference(elastic);

#endregion

#region Frontend

// Frontend uygulaması
builder.AddNpmApp("frontend", @"C:\Users\abura\OneDrive\Desktop\Udemy\frontend", "dev")
    .WithHttpEndpoint(3000, 3000, isProxied: false)
    .WithReference(user)
    .WithReference(support)
    .WithReference(streaming)
    .WithReference(notification)
    .WithReference(lesson)
    .WithReference(language)
    .WithReference(course)
    .WithReference(certificate)
    .WithReference(admin)
    .WithReference(payment)
    .WithExternalHttpEndpoints();

#endregion

builder.Build().Run();