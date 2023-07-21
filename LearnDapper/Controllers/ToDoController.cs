﻿using LearnDapper.Interface;
using LearnDapper.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearnDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IDapperService _dapper;
        public ToDoController(IDapperService dapper)
        {
            _dapper = dapper;
        }
        // GET: api/<ToDoController>
        [HttpGet]
        public Task<List<ToDo>> Get()
        {
            var tasks = _dapper.GetAll();
            return tasks;
        }

        // GET api/<ToDoController>/5
        [HttpGet("{id}")]
        public async Task<ToDo> Get(int id)
        {
           var task = await _dapper.GetTaskById(id);
            return task;
        }

        // POST api/<ToDoController>
        [HttpPost]
        public async Task<string> Post([FromBody] ToDo toDo)
        {
            var task = await _dapper.CreateTask(toDo);
            return task;
        }

        // PUT api/<ToDoController>/5
        [HttpPut("{id}")]
        public async Task<string> Put(int id, [FromBody] ToDo toDo)
        {
            var task = await _dapper.UpdateTask(toDo);
            return task;
        }

        // DELETE api/<ToDoController>/5
        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            var response = await _dapper.DeleteTask(id);
            return response;
        }
    }
}
