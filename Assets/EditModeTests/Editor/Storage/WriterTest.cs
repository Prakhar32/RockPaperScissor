using NUnit.Framework;
using Storage;
using System;
using UnityEngine;

public class WriterTest
{
    private string initialValue;

    [SetUp]
    public void Setup()
    {
        initialValue = PlayerPrefs.GetString("Test");
    }

    [Test]
    public void NullKeyWriting()
    {
        Assert.Throws(typeof(ArgumentException), () => Writer.WriteData(null, ""));
    }

    [Test]
    public void EmptyKeyWriting()
    {
        Assert.Throws(typeof(ArgumentException), () => Writer.WriteData("", ""));
    }

    [Test]
    public void WriteSuccessful()
    {
        Assert.DoesNotThrow(() => Writer.WriteData("Test", "1"));
    }

    [TearDown]
    public void Teardown()
    {
        PlayerPrefs.SetString("Test", initialValue);
    }
}
