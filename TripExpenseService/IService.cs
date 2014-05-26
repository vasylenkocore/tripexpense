using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Entities.Implementation;

namespace TripExpenseService
{
	[ServiceContract]
	public interface IService
	{
		[WebInvoke(Method = "PUT", UriTemplate = "users")]
		[OperationContract]
		void AddOrUpdateUser(User user);

		[WebInvoke(Method = "PUT", UriTemplate = "trips")]
		[OperationContract]
		void AddOrUpdateTrip(Trip trip);

		[WebInvoke(Method = "PUT", UriTemplate = "trips/{tripId}/expenses")]
		[OperationContract]
		void AddOrUpdateExpense(Expense expense, string tripId);

		[WebInvoke(Method = "PUT", UriTemplate = "trips/{tripId}/courses")]
		[OperationContract]
		void AddOrUpdateCourse(Course course, string tripId);

		[WebInvoke(Method = "PUT", UriTemplate = "expenses/{expenseId}/payifos")]
		[OperationContract]
		void AddOrUpdatePayInfo(PayInfo payInfo, string expenseId);

		[WebInvoke(Method = "GET", UriTemplate = "trips/{userId}")]
		[OperationContract]
		List<Trip> GetTrips(string userId);

		[WebInvoke(Method = "GET", UriTemplate = "expenses/{tripId}")]
		[OperationContract]
		List<Expense> GetExpenses(string tripId);

		[WebInvoke(Method = "GET", UriTemplate = "courses/{tripId}")]
		[OperationContract]
		List<Course> GetCourses(string tripId);
	}
}