using System;
using UnityEngine;

public class Peg : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    public BoardCreator boardReference { get; set; }
    public Slot slotReference { get; set; }

    private void Start()
    {
        spriteRenderer.color = Utils.PlayerColorToRGB(color);
    }

    public PlayerColors color { get; set; }


    private bool Clickable => true;
    public void OnClick()
    {
        if (Clickable)
        {
            bool success = boardReference.AdvancePegPosition(this);
        }
    }
}