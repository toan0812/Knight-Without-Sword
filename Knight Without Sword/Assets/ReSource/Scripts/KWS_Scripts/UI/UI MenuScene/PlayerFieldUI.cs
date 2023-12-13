using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFieldUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Button btn_Next;
    [SerializeField] private Button btn_before;
    [Header("Properties")]
    [SerializeField] private UnityEditor.Animations.AnimatorController baseChacterAnimator;
    [SerializeField] private Sprite baseChacterSprite;
    [SerializeField] private List<CharactersProperties> charactersProperties = new List<CharactersProperties>();
    [Header("prefabs")]
    [SerializeField] private GameObject characterPrefab;
    [SerializeField] private Transform parent;
    private void Awake()
    {
        characterPrefab.SetActive(false);
        
        charactersProperties[0] = new CharactersProperties(baseChacterAnimator, baseChacterSprite);
    }
    void Start()
    {
        SpawnListChacter();
        btn_Next.onClick.AddListener(() => { });
        btn_before.onClick.AddListener(() => { });
    }

    private void SpawnListChacter()
    {
        for(int i = 0;i< charactersProperties.Count; i++)
        {
            var characterUI = Instantiate(characterPrefab, parent);
            characterUI.GetComponent<Image>().sprite = charactersProperties[i].sprite;
            characterUI.GetComponent<Animator>().runtimeAnimatorController = charactersProperties[i].animator;
            characterUI.SetActive(true);
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
