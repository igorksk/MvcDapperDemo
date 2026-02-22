using Microsoft.AspNetCore.Mvc;
using MvcDapperDemo.Data;
using MvcDapperDemo.Models;

namespace MvcDapperDemo.Controllers;

public class PeopleController(PersonRepository repo) : Controller
{
    private readonly PersonRepository _repo = repo;

    public async Task<IActionResult> Index()
    {
        var list = await _repo.GetAllAsync();
        return View(list);
    }

    public IActionResult Create()
    {
        return View(new Person());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Person person)
    {
        if (!ModelState.IsValid) return View(person);
        await _repo.CreateAsync(person);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var person = await _repo.GetByIdAsync(id);
        if (person == null) return NotFound();
        return View(person);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Person person)
    {
        if (!ModelState.IsValid) return View(person);
        await _repo.UpdateAsync(person);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var person = await _repo.GetByIdAsync(id);
        if (person == null) return NotFound();
        return View(person);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _repo.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
