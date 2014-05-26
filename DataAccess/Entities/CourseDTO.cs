﻿using System;
using DataAccess.Entities.Interfaces;
using DataAccess.Helper;

namespace DataAccess.Entities
{
	public class CourseDTO : IIdentityObject
	{
		public CourseDTO(string tripId, string currencyOne, string currencyTwo, double course)
			: this(
				MongoIdentityHelper.GetComplexIdentity(tripId, currencyOne, currencyTwo),
				tripId,
				currencyOne,
				currencyTwo,
				course)
		{
		}

		public CourseDTO(string id, string tripId, string currencyOne, string currencyTwo, double course)
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

			TripId = tripId;
			CurrencyOne = currencyOne;
			CurrencyTwo = currencyTwo;
			Course = course;

			Id = MongoIdentityHelper.GetComplexIdentity(tripId, currencyOne, currencyTwo);
		}

		public string TripId { get; set; }

		public double Course { get; set; }

		public string CurrencyOne { get; set; }

		public string CurrencyTwo { get; set; }

		public string Id { get; set; }
	}
}