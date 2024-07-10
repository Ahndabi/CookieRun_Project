using UnityEngine;
using Firebase.Auth;
using System;
using System.Collections;

public class AuthManager: MonoBehaviour
{
    FirebaseAuth auth;  // 로그인, 회원가입 등에 사용
    FirebaseUser user;  // 인증이 완료된 유저 정보

    [SerializeField] LobbySceneUI lobbySceneUI;
    public Action<bool> LoginState;     // output text랑 연동하기 위함

    public void Init()
    {
        auth = FirebaseAuth.DefaultInstance;

        if (auth.CurrentUser != null)
        {
            LogOut();
        }

        auth.StateChanged += OnChanged;     // 이벤트 핸들러. StateChanged: 계정 상태가 바뀔 때마다 호출됨
    }


    void OnChanged(object sender, EventArgs e)
    {
        if (auth.CurrentUser != user)
        {
            bool signed = (auth.CurrentUser != user && auth.CurrentUser != null);
            if (!signed && user != null)
            {
                Debug.Log("로그아웃");
                LoginState?.Invoke(false);
            }

            // 로그인을 한 경우
            user = auth.CurrentUser;
            if (signed)
            {
                Debug.Log("로그인");
                LoginState?.Invoke(true);
            }
        }
    }

    public void SignUp(string email, string password)    // 회원가입
    {
        // 밑의 비동기 처리 함수 안에서는 코루틴 호출이 안 됨..
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => 
        { 
            if (task.IsCanceled)    // 회원가입 중간에 취소가 되었을 경우
            {
                Debug.Log("회원가입 취소");
                return;
            }
            if (task.IsFaulted)     // 회원가입을 실패했을 경우
            {
                // 회원가입 실패 이유 -> 이메일이 비정상 / 비밀번호가 너무 간단 / 이미 가입된 이메일 등...
                Debug.Log("회원가입 실패");
                return;
            }

            // FirebaseUser newUser = task.Result;

            AuthResult newUser = task.Result;   // 위의 코드가 오류나서 일단 이렇게 대체
            GameManager.Data.SetUserID(user.UserId);

            Debug.Log("회원가입 완료");
        });
    }

    public async void SignIn(string email, string password)    // 로그인
    {
        bool isSignedIn = false;
        await auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)    // 로그인이 취소가 되었을 경우
            {
                Debug.Log("로그인 취소");
                return;
            }
            if (task.IsFaulted)     // 로그인을 실패했을 경우
            {
                Debug.Log("로그인 실패");
                return;
            }

            isSignedIn = true;
            
            // FirebaseUser newUser = task.Result;
            AuthResult newUser = task.Result;   // 위의 코드가 오류나서 일단 이렇게 대체
            // Data에서 함수 자체를 불러오는 건 되는데 코루틴을 호출하는 순간 멈춤..

            GameManager.Data.SetUserID(user.UserId);
            Debug.Log("로그인 완료");
        });

        if (isSignedIn == true)     // 로그인이 되었을 경우
        {
            GameManager.Data.LoadData();
            GameManager.Data.CheckToHaveData(user.UserId, lobbySceneUI);
        }
    }

    public void LogOut()    // 로그아웃
    {
        auth.SignOut();
        Debug.Log("로그아웃");
    }
}
