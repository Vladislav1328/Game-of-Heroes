using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text text;
    public float time { get; set; } = 8;
    public bool condition { get; set; }

    private void Start()
    {
        text = this.GetComponent<Text>();
    }
    private void Update()
    {
        TimeWorks();
    }

    //�����, ������� ��������� ������� ������, ��������� ��� ���������
    public void TimeStart()
    {
        condition = true;
    }

    //����� � ����������� ������� (�������� ���� ������� ��������� condition)
    public void TimeWorks()
    {
        if (condition == true)
        {
            time -= Time.deltaTime;
            text.text = Mathf.Round(time).ToString();
        }
    }

    //������������� ������
    public void TimeStop()
    {
        condition = false;
    }
}
