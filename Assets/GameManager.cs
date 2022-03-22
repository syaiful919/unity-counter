using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text countText;
    public Button countButton;
    public Button resetButton;

    private int countNumber = 0;

    public void Count()
    {
        countNumber++;
        countText.text = countNumber.ToString();
    }

    public void Reset() 
    {
        countNumber = 0;
        countText.text = countNumber.ToString();
    }
    
}
