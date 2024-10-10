using NUnit.Framework;
using Storage;
using UnityEngine;

public class ReadWriteIntegationTest
{
    string testKey = "Test";

    [SetUp]
    public void Setup()
    {
        PlayerPrefs.DeleteKey(testKey);
    }

    [Test]
    public void DataLoadingCorrectly()
    {
        Writer.WriteData("Test", "1");
        Assert.AreEqual("1", Reader.ReadData("Test"));
    }

    [TearDown]
    public void TearDown()
    {
        PlayerPrefs.DeleteKey(testKey);
    }   
}
