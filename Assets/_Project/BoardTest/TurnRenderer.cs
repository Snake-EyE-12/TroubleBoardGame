using UnityEngine;
using UnityEngine.UI;

public class TurnRenderer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    public void SetColor(Color color)
    {
		sprite.color = color;
    }
}