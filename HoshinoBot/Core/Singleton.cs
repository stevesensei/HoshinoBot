using System.Diagnostics;

namespace HoshinoBot.Core;

/// <summary>
/// 单例模式
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> where T : Singleton<T>, new()
{
    protected Singleton() => Trace.Assert(Instance is null, // (运行时)检查: 防止外部代码创建实例
        $"You can't create new instance for a Singleton! \r Please use {typeof(T).Name}.Instance to Access it.");
    public static T Instance { get; private set; }
    static Singleton() => Instance = new T();     // 静态构造函数,无需加锁.
}
