using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Firebase.Database;

[Serializable]
public class dataToSave_Test
{
    public string userName;
    public int totalCoins;
    public int totalJelly;
    public int highScore;   // and many more
}

public class DataSaver : MonoBehaviour
{
    public dataToSave_Test dts;
    public string userId;

    // 데이터베이스에 데이터를 쓰려면 DatabaseReference의 인스턴스가 필요
    DatabaseReference dbRef;    

    void Start()
    {
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;     // Get the root reference location of the database
    }

    public void SaveData()
    {
        // 오브젝트(dts)를 문자열로 된 JSON 데이터로 변환
        string json = JsonUtility.ToJson(dts);

        dbRef.Child("users").Child(userId).SetRawJsonValueAsync(json);
        // SetRawJsonValueAsync() : 원시 JSON으로 데이터를 쓰거나 대체함
    }

    public void LoadData()
    {
        StartCoroutine(LoadDataRoutine());
    }

    IEnumerator LoadDataRoutine()
    {
        var serverData = dbRef.Child("users").Child(userId).GetValueAsync();
        yield return new WaitUntil(predicate: () => serverData.IsCompleted);    // 요청한 것이 완료될 때까지 기다려야함 

        print("process is complete");

        DataSnapshot snapshot = serverData.Result;

        string jsonData = snapshot.GetRawJsonValue();

        if (jsonData != null)
        {
            print("server data found");
            dts = JsonUtility.FromJson<dataToSave_Test>(jsonData);
        }
        else
        {
            print("no data found");
        }
    }


    bool isExistedNickName = false;
    // 매개변수로 오는 UserID가 DB에 이미 있는 아이디인지 확인하는 함수
    public void IsUserInData(string _userID)
    {
        StartCoroutine(LoadDataRoutine2(_userID));
    }

    // 코루틴에서 닉네임 있는 걸 체킹하고 닉네임이 존재했는지 아닌지를 위의 함수에서 어떻게 알지? 전역변수말고는 답이 뭐가 있지..
    IEnumerator LoadDataRoutine2(string _userID)
    {
        var serverData = dbRef.Child("users").GetValueAsync();
        yield return new WaitUntil(predicate: () => serverData.IsCompleted);    // 요청한 것이 완료될 때까지 기다려야함 

        print("process is complete");

        DataSnapshot snapshot = serverData.Result;

        var a2 = snapshot.Child($"{_userID}");
        // var a2 = snapshot.Child("highScore: 1111");

        if (a2.Exists == false)
            isExistedNickName = false;
        if (a2.Exists == true)
            isExistedNickName = true;

        Debug.Log(isExistedNickName);
    }
}
