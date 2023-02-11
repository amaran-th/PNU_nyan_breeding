using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager: MonoBehaviour
{
    public List<Dictionary<int, Activity>> activityDataList=new List<Dictionary<int, Activity>>();
    private string[] pathList={"Json/activity_major", "Json/activity_culture","Json/activity_club","Json/activity_leisure","Json/activity_arbite","Json/activity_event"};
    
    public Dictionary<int, NPC> npcData=new Dictionary<int, NPC>();
    public Dictionary<int, CatSpecies> catSpeciesDataList =new Dictionary<int, CatSpecies>();
    public Dictionary<int, RandomName> randomNameDataList =new Dictionary<int, RandomName>();

    public Dictionary<int, EndingDialogue> dialogueList =new Dictionary<int, EndingDialogue>(); 
    public Dictionary<int, EndingDialogue> employmentEnd =new Dictionary<int, EndingDialogue>(); 
    public Dictionary<int, EndingDialogue> joblessEnd =new Dictionary<int, EndingDialogue>(); 
    public Dictionary<int, EndingDialogue> graduateSchoolEnd =new Dictionary<int, EndingDialogue>(); 
    public Dictionary<int, TempEvent> tempEvent =new Dictionary<int, TempEvent>();
    public Dictionary<int, Standing> standingList =new Dictionary<int, Standing>(); 
    public Dictionary<int, EndingIllust> illustList =new Dictionary<int, EndingIllust>(); 
    public Dictionary<int, Background> backgroundList =new Dictionary<int, Background>(); 

    public void Init()
    {
        for(int i=0;i<pathList.Length;i++){
            activityDataList.Add(LoadJson<ActivityData, int, Activity>(pathList[i]).MakeDict());
        }
        npcData=LoadJson<NPCData, int, NPC>("Json/npc").MakeDict();
        catSpeciesDataList = (LoadJson<CatSpeciesData, int, CatSpecies>("Json/cat_species").MakeDict());
        randomNameDataList = (LoadJson<RandomNameData, int, RandomName>("Json/random_name").MakeDict());
        dialogueList = (LoadJson<DialogueData, int, EndingDialogue>("Json/endingDialogue").MakeDict());
        employmentEnd = (LoadJson<EmploymentEndData, int, EndingDialogue>("Json/endingDialogue").MakeDict());
        joblessEnd = (LoadJson<JoblessEndData, int, EndingDialogue>("Json/endingDialogue").MakeDict());
        graduateSchoolEnd = (LoadJson<GraduateSchoolEndData, int, EndingDialogue>("Json/endingDialogue").MakeDict());
        tempEvent = (LoadJson<TempEventData, int, TempEvent>("Json/npcEvent").MakeDict());
        standingList = (LoadJson<StandingData, int, Standing>("Json/standing").MakeDict());
        illustList = (LoadJson<EndingIllustData, int, EndingIllust>("Json/endingIllust").MakeDict());
        backgroundList = (LoadJson<BackgroundData, int, Background>("Json/background").MakeDict());
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
		TextAsset textAsset = Resources.Load<TextAsset>(path); // text 파일이 textAsset에 담긴다. TextAsset 타입은 텍스트파일 에셋이라고 생각하면 됨!
        return JsonUtility.FromJson<Loader>(textAsset.text);
	}
}
