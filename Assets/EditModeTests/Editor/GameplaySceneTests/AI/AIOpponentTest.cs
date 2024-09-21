using System.Collections;
using System.Collections.Generic;
using Gameplay.AI;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AIOpponentTest
{
    [Test]
    public void NullTest()
    {
        AIOpponent aiOpponent = new AIOpponent();
        Assert.IsNotNull(aiOpponent.computeMove());
    }

    [Test]
    public void ValidReturnType()
    {
        AIOpponent aiOpponent = new AIOpponent();
        Assert.True(aiOpponent.computeMove().GetType().IsSubclassOf(typeof(Choice)));
    }
}
