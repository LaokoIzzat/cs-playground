using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting
{
    public sealed class RestaurantFilter
    {
        // filter out all restaurants where for any table Id within any booking for a restaurant,
        // its booking date falls in a closure period for that restaurant.

        #region Foreach Filter
        public IEnumerable<Restaurant> ForeachFilter(IEnumerable<Restaurant> restaurants)
        {
            var restaurantList = restaurants.ToList();

            var tableIdToBookingDateDict = new Dictionary<int, DateTime>();
            {
                tableIdToBookingDateDict.Add(1, DateTime.Now.AddDays(1));
                tableIdToBookingDateDict.Add(2, DateTime.Now.AddDays(2));
                tableIdToBookingDateDict.Add(3, DateTime.Now.AddDays(3));
            }

            var filteredRestaurantList = new List<Restaurant>();

            foreach (var restaurant in restaurants)
            {
                var bookingInClosurePeriod = false;
                if (restaurant.ClosurePeriods == null)
                {
                    filteredRestaurantList.Add(restaurant);
                    continue;
                }
                foreach (var booking in restaurant.Bookings)
                {
                    foreach (var availableTableId in booking.AvailableTableIds)
                    {
                        tableIdToBookingDateDict.TryGetValue(availableTableId, out var bookingDate);
                        if (!restaurant.ClosurePeriods.Any(cp => cp.FromDate <= bookingDate && cp.ToDate >= bookingDate)) continue;
                        bookingInClosurePeriod = true;
                        break;
                    }
                }
                if (!bookingInClosurePeriod) filteredRestaurantList.Add((restaurant));
            }

            return filteredRestaurantList;
        }
        #endregion

        #region LINQ Filter
        public IEnumerable<Restaurant> LinqFilter(IEnumerable<Restaurant> restaurants)
        {
            var tableIdToBookingDateDict = new Dictionary<int, DateTime>()
            {
                { 1, DateTime.Now.AddDays(1) },
                { 2, DateTime.Now.AddDays(2) }
            };

            bool IsBookingInClosurePeriod(Restaurant restaurant) =>
              restaurant.Bookings.SelectMany(x => x.AvailableTableIds).Any(availableTableId =>
              {
                  tableIdToBookingDateDict.TryGetValue(availableTableId, out var bookingDate);
                  return restaurant.ClosurePeriods.Any(cp => cp.FromDate <= bookingDate && cp.ToDate >= bookingDate);
              });

            var filteredList =  restaurants.Where(x => x.ClosurePeriods == null || !IsBookingInClosurePeriod(x));

            return filteredList;
        }

        //public IEnumerable<Restaurant> Filter(IEnumerable<Restaurant> restaurants)
        //{
        //    var tableIdToBookingDateDict = new Dictionary<int, DateTime>();
        //    {
        //        { 1, DateTime.Now.AddDays(1) },
        //        { 2, DateTime.Now.AddDays(2) },
        //        { 3, DateTime.Now.AddDays(3) },
        //    };

        //            bool IsBookingInClosurePeriod(Restaurant restaurant) =>
        //                restaurant.Bookings.SelectMany(x => x.AvailableTableIds).Any(availableTableId =>
        //                {
        //                tableIdToBookingDateDict.TryGetValue(availableTableId, out var bookingDate);
        //                return !restaurant.ClosurePeriods.Any(cp => cp.FromDate <= bookingDate && cp.ToDate >= bookingDate));
        //        });

        //    foreach (var restaurant in restaurants)
        //    {
        //        if (restaurant.ClosurePeriods == null || !IsBookingInClosurePeriod(restaurant))
        //        {
        //            yield return restaurant;
        //        }
        //    }
        //}
        #endregion

    }
}
