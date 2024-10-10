using NUnit.Framework;
using Storage;
using System;
using UnityEngine;

public class ReaderTest
{
    [Test]
    public void NullArguementLoading()
    {
        Assert.Throws(typeof(ArgumentException), () => Reader.ReadData(null));
    }

    [Test]
    public void InvalidLoading()
    {
        Assert.Throws(typeof(ArgumentException), () => Reader.ReadData("name"));
    }
}
