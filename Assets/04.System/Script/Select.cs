using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;
using Unity.VisualScripting;

public class Select : MonoBehaviour
{
    public GameObject creat;	// �÷��̾� �г��� �Է�UI
    public GameObject[] deleteButton; //���� ��ư
    public TextMeshProUGUI[] slotText;		// ���Թ�ư �Ʒ��� �����ϴ� Text��
    public TextMeshProUGUI newStageLV;	// ���� �Էµ� �÷��̾��� �г���

    bool[] savefile = new bool[3];	// ���̺����� �������� ����

    void Start()
    {
        // ���Ժ��� ����� �����Ͱ� �����ϴ��� �Ǵ�.
        for (int i = 0; i < 3; i++)
        {
            if (File.Exists(DataManager.instance.path + $"{i}"))	// �����Ͱ� �ִ� ���
            {
                savefile[i] = true;			// �ش� ���� ��ȣ�� bool�迭 true�� ��ȯ
                DataManager.instance.nowSlot = i;	// ������ ���� ��ȣ ����
                DataManager.instance.LoadData();	// �ش� ���� ������ �ҷ���
                slotText[i].text = DataManager.instance.nowPlayer.stageLV.ToString();	// ��ư�� �г��� ǥ��
                deleteButton[i].gameObject.SetActive(true);
            }
            else	// �����Ͱ� ���� ���
            {
                slotText[i].text = "Empty";
            }
        }
        // �ҷ��� �����͸� �ʱ�ȭ��Ŵ.(��ư�� �г����� ǥ���ϱ������̾��� ����)
        DataManager.instance.DataClear();
    }

    public void Slot(int number)	// ������ ��� ����
    {
        DataManager.instance.nowSlot = number;	// ������ ��ȣ�� ���Թ�ȣ�� �Է���.

        if (savefile[number])	// bool �迭���� ���� ���Թ�ȣ�� true��� = ������ �����Ѵٴ� ��
        {
            DataManager.instance.LoadData();	// �����͸� �ε��ϰ�
            GoGame();	// ���Ӿ����� �̵�
        }
        else	// bool �迭���� ���� ���Թ�ȣ�� false��� �����Ͱ� ���ٴ� ��
        {
            Creat();	// �÷��̾� �г��� �Է� UI Ȱ��ȭ
        }
    }

    public void Creat()	// �÷��̾� �г��� �Է� UI�� Ȱ��ȭ�ϴ� �޼ҵ�
    {
        creat.gameObject.SetActive(true);
    }

    public void GoGame()	// ���Ӿ����� �̵�
    {
        if (!savefile[DataManager.instance.nowSlot])	// ���� ���Թ�ȣ�� �����Ͱ� ���ٸ�
        {
            DataManager.instance.nowPlayer.stageLV = int.Parse(newStageLV.text); // �Է��� �̸��� �����ؿ�
            DataManager.instance.SaveData(); // ���� ������ ������.
        }
        SceneManager.LoadScene(1); // ���Ӿ����� �̵�
    }
    public void AddStageLV()
    {
        newStageLV.text = (int.Parse(newStageLV.text)+1).ToString();
    }
    public void AbstrubtStageLV()
    {
        if (int.Parse(newStageLV.text) == 0)
        {
            return;
        }
        newStageLV.text = (int.Parse(newStageLV.text) - 1).ToString();
    }
    public void DeleteDataButton(int number)
    {
        DataManager.instance.DeleteData(number);
        SceneManager.LoadScene(1); // ���Ӿ����� �̵�
    }
}
