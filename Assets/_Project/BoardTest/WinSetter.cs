using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSetter : MonoBehaviour
{
    public static PlayerColors winnerColor;
    public void SetWinner(PlayerColors color)
    {
        winnerColor = color;
        SceneManager.LoadScene("WinScreen");
    }
}
