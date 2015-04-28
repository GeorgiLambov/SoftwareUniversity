namespace TheatreSystem
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines a repository holding theatre, performance
    /// and a set of commands to addtheatre / listtheatres / addperformance/ listallperformances/ 
    /// listperformances.
    /// </summary>
    public interface IPerformanceDatabase
    {
        /// <summary>
        /// Adds an theatre to the repository by given theatre name
        /// </summary>
        /// <param name="theatreName">The name of theatre.</param>
        /// <returns>A message "Theatre added" in case of success or DuplicateTheatreException
        /// if theatre already exists.</returns>
        void AddTheatre(string theatreName);

        /// <summary>
        /// List all theatres from the repository.
        /// </summary>
        /// <returns>All theatres on a single line, separated by comma, in format
        /// Theatre name, Theatre name
        /// If theatre are not found, returns "No theatres".</returns>
        IEnumerable<string> ListTheatres();

        /// <summary>
        /// Adds an  performance to the repository by given theatre name, performance title,
        /// start time, duration and price
        /// </summary>
        /// <param name="theatreName">The name of theatre.</param>
        /// <param name="performanceTitle">The title of performance.</param>
        /// <param name="startDateTime">The date and time  of performance.</param>
        /// <param name="duration">The duration of performance.</param>
        /// <param name="price">The price of performance.</param>
        /// <returns>A message "Performance added" in case of success or TheatreNotFoundException
        /// if theatre not exists.</returns>
        void AddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price);

        /// <summary>
        /// List all performances from the repository.
        /// </summary>
        /// <returns>All performances if format
        /// performance name, theatre name,  performance date
        /// on a single line, separated by comma and brackets
        /// If theatre are not found, returns "No performances".</returns>
        IEnumerable<Performance> ListAllPerformances();

        /// <summary>
        /// List all performances from the repository of current theatre.
        /// </summary>
        /// <param name="theatreName">The name of theatre.</param>
        /// <returns>All performances form current theatre in format
        /// performance name, performance date
        ///  on a single line, separated by comma and brackets
        /// If theatre are not found, returns "No performances".</returns>
        IEnumerable<Performance> ListPerformances(string theatreName);
    }
}