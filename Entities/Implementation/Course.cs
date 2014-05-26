using System;
using System.Runtime.Serialization;

namespace Entities.Implementation
{
	[DataContract]
	public class Course : IEntity
	{
		public Course(string id, string tripId, string currencyOne, string currencyTwo, double course)
		{
			if (tripId == null)
			{
				throw new ArgumentNullException("tripId");
			}

			if (currencyOne == null)
			{
				throw new ArgumentNullException("currencyOne");
			}

			if (currencyTwo == null)
			{
				throw new ArgumentNullException("currencyTwo");
			}

			Id = id;
			TripId = tripId;
			CurrencyOne = currencyOne;
			CurrencyTwo = currencyTwo;
			CourseAmount = course;
		}

		[DataMember]
		public string Id { get; set; }

		[DataMember]
		public string TripId { get; set; }
		
		[DataMember]
		public double CourseAmount { get; set; }

		[DataMember]
		public string CurrencyOne { get; set; }

		[DataMember]
		public string CurrencyTwo { get; set; }
	}
}