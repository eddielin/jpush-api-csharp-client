
using JPush.Api.Utils;
using System;
using System.Text.RegularExpressions;
namespace JPush.Api.Push
{
    /// <summary>
    /// 一个 SomeType 的可视化工具。  
    /// </summary>
    public class PushPayload
    {
    }

    enum PushPayloadKeyDefined
    {
        //PLATFORM = "platform",
        //AUDIENCE = "audience",
        //NOTIFICATION = "notification",
        //MESSAGE = "message",
        //OPTIONS = "options"
    }

    enum Platform
    {
        [EnumDescription("android")]
        Android = 1,
        [EnumDescription("ios")]
        iOS = 2,
        [EnumDescription("winphone")]
        WinPhone = 3,
        [EnumDescription("all")]
        All = 0
    }
}
