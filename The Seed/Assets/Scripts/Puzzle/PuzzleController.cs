using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    [SerializeField] private PuzzleMoveablePieces[] moveablePieces;
    [SerializeField] private PuzzleGridSlot[] gridSlots;

    [SerializeField] private PuzzleMoveablePieces pieceSelected;

    [SerializeField] private PuzzleCondition[] conditions;

    [SerializeField] private bool isCompleted;

    private EnablePuzzle controller;

    public void SetSelectedPiece(PuzzleMoveablePieces pieceSelected)
    {
        if(pieceSelected == null)
        {
            this.pieceSelected = null;
            return;
        }

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
        isCompleted = true;
        controller.OpenDoors();
        Debug.Log("O jogo acabou");
    }

    public bool GetIsCompleted()
    {
        return isCompleted;
    }

    public void RemovingPiece(PuzzleGridSlot slot)
    {
        slot.PlacePiece(pieceSelected);
    }

    public void SetController(EnablePuzzle p) {
        this.controller = p;
    }

}
