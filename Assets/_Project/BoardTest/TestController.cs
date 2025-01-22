using UnityEngine;

public class TestController : MonoBehaviour
{
    [SerializeField] private BoardCreator boardCreator;
    [SerializeField] private Dice dice;

    private void Start()
    {
        boardCreator.PlayerCount = 4;
        boardCreator.Build();
    }
    private int diceRoll;

    private void Update()
    {
        
    }

    public void OnButtonClicked()
    {
		diceRoll = dice.Roll();
		boardCreator.AdvancementAmount = diceRoll;
		Debug.Log("Dice Roll: " + diceRoll);
	}
}
