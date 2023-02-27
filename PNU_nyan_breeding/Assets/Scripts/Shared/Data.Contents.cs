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
	public int creative_stat;
    public int stress_stat;
    public int money_stat;
    public int flag;
	public int grade;

	public List<int> GetStatList(){
		return new List<int>(){coding_stat, know_stat, security_stat, sociality_stat, interest_stat, creative_stat, stress_stat};
	}
	public int GetMoney(){
		return money_stat;
	}
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
	public string mail_title;
	public string mail_content;
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
	//엔딩 정보
	public EndingCollection endingCollection;

}
[System.Serializable]
public class PlayerInfo{
    public string name;
    public int species;
    public string university;
	public int grade;
	public int month;
	public int money_stat;
	public int[] npc_bond;
	public int[] npc_story_count;
	
	//grade, month, money 업데이트
	public void UpdateInfo(int moneyDiff){
		if(month==2) grade+=1;
		month=(month+1)%12;
		money_stat+=moneyDiff;
	}
	public void UpdateStoryCount(int npcId){
		if(npcId!=-1) npc_story_count[npcId]+=1;
	}
}
[System.Serializable]
public class PlayerStat{
    public int coding_stat;
    public int know_stat;
    public int security_stat;
    public int sociality_stat;
    public int interest_stat;
	public int creative_stat;
    public int stress_stat;

	public List<int> GetStatList(){
		return new List<int>(){coding_stat, know_stat, security_stat, sociality_stat, interest_stat,creative_stat, stress_stat};
	}
	public void UpdateStat(List<int> diff){
		coding_stat += diff[0];
        know_stat   += diff[1];
        security_stat   += diff[2];
        sociality_stat  += diff[3];
        interest_stat   += diff[4];
		creative_stat += diff[5];
        stress_stat += diff[6];
        
	}
}
[System.Serializable]
public class EndingCollection{
	public string endingName;
	public int done;
	// public string completeDate;
}

/* [System.Serializable]
public class Ending{
	public string endingName;
	public int done;
	// public string completeDate;
}

public class EndingCollection{
    //public Ending ending1;
	//public Ending ending2;
	//public Ending ending3;
	//public Ending ending4;
	/* public List<Ending> GetEndingList(){
		return new List<Ending>(){ending1, ending2, ending3, ending4};
	}
	public void UpdateEnding(List<string> diff){
		ending1.endingName += diff[0];
        ending2.endingName += diff[1];
		ending3.endingName += diff[2];
        ending4.endingName += diff[3];
	}*/

	/*public Ending[] EndingCollectionList;   

	public Dictionary<int, Ending> MakeDict() // 오버라이딩
	{
		Dictionary<int, Ending> endingCollectionDict = new Dictionary<int, Ending>();
		foreach (Ending ending in EndingCollectionList) // 리스트에서 Dictionary로 옮기는 작업
			endingCollectionDict.Add(ending.id, ending); // level을 ID(Key)로 
		return endingCollectionDict;
	}
}*/
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


 #region Diagloue

[System.Serializable]
public class EndingDialogue : RawData
{
    public string name;
    public string script;
}

[System.Serializable]   
public class DialogueData : ILoader<int, EndingDialogue>
{
	public EndingDialogue[] dialogueList;  // json 파일에서 여기로 담김

	public Dictionary<int, EndingDialogue> MakeDict() // 오버라이딩
	{
		Dictionary<int, EndingDialogue> dataDict = new Dictionary<int, EndingDialogue>();
		foreach (EndingDialogue dialogue in dialogueList) // 리스트에서 Dictionary로 옮기는 작업
			dataDict.Add(dialogue.id, dialogue); // level을 ID(Key)로 
		return dataDict;
	}
}

#endregion

#region EmploymentEnding

[System.Serializable]   
public class EmploymentEndData : ILoader<int, EndingDialogue>
{
	public EndingDialogue[] employmentEnd;   

	public Dictionary<int, EndingDialogue> MakeDict() // 오버라이딩
	{
		Dictionary<int, EndingDialogue> dataDict = new Dictionary<int, EndingDialogue>();
		foreach (EndingDialogue dialogue in employmentEnd) // 리스트에서 Dictionary로 옮기는 작업
			dataDict.Add(dialogue.id, dialogue); // level을 ID(Key)로 
		return dataDict;
	}

}

#endregion

#region JoblessEnding

[System.Serializable]   
public class JoblessEndData    : ILoader<int, EndingDialogue>
{
	public EndingDialogue[] joblessEnd;   

	public Dictionary<int, EndingDialogue> MakeDict() // 오버라이딩
	{
		Dictionary<int, EndingDialogue> dataDict = new Dictionary<int, EndingDialogue>();
		foreach (EndingDialogue dialogue in joblessEnd) // 리스트에서 Dictionary로 옮기는 작업
			dataDict.Add(dialogue.id, dialogue); // level을 ID(Key)로 
		return dataDict;
	}
}

#endregion

#region GraduateSchoolEnding


