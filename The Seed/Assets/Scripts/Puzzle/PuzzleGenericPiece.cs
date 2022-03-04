using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGenericPiece : MonoBehaviour
{
    public enum Direction
    {
        North,
        NorthEast,
        East,
        SouthEast,
        South,
        SouthWest,
        West,
        NorthWest
    }

    [SerializeField] protected Direction pieceFirstDirection;
}
