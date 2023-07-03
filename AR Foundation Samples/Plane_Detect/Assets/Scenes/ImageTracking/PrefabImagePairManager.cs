// using System;
// using System.Collections;
// using System.Collections.Generic;
// #if UNITY_EDITOR
// using UnityEditor;
// #endif
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.XR.ARFoundation;
// using UnityEngine.XR.ARSubsystems;


// [RequireComponent(typeof(ARTrackedImageManager))]
// public class PrefabImagePairManager : MonoBehaviour, ISerializationCallbackReceiver
// {
//     [Serializable]
//     struct NamedPrefab{
//         public string imageGuid;
//         public GameObject imagePrefab;

//         public NamedPrefab(Guid guid, GameObject prefab){
//             imageGuid = guid.ToString();
//             imagePrefab = prefab;
//         }
//     }

//     [SerializeField]
//     [HideInInspector]
//     List<NamedPrefab> m_PrefabsList = new List<NamedPrefab>();

//     Dictionary<Guid, GameObject> m_PrefabsDictionary = new Dictionary<Guid, GameObject>();
//     Dictionary<Guid, GameObject> m_Instantiated = new Dictionary<Guid, GameObject>();
//     ARTrackedImageManager m_TrackedImageManager;

//     [SerializeField]
//     [Tooltip("Reference Image Library")]
//     XRReferenceImageLibrary m_ImageLibrary;

//     public XRReferenceImageLibrary imageLibrary{
//         get => m_ImageLibrary;
//         set => m_ImageLibrary = value;
//     }

//     public void OnBeforeSerialize(){
//         m_PrefabsList.Clear();
//         foreach(var kvp in m_PrefabsDictionary){
//             m_PrefabsList.Add(new NamedPrefab(kvp.Key, kvp.Value));
//         }
//     }

//     public void OnAfterDeserialize(){
//         m_PrefabsDictionary = new Dictionary<Guid, GameObject>();
//         foreach (var entry in m_PrefabsList){
//             m_PrefabsDictionary.Add(Guid.Parse(entry.imageGuid), entry.imagePrefab);
//         }
//     }

//     // void Awake(){
//     //     m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
//     // }

//     // void OnEnalbe(){
//     //     m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
//     // }

//     // void OnDisable(){
//     //     m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
//     // }

//     // void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs){
//     //     foreach(var trackedImage in EventArgs.added){
//     //         var minLocalScalar = Mathf.Min(trackedImage.size.x, trackedImage.size.y)/z;
//     //         trackedImage.transform.localScale = new Vector3(minLocalScalar,minLocalScalar,minLocalScalar);
//     //         AssignPrefab(trackedImage);
//     //     }

//     // }
// }


// #if UNITY_EDITOR
//     [CustomEditor(typeof(PrefabImagePairManager))]
//     class PrefabImagePairManagerInspector : Editor {
//         List<XRReferenceImage> m_ReferenceImages = new List<XRReferenceImage>();
//         bool m_IsExpanded = true;

//         bool HasLibraryChanged(XRReferenceImageLibrary library){
//             if(library == null)
//                 return m_ReferenceImages.Count == 0;
//             if(m_ReferenceImages.Count != library.count)
//                 return true;

//             for(int i=0; i<library.count; i++){
//                 if(m_ReferenceImages[i] != library[i])
//                     return true;
//             }

//             return false;
//         }
//     }
// #endif