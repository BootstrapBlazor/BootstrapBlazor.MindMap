// ********************************** 
// Densen Informatica 中讯科技 
// 作者：Alex Chow
// e-mail:zhouchuanglin@gmail.com 
// **********************************

using System.ComponentModel;
using System.Text.Json.Serialization;

namespace BootstrapBlazor.Components;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EnumMindMapLayout
{
    /// <summary>
    /// 逻辑结构图
    /// </summary>
    [Description("逻辑结构图")]
    logicalStructure,

    /// <summary>
    /// 思维导图
    /// </summary>
    [Description("思维导图")]
    mindMap,

    /// <summary>
    /// 组织结构图
    /// </summary>
    [Description("组织结构图")]
    organizationStructure,

    /// <summary>
    /// 目录组织图
    /// </summary>
    [Description("目录组织图")]
    catalogOrganization,

    /// <summary>
    /// 时间轴
    /// </summary>
    [Description("时间轴")]
    timeline,

    /// <summary>
    /// 时间轴2
    /// </summary>
    [Description("时间轴2")]
    timeline2,

    /// <summary>
    /// 鱼骨图
    /// </summary>
    [Description("鱼骨图")]
    fishbone,

    /// <summary>
    /// 竖向时间轴
    /// </summary>
    [Description("竖向时间轴")]
    verticalTimeline
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EnumMindMapTheme
{
    defaultTheme,
    freshGreen,
    blueSky,
    brainImpairedPink,
    romanticPurple,
    freshRed,
    earthYellow,
    classic,
    classic2,
    classic3,
    classic4,
    dark,
    classicGreen,
    classicBlue,
    minions,
    pinkGrape,
    mint,
    gold,
    vitalityOrange,
    greenLeaf,
    dark2,
    skyGreen,
    simpleBlack,
    courseGreen,
    coffee,
    redSpirit,
    blackHumour,
    lateNightOffice,
    blackGold,
    avocado,
    autumn,
    orangeJuice
}
