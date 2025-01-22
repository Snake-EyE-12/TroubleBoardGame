using System;
using UnityEngine;

public class ColorPingPong : MonoBehaviour
{
    [SerializeField] private Color colorStart;
    [SerializeField] private Color colorEnd;
    [SerializeField] private float duration = 1f;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        spriteRenderer.color = Color.Lerp(colorStart, colorEnd, t);
    }
}
