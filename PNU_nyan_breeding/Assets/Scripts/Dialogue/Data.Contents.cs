using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
#region Diagloue

[System.Serializable]
public class Diagloue : RawData
{
    public string name;
    public string script;
}

[System.Serializable]
public class DialogueData : ILoader<int, Diagloue>
{
	public Diagloue[] diagloues;  // json 파일에서 여기로 담김

	public Dictionary<int, Diagloue> MakeDict() // 오버라이딩
	{
		Dictionary<int, Diagloue> dataDict = new Dictionary<int, Diagloue>();
		foreach (Diagloue diagloue in diagloues) // 리스트에서 Dictionary로 옮기는 작업
			dataDict.Add(diagloue.id, diagloue); // level을 ID(Key)로 
		return dataDict;
	}
}

#endregion
