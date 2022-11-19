using ConsoleTesting;
using DataStructures.SinglyLinkedList;

#region SLL Calls
/*
SinglyLinkedList<int> list = new SinglyLinkedList<int>();
list.InsertAtFront(10);
list.InsertAtFront(10);
list.InsertAtFront(10);
list.InsertAtBack(20);
list.InsertAtBack(30);
list.InsertAtBack(40);
list.Print();
list.RemoveFirstNode();
list.RemoveFirstNode();
list.Print();


Console.WriteLine("------------------------");
// able to use foreach and linq on the SLL because class implements IEnumerable
foreach(int i in list) { Console.WriteLine($"num: {i}"); }
*/
#endregion

#region Exceptions

//Something.DoSomething(1);

#endregion

#region LINQ Examples

var restaurants = new List<Restaurant>()
{
    new Restaurant()
    {
        Name = "Restaurant 1",
        Bookings = new List<Booking>()
        {
            new Booking()
            {
                AvailableTableIds = new List<int> { 1 }
            }
        },
        ClosurePeriods = new List<ClosurePeriod>()
        {
            new ClosurePeriod()
            {
                FromDate = DateTime.Now,
                ToDate = DateTime.Now.AddDays(2)
            }
        }
    },
    new Restaurant()
    {
        Name = "Restaurant 2",
        Bookings = new List<Booking>()
        {
            new Booking()
            {
                AvailableTableIds = new List<int> { 1, 2 }
            }
        }
    },
    new Restaurant()
    {
        Name = "Restaurant 3",
        Bookings = new List<Booking>()
        {
            new Booking()
            {
                AvailableTableIds = new List<int> { 1, 2 }
            }
        },
        ClosurePeriods = new List<ClosurePeriod>()
        {
            new ClosurePeriod()
            {
                FromDate = DateTime.Now.AddDays(4),
                ToDate = DateTime.Now.AddDays(7)
            }
        }
    },
};

var restaurantFilter = new RestaurantFilter();

restaurantFilter.LinqFilter(restaurants);

#endregion