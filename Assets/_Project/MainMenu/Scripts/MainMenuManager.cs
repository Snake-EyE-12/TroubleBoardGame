using UnityEditor;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenuBtns;
    [SerializeField] GameObject playerSelectBtns;
    static int playerCount;
    public void StartGameButton()
    {
        mainMenuBtns.SetActive(false);
        playerSelectBtns.SetActive(true);
    }

    public void MainMenuBackBtn()
    {
        mainMenuBtns.SetActive(true);
        playerSelectBtns.SetActive(false);
    }

    public void PlayerCountSelection(int playerNum)
    {
        playerCount = playerNum;
    }
    
    public void QuitGameButton()
    {
        //Exits the play mode when run in the editor
        EditorApplication.EnterPlaymode();
        //Exits the game
        Application.Quit();
    }
}
