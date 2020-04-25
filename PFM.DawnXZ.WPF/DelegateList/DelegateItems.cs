using System;

namespace PFM.DawnXZ.WPF.DelegateList
{
    /// <summary>
    /// 模块扩展通用委托
    /// </summary>
    /// <param name="isChild">是否为模块子控件</param>
    /// <param name="nameItems">模块名称标识</param>
    public delegate void ModuleExtendEventHandler(bool isChild, PFM.DawnXZ.Library.Transit.NameItems nameItems);
    /// <summary>
    /// 报表模块专用委托
    /// </summary>
    /// <param name="rptId">报表编号</param>
    public delegate void ReportViewEventHandler(long rptId);
    /// <summary>
    /// 委托项目
    /// </summary>
    public class DelegateItems
    {

    }
}
