using System;
using UnityEngine;

namespace Storage
{
    public class Writer
    {
        public static void WriteData(string key, string value)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException();
            PlayerPrefs.SetString(key, value);
        }
    }
}