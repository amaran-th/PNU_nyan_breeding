using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialSetActive : TutorialBase
{
    [SerializeField]
	private GameObject ActiveObj;
    
    public override void Enter()
	{
        ActiveObj.gameObject.SetActive(true);
	}

	public override void Execute(TutorialController controller)
	{
		controller.SetNextTutorial();
		
	}

	public override void Exit()
	{
        // ActiveObj.gameObject.SetActive(false);
	}
 
    
}
