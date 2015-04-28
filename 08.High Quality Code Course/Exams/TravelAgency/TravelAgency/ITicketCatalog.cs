namespace TravelAgency
{
    using System;

    /// <summary>
    /// Defines a catalog holding tickets (air tickets, bus tickets and train tickets)
    /// and a set of commands to add / delete / search tickets.
    /// </summary>
    public interface ITicketCatalog
    {
        /// <summary>
        /// Adds an air ticket to the catalog by given flight number, departure and arrival
        /// airports (from, to), airline, departure date and time and price.
        /// </summary>
        /// <param name="flightNumber">The number of flight</param>
        /// <param name="from">The start destination</param>
        /// <param name="to">The end destination</param>
        /// <param name="airline">The name of airline company</param>
        /// <param name="dateTime">The departure date and time for the flight</param>
        /// <param name="price">The price of the ticket</param>
        /// <returns>A message "Ticket added" in case of success or "Duplicate ticket"
        /// if such flight already exists.</returns>
        string AddAirTicket(string flightNumber, string from, string to, string airline, DateTime dateTime, decimal price);

        string DeleteAirTicket(string flightNumber);

        string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentPrice);

        string DeleteTrainTicket(string from, string to, DateTime dateTime);

        string AddBusTicket(string from, string to, string travelCompany, DateTime dateTime, decimal price);

        /// <summary>
        /// Deletes a bus ticket from the catalog by given departure town (from), arrival town (to),
        /// travel company and date and time.
        /// </summary>
        /// <param name="from">The start destination</param>
        /// <param name="to">The end destination</param>
        /// <param name="travelCompany">The travel company (bus operator)</param>
        /// <param name="dateTime">The departure date and time for the bus</param>
        /// <returns>A message "Ticket deleted" in case of success or "Ticket does not exist"
        /// if the ticket could not be found in the catalog.</returns>
        string DeleteBusTicket(string from, string to, string travelCompany, DateTime dateTime);

        /// <summary>
        /// Finds all tickets from the catalog by given departure town/airport (from) and arrival town/airport (to).
        /// </summary>
        /// <param name="from">The start destination (airport)</param>
        /// <param name="to">The end destination (airport)</param>
        /// <returns>All matching tickets on a single line, separated by spaces, in format
        /// [date and time; type; price], ordered by date and time (as first criteria, ascending),
        /// then by type (as second criteria, ascending) and then by price (as third criteria, ascending).
        /// If no tickets are found by the specified criteria, returns "Not found".</returns>
        string FindTickets(string from, string to);

        /// <summary>
        /// Finds all tickets from the catalog by given departure time interval (inclusive range).
        /// </summary>
        /// <param name="startDateTime">The start date and time (inclisive)</param>
        /// <param name="endDateTime">The end date and time (inclusive)</param>
        /// <returns>All matching tickets on a single line, separated by spaces, in format
        /// [date and time; type; price], ordered by date and time (as first criteria, ascending),
        /// then by type (as second criteria, ascending) and then by price (as third criteria, ascending).
        /// If no tickets are found by the specified criteria, returns "Not found".</returns>
        string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime);

        int GetTicketsCount(TicketType type);
    }
}
