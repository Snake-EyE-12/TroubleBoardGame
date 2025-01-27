using UnityEngine;
using UnityEngine.Assertions;

public class Tester : MonoBehaviour
{
    private void RunTests()
    {
        TestColorToRGBCode();
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
    
    
    
}
