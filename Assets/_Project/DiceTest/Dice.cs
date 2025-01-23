using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{
    [SerializeField] private int minSide;
    [SerializeField] private int maxSide;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private float rollDuration;
    [SerializeField] private AnimationCurve changeCurve;
    [SerializeField] private GameObject highlight;
    private bool rolling;
    private int rolledNumber;
    public int Roll()
    {
        rolledNumber = GetRandomInRange();
        Debug.Log("RolledNumber: " + rolledNumber);
        rolling = true;
        highlight.SetActive(false);
        return rolledNumber;
    }

    private int GetRandomInRange()
    {
        return Random.Range(minSide, maxSide + 1);
    }

    private float elapsedTime;
    private float lastUpdateTime;
    [SerializeField] private float startingUpdateRate;
    [SerializeField] private float endingUpdateRate;
    private void Update()
    {
        if (!rolling) return;
        elapsedTime += Time.deltaTime;
        if (elapsedTime > rollDuration)
        {
            FinishRoll();
            return;
        }

        float t = elapsedTime / rollDuration;
        float value = changeCurve.Evaluate(t);
        float updateRate = Mathf.Lerp(startingUpdateRate, endingUpdateRate, value); // Start fast (10 updates per second), slow down (1 update per second)

        
        // The value to decide when to change the dice face based on updateRate
        if (elapsedTime > lastUpdateTime + updateRate)
        {
            lastUpdateTime = elapsedTime; // Update the timer based on the adjusted update rate
            SetSprite(GetRandomInRange());  // Change the sprite to a random face
        }
    }

    private void FinishRoll()
    {
        SetSprite(rolledNumber);
        rolling = false;
        elapsedTime = 0;
        lastUpdateTime = 0;
        highlight.SetActive(true);
    }

    private void SetSprite(int number)
    {
        spriteRenderer.sprite = sprites[number - 1];
    }
    
}
