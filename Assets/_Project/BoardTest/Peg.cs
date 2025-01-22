using System;
using UnityEngine;

public class Peg : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    public BoardCreator boardReference { get; set; }
    public Slot slotReference { get; set; }
    [SerializeField] private Destinator destinator;

    private void Start()
    {
        spriteRenderer.color = Utils.PlayerColorToRGB(color);
    }

    public PlayerColors color { get; set; }


	public bool clickable = false;
    public void OnClick()
    {
        if (clickable && boardReference.diceRollable == false)
        {
            bool success = boardReference.AdvancePegPosition(this);
        }
    }

    public void Move(Vector3 newPosition)
    {
        destinator.Move(newPosition);
    }
}