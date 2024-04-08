using sem3rub1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sem3rub1
{
	public class InMemoryStudentsRepository : IStudentsRepository
	{
		private List<Student> Students = new List<Student>() { new Student("Anton", "Proga", 20, 20), new Student("PAvel", "Proga", 25, 10) };
		public void Add(Student student)
		{
			Students.Add(student);
		}
		public List<Student> GetStudents()
		{
			return Students;
		}
		public Student TryGetById(Guid id)
		{
			return Students.FirstOrDefault(st => st.Id == id);
		}
		public void EditStudent(Guid id, string name, string subject, int current, int rating)
		{
			foreach(var student in Students)
			{
				if(student.Id == id)
				{
					student.Name = name;
					student.Subject = subject;
					student.CurrentPoint = current;
					student.RatingPoint = rating;
				}
			}
		}
	}

	public interface IStudentsRepository
	{
		public void Add(Student student);
		public List<Student> GetStudents();
		public Student TryGetById(Guid id);
		public void EditStudent(Guid id, string name, string subject, int current, int rating);

	}
}
