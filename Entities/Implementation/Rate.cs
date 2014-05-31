using System;
using System.Runtime.Serialization;

namespace Entities.Implementation
{
	[DataContract]
	public class Rate : IEntity
	{
		public Rate(string currencyOne, string currencyTwo, double rate)
		{
			if (currencyOne == null)
			{
				throw new ArgumentNullException("currencyOne");
			}

			if (currencyTwo == null)
			{
				throw new ArgumentNullException("currencyTwo");
			}

			CurrencyOne = currencyOne;
			CurrencyTwo = currencyTwo;
			RateAmount = rate;
		}

		public Rate(string id, string tripId, string currencyOne, string currencyTwo, double rate)
			: this(currencyOne, currencyTwo, rate)
		{
			if (id == null)
			{
				throw new ArgumentNullException("id");
			}

			if (tripId == null)
			{
				throw new ArgumentNullException("tripId");
			}

			Id = id;
			TripId = tripId;
		}

		[DataMember]
		public string Id { get; set; }

		[DataMember]
		public string TripId { get; set; }
		
		[DataMember]
		public double RateAmount { get; set; }

		[DataMember]
		public string CurrencyOne { get; set; }

		[DataMember]
		public string CurrencyTwo { get; set; }
	}
}