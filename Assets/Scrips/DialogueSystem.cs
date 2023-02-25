using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    private string [] lines = new string[10];
    private string [] authors = new string[10];
    [SerializeField] float TextSpeed;
    [SerializeField] private GameObject SceneSwitcher;
    [SerializeField] private TextMeshProUGUI nameField;
    [SerializeField] private Sprite[] krips;

    private int index;
    private int counter;
    private void Start()
    {
        counter = GameObject.FindWithTag("DontDestroy").GetComponent<DontDestroy>().counter;

        SceneSwitcher.SetActive(false);
        GameObject.FindWithTag("Speaker").GetComponent<SpriteRenderer>().sprite = krips[Random.Range(0, krips.Length)];

        switch (counter)
        {
            case 0:
                lines[0] = "������������, ����� ���� � �������?";
                lines[1] = "����� �������";
                authors[0] = "��������";
                authors[1] = "��";
                break;
            case 2:
                lines[0] = "�������, ��� ������";
                lines[1] = "����� �������";
                authors[0] = "��������";
                authors[1] = "��";
                GameObject.FindWithTag("DontDestroy").GetComponent<DontDestroy>().money += 60;
                break;
        }

        lines = lines.Where(x => x != null).ToArray();

        text.text = string.Empty;
        nameField.text = authors[index];
        StartDialogue();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (text.text == lines[index])
            {
                IsNextLine();
            }
            else
            {
                StopAllCoroutines();
                text.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        nameField.text = authors[index];
            foreach (char c in lines[index].ToCharArray())
            {
                text.text += c;
                yield return new WaitForSeconds(TextSpeed);
            }
        
    }

    private void IsNextLine()
    {
        if (index < lines.Length - 1 )
        {
            index++;
            text.text = string.Empty;
            StartCoroutine(TypeLine());
        } else
        {
            gameObject.SetActive(false);
            SceneSwitcher.SetActive(true);
        }
    }
}
