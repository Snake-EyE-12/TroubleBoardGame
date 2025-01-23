using UnityEngine;
using UnityEngine.UI;

public class TurnRenderer : MonoBehaviour
{
    [SerializeField] private Image image;
    public void SetColor(Color color)
    {
        image.color = color;
    }
}