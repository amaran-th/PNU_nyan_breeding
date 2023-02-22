using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialShowBack : TutorialBase
{
    [SerializeField]
	private GameObject ShowObj;
    //튜토리얼 시간표씬에서만 예외로 쓰일 스크립트
    //순서를 맨 뒤로 보냄.
    
    public override void Enter()
	{
		SetHierarchy(ShowObj);
	}

	public override void Execute(TutorialController controller)
	{
		controller.SetNextTutorial();
		
	}

	public override void Exit()
	{
	}

    void SetHierarchy(GameObject Object){
        Object.transform.SetAsFirstSibling();
    }
 
    
}
