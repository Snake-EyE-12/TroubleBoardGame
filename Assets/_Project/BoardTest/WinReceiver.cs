using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinReceiver : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text textAsset;
    [SerializeField] private string winMessage = "You Win!";


    private void Start()
    {
        image.color = Utils.PlayerColorToRGB(WinSetter.winnerColor);
        textAsset.text = WinSetter.winnerColor.ToString() + " " + winMessage;
    }
}
