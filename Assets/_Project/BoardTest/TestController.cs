using UnityEngine;

public class TestController : MonoBehaviour
{
    [SerializeField] private BoardCreator boardCreator;
    [SerializeField] private Dice dice;

	private int diceRoll;
	
	private void Start()
	{
		boardCreator.PlayerCount = MainMenuManager.playerCount;
		boardCreator.Build();

		PassTurn();
	}

	public void PassTurn()
	{
		boardCreator.ChangeTurn();
		boardCreator.SetClickablePegs();
	}
    public void OnButtonClicked()
    {
		if (boardCreator.diceRollable)
		{
			diceRoll = dice.Roll();
			boardCreator.AdvancementAmount = diceRoll;
			Debug.Log("Dice Roll: " + diceRoll);
			boardCreator.diceRollable = false;
		}
		
	}
}