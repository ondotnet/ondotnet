﻿using System;

namespace backenddomain
{
    public class Samurai
    {
        public Samurai() 
        {
            Quotes = new List<Quote>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Quote> Quotes { get; set; }
        public Clan Clan { get; set; }
    }
}
