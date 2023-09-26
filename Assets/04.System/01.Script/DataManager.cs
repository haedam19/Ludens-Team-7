using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//참고 문헌 - https://coding-of-today.tistory.com/178

public class DataManager : MonoBehaviour
{
    //싱글톤
    public static DataManager instance;

    private void Awake() //게임 실행 시 단일된 DataManager을 생성.
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);//보존
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);//이미 존재한다면 파괴
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
