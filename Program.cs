var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add repository with SQLite connection string
var connectionString = builder.Configuration.GetConnectionString("Default") ?? "Data Source=people.db";
builder.Services.AddSingleton(new MvcDapperDemo.Data.PersonRepository(connectionString));

var app = builder.Build();

// Ensure database exists and create table
using (var scope = app.Services.CreateScope())
{
    var conn = new Microsoft.Data.Sqlite.SqliteConnection(connectionString);
    conn.Open();
    var cmd = conn.CreateCommand();
    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS People (
        Id INTEGER PRIMARY KEY AUTOINCREMENT,
        Name TEXT NULL,
        Age INTEGER NOT NULL
    );";
    cmd.ExecuteNonQuery();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
