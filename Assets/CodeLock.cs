using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CodeLock : MonoBehaviour
{
    public UnityEvent RightCode;
    public UnityEvent WrongCode;

    public UnityEvent Stop;

    [SerializeField] private TMP_Text display;

    [SerializeField] List<int> rightCode;

    private List<int> numbers = new();

    private bool disabled = false;

    

    public void AddNumber(int number)
    {
        if (disabled)
            return;

        numbers.Add(number);
        Display();

        if (numbers.Count == rightCode.Count)
        {
            CheckCombination();
        }
    }

    public void ResetCode()
    {
        numbers.Clear();

        display.text = "Enter code";
    }

    private void Display()
    {
        string text = "";

        for(int i = 0; i < numbers.Count; i++)
        {
            text += numbers[i].ToString();
        }

        display.text = text;
    }

    private void CheckCombination()
    {
        int goodNumber = 0;

        for(int i = 0; i < numbers.Count; i++)
        {
            if(numbers[i] == rightCode[i])
            {
                goodNumber++;
            }
        }

        if (goodNumber == rightCode.Count)
        {
            StartCoroutine(Right());
        }
        else
        {
            StartCoroutine(Wrong());
        }
    }

    public void Quit()
    {
        Stop?.Invoke();
        gameObject.SetActive(false);
    }

    private IEnumerator Right()
    {
        RightCode.Invoke();
        display.text = "Door opening....";

        yield return new WaitForSeconds(2f);

        Quit();
    }

    private IEnumerator Wrong()
    {
        WrongCode.Invoke();
        display.text = "Wrong";
        disabled = true;
        yield return new WaitForSeconds(4f);
        disabled = false;
        ResetCode();
    }
}
