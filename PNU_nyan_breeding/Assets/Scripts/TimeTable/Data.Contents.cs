using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
#region Activity

[System.Serializable]
public class Activity : RawData
{
    public string name;
    public string img_path;
    public int coding_stat;
    public int know_stat;
    public int security_stat;
    public int sociality_stat;
    public int interest_stat;
    public int stress_stat;
    public int money_stat;
    public int flag;
}

[System.Serializable]
public class ActivityData : ILoader<int, Activity>
{
	public Activity[] activities;  // json 파일에서 여기로 담김

	public Dictionary<int, Activity> MakeDict() // 오버라이딩
	{
		Dictionary<int, Activity> dataDict = new Dictionary<int, Activity>();
		foreach (Activity activity in activities) // 리스트에서 Dictionary로 옮기는 작업
			dataDict.Add(activity.id, activity); // level을 ID(Key)로 
		return dataDict;
	}
}

#endregion