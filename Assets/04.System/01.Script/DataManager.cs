using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//���� ���� - https://coding-of-today.tistory.com/178

public class DataManager : MonoBehaviour
{
    //�̱���
    public static DataManager instance;

    private void Awake() //���� ���� �� ���ϵ� DataManager�� ����.
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);//����
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);//�̹� �����Ѵٸ� �ı�
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
