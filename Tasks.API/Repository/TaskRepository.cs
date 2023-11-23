using Dapper;
using Npgsql;
using System.Data.SqlClient;
using Tasks.API.Interfaces;
using Tasks.API.Models;

namespace Tasks.API.Repository
{
    public class TaskRepository: ITaskRepository
    {
        private readonly IConfiguration _configuration;
        public TaskRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<TaskGET>> GetTasks()
        {
            const string sql = """
            SELECT 
                T."IdTask", 
                T."Title", 
                T."Description",
                T."IdStatus",
                TS."description" AS StatusDescription,
                T."DeliveryDate",
                T."CreateDate",
                T."FinishDate"
            FROM "Tasks" T
            INNER JOIN "TasksStatus" TS ON TS."IdTaskStatus" = T."IdStatus"
            """;

            /*await using var connection = new SqlConnection(GetTaskConnectionString());*/
            await using var connection = new NpgsqlConnection(GetTaskConnectionString());
            var tasks = await connection.QueryAsync<TaskGET>(sql);
            return tasks.ToList();
        }
        private string GetTaskConnectionString() =>
        _configuration.GetConnectionString("TaskConnection")!;
    }
}
