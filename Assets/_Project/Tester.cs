using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;

public class Tester : MonoBehaviour
{
    private void RunTests()
    {
        TestColorToRGBCode();
        TestPlayerCount();
        TestMainMenuSelection();
	}

	private void TestColorToRGBCode()
	{
		// Arrange
		Color expected = Color.green;

		// Act
		Color actual = Utils.PlayerColorToRGB(PlayerColors.Green);

		// Assert
		Assert.AreEqual(expected, actual);
	}

	private void TestPlayerCount()
    {
        // Create new board
        BoardCreator board = new BoardCreator();

        // Choose random range from 2-4 players for game
        board.PlayerCount = Random.Range(2, 5);

        // Create the board after PlayerCount is chosen
        board.Build();
    }

    private void TestMainMenuSelection()
    {
        // Create new menu manager
        MainMenuManager menuManager = new MainMenuManager();

        // Simulate button presses: start, back to main menu, start again
        menuManager.StartGameButton();
		menuManager.MainMenuBackBtn();
		menuManager.StartGameButton();

		// Choose random range from 2-4 players for game
		menuManager.PlayerCountSelection(Random.Range(2, 5));

        // Test quit button
        menuManager.QuitGameButton();
	}
}
