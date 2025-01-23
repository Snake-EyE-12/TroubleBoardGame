using UnityEngine;

public class TestRoll : MonoBehaviour
{
    [SerializeField] private Dice dice;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            dice.Roll();
        }
    }
}
