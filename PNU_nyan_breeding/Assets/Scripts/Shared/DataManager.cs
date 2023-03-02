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
    //Illust
    public Dictionary<int, Standing> standingList =new Dictionary<int, Standing>(); 
    public Dictionary<int, EndingIllust> illustList =new Dictionary<int, EndingIllust>(); 
    public Dictionary<int, Background> backgroundList =new Dictionary<int, Background>(); 

    //Ending
    public List<Dictionary<int, EndingDialogue>> normalEnding=new List<Dictionary<int, EndingDialogue>>();
    private string[] NormalEndingPath={"Json/NormalEnding/developerEnd","Json/NormalEnding/graduateSchoolEnd"};
    public List<Dictionary<int, EndingDialogue>> badEnding=new List<Dictionary<int, EndingDialogue>>();
    private string[] BadEndingPath={};
    public List<Dictionary<int, EndingDialogue>> hiddenEnding=new List<Dictionary<int, EndingDialogue>>();
    private string[] HiddenEndingPath={"Json/HiddenEnding/overworkEnd"};
 
    //NPCEvent
    public List<Dictionary<int, ProfessorEvent>> professorEvent=new List<Dictionary<int, ProfessorEvent>>();
    private string[] professorEventPath={"Json/NpcEventProfessor/professorEvent0", "Json/NpcEventProfessor/professorEvent1","Json/NpcEventProfessor/professorEvent3","Json/NpcEventProfessor/professorEvent4","Json/NpcEventProfessor/professorEvent5","Json/NpcEventProfessor/professorEvent6","Json/NpcEventProfessor/professorEvent7","Json/NpcEventProfessor/professorEvent8","Json/NpcEventProfessor/professorEvent9"};
    public List<Dictionary<int, ProfessorEvent>> blackCatEvent=new List<Dictionary<int, ProfessorEvent>>();
    private string[] blackCatEventPath={"Json/NpcEventBlackCat/blackCatEvent0", "Json/NpcEventBlackCat/blackCatEvent1","Json/NpcEventBlackCat/blackCatEvent3","Json/NpcEventBlackCat/blackCatEvent4","Json/NpcEventBlackCat/blackCatEvent5","Json/NpcEventBlackCat/blackCatEvent6","Json/NpcEventBlackCat/blackCatEvent7","Json/NpcEventBlackCat/blackCatEvent8","Json/NpcEventBlackCat/blackCatEvent9"};
    public List<Dictionary<int, ProfessorEvent>> butlerEvent=new List<Dictionary<int, ProfessorEvent>>();
    private string[] butlerEventPath={"Json/NpcEventButler/butlerEvent0", "Json/NpcEventButler/butlerEvent1","Json/NpcEventButler/butlerEvent3","Json/NpcEventButler/butlerEvent4","Json/NpcEventButler/butlerEvent5","Json/NpcEventButler/butlerEvent6","Json/NpcEventButler/butlerEvent7","Json/NpcEventButler/butlerEvent8","Json/NpcEventButler/butlerEvent9"};
    public List<Dictionary<int, ProfessorEvent>> presidentEvent=new List<Dictionary<int, ProfessorEvent>>();
    private string[] presidentEventPath={"Json/NpcEventPresident/presidentEvent0", "Json/NpcEventPresident/presidentEvent1","Json/NpcEventPresident/presidentEvent3","Json/NpcEventPresident/presidentEvent4","Json/NpcEventPresident/presidentEvent5","Json/NpcEventPresident/presidentEvent6","Json/NpcEventPresident/presidentEvent7","Json/NpcEventPresident/presidentEvent8","Json/NpcEventPresident/presidentEvent9"};

    public void Init()
    {
        for(int i=0;i<pathList.Length;i++){
            activityDataList.Add(LoadJson<ActivityData, int, Activity>(pathList[i]).MakeDict());
        }
        npcData=LoadJson<NPCData, int, NPC>("Json/npc").MakeDict();
        catSpeciesDataList = (LoadJson<CatSpeciesData, int, CatSpecies>("Json/cat_species").MakeDict());
        randomNameDataList = (LoadJson<RandomNameData, int, RandomName>("Json/random_name").MakeDict());

        //Ending
       for(int i=0;i<NormalEndingPath.Length;i++){
            normalEnding.Add(LoadJson<NormalEndingData, int, EndingDialogue>(NormalEndingPath[i]).MakeDict());
        }
        for(int i=0;i<HiddenEndingPath.Length;i++){
            hiddenEnding.Add(LoadJson<HiddenEndingData, int, EndingDialogue>(HiddenEndingPath[i]).MakeDict());
        }
        for(int i=0;i<BadEndingPath.Length;i++){
            badEnding.Add(LoadJson<BadEndingData, int, EndingDialogue>(BadEndingPath[i]).MakeDict());
        }

        //Illust
        standingList = (LoadJson<StandingData, int, Standing>("Json/standing").MakeDict());
        illustList = (LoadJson<EndingIllustData, int, EndingIllust>("Json/endingIllust").MakeDict());
        backgroundList = (LoadJson<BackgroundData, int, Background>("Json/background").MakeDict());
    
        //NPCEvent
        for(int i=0;i<professorEventPath.Length;i++){
            professorEvent.Add(LoadJson<ProfessorEventData, int, ProfessorEvent>(professorEventPath[i]).MakeDict());
        }
        for(int i=0;i<blackCatEventPath.Length;i++){
            blackCatEvent.Add(LoadJson<BlackCatEventData, int, ProfessorEvent>(blackCatEventPath[i]).MakeDict());
        }
        for(int i=0;i<butlerEventPath.Length;i++){
            butlerEvent.Add(LoadJson<ButlerEventData, int, ProfessorEvent>(butlerEventPath[i]).MakeDict());
        }
        for(int i=0;i<presidentEventPath.Length;i++){
            presidentEvent.Add(LoadJson<PresidentEventData, int, ProfessorEvent>(presidentEventPath[i]).MakeDict());
        }
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
		TextAsset textAsset = Resources.Load<TextAsset>(path); // text 파일이 textAsset에 담긴다. TextAsset 타입은 텍스트파일 에셋이라고 생각하면 됨!
        return JsonUtility.FromJson<Loader>(textAsset.text);
	}
}
