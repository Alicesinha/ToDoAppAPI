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

        public async Task<List<TaskGetResult>> GetTasks()
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

            await using var connection = new NpgsqlConnection(GetTaskConnectionString());
            var tasks = await connection.QueryAsync<TaskGetResult>(sql);
            return tasks.ToList();
        }
        public async Task<List<SubTaskGetResult>> GetSubTasks(int IdTask)
        {
            const string sql = """
            SELECT 
                T."IdSubTask", 
                T."Description",
                T."CheckDae",
                T."Check",
                T."IdTask"
            FROM "Tasks" T
            WHERE T."IdTask" = @IdTask
            """;

            await using var connection = new NpgsqlConnection(GetTaskConnectionString());
            var tasks = await connection.QueryAsync<SubTaskGetResult>(sql, new {IdTask = IdTask });
            return tasks.ToList();
        }
        public async Task<int> InsertTask(InsertTaskDto dto)
        {
            const string sql = """
            INSERT INTO "Tasks"
            (
                "Title", 
                "Description",
                "IdStatus",
                "DeliveryDate",
                "CreateDate"
            )
            VALUES 
            (
                @Title,
                @Description,
                @IdStatus,
                @DeliveryDate,
                @CreateDate
            )
            RETURNING "IdTask"
            """;

            var parameters = new DynamicParameters();
            parameters.Add("@Title", dto.Title);
            parameters.Add("@Description", dto.Description);
            parameters.Add("@IdStatus", 1);
            parameters.Add("@DeliveryDate", dto.DeliveryDate);
            parameters.Add("@CreateDate", DateTime.Now);


            await using var connection = new NpgsqlConnection(GetTaskConnectionString());
            var idTask = await connection.ExecuteAsync(sql, parameters);
            return idTask;
        }
        public async Task<int> AlterTask(AlterTaskDto dto)
        {
            const string sql = """
                UPDATE "Tasks"
                SET
                    "Title" = @Title,
                    "Description" = @Description,
                    "IdStatus" = @IdStatus,
                    "DeliveryDate" = @DeliveryDate,
                    "FinishDate" = @FinishDate
                WHERE
                  "IdTask" = @IdTask
                RETURNING "IdTask"
                """;

            var parameters = new DynamicParameters();
            parameters.Add("@Title", dto.Title);
            parameters.Add("@Description", dto.Description);
            parameters.Add("@IdTask", dto.idTask);
            parameters.Add("@IdStatus", dto.IdStatus);
            parameters.Add("@FinishDate", dto.IdStatus == 3 ? DateTime.Now : null);
            parameters.Add("@DeliveryDate", dto.DeliveryDate);

            await using var connection = new NpgsqlConnection(GetTaskConnectionString());
            var idTask = await connection.ExecuteAsync(sql, parameters);
            return idTask;
        }
        public async Task<int> AlterTaskStatus(int idTask, int idStatus, DateTime? finishDate)
        {
                    const string sql = """
            UPDATE "Tasks"
            SET
                "IdStatus" = @IdStatus,
                "FinishDate" = @FinishDate
            WHERE
              "IdTask" = @IdTask
            RETURNING "IdTask"
            """;

            var parameters = new DynamicParameters();
            parameters.Add("@IdStatus", idStatus);
            parameters.Add("@FinishDate", finishDate);
            parameters.Add("@IdTask", idTask);

            await using var connection = new NpgsqlConnection(GetTaskConnectionString());
            var result = await connection.ExecuteAsync(sql, parameters);
            return result;
        }
        public async Task<int> DeleteTask(int IdTask)
        {
            const string sql = """
                DELETE FROM "Tasks"
                WHERE "IdTask" = @IdTask
            """;

            await using var connection = new NpgsqlConnection(GetTaskConnectionString());
            var task = await connection.ExecuteAsync(sql, new { IdTask = IdTask });
            return task;
        }
        private string GetTaskConnectionString() =>
        _configuration.GetConnectionString("TaskConnection")!;
        public async Task<int> InsertSubtask(InsertSubTaskDTO dto, int IdTask)
        {
            const string sql = """
            INSERT INTO "SubTasks"
            (
                "Description",
                "CheckDate",
                "Check",
                "IdTask"
            )
            VALUES 
            (
                @Description,
                @CheckDate,
                @Check,
                @IdTask
            )
            RETURNING "IdSubTask"
            """;

            var parameters = new DynamicParameters();
            parameters.Add("@Description", dto.Description);
            parameters.Add("@CheckDate", dto.Check == true ? DateTime.Now : null);
            parameters.Add("@Check", dto.Check);
            parameters.Add("@IdTask", IdTask);

            await using var connection = new NpgsqlConnection(GetTaskConnectionString());
            var idTask = await connection.ExecuteAsync(sql, parameters);
            return idTask;
        }
        public async Task<int> DeleteSubTask(int IdSubTask)
        {
            const string sql = """
                DELETE FROM "IdSubTask"
                WHERE "IdSubTask" = @IdSubTask
            """;

            await using var connection = new NpgsqlConnection(GetTaskConnectionString());
            var task = await connection.ExecuteAsync(sql, new { IdSubTask = IdSubTask });
            return task;
        }
    }
}
