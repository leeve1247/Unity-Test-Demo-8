using Firebase;
using Firebase.Database;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public void OnClickButton()
    {
        Debug.Log("버튼을 클릭하였다");
        var firebaseScript = gameObject.AddComponent<FirebaseScript>();
        firebaseScript.SendDataToFirebase();
    }
}
