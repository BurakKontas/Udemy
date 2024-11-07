using Projects;

var builder = DistributedApplication.CreateBuilder(args);

#region Postgres

// PostgreSQL entegrasyonu
var postgres = builder.AddPostgres("postgres");

// PostgreSQL database entegrasyonu
var supportdb = postgres.AddDatabase("supportdb");
var streamingdb = postgres.AddDatabase("streamingdb");
var notificationdb = postgres.AddDatabase("notificationdb");
var lessondb = postgres.AddDatabase("lessondb");
var languagedb = postgres.AddDatabase("languagedb");
var coursedb = postgres.AddDatabase("coursedb");
var certificatedb = postgres.AddDatabase("certificatedb");
var admindb = postgres.AddDatabase("admindb");
var paymentdb = postgres.AddDatabase("paymentdb");
var ratingdb = postgres.AddDatabase("ratingdb");
var userdb = postgres.AddDatabase("userdb");

// PostgreSQL PGAdmin entegrasyonu
postgres.WithPgAdmin();
// PostgreSQL Volume entegrasyonu
postgres.WithDataVolume("udemy-postgres");

#endregion

#region Service and Databases

// Seq entegrasyonu
var seq = builder.AddSeq("seq")
    .ExcludeFromManifest()
    .WithDataVolume("udemy-seq");

// Elasticsearch entegrasyonu
var elastic = builder.AddElasticsearch("elastic")
    .WithDataVolume("udemy-elastic");

// Redis entegrasyonu
var redis = builder.AddRedis("cache")
    .WithRedisCommander()
    .WithDataVolume("udemy-redis");

// Kafka entegrasyonu
var rabbitmq = builder.AddRabbitMQ("rabbitmq")
    .WithManagementPlugin()
    .WithDataVolume("udemy-rabbitmq");

// Azure Storage entegrasyonu
var storage = builder.AddAzureStorage("storage")
    .RunAsEmulator(container => container.WithDataVolume("udemy-azure-storage"));

var videodb = storage.AddBlobs("blobs");

#endregion

#region User

var user = builder.AddProject<Udemy_User_API>("udemy-user-api")
    .WithReference(rabbitmq)
    .WithReference(redis)
    .WithReference(seq)
    .WithReference(userdb)
    .WithReference(elastic);

#endregion

#region Support

var support = builder.AddProject<Udemy_Support_API>("udemy-support-api")
    .WithReference(rabbitmq)
    .WithReference(redis)
    .WithReference(seq)
    .WithReference(supportdb);

#endregion

#region Streaming

var streaming = builder.AddProject<Udemy_Streaming_API>("udemy-streaming-api")
    .WithReference(rabbitmq)
    .WithReference(redis)
    .WithReference(seq)
    .WithReference(streamingdb)
    .WithReference(videodb);

#endregion

#region Notification

var notification = builder.AddProject<Udemy_Notification_API>("udemy-notification-api")
    .WithReference(rabbitmq)
    .WithReference(redis)
    .WithReference(seq)
    .WithReference(notificationdb);

#endregion

#region Lesson

var lesson = builder.AddProject<Udemy_Lesson_API>("udemy-lesson-api")
    .WithReference(rabbitmq)
    .WithReference(redis)
    .WithReference(seq)
    .WithReference(lessondb);

#endregion

#region Language

var language = builder.AddProject<Udemy_Language_API>("udemy-language-api")
    .WithReference(rabbitmq)
    .WithReference(redis)
    .WithReference(seq)
    .WithReference(languagedb);

#endregion

#region Course

var course = builder.AddProject<Udemy_Course_API>("udemy-course-api")
    .WithReference(rabbitmq)
    .WithReference(redis)
    .WithReference(seq)
    .WithReference(coursedb)
    .WithReference(videodb)
    .WithReference(elastic);

#endregion

#region Certificate

var certificate = builder.AddProject<Udemy_Certificate_API>("udemy-certificate-api")
    .WithReference(rabbitmq)
    .WithReference(redis)
    .WithReference(seq)
    .WithReference(certificatedb);

#endregion

#region Admin

var admin = builder.AddProject<Udemy_Admin_API>("udemy-admin-api")
    .WithReference(rabbitmq)
    .WithReference(redis)
    .WithReference(seq)
    .WithReference(admindb);

#endregion

#region Payment

var payment = builder.AddProject<Udemy_Payment_API>("udemy-payment-api")
    .WithReference(rabbitmq)
    .WithReference(redis)
    .WithReference(seq)
    .WithReference(paymentdb);

#endregion

#region Rating

builder.AddProject<Udemy_Rating_API>("udemy-rating-api")
    .WithReference(rabbitmq)
    .WithReference(redis)
    .WithReference(seq)
    .WithReference(ratingdb);

#endregion

#region Search

builder.AddProject<Udemy_Search_API>("udemy-search-api")
    .WithReference(rabbitmq)
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