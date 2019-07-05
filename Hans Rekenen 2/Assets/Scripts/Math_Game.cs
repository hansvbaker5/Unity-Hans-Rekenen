using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class formula
{
    public int mainNumber;
    public int secondNumber;
    public int answer;

    public formula(int MainNumber, int SecondNumber, int Answer)
    {
        MainNumber = mainNumber;
        SecondNumber = secondNumber;
        Answer = answer;
    }
}

public class Math_Game : MonoBehaviour {

    public TextMesh textPro;

    public int[] answers;

    public TextMesh[] buttons;

    public TextMesh result;

    public TextMesh Restart;

    public List<formula> neat = new List<formula>();

    private int x;
    private int y;
    private int z;

    private int what;
    private string anotherwhat;

    private string answer = "?";

	// Use this for initialization
	void Start () {

        textPro = GetComponent<TextMesh>();
        MakeMathQuestion(false); 
	}
	
    public void MakeMathQuestion(bool restart)
    {
        x = Random.Range(1, 10);
        y = Random.Range(1, 10);
        what = Random.Range(0, 4);

        if(what == 0)
        {
            z = x + y;
            anotherwhat = " + ";
        }
        else if (what == 1)
        {
            x = Random.Range(1, 100);
            y = Random.Range(1, 100);
            z = x - y;
            if(z <= 0)
            {
                x = 6;
                y = 5;
                z = 1;
            }
            anotherwhat = " - ";
        }
        else if(what == 2)
        {
            z = x * y;
            anotherwhat = " X ";
        }
        else if(what == 3)
        {
            int randam = Random.Range(0, 54);
            x = neat[randam].mainNumber;
            y = neat[randam].secondNumber;
            z = neat[randam].answer;
            anotherwhat = " / ";
        }
        

        Restart.text = "Restart";

        answer = "?";

        textPro.text = string.Format(x + anotherwhat + y + " = " + answer);

        for (int i = 0; i < answers.Length; i++)
        {
            answers[i] = 0;
        }

        answers[Random.Range(0, 3)] = z;

        for (int i = 0; i < answers.Length; i++)
        {
            if(answers[i] == 0)
            {
                answers[i] = Random.Range(1, 100);

                if (answers[i] == z)
                {
                    answers[i] += Random.Range(-z, -1);
                    Debug.Log("Same");
                }
            }

            buttons[i].text = string.Format("" + answers[i]);
        }

        if (restart == true)
        {
            result.text = "What is the Answer?";
        }
    }

    public void SeeResult(int id)
    {
        if(answers[id] == z)
        {
            answer = z.ToString();
            textPro.text = string.Format(x + anotherwhat + y + " = " + answer);
            result.text = "Correct!";
            Restart.text = "Next";

        }
        else
        {
            result.text = "Incorrect!";
        }
    }
}
