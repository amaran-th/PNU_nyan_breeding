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
	public int grade;
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

#region NPC

[System.Serializable]
public class NPC : RawData
{
    public string name;
    public string img_path;
    public int pos_x;
    public int pos_y;
}

[System.Serializable]
public class NPCData : ILoader<int, NPC>
{
	public NPC[] npcList;  // json 파일에서 여기로 담김

	public Dictionary<int, NPC> MakeDict() // 오버라이딩
	{
		Dictionary<int, NPC> dataDict = new Dictionary<int, NPC>();
		foreach (NPC npc in npcList) // 리스트에서 Dictionary로 옮기는 작업
			dataDict.Add(npc.id, npc); // level을 ID(Key)로 
		return dataDict;
	}
}

#endregion

#region Player

[System.Serializable]
public class Player{
    //정보
    public PlayerInfo playerInfo;
    //스탯
    public PlayerStat playerStat;

}
[System.Serializable]
public class PlayerInfo{
    public string name;
    public int species;
    public string university;

}
[System.Serializable]
public class PlayerStat{
    public int coding_stat;
    public int know_stat;
    public int security_stat;
    public int sociality_stat;
    public int interest_stat;
    public int stress_stat;
    public int money_stat;
}

#endregion


#region CatSpecies

[System.Serializable]
public class CatSpecies : RawData{
    public string name;
    public string img_path;
}

[System.Serializable]
public class CatSpeciesData : ILoader<int, CatSpecies>
{
	public CatSpecies[] catSpeciesList;  // json 파일에서 여기로 담김

	public Dictionary<int, CatSpecies> MakeDict() // 오버라이딩
	{
		Dictionary<int, CatSpecies> dataDict = new Dictionary<int, CatSpecies>();
		foreach (CatSpecies catSpecies in catSpeciesList) // 리스트에서 Dictionary로 옮기는 작업
			dataDict.Add(catSpecies.id, catSpecies); // level을 ID(Key)로 
		return dataDict;
	}
}
#endregion

#region RandomName

[System.Serializable]
public class RandomName : RawData{
    public string name;
}

[System.Serializable]
public class RandomNameData : ILoader<int, RandomName>
{
	public RandomName[] randomNameList;  // json 파일에서 여기로 담김

	public Dictionary<int, RandomName> MakeDict() // 오버라이딩
	{
		Dictionary<int, RandomName> dataDict = new Dictionary<int, RandomName>();
		foreach (RandomName randomName in randomNameList) // 리스트에서 Dictionary로 옮기는 작업
			dataDict.Add(randomName.id, randomName); // level을 ID(Key)로 
		return dataDict;
	}
}
#endregion