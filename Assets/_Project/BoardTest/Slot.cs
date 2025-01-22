using UnityEngine;

public class Slot : MonoBehaviour
{
    private Peg peg;
    public bool HasPiece => peg != null;
    public void SetPeg(Peg peg)
    {
        if(peg != null && peg.slotReference != null) peg.slotReference.Clear();
        this.peg = peg;
        peg.slotReference = this;
        peg.Move(transform.position);
    }

    public void SendPegHome()
    {
        peg.boardReference.ReturnPieceHome(peg);
        Clear();
    }

    public Peg GetPeg()
    {
        return peg;
    }

    public void Clear()
    {
        peg = null;
    }
}

public enum PlayerColors
{
    Blue,
    Red,
    Green,
    Yellow
}