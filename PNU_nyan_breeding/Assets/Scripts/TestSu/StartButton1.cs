using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartButton1 : MonoBehaviour
{
    public TMP_InputField NameInputField;
    public TMP_InputField UniversityInputField;
    
    public void OnClickStartButton(){
        if (NameInputField.text == "" || UniversityInputField.text == "" ){
           ModalManager.instance.OpenModal("이름 또는 대학을 입력해주세요!");
        }
        else{
            Managers.Player.playerInfoData.name = NameInputField.text;
            Managers.Player.playerInfoData.university = UniversityInputField.text;
            Managers.Player.playerInfoData.species = SelectSpecies.currentSpecies;
            Managers.Player.playerInfoData.grade = 1;
            Managers.Player.playerInfoData.month = 3;
            Managers.Player.playerInfoData.money_stat = 30000;
        
            Managers.Player.SaveData();

            SceneManager.LoadScene("HomeScene");
        }
        
    }
}