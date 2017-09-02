using System;
using System.Collections.Generic;
using System.Text;

namespace EsEntity.TaskCenterMethod
{
    public class TaskMethed:TaskCenter.Task
    {
        public EsEnum.TaskCenter.TaskMethodEnum Methed { set; get; }
    }
}
