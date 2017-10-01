using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoteApplication.Controllers;
using NoteApplication.Models;

namespace NoteApplication.Controllers
{
    [RoutePrefix("")]
    public class NotesController : Controller
    {
        [Route]
        public ActionResult Index()
        {
            using (TaskContext db = new TaskContext())
            {
                List<Task> notes = db.TasksList.ToList();
                return View(notes);
            }
        }

        [Route("add/")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("add/")]
        public ActionResult Add(Task note)
        {
            if (ModelState.IsValid)
            {
                using (var db = new TaskContext())
                {
                    db.AddNewTask(note);

                    return RedirectToAction("Index");
                }
            }

            return View(note);
        }

        [Route("edit/")]
        public ActionResult Edit(int id)
        {
            using (var taskContext = new TaskContext())
            {
                Task taskForEdit = taskContext.TasksList.First(task => task.Id == id);
                return View(taskForEdit);
            }
        }

        [HttpPost]
        [Route("edit/")]
        public ActionResult Edit(Task updatedTask)
        {
            if (ModelState.IsValid)
            {
                using (var taskContext = new TaskContext())
                {
                    taskContext.UpdateTask(updatedTask.Id, updatedTask.Description);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(updatedTask);
            }
        }

        [Route("remove/")]
        public ActionResult Remove(int id)
        {
            using (var taskContext = new TaskContext())
            {
                taskContext.DeleteTask(id);

                return RedirectToAction("Index");
            }
        }
    }
}