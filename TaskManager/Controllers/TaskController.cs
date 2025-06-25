using Microsoft.AspNetCore.Mvc;
using TaskManager.Models.DTO;
using TaskManager.Repositories;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _repo;

        public TaskController(ITaskRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index() => View(_repo.GetAll());

        public IActionResult Details(int id)
        {
            var task = _repo.GetById(id);
            return task == null ? NotFound() : View(task);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(TaskDto dto)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        public IActionResult Edit(int id)
        {
            var task = _repo.GetById(id);
            return task == null ? NotFound() : View(task);
        }

        [HttpPost]
        public IActionResult Edit(TaskDto dto)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        public IActionResult Delete(int id)
        {
            var task = _repo.GetById(id);
            return task == null ? NotFound() : View(task);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
