using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageRecognition : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;

    // �ϥΰ}�C�Ӻ޲z�h�� prefab
    public GameObject[] prefabs;  // �N�Ҧ��� prefab �s�J�}�C

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
        // �B�z�s�W���Ϲ�
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            // �ھڹϹ��W�ٿ�ܥ��T�� prefab
            int index = GetPrefabIndex(trackedImage.referenceImage.name);
            if (index != -1 && index < prefabs.Length)
            {
                // �s�W������ 3D ����
                Instantiate(prefabs[index], trackedImage.transform.position, trackedImage.transform.rotation, trackedImage.transform);
            }
        }

        // �B�z��s���Ϲ�
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            // ��s 3D ���󪺦�m
            if (trackedImage.transform.childCount > 0)
            {
                var obj = trackedImage.transform.GetChild(0);
                obj.position = trackedImage.transform.position;
                obj.rotation = trackedImage.transform.rotation;
            }
        }

        // �B�z�Q�������Ϲ�
        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            // ���� 3D ����
            if (trackedImage.transform.childCount > 0)
            {
                Destroy(trackedImage.transform.GetChild(0).gameObject);
            }
        }
    }

    // �ھڹϹ��W�٪�^������ prefab ����
    int GetPrefabIndex(string imageName)
    {
        switch (imageName)
        {
            case "firstARimage": // �Ϲ��w�����Ĥ@�i�Ϫ��W��
                return 0;    // ������ prefabs[0]
            case "wusha": // �Ϲ��w�����ĤG�i�Ϫ��W��
                return 1;    // ������ prefabs[1]
            // �i�̷ӻݨD�~��K�[��h�Ϲ�
            default:
                return -1;   // �p�G�S���������Ϲ��A��^ -1
        }
    }
}
