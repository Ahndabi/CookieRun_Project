using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LogInSystem : MonoBehaviour
{
    // 여기서 로그인/회원가입 ui 기능 구현

    public TMP_InputField email;
    public TMP_InputField password;

    public TMP_Text outputText;

    private void Start()
    {
        //AuthManager.Instance.LoginState += OnChangedState;
        //AuthManager.Instance.Init();
    }

    void OnChangedState(bool _sign)
    {
        outputText.text = _sign ? "Log In : " : "Log Out : ";
        // outputText.text += AuthManager.Instance.userID;
    }

    public void SignUp()
    {
        string _email = email.text;
        string _pw = password.text;

        // AuthManager.Instance.SignUp(_email, _pw);
    }

    public void SignIn()
    {
        // AuthManager.Instance.SignIn(email.text, password.text);

    }

    public void LogOut()
    {
        // AuthManager.Instance.LogOut();
    }
}
