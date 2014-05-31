using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using Entities.Implementation;

namespace Business.Managers.Implementation
{
	public class RateManager : BaseManager
	{
		public Rate AddOrUpdate(Rate rate, string tripId)
		{
			RateDTO rateDTO = EntityConverter.Convert(rate, tripId);

			RateDTO savedRate = DataAccessClient.AddOrUpdate(rateDTO);

			return EntityConverter.Convert(savedRate);
		}

		public IEnumerable<Rate> GetRates(string tripId)
		{
			IEnumerable<RateDTO> courses = DataAccessClient.GetRates(tripId);

			return courses.Select(t => EntityConverter.Convert(t));
		}

		public Rate GetCourse(string id)
		{
			Rate rate = null;

			RateDTO rateDTO = DataAccessClient.Get<RateDTO>(id);

			if (rateDTO != null)
			{
				rate = EntityConverter.Convert(rateDTO);
			}

			return rate;
		}

		public void Delete(Rate rate)
		{
			if (string.IsNullOrEmpty(rate.Id))
			{
				throw new ArgumentNullException("rate.Id");
			}

			DataAccessClient.Delete<RateDTO>(rate.Id);
		}
	}
}