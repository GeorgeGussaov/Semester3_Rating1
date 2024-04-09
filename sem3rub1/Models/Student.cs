using System;
using System.ComponentModel.DataAnnotations;

namespace sem3rub1.Models
{
	public class Student
	{
		[Required(ErrorMessage ="Errorr")]
		public Guid Id {get; set;}
		[Required(ErrorMessage ="Укажите ФИО")]
		[StringLength(25, MinimumLength = 5, ErrorMessage = "Фио должно быть от 5 до 25 символов")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Укажите Предмет")]
		[StringLength(20, MinimumLength = 1, ErrorMessage = "до 20 символов")]
		public string Subject { get; set; }
		[Required(ErrorMessage ="Укажите текущие баллы")]
		[Range(0,20, ErrorMessage ="не больше 20 баллов")]
		public int CurrentPoint { get; set; }
		[Required(ErrorMessage = "Укажите рейтинговые баллы")]
		[Range(0, 15, ErrorMessage = "не больше 15 баллов")]
		public int RatingPoint { get; set; }
		public Student(string name, string subject, int currentPoint, int ratintPoint)
		{
			Name = name;
			Subject = subject;
			CurrentPoint = currentPoint;
			RatingPoint = ratintPoint;
			Id = Guid.NewGuid();
		}
		public Student() {
			Id = Guid.NewGuid();
		}
	}
}
