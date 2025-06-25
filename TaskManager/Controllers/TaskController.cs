using Microsoft.AspNetCore.Mvc;
using TaskManager.Models.DTO;
using TaskManager.Repositories;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _repo;
        private readonly IDbLogger _logger;

        public TaskController(ITaskRepository repo, IDbLogger logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.Log("Visited Task List (Index)", "Info");
            return View(_repo.GetAll());
        }

        public IActionResult Details(int id)
        {
            _logger.Log($"Viewed Task Details. TaskID: {id}", "Info");
            var task = _repo.GetById(id);
            return task == null ? NotFound() : View(task);
        }

        public IActionResult Create()
        {
            _logger.Log("Navigated to Create Task page", "Info");
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskDto dto)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(dto);
                _logger.Log($"Created Task: {dto.TaskDescription}", "Success");
                return RedirectToAction(nameof(Index));
            }

            _logger.Log("Create Task failed due to invalid model", "Warning");
            return View(dto);
        }

        public IActionResult Edit(int id)
        {
            _logger.Log($"Navigated to Edit Task page. TaskID: {id}", "Info");
            var task = _repo.GetById(id);
            return task == null ? NotFound() : View(task);
        }

        [HttpPost]
        public IActionResult Edit(TaskDto dto)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(dto);
                _logger.Log($"Updated TaskID: {dto.TaskID}", "Info");
                return RedirectToAction(nameof(Index));
            }

            _logger.Log("Edit Task failed due to invalid model", "Warning");
            return View(dto);
        }

        public IActionResult Delete(int id)
        {
            _logger.Log($"Navigated to Delete page for TaskID: {id}", "Info");
            var task = _repo.GetById(id);
            return task == null ? NotFound() : View(task);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            _logger.Log($"Deleted TaskID: {id}", "Warning");
            return RedirectToAction(nameof(Index));
        }
    }
}
