using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenuBtns;
    [SerializeField] GameObject playerSelectBtns;
    public static int playerCount;
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
        SceneManager.LoadScene("Board");
    }
    
    public void QuitGameButton()
    {
        //Exits the play mode when run in the editor
        EditorApplication.EnterPlaymode();
        //Exits the game
        Application.Quit();
    }
}
