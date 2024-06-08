using HoshinoBot.Core;

namespace HoshinoBot.Manager;

public class EventManager: Singleton<EventManager>
{
    public event Action<BotType> OnBotFinishTask;
    public void BotFinishTask(BotType type)
    {
        OnBotFinishTask.Invoke(type);
    }
}