using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace oop3
{
    public enum EventType{Coffee, Lecture, Concert, StudySession}
    public class Event
    {
        public Event(string name, EventType eventType, int startTime, int endTime)
        {
            Name= name;
            EventType = eventType;
            StartTime = startTime;
            EndTime = endTime;
        }
    public string Name { get; set; }
    public EventType EventType { get; set; }
    public int StartTime { get; set; }
    public int EndTime { get; set; }
    }
}

