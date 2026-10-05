using UnityEngine;

public class AssayerSegment : Interactable, InteractInterface
{
    public AssayerStoryStates state;
    public EncounterDialog dialog1;
    public void OnInteract()
    {
        switch (state)
        {
            case AssayerStoryStates.NULL:
                state = AssayerStoryStates.TALKING_TO_ASSAYER;
                SmileYourDayTaskList.instance.fpc.DisplayDialog(dialog1, transform);
                break;
            case AssayerStoryStates.TALKING_TO_ASSAYER:
                if(SmileYourDayTaskList.instance.slateObtained)
                {

                }
                state = AssayerStoryStates.ASSAYER_WAITING_FOR_SLATES;
                break;
            case AssayerStoryStates.ASSAYER_CALLS_GUARDS:
                break;
            case AssayerStoryStates.ASSAYER_ALLOWS_PROCEDURE:
                break;
            default:
                break;
        }
    }
}

public enum AssayerStoryStates
{
    NULL,
    TALKING_TO_ASSAYER,
    ASSAYER_CALLS_GUARDS,
    ASSAYER_ALLOWS_PROCEDURE,
    ASSAYER_WAITING_FOR_SLATES,
}
