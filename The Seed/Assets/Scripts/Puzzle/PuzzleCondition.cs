using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCondition : MonoBehaviour
{
    [SerializeField] private PuzzleGridSlot gridSlot;
    [SerializeField] private PuzzleMoveablePieces piece;

    public bool ConditionMet()
    {
        if(gridSlot.GetPiece() == null)
        {
            return false;
        }

        if(gridSlot.GetPiece() == piece)
        {
            return true;
        }

        return false;
    }
}
