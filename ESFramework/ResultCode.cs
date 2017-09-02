using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ESFramework
{
    public enum ResultCode
    {
        /// <summary>
        ///   操作引发错误
        /// </summary>
        [Description("操作引发错误")]
        Error = 0,

        /// <summary>
        ///   操作成功
        /// </summary>
        [Description("操作成功")]
        Success = 1,

        /// <summary>
        ///   输入信息验证失败
        /// </summary>
        [Description("输入信息验证失败")]
        ValidError = 2,

        /// <summary>
        ///   指定参数的数据不存在
        /// </summary>
        [Description("指定参数的数据不存在")]
        QueryNull = 3,

    }
}
