using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PuzzleMoveablePieces : PuzzleGenericPiece, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] private PuzzleController puzzleController;
    [SerializeField] private Transform queueGridSlot;
    [SerializeField] private PuzzleGridSlot gridSlot;

    [SerializeField] private Direction secondDirection;

    private Image image;

    [SerializeField] private bool isMoveable = true;

    [SerializeField] private bool hasHighlight;

    [SerializeField] private bool isSelected;
    [SerializeField] private bool isPlaced;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!isPlaced)
        {
            if (isMoveable)
            {
                SetHighlight();
                puzzleController.SetSelectedPiece(this);
            }
        }
        else
        {
            if(puzzleController.GetSelectedPiece() != null)
            {
                puzzleController.RemovingPiece(gridSlot);
            }

            gridSlot = null;
            transform.position = queueGridSlot.position;
            isPlaced = false;
        }
    }

    public void SetHighlight()
    {
        isSelected = !isSelected;

        if(isSelected)
        {
            image.color = new Color32(49,90,130, 255);
        }
        else
        {
            image.color = Color.white;
        }
    }

    public void SetHighlight(bool isSelected)
    {
        this.isSelected = isSelected;

        if (isSelected)
        {
            image.color = new Color32(49, 90, 130, 255);
        }
        else
        {
            image.color = Color.white;
        }
    }

    public bool GetIsSelected()
    {
        return isSelected;
    }

    public void SetPlaced(bool isPlaced)
    {
        this.isPlaced = isPlaced;
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void SetGridSlot(PuzzleGridSlot slot)
    {
        this.gridSlot = slot;
    }
}
