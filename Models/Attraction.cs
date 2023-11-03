﻿namespace GoTravnikApi.Models
{
    public class Attraction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public Rating Rating { get; set; }
    }
}
