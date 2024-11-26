using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Register : MonoBehaviour
{
    public TMP_InputField usernameInput1;
    public TMP_InputField Email;
    public TMP_InputField passwordInput1;
    public TMP_InputField Confirmpassword;
    public Button registerButton;
    public Button goToLoginButton;

    ArrayList credentials;

    // Start is called before the first frame update
    void Start()
    {
        registerButton.onClick.AddListener(writeStuffToFile);
        goToLoginButton.onClick.AddListener(goToLoginScene);

        if (File.Exists(Application.dataPath + "/credentials.txt"))
        {
            credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/credentials.txt"));
        }
        else
        {
            File.WriteAllText(Application.dataPath + "/credentials.txt", "");
        }

    }

    void goToLoginScene()
    {
        SceneManager.LoadScene("Login");
    }


    void writeStuffToFile()
    {
        bool isExists = false;

        credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/credentials.txt"));
        foreach (var i in credentials)
        {
            if (i.ToString().Contains(usernameInput1.text))
            {
                isExists = true;
                break;
            }
        }

        if (isExists)
        {
            Debug.Log($"Username '{usernameInput1.text}' already exists");
        }
        else
        {
            credentials.Add(usernameInput1.text + ":" + passwordInput1.text);
            File.WriteAllLines(Application.dataPath + "/credentials.txt", (String[])credentials.ToArray(typeof(string)));
            Debug.Log("Account Registered");
        }
    }


}
