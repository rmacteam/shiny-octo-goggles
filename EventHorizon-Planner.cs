using System;
using System.Collections.Generic;

public class Event
{
    public int Id;
    public string Name;
    public DateTime Date;
    public List<string> Attendees;
    public int TicketsAvailable;
    public Event(int id, string name, DateTime date, int tickets)
    {
        Id = id; Name = name; Date = date; Attendees = new List<string>(); TicketsAvailable = tickets;
    }
    public bool BookTicket(string attendee)
    {
        if (TicketsAvailable > 0)
        {
            Attendees.Add(attendee);
            TicketsAvailable--;
            return true;
        }
        return false;
    }
}

public class EventHorizonPlanner
{
    private List<Event> events = new List<Event>();
    public void AddEvent(string name, DateTime date, int tickets)
    {
        events.Add(new Event(events.Count+1, name, date, tickets));
    }
    public void BookTicket(int eventId, string attendee)
    {
        foreach (var e in events)
            if (e.Id == eventId)
                e.BookTicket(attendee);
    }
    public void ShowEvents()
    {
        foreach (var e in events)
        {
            Console.WriteLine($"{e.Id}. {e.Name} on {e.Date.ToShortDateString()} ({e.TicketsAvailable} tickets left)");
            Console.WriteLine($"Attendees: {string.Join(",", e.Attendees)}");
        }
    }
    public static void Main()
    {
        var planner = new EventHorizonPlanner();
        planner.AddEvent("React Meetup", DateTime.Now.AddDays(10), 100);
        planner.AddEvent("GoLang Conference", DateTime.Now.AddDays(30), 200);
        planner.BookTicket(1, "Zarokin");
        planner.BookTicket(2, "Alice");
        planner.ShowEvents();
    }
}