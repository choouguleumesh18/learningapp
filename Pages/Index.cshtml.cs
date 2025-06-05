using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace learningapp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IConfiguration _configuration;


    public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public void OnGet()
    {
        List<UserInfo> lstusers = new List<UserInfo>();
        string? con = _configuration.GetConnectionString("Azure_SQL_ConnectionString");        
        SqlConnection sqlConnection = new SqlConnection(con);
        ViewData["Environment"] = Environment.GetEnvironmentVariable("Environment");        
        sqlConnection.Open();
        SqlCommand command = new("Select * from UserInfo", sqlConnection);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            lstusers.Add(new () { ID = reader.GetInt32(0), FirstName = reader.GetString(1), LastName = reader.GetString(2) });
            int id = reader.GetInt32(0);            // index-based reading
            string name = reader.GetString(1);
            Console.WriteLine($"ID: {id}, Name: {name}");
        }
        sqlConnection.Close();
        ViewData["Title"] = "Home page Updated";
        ViewData["users"] = lstusers;
    }
}

public class UserInfo
{
    public int ID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
