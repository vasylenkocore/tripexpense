using System.Collections.Generic;
using DataAccess.Entities;
using Entities.Implementation;

namespace Business.Managers.Implementation
{
	public class CourseManager : BaseManager
	{
		public void AddOrUpdate(Course course, string tripId)
		{
			CourseDTO courseDTO = EntityConverter.ConvertCourse(course);

			DataAccessClient.AddOrUpdate(courseDTO);
		}

		public List<Course> GetCourses(string tripId)
		{
			throw new System.NotImplementedException();
		}
	}
}