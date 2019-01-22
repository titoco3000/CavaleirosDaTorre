using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int maxLevel;
    public int currentLevel;

    public List<int> personagensConvocados;


    public string p1_Up ;
    public string p1_Down;
    public string p1_Left;
    public string p1_Right;
    public string p1_Action;

    public string p2_Up;
    public string p2_Down;
    public string p2_Left;
    public string p2_Right;
    public string p2_Action;

    public string p3_Up;
    public string p3_Down;
    public string p3_Left;
    public string p3_Right;
    public string p3_Action;

    public string p4_Up;
    public string p4_Down;
    public string p4_Left;
    public string p4_Right;
    public string p4_Action;



    void Start()
    {
        DontDestroyOnLoad(this);
        personagensConvocados = new List<int>();
        //SaveControls();
        LoadControls();
        //Invoke("SaveData", 10f);
        //Invoke("LoadData", 20f);
    }

    void OnLevelWasLoaded()
    {
        Debug.Log("A new scene was loaded");
        foreach(int i in personagensConvocados)
        {
            PlacePlayerInScene(i); 
        }
    }
    void Update()
    {
        if (Input.GetKey("space"))
        {
            NextLevel();
        }
    }
    
    void PlacePlayerInScene(int id)
    {
        Player player = Instantiate(Resources.Load("Player" + id) as GameObject).GetComponent<Player>();
        string[] comandos = GetControles(id);
        player.Up = comandos[0];
        player.Down = comandos[1];
        player.Left = comandos[2];
        player.Right = comandos[3];
        player.Action = comandos[4];
    }
    public void ChangeInput(int player, string type, string newValue)
    {
        Debug.Log("recebendo " + newValue);
        if (player == 1)
        {
            if (type == "up")
                p1_Up = newValue;
            else if (type == "down")
                p1_Down = newValue;
            else if (type == "left")
                p1_Left = newValue;
            else if (type == "right")
                p1_Right = newValue;
            else if (type == "action")
                p1_Action = newValue;
        }
        else if (player == 2)
        {
            if (type == "up")
                p2_Up = newValue;
            else if (type == "down")
                p2_Down = newValue;
            else if (type == "left")
                p2_Left = newValue;
            else if (type == "right")
                p2_Right = newValue;
            else if (type == "action")
                p2_Action = newValue;
        }
        else if (player == 3)
        {
            if (type == "up")
                p3_Up = newValue;
            else if (type == "down")
                p3_Down = newValue;
            else if (type == "left")
                p3_Left = newValue;
            else if (type == "right")
                p3_Right = newValue;
            else if (type == "action")
                p3_Action = newValue;
        }
        else if (player == 4)
        {
            if (type == "up")
                p4_Up = newValue;
            else if (type == "down")
                p4_Down = newValue;
            else if (type == "left")
                p4_Left = newValue;
            else if (type == "right")
                p4_Right = newValue;
            else if (type == "action")
                p4_Action = newValue;
        }


    }
    public string[] GetControles(int player)
    {
        string[] retorno = new string[5];
        if(player == 1)
        {
            retorno[0] = p1_Up;
            retorno[1] = p1_Down;
            retorno[2] = p1_Left;
            retorno[3] = p1_Right;
            retorno[4] = p1_Action;
        }
        else if (player == 2)
        {
            retorno[0] = p2_Up;
            retorno[1] = p2_Down;
            retorno[2] = p2_Left;
            retorno[3] = p2_Right;
            retorno[4] = p2_Action;
        }
        else if (player == 3)
        {
            retorno[0] = p3_Up;
            retorno[1] = p3_Down;
            retorno[2] = p3_Left;
            retorno[3] = p3_Right;
            retorno[4] = p3_Action;
        }
        else
        {
            retorno[0] = p4_Up;
            retorno[1] = p4_Down;
            retorno[2] = p4_Left;
            retorno[3] = p4_Right;
            retorno[4] = p4_Action;
        }

        return retorno;
    }


    void SaveData()
    {
        Debug.Log("salvando...");
        SaveSystem.SaveData(this);
        Debug.Log("Agora mude alguma coisa.");
    }

    void LoadData()
    {
        SavedData data = SaveSystem.LoadData();
        maxLevel = data.maxLevel;
        currentLevel = data.currentLevel;
        Debug.Log("loaded");
    }
    public void SaveControls()
    {
        SaveSystem.SaveControls(this);
    }
    void LoadControls()
    {
        ControlesSave data =  SaveSystem.LoadControls();
        p1_Up = data.p1_Up;
        p1_Down = data.p1_Down;
        p1_Left = data.p1_Left;
        p1_Right = data.p1_Right;
        p1_Action = data.p1_Action;

        p2_Up = data.p2_Up;
        p2_Down = data.p2_Down;
        p2_Left = data.p2_Left;
        p2_Right = data.p2_Right;
        p2_Action = data.p2_Action;

        p3_Up = data.p3_Up;
        p3_Down = data.p3_Down;
        p3_Left = data.p3_Left;
        p3_Right = data.p3_Right;
        p3_Action = data.p3_Action;

        p4_Up = data.p4_Up;
        p4_Down = data.p4_Down;
        p4_Left = data.p4_Left;
        p4_Right = data.p4_Right;
        p4_Action = data.p4_Action;
    }

    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
