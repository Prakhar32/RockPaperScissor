using Gameplay.RulesComposition;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    public const string NoRuleError = "Incorrect composition";

    public const string NullArguementError = "Cannot pass null arguements";

    public const string InvalidTypeArguement = "Cannot pass invalid type. Please pass type derived from Choice class.";

    public const string DrawMessage = "Both are same. Nothing Happens.";

    public const int numberOfOptions = 5;

    public const string spriteAtlusBaseName = "AllSpritesWoNames";

    public const int TimeLimit = 3;

    public const float WaitTime = 1.5f;

    public const string ScoreText = "Score : ";

    public const string TopScoreText = "Top Score : ";

    public const string PlayerPrefsScoreText = "Top Score"; 
}

public class CommonStructures
{
    public static Type[] Moves = new Type[] { typeof(Rock), typeof(Paper), typeof(Scissor), typeof(Lizard), typeof(Spock) };

    public static Dictionary<Type, int> SpriteAtlusIndexMapper = new Dictionary<Type, int>
    {
        {typeof(Rock),  0},
        {typeof(Paper), 1},
        {typeof(Scissor), 2},
        {typeof(Lizard), 3},
        {typeof(Spock), 4},
    };

    public static Dictionary<Type, String> FlavourText = new Dictionary<Type, String>
    {
        {typeof(ScissorPaperRule), "Scissors cut Paper"},
        {typeof(ScissorRockRule), "Rock crushes Scissors" },
        {typeof(ScissorLizardRule), "Scissor decapitates Lizard" },
        {typeof(ScissorSpockRule), "Spock smashes Lizard" },
        {typeof(RockPaperRule), "Paper covers Rock" },
        {typeof(RockLizardRule), "Rock crushes Lizard" },
        {typeof(RockSpockRule), "Spock varoupizes Rock" },
        {typeof(PaperLizardRule), "Lizard eats Paper" },
        {typeof(PaperSpockRule), "Paper disproves Spock" },
        {typeof(SpockLizardRule), "Lizard poisons Spock" },
    };
}
