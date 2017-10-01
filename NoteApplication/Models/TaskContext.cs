using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NoteApplication.Models
{
    public class TaskContext : DbContext
    {
        public DbSet<Task> TasksList { get; set; }

        public void AddNewTask(Task task)
        {
            TasksList.Add(task);
            SaveChanges();
        }

        public void DeleteTask(int id)
        {
            Task deletingTask = TasksList.FirstOrDefault(task => task.Id == id);
            TasksList.Remove(deletingTask);
            SaveChanges();
        }

        public void UpdateTask(int id, string updatedDescription)
        {
            Task prevTask = TasksList.FirstOrDefault(task => task.Id == id);
            prevTask.Description = updatedDescription;
            SaveChanges();
        }

    }
  /*  public class NotesDbInitiallizer: DropCreateDatabaseAlways<TaskContext>
    {
        protected override void Seed(TaskContext db)
        {
            db.TasksList.Add(new Task {Id=1, Description = "Купить хлеб",IsDone = false });
            base.Seed(db);
        }
    }*/
}