using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialShow : TutorialBase
{
    [SerializeField]
	private GameObject ShowObj;
    [SerializeField]
    private GameObject TutorialModalObj;
    
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
        TutorialModalObj.transform.SetAsLastSibling();
        Object.transform.SetAsLastSibling();
    }
 
    
}
