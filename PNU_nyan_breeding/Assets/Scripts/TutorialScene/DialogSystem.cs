using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[System.Serializable]
public struct Dialog
{
	public	string		dialogue;	// 대사
}

public class DialogSystem : MonoBehaviour
{
	[SerializeField]
	private	Dialog[]			dialogs;						// 현재 분기의 대사 목록

	[SerializeField]
	private	Image 				imageDialogs;					// 대화창 Image UI
	[SerializeField]
	private	TextMeshProUGUI	textDialogues;					// 현재 대사 출력 Text UI
	[SerializeField]
	private	GameObject		objectArrows;					// 대사가 완료되었을 때 출력되는 커서 오브젝트
 

	private	int					currentIndex = -1;
	private	bool				isTypingEffect = false;			// 텍스트 타이핑 효과를 재생중인지

    
    public void Setup()
	{
		// 모든 대화 관련 게임오브젝트 비활성화
		InActiveObjects();
		SetNextDialog();
	}

	public bool UpdateDialog()
	{
		if ( Input.GetMouseButtonDown(0) )
		{
			// 텍스트 타이핑 효과를 재생중일때 마우스 왼쪽 클릭하면 타이핑 효과 종료
			if ( isTypingEffect == true )
			{
				// 타이핑 효과를 중지하고, 현재 대사 전체를 출력한다
				StopCoroutine("TypingText");
				isTypingEffect = false;
				textDialogues.text = dialogs[currentIndex].dialogue;
				// 대사가 완료되었을 때 출력되는 커서 활성화
				objectArrows.SetActive(true);

				return false;
			}

			// 다음 대사 진행
			if ( dialogs.Length > currentIndex + 1 )
			{
				SetNextDialog();
			}
			// 대사가 더 이상 없을 경우 true 반환
			else
			{
				// 모든 대화 관련 게임오브젝트 비활성화
				InActiveObjects();

				return true;
			}
		}

		return false;
	}

	private void SetNextDialog()
	{
		currentIndex ++;
 
		imageDialogs.gameObject.SetActive(true); //모달창 활성화

		StartCoroutine(nameof(TypingText));
	}

	private void InActiveObjects()
	{
		imageDialogs.gameObject.SetActive(false);
		objectArrows.SetActive(false);
	}

	private IEnumerator TypingText() // 텍스트를 한글자씩 타이핑치듯 재생
	{
		int index = 0;
		
		isTypingEffect = true;

		while ( index <= dialogs[currentIndex].dialogue.Length )
		{
			textDialogues.text = dialogs[currentIndex].dialogue.Substring(0, index);

			index ++;

			yield return new WaitForSeconds(0.1f);
		}

		isTypingEffect = false;

		objectArrows.SetActive(true); // 대사가 완료되었을 때 출력되는 커서 활성화
	}
}



