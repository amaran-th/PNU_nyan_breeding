using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCollectionButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(JsonUtility.ToJson(EndingCollectionManager.endingCollectionData)); //json파일 잘 받아오는지 검사
    }

    public void GoTitleButtonOnClick() 
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void FlipPageLeft()
    {
        Debug.Log(EndingCollectionManager.endingCollectionData.ending1.endingName);
    }

    public void FlipPageRight()
    {
        
    }

    public void ShowData()
    {
        // Debug.Log(EndingCollectionManager.endingData);
    }
}
