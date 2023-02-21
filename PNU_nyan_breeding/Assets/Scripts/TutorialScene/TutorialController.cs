using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    public static PlayerInfo playerInfoData;
    public static PlayerStat playerStatData;

    public static List<int> playerStat = new List<int>();
 
    
    void Awake()
    {
        playerInfoData = Managers.Player.playerInfoData;  
        playerStatData = Managers.Player.playerStatData;  
        playerStat = playerStatData.GetStatList();
 
    }

 

    [SerializeField]
	private	List<TutorialBase>	tutorials;
	[SerializeField]
	private	string				nextSceneName = "";

	private TutorialBase		currentTutorial = null;
	private	int					currentIndex = -1;

	private void Start()
	{
		SetNextTutorial();
	}

	private void Update()
	{
		if ( currentTutorial != null )
		{
			currentTutorial.Execute(this);
		}
	}

	public void SetNextTutorial()
	{
		// 현재 튜토리얼의 Exit() 메소드 호출
		if ( currentTutorial != null )
		{
			currentTutorial.Exit();
		}

		// 마지막 튜토리얼을 진행했다면 CompletedAllTutorials() 메소드 호출
		if ( currentIndex >= tutorials.Count-1 )
		{
			CompletedAllTutorials();
			return;
		}

		// 다음 튜토리얼 과정을 currentTutorial로 등록
		currentIndex ++;
		currentTutorial = tutorials[currentIndex];

		// 새로 바뀐 튜토리얼의 Enter() 메소드 호출
		currentTutorial.Enter();
	}

	public void CompletedAllTutorials()
	{
		currentTutorial = null;

		// 행동 양식이 여러 종류가 되었을 때 코드 추가 작성
		// 현재는 씬 전환

		Debug.Log("Complete All");

		if ( !nextSceneName.Equals("") )
		{
			SceneManager.LoadScene(nextSceneName);
		}
	}

    
 
    
}
