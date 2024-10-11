using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageRecognition : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;

    // 使用陣列來管理多個 prefab
    public GameObject[] prefabs;  // 將所有的 prefab 存入陣列

    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    void OnImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        // 處理新增的圖像
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            // 根據圖像名稱選擇正確的 prefab
            int index = GetPrefabIndex(trackedImage.referenceImage.name);
            if (index != -1 && index < prefabs.Length)
            {
                // 新增對應的 3D 物件
                Instantiate(prefabs[index], trackedImage.transform.position, trackedImage.transform.rotation, trackedImage.transform);
            }
        }

        // 處理更新的圖像
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            // 更新 3D 物件的位置
            if (trackedImage.transform.childCount > 0)
            {
                var obj = trackedImage.transform.GetChild(0);
                obj.position = trackedImage.transform.position;
                obj.rotation = trackedImage.transform.rotation;
            }
        }

        // 處理被移除的圖像
        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            // 移除 3D 物件
            if (trackedImage.transform.childCount > 0)
            {
                Destroy(trackedImage.transform.GetChild(0).gameObject);
            }
        }
    }

    // 根據圖像名稱返回對應的 prefab 索引
    int GetPrefabIndex(string imageName)
    {
        switch (imageName)
        {
            case "firstARimage": // 圖像庫中的第一張圖的名稱
                return 0;    // 對應到 prefabs[0]
            case "wusha": // 圖像庫中的第二張圖的名稱
                return 1;    // 對應到 prefabs[1]
            // 可依照需求繼續添加更多圖像
            default:
                return -1;   // 如果沒有對應的圖像，返回 -1
        }
    }
}
