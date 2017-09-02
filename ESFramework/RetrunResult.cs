using System;
using System.Collections.Generic;
using System.Text;

namespace ESFramework
{
    public class ReturnResult : RetrunResult<object>
    {
        #region 构造函数

        /// <summary>
        /// 初始化一个<see cref="ReturnResult"/>类型的新实例
        /// </summary>
        public ReturnResult(ResultCode resultType)
            : this(resultType, null, null)
        {
        }

        /// <summary>
        /// 初始化一个<see cref="ReturnResult"/>类型的新实例
        /// </summary>
        public ReturnResult(ResultCode resultType, string message)
            : this(resultType, message, null)
        { }

        /// <summary>
        /// 初始化一个<see cref="ReturnResult"/>类型的新实例
        /// </summary>
        public ReturnResult(ResultCode resultType, string message, object data)
            : base(resultType, message, data)
        { }
        #endregion
    }

    /// <summary>
    /// 泛型版本的业务操作结果信息类，对操作结果进行封装
    /// </summary>
    /// <typeparam name="T">返回数据的类型</typeparam>
    public class RetrunResult<T>
    {
        /// <summary>
        /// 初始化一个<see cref="RetrunResult{T}"/>类型的新实例
        /// </summary>
        public RetrunResult(ResultCode code)
            : this(code, null, default(T))
        { }

        /// <summary>
        /// 初始化一个<see cref="RetrunResult{T}"/>类型的新实例
        /// </summary>
        public RetrunResult(ResultCode code, string msg)
            : this(code, msg, default(T))
        { }

        /// <summary>
        /// 初始化一个<see cref="RetrunResult{T}"/>类型的新实例
        /// </summary>
        public RetrunResult(ResultCode code, string msg, T data)
        {
            this.code = code;
            this.msg = msg;
            this.data = data;
        }

        /// <summary>
        /// 获取或设置 操作结果类型
        /// </summary>
        public ResultCode code { get; set; }

        /// <summary>
        /// 获取或设置 操作返回消息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 获取或设置 操作返回数据
        /// </summary>
        public T data { get; set; }
    }
}
