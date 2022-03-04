using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    [SerializeField] private PuzzleMoveablePieces[] moveablePieces;
    [SerializeField] private PuzzleGridSlot[] gridSlots;

    [SerializeField] private PuzzleMoveablePieces pieceSelected;

    [SerializeField] private PuzzleCondition[] conditions;

    public void SetSelectedPiece(PuzzleMoveablePieces pieceSelected)
    {
        if(pieceSelected.GetIsSelected())
        {
            this.pieceSelected = pieceSelected;
        }
        else
        {
            this.pieceSelected = null;
        }

        foreach (PuzzleMoveablePieces piece in moveablePieces)
        {
            if(piece != pieceSelected)
            {
                piece.SetHighlight(false);
            }
        }
    }

    public PuzzleMoveablePieces GetSelectedPiece()
    {
        return pieceSelected;
    }

    public void PlayMade()
    {
        foreach (PuzzleCondition condition in conditions)
        {
            if(!condition.ConditionMet())
            {
                return;
            }
        }

        //Acabar jogo.
        Debug.Log("O jogo acabou");
    }
}
