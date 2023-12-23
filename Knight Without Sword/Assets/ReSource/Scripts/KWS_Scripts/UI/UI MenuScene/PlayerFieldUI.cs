using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerFieldUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private ButtonScrollView btn_Next;
    [SerializeField] private ButtonScrollView btn_before;
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private float scrollRectSpeed = 1f;
    [Header("Properties")]
    [SerializeField] private UnityEditor.Animations.AnimatorController baseChacterAnimator;
    [SerializeField] private Sprite baseChacterSprite;
    [SerializeField] private List<CharactersProperties> charactersProperties = new List<CharactersProperties>();
    [Header("prefabs")]
    [SerializeField] private GameObject characterPrefab;
    [SerializeField] private Transform parent;
    [Header("SO")]
    [SerializeField] private List<PlayerSO> characterSOs = new List<PlayerSO>();
    private List<GameObject> characterObjects = new List<GameObject>();

    private void Awake()
    {
        charactersProperties[0] = new CharactersProperties(baseChacterAnimator, baseChacterSprite);
    }
    
    private void Update()
    {
        if(btn_Next!= null)
        {
            if(btn_Next.isDown)
            {
                if (scrollRect != null)
                {
                    if (scrollRect.horizontalNormalizedPosition <= 1f)
                    {
                        scrollRect.horizontalNormalizedPosition += scrollRectSpeed;
                    }
                }
            }
        }  
        if(btn_before != null)
        {
            if(btn_before.isDown)
            {
                if (scrollRect != null)
                {
                    if (scrollRect.horizontalNormalizedPosition >= 0f)
                    {
                        scrollRect.horizontalNormalizedPosition -= scrollRectSpeed;
                    }
                }
            }
        }
    }
    void Start()
    {
        SpawnListChacter();
    }

    private void SpawnListChacter()
    {
        for(int i = 0;i< characterSOs.Count; i++)
        {
            var characterUI = Instantiate(characterPrefab, parent);
            characterUI.GetComponentInChildren<Image>().sprite = characterSOs[i].prefabImage;
            characterUI.GetComponentInChildren<Animator>().runtimeAnimatorController = charactersProperties[i].animator;
            characterUI.GetComponent<CharacterUI>().characterSO = characterSOs[i];
            characterUI.SetActive(true);
            characterObjects.Add(characterUI);
        }
    }
    [System.Serializable]
    public class CharactersProperties 
    {
        public UnityEditor.Animations.AnimatorController animator;
        public Sprite sprite;

        public CharactersProperties(UnityEditor.Animations.AnimatorController animator, Sprite sprite)
        {
            this.animator = animator;
            this.sprite = sprite;
        }
    }
}
