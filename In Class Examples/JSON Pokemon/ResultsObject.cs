﻿namespace JSON_Pokemon
{
    public class ResultsObject
    {
        public string name { get; set; }

        public string url { get; set; }

        public override string ToString()
        {
            return name.ToUpper();
        }
    }
}