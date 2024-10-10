using UnityEngine;
using System;

namespace Storage
{
    public class Reader
    {
        public static string ReadData(string name)
        {
            if (name == null)
                throw new ArgumentException("Cannot enter null as value");

            string data = PlayerPrefs.GetString(name, null);
            if (string.IsNullOrEmpty(data))
                throw new ArgumentException("Value passed has no records");
            return data;
        }
    }
}