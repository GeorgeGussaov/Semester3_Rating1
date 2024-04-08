using Microsoft.AspNetCore.Mvc;
using sem3rub1.Models;
using System;

namespace sem3rub1.Controllers
{
	public class RatingController : Controller
	{
		private readonly IStudentsRepository _studentsRepository;
		public RatingController(IStudentsRepository studentsRepository)
		{
			_studentsRepository = studentsRepository;
		}
		public IActionResult Index()
		{
			var students = _studentsRepository.GetStudents();
			return View(students);
		}
		public IActionResult Add(Student student)
		{
			if (ModelState.IsValid)
			{
				_studentsRepository.Add(student);
				return RedirectToAction("Index");
			}
			return View("Edit");
		}
		public IActionResult Edit(Guid id)
		{
			var student = _studentsRepository.TryGetById(id);
			return View(student);
		}
		[HttpPost]
		public IActionResult Save(Guid id,Student student)
		{
			if (ModelState.IsValid)
			{
				_studentsRepository.EditStudent(id, student.Name, student.Subject, student.CurrentPoint, student.RatingPoint);
				return RedirectToAction("Index");
			}
			return View("Edit", student);
		}
	}
}