[System.Serializable]   
public class GraduateSchoolEndData : ILoader<int, EndingDialogue>
{
	public EndingDialogue[] graduateSchoolEnd;   

	public Dictionary<int, EndingDialogue> MakeDict() // 오버라이딩
	{
		Dictionary<int, EndingDialogue> dataDict = new Dictionary<int, EndingDialogue>();
		foreach (EndingDialogue dialogue in graduateSchoolEnd) // 리스트에서 Dictionary로 옮기는 작업
			dataDict.Add(dialogue.id, dialogue); // level을 ID(Key)로 
		return dataDict;
	}
}

#endregion

#region professorEvent
[System.Serializable]
public class ProfessorEvent : RawData
{
    public string name;
    public string script;
	public string background;
}

[System.Serializable]   
public class ProfessorEventData : ILoader<int, ProfessorEvent>
{
	public ProfessorEvent[] professorEvent;   

	public Dictionary<int, ProfessorEvent> MakeDict() // 오버라이딩
	{
		Dictionary<int, ProfessorEvent> dataDict = new Dictionary<int, ProfessorEvent>();
		foreach (ProfessorEvent dialogue in professorEvent) // 리스트에서 Dictionary로 옮기는 작업
			dataDict.Add(dialogue.id, dialogue); // level을 ID(Key)로 
		return dataDict;
	}
}

[System.Serializable]   
public class BlackCatEventData : ILoader<int, ProfessorEvent>
{
	public ProfessorEvent[] blackCatEvent;   

	public Dictionary<int, ProfessorEvent> MakeDict() // 오버라이딩
	{
		Dictionary<int, ProfessorEvent> dataDict = new Dictionary<int, ProfessorEvent>();
		foreach (ProfessorEvent dialogue in blackCatEvent) // 리스트에서 Dictionary로 옮기는 작업
			dataDict.Add(dialogue.id, dialogue); // level을 ID(Key)로 
		return dataDict;
	}
}

[System.Serializable]   
public class ButlerEventData : ILoader<int, ProfessorEvent>
{
	public ProfessorEvent[] butlerEvent;   

	public Dictionary<int, ProfessorEvent> MakeDict() // 오버라이딩
	{
		Dictionary<int, ProfessorEvent> dataDict = new Dictionary<int, ProfessorEvent>();
		foreach (ProfessorEvent dialogue in butlerEvent) // 리스트에서 Dictionary로 옮기는 작업
			dataDict.Add(dialogue.id, dialogue); // level을 ID(Key)로 
		return dataDict;
	}
}

[System.Serializable]   
public class PresidentEventData : ILoader<int, ProfessorEvent>
{
	public ProfessorEvent[] presidentEvent;   

	public Dictionary<int, ProfessorEvent> MakeDict() // 오버라이딩
	{
		Dictionary<int, ProfessorEvent> dataDict = new Dictionary<int, ProfessorEvent>();
		foreach (ProfessorEvent dialogue in presidentEvent) // 리스트에서 Dictionary로 옮기는 작업
			dataDict.Add(dialogue.id, dialogue); // level을 ID(Key)로 
		return dataDict;
	}
}
#endregion


#region Standing

[System.Serializable]
public class Standing : RawData
{
    public string name;
    public string image;
    public int locationX;
}

[System.Serializable]
public class StandingData : ILoader<int, Standing>
{
	public Standing[] standingList;  // json 파일에서 여기로 담김

	public Dictionary<int, Standing> MakeDict() // 오버라이딩
	{
		Dictionary<int, Standing> dataDict = new Dictionary<int, Standing>();
		foreach (Standing standing in standingList) // 리스트에서 Dictionary로 옮기는 작업
			dataDict.Add(standing.id, standing); // level을 ID(Key)로 
		return dataDict;
	}
}

#endregion



#region EndingIllust

[System.Serializable]
public class EndingIllust : RawData
{
    public string name;
    public string img_path;
}

[System.Serializable]
public class EndingIllustData : ILoader<int, EndingIllust>
{
	public EndingIllust[] illustList;  // json 파일에서 여기로 담김

	public Dictionary<int, EndingIllust> MakeDict() // 오버라이딩
	{
		Dictionary<int, EndingIllust> dataDict = new Dictionary<int, EndingIllust>();
		foreach (EndingIllust illust in illustList) // 리스트에서 Dictionary로 옮기는 작업
			dataDict.Add(illust.id, illust); // level을 ID(Key)로 
		return dataDict;
	}
}

#endregion

#region Background

[System.Serializable]
public class Background : RawData
{
    public string name;
    public string img_path;
}

[System.Serializable]
public class BackgroundData : ILoader<int, Background>
{
	public Background[] backgroundList;  // json 파일에서 여기로 담김

	public Dictionary<int, Background> MakeDict() // 오버라이딩
	{
		Dictionary<int, Background> dataDict = new Dictionary<int, Background>();
		foreach (Background background in backgroundList) // 리스트에서 Dictionary로 옮기는 작업
			dataDict.Add(background.id, background); // level을 ID(Key)로 
		return dataDict;
	}
}

#endregion

