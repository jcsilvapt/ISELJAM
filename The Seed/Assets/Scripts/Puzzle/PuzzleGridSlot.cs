using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleGridSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private PuzzleController puzzleController;

    [SerializeField] private int posX, posY;

    [SerializeField] private bool isOccupied;
    [SerializeField] private PuzzleMoveablePieces placedPiece;

    [SerializeField] private GameObject highlight;

    private void Start()
    {
        highlight = transform.GetChild(0).gameObject;
    }

    public int GetPosX()
    {
        return posX;
    }

    public int GetPosY()
    {
        return posY;
    }

    public void RemovePiece()
    {
        placedPiece = null;
    }

    public PuzzleGenericPiece GetPiece()
    {
        return placedPiece;
    }

    public void ChangeToOccupied()
    {
        isOccupied = true;
    }

    public void ChangeToNotOccupied()
    {
        isOccupied = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!isOccupied)
        {
            highlight.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isOccupied)
        {
            highlight.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(isOccupied)
        {
            return;
        }

        if(puzzleController.GetSelectedPiece() != null)
        {
            placedPiece = puzzleController.GetSelectedPiece();
            placedPiece.SetPlaced(true);
            placedPiece.SetPosition(transform.position);
            placedPiece.SetHighlight(false);
            placedPiece.SetGridSlot(this);

            puzzleController.SetSelectedPiece(null);
            puzzleController.PlayMade();
        }
    }

    public void PlacePiece(PuzzleMoveablePieces piece)
    {
        placedPiece = piece;

        piece.SetPlaced(true);
        piece.SetPosition(transform.position);
        piece.SetHighlight(false);
        piece.SetGridSlot(this);

        puzzleController.SetSelectedPiece(null);
        puzzleController.PlayMade();
    }
}
