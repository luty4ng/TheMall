using System.Collections.Generic;
using UnityEngine;
using Febucci.UI;
using GameKit.DataStructure;
using GameKit;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

[DisallowMultipleComponent]
[AddComponentMenu("GameKit/Dialog System")]
public class DialogSystem : GameKitComponent
{
    public static bool IsActive = true;
    private DialogTree dialogTree;
    private UI_DialogSystem uI_DialogSystem;
    private UI_Recorder uI_Recorder;
    private TextAnimatorPlayer textAnimatorPlayer;
    private CharacterPool characterPool;
    private List<RuntimeAnimatorController> charaAnimators = new List<RuntimeAnimatorController>();
    private bool isOptionShowing = false;
    private bool isInSelection = false;
    private bool isTextShowing = false;
    public bool isDialoging;

    private UnityAction Callback;

    private void Start()
    {
        uI_DialogSystem = UIManager.instance.GetUI<UI_DialogSystem>("UI_DialogSystem");
        uI_Recorder = UIManager.instance.GetUI<UI_Recorder>("UI_Recorder");
        textAnimatorPlayer = uI_DialogSystem.textAnimatorPlayer;
        AddressableManager.instance.GetAssetAsyn<CharacterPool>("Character Pool", (characterPool) =>
        {
            this.characterPool = characterPool;
        });
    }

    public void StartDialog(string title, string dialogText, UnityAction callback = null)
    {
        isDialoging = true;
        Debug.Log($"Start Dialog");
        isTextShowing = false;
        dialogTree = DialogManager.instance.CreateTree(title, dialogText);
        dialogTree.Reset();
        uI_DialogSystem.Show();
        Callback = callback;
        ExcuteTextDisplay();
    }

    public void StartDialog(string title, UnityAction callback = null)
    {
        AddressableManager.instance.GetAssetsAsyn<DialogAsset>(new List<string> { "DialogPack" }, callback: (IList<DialogAsset> assets) =>
        {
            List<DialogAsset> dialogAssets = new List<DialogAsset>(assets);
            for (int i = 0; i < dialogAssets.Count; i++)
            {
                if (dialogAssets[i].title.Correction() == title.Correction())
                {
                    StartDialog(dialogAssets[i].title, dialogAssets[i].contents, callback);
                    return;
                }
            }
        });
    }

