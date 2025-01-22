using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private int minSide;
    [SerializeField] private int maxSide;
    public int Roll()
    {
        return Random.Range(minSide, maxSide + 1);
    }
}
