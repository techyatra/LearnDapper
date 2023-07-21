using Dapper;
using LearnDapper.DapperContext;
using LearnDapper.Interface;
using LearnDapper.Models;

namespace LearnDapper.Repo
{
    public class DapperRepo : IDapperService
    {
        private readonly DapperDbContext _dapperContext;
        public DapperRepo(DapperDbContext dapperContext) {
            _dapperContext = dapperContext;
        }

        public async Task<string> CreateTask(ToDo toDo)
        {
            string response = String.Empty;
            var sql = "insert into todos(name, description, status, createdAt) values(@name, @description,@status, @createdAt)";
            var parameters = new DynamicParameters();
            parameters.Add("id", toDo.Id, System.Data.DbType.String);
            parameters.Add("name", toDo.Name, System.Data.DbType.String);
            parameters.Add("description", toDo.Description, System.Data.DbType.String);
            parameters.Add("status", toDo.Status, System.Data.DbType.String);
            parameters.Add("createdAt", toDo.CreatedAt, System.Data.DbType.DateTime);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(sql, parameters);
                response = "pass";
            }
            return response;
        }

        public async Task<string> DeleteTask(int id)
        {
            string response = String.Empty;
            var sql = "delete from todos where id = @id";
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(sql, new { id });
                response = "pass";
            }
            return response;
        }

        public async Task<List<ToDo>> GetAll()
        {
            var sql = "select * from todos";
            using (var connection = _dapperContext.CreateConnection())
            {
                var tasks = await connection.QueryAsync<ToDo>(sql);
                return tasks.ToList();
            }
        }

        public async Task<ToDo> GetTaskById(int id)
        {
            var sql = "select * from todos where id = @id";
            using (var connection = _dapperContext.CreateConnection())
            {
                var task = await connection.QueryFirstOrDefaultAsync<ToDo>(sql, new { id });
                return task;
            }
        }

        public async Task<string> UpdateTask(ToDo toDo)
            {
                string response = String.Empty;
                var sql = "update todos set  name= @name, description = @description, status = @status";
                var parameters = new DynamicParameters();
                parameters.Add("id", toDo.Id, System.Data.DbType.String);
                parameters.Add("name", toDo.Name, System.Data.DbType.String);
                parameters.Add("description", toDo.Description, System.Data.DbType.String);
                parameters.Add("status", toDo.Status, System.Data.DbType.String);
                using (var connection = _dapperContext.CreateConnection())
                {
                    await connection.ExecuteAsync(sql, parameters);
                    response = "pass";
                }
                return response;
            }
        }
    } 

