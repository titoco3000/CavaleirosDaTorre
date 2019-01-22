using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InputChooser : MonoBehaviour
{
    public int playerID = 1;
    public Dropdown dropIt;
    public Image dropDownImg;
    public Sprite[] images;

    public GameObject CharacterBasics;
    public GameObject keyChoiceButton;
    public GameObject keyChoiceArea;

    GameManager gameManager;

    public Text upText;
    public Text downText;
    public Text leftText;
    public Text rightText;
    public Text actionText;

    bool jaFoiAcionado;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        AtualizarTexto();
    }

    void AtualizarTexto()
    {
        string[] valores = gameManager.GetControles(playerID);
        upText.text = valores[0];
        downText.text = valores[1];
        leftText.text = valores[2];
        rightText.text = valores[3];
        actionText.text = valores[4];
    }

    public void AddPersonagem()
    {
        if (!jaFoiAcionado)
        {
            jaFoiAcionado = true;
        CharacterBasics.SetActive(true);
        gameManager.personagensConvocados.Add(playerID);
        }
    }

    public void OnDropdownEvent()
    {
        dropDownImg.sprite = images[dropIt.value];
        if(dropIt.value == 0) //se é 'teclado'
        {
            RevelarButton_KeyChoice();
        }
        else
        {
            EsconderButton_KeyChoice();
        }
    }

    void RevelarButton_KeyChoice()
    {
        keyChoiceButton.SetActive(true);
    }
    void EsconderButton_KeyChoice()
    {
        keyChoiceButton.SetActive(false);
    }

    public void RevelarKeyChoiceArea()
    {
        keyChoiceArea.SetActive(true);
    }
    public void EsconderKeyChoiceArea()
    {
        keyChoiceArea.SetActive( false );
        gameManager.SaveControls();

    }


    public void UpChooserPress()
    {
        StartCoroutine(WaitForKeyPress("up"));
    }
    public void DownChooserPress()
    {
        StartCoroutine(WaitForKeyPress("down"));
    }
    public void LeftChooserPress()
    {
        StartCoroutine(WaitForKeyPress("left"));
    }
    public void RightChooserPress()
    {
        StartCoroutine(WaitForKeyPress("right"));
    }
    public void ActionChooserPress()
    {
        StartCoroutine(WaitForKeyPress("action"));
    }


    IEnumerator WaitForKeyPress(string target)
    {
        Debug.Log("started coroutine");
        while(!Input.anyKey)
        {
            yield return new WaitForEndOfFrame();
        }
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(kcode))
            {
                Debug.Log("enviando " + kcode.ToString() + " para " +target);
                gameManager.ChangeInput(playerID, target, kcode.ToString());
                AtualizarTexto();
            }
        }
        Debug.Log("finished coroutine");
        yield return null;
    }

}
