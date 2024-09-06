using System;

namespace Gameplay.AI
{
    public class AIOpponent 
    {
        public Type computeMove()
        {
            Type[] moves = CommonStructures.Moves;
            int index = UnityEngine.Random.Range(0, moves.Length);
            return moves[index];
        }
    }
}