using System;
using System.Collections.Generic;
using System.Text;

namespace EsEnum.TaskCenter
{
    public enum FolderMethodEnum
    {
        Set_UpdateTime = 1,
        Set_CreateAccountId = 2,

        Set_FolderName = 3,
        Set_Visibility = 4,
        Set_GroupIds = 5,
        Set_Content = 6,

        Pull_MemberIds = 7,
        Push_MemberIds = 8,
    }
}
