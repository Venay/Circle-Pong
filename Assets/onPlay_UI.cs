
using UnityEngine;
using TMPro;


public class onPlay_UI : MonoBehaviour
{
    
    public static TextMeshProUGUI scoreText;
    public TextMeshProUGUI textElement;
    

    private void Awake()
    {
        scoreText = textElement;
        Time.timeScale = 0;
    }

    

    public void pressToStart()
    {
        
        Time.timeScale = 1;
        
    } 

    

    public void updateSore()
    {
        scoreText.SetText("0");
    }
    


}
