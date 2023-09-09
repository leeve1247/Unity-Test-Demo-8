using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScripts : MonoBehaviour
{
    public Camera mainCamera;

    // 카메라 높이의 중간 지점
    private float cameraMiddleY;
    
    private Rigidbody rb;

    void Start()
    {
        // 카메라의 높이를 기준으로 중간 지점 계산
        cameraMiddleY = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0)).y;
        
        // Rigidbody 컴포넌트를 가져옴
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        // 뷰포트 좌표가 (0,0)보다 작거나 (1,1)보다 크면 화면 밖으로 나갔다고 판단
        if (viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1)
        {
            // 화면 밖으로 나갔으므로 위치와 회전을 재설정
            Vector3 newPosition = transform.position;
            
            // X 좌표는 카메라 중앙으로, Y 좌표는 카메라 높이의 중간으로 설정
            newPosition.x = mainCamera.transform.position.x;
            newPosition.y = cameraMiddleY;

            transform.position = newPosition;

            // 회전을 초기화
            transform.rotation = Quaternion.identity;

            // Rigidbody의 속도를 초기화
            rb.velocity = Vector3.zero;
        }
    }
}
