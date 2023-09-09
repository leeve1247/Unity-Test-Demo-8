using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;
using UnityEngine.Events;

public class FirebaseScript : MonoBehaviour
{
    public UnityEvent OnfirebaseInitialized = new UnityEvent();
    // ㅎㅔ헤 주석
    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
            {
                Debug.LogError($"Failed to initialize Firebase with {task.Exception}");
                return;
            }
            OnfirebaseInitialized.Invoke();
        });
    }
    
    public void SendDataToFirebase()
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        reference.Child("your_data_node").Push().SetValueAsync("YourDataToSend");
    }
}


