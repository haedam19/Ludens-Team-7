//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
//using System.IO;
//using TMPro;
//using Unity.VisualScripting;

//public class Select : MonoBehaviour
//{
//    public GameObject creat;	// 스테이지 입력UI
//    public GameObject[] deleteButton; //삭제 버튼
//    public TextMeshProUGUI[] slotText;		// 슬롯버튼 아래에 존재하는 Text들
//    public TextMeshProUGUI newStageLV;	// 새로 입력된 스테이지

//    bool[] savefile = new bool[3];	// 세이브파일 존재유무 저장

//    void Start()
//    {
//        // 슬롯별로 저장된 데이터가 존재하는지 판단.
//        for (int i = 0; i < 3; i++)
//        {
//            if (File.Exists(DataManager.instance.path + $"{i}"))	// 데이터가 있는 경우
//            {
//                savefile[i] = true;			// 해당 슬롯 번호의 bool배열 true로 변환
//                DataManager.instance.nowStage = i;	// 선택한 슬롯 번호 저장
//                DataManager.instance.LoadData();	// 해당 슬롯 데이터 불러옴
//                slotText[i].text = DataManager.instance.nowPlayer.stage.ToString();	// 버튼에 스테이지 표시
//                deleteButton[i].gameObject.SetActive(true);
//            }
//            else	// 데이터가 없는 경우
//            {
//                slotText[i].text = "Empty";
//            }
//        }
//        // 불러온 데이터를 초기화시킴.(버튼에 스테이지를 표현하기위함이었기 때문)
//        DataManager.instance.DataClear();
//    }

//    public void Slot(int number)	// 슬롯의 기능 구현
//    {
//        DataManager.instance.nowStage = number;	// 슬롯의 번호를 슬롯번호로 입력함.

//        if (savefile[number])	// bool 배열에서 현재 슬롯번호가 true라면 = 데이터 존재한다는 뜻
//        {
//            DataManager.instance.LoadData();	// 데이터를 로드하고
//            GoGame();	// 게임씬으로 이동
//        }
//        else	// bool 배열에서 현재 슬롯번호가 false라면 데이터가 없다는 뜻
//        {
//            Creat();	// 플레이어 스테이지 입력 UI 활성화
//        }
//    }

//    public void Creat()	// 스테이지 입력 UI를 활성화하는 메소드
//    {
//        creat.gameObject.SetActive(true);
//    }

//    public void GoGame()	// 게임씬으로 이동
//    {
//        if (!savefile[DataManager.instance.nowStage])	// 현재 슬롯번호의 데이터가 없다면
//        {
//            DataManager.instance.nowPlayer.stage = int.Parse(newStageLV.text); // 입력한 스테이지를 복사해옴
//            DataManager.instance.SaveData(); // 현재 정보를 저장함.
//        }
//        SceneManager.LoadScene(1); // 게임씬으로 이동
//    }
//    public void AddStageLV()
//    {
//        newStageLV.text = (int.Parse(newStageLV.text)+1).ToString();
//    }
//    public void AbstrubtStageLV()
//    {
//        if (int.Parse(newStageLV.text) == 0)
//        {
//            return;
//        }
//        newStageLV.text = (int.Parse(newStageLV.text) - 1).ToString();
//    }
//    public void DeleteDataButton(int number)
//    {
//        DataManager.instance.DeleteData(number);
//        SceneManager.LoadScene(1); // 게임씬으로 이동
//    }
//}
