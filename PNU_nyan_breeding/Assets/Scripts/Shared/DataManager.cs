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
    private string[] pathList={"Json/activity_study","Json/activity_arbite","Json/activity_leisure","Json/activity_club","Json/activity_competition"};
    
    public Dictionary<int, CatSpecies> catSpeciesDataList =new Dictionary<int, CatSpecies>();
    public Dictionary<int, RandomName> randomNameDataList =new Dictionary<int, RandomName>();

    public void Init()
    {
        for(int i=0;i<pathList.Length;i++){
            activityDataList.Add(LoadJson<ActivityData, int, Activity>(pathList[i]).MakeDict());
        }
         catSpeciesDataList = (LoadJson<CatSpeciesData, int, CatSpecies>("Json/cat_species").MakeDict());
         randomNameDataList = (LoadJson<RandomNameData, int, RandomName>("Json/random_name").MakeDict());
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
		TextAsset textAsset = Resources.Load<TextAsset>(path); // text 파일이 textAsset에 담긴다. TextAsset 타입은 텍스트파일 에셋이라고 생각하면 됨!
        return JsonUtility.FromJson<Loader>(textAsset.text);
	}
}