    private void Update()
    {
        if (IsActive == false || dialogTree == null)
        {
            GlobalSound.current.flipping.enabled = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            uI_DialogSystem.Hide();
            dialogTree = null;
            DialogManager.instance.DequeueTree();
        }

        if (!isOptionShowing && isInSelection)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                int choiceIndex = uI_DialogSystem.GetSelection();
                isInSelection = false;
                Node<Dialog> nextNode = GetNextNode(choiceIndex);
                ExcuteTextDisplay();
                uI_DialogSystem.HideResponse(() =>
                {
                    uI_DialogSystem.uI_DialogResponse.IsActive = false;
                    uI_DialogSystem.uI_DialogResponse.gameObject.SetActive(false);
                });
                return;
            }
        }

        if (!isInSelection)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isTextShowing == false)
                {
                    ExcuteTextDisplay();
                }
                else
                    InterruptTextDisplay();
                GlobalSound.current.flipping.enabled = true;
            } else if (Input.GetKeyUp(KeyCode.Space)) GlobalSound.current.flipping.enabled = false;
        }

        uI_DialogSystem.indicator.SetActive(!isTextShowing);
    }

    private void UpdateChoiceUI()
    {
        List<Option> options = dialogTree.GetOptions();
        if (options != null)
        {
            // Debug.Log($"Update Choice UI");
            uI_DialogSystem.UpdateOptions(options);
            uI_DialogSystem.uI_DialogResponse.IsActive = true;
            uI_DialogSystem.uI_DialogResponse.gameObject.SetActive(true);
            isOptionShowing = true;
            isInSelection = true;
            uI_DialogSystem.ShowResponse(() =>
            {
                isOptionShowing = false;
            });

        }
    }

    private void UpdateUI(Node<Dialog> node)
    {
        if (node == null || node.nodeEntity.speaker == "Default")
            return;

        if (node.nodeEntity.speaker == ">>")
            uI_DialogSystem.speakerName.text = "";
        else if (node.nodeEntity.speaker == "??")
            uI_DialogSystem.speakerName.text = "未知";
        else
            uI_DialogSystem.speakerName.text = node.nodeEntity.speaker;
        uI_DialogSystem.contents.text = node.nodeEntity.contents;

        if (node.nodeEntity.speaker != ">>")
        {
            Character character = characterPool.FindCharacter(node.nodeEntity.speaker.Correction());
            uI_DialogSystem.character.sprite = character.GetMood(node.nodeEntity.moodName).avatar;
        }

        uI_Recorder.CreateLine(node);
    }

    private void PhaseNode(Node<Dialog> dialogNode, UnityAction onTextShowed = null)
    {
        UpdateUI(dialogNode);
        textAnimatorPlayer.onTypewriterStart.AddListener(() =>
        {
            isTextShowing = true;
        });
        textAnimatorPlayer.onTextShowed.AddListener(() =>
        {
            isTextShowing = false;
        });

        if (onTextShowed != null)
            textAnimatorPlayer.onTextShowed.AddListener(onTextShowed);

        textAnimatorPlayer.StartShowingText();
    }

    private Node<Dialog> GetNextNode(int index = 0)
    {
        if (dialogTree.currentNode.IsLeaf || index < 0 || index >= dialogTree.currentNode.Sons.Count)
            return null;

        dialogTree.currentNode = dialogTree.currentNode.Sons[index];
        return dialogTree.currentNode as Node<Dialog>;
    }
    private void ExcuteTextDisplay(Node<Dialog> nextNode)
    {
        if (isDialoging == false)
            return;
        if (nextNode == null)
        {
            ReachTheEndOfConversation();
            return;
        }

        if (nextNode.nodeEntity.IsFunctional)
        {
            if (nextNode.nodeEntity.IsCompleter)
            {
                for (int j = 0; j < nextNode.nodeEntity.completeConditons.Count; j++)
                {
                    dialogTree.LocalConditions[nextNode.nodeEntity.completeConditons[j]] = true;
                }
            }

            if (nextNode.nodeEntity.IsDivider)
            {
                bool isComplete = true;
                for (int j = 0; j < nextNode.nodeEntity.dividerConditions.Count; j++)
                {
                    if (!dialogTree.LocalConditions[nextNode.nodeEntity.dividerConditions[j]])
                    {
                        isComplete = false;
                        break;
                    }
                }

                if (isComplete)
                {
                    PhaseNode(GetNextNode(0));
                }
                else
                {
                    PhaseNode(GetNextNode(1));
                }
            }
        }
        else
        {
            if (nextNode.IsBranch)
            {
                PhaseNode(nextNode, UpdateChoiceUI);
            }
            else
            {
                PhaseNode(nextNode);
            }
        }
    }
    private void ExcuteTextDisplay(int index = 0)
    {
        Node<Dialog> nextNode = GetNextNode(index);
        ExcuteTextDisplay(nextNode);
    }

    private void InterruptTextDisplay()
    {
        textAnimatorPlayer.SkipTypewriter();
        isTextShowing = false;
    }

    private void ReachTheEndOfConversation()
    {
        isDialoging = false;
        Debug.Log("Reach The End Of Conversation.");
        dialogTree.Clear();
        dialogTree = null;
        uI_DialogSystem.Hide();
        DialogManager.instance.DequeueTree();
        ClearRecords();
        Callback?.Invoke();
        Callback = null;
    }

    private RuntimeAnimatorController FindAnimator(string name)
    {
        for (int i = 0; i < charaAnimators.Count; i++)
        {
            if (charaAnimators[i].name == "AC_" + name)
            {
                return charaAnimators[i];
            }
        }
        return null;
    }

    public void ClearRecords() => uI_Recorder.ClearLines();
}
