# Protocol Documentation
<a name="top"/>

## Table of Contents

- [ESService.proto](#ESService.proto)
    - [AddAttachmentsIntoTaskRequest](#Elasticsearch.AddAttachmentsIntoTaskRequest)
    - [AddTaskDiscussionInTaskRequest](#Elasticsearch.AddTaskDiscussionInTaskRequest)
    - [AddTasksRequest](#Elasticsearch.AddTasksRequest)
    - [Attachment](#Elasticsearch.Attachment)
    - [ExecuteResult](#Elasticsearch.ExecuteResult)
    - [RemoveAttachmentsInTaskRequest](#Elasticsearch.RemoveAttachmentsInTaskRequest)
    - [RemoveTaskDiscussionRequest](#Elasticsearch.RemoveTaskDiscussionRequest)
    - [RemoveTasksByFolderIdRequest](#Elasticsearch.RemoveTasksByFolderIdRequest)
    - [RemoveTasksByTaskIdsRequest](#Elasticsearch.RemoveTasksByTaskIdsRequest)
    - [SearchTasksRequest](#Elasticsearch.SearchTasksRequest)
    - [SearchTasksResult](#Elasticsearch.SearchTasksResult)
    - [Task](#Elasticsearch.Task)
    - [TaskDto](#Elasticsearch.TaskDto)
    - [TaskMethod](#Elasticsearch.TaskMethod)
    - [UnlockFolderAndTasksRequest](#Elasticsearch.UnlockFolderAndTasksRequest)
    - [UpdateTasksFolderNameByFolderIdRequest](#Elasticsearch.UpdateTasksFolderNameByFolderIdRequest)
    - [UpdateTasksRequest](#Elasticsearch.UpdateTasksRequest)
  
    - [TaskMethod.Method](#Elasticsearch.TaskMethod.Method)
  
  
    - [ESService](#Elasticsearch.ESService)
  

- [Scalar Value Types](#scalar-value-types)



<a name="ESService.proto"/>
<p align="right"><a href="#top">Top</a></p>

## ESService.proto



<a name="Elasticsearch.AddAttachmentsIntoTaskRequest"/>

### AddAttachmentsIntoTaskRequest
添加附件


| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| taskId | [string](#string) |  | 任务id |
| atts | [Attachment](#Elasticsearch.Attachment) | repeated | 附件集合 |






<a name="Elasticsearch.AddTaskDiscussionInTaskRequest"/>

### AddTaskDiscussionInTaskRequest
添加讨论


| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| taskId | [string](#string) |  | 任务id |
| discId | [string](#string) |  | 讨论id |
| message | [string](#string) |  | 讨论内容 |
| mentionedAIds | [string](#string) | repeated | @到的人 |






<a name="Elasticsearch.AddTasksRequest"/>

### AddTasksRequest
批量增加任务


| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| tasks | [Task](#Elasticsearch.Task) | repeated | 任务集合 |






<a name="Elasticsearch.Attachment"/>

### Attachment
附件


| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| fileId | [string](#string) |  | 附件id |
| content | [string](#string) |  | 附件内容 |






<a name="Elasticsearch.ExecuteResult"/>

### ExecuteResult
操作执行结果


| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| code | [int32](#int32) |  | 执行结果 |
| msg | [string](#string) |  | 信息 |






<a name="Elasticsearch.RemoveAttachmentsInTaskRequest"/>

### RemoveAttachmentsInTaskRequest
删除附件


| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| taskId | [string](#string) |  | 任务id |
| fileIds | [string](#string) | repeated | 附件id集合 |






<a name="Elasticsearch.RemoveTaskDiscussionRequest"/>

### RemoveTaskDiscussionRequest
删除讨论


| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| taskId | [string](#string) |  | 任务id |
| discId | [string](#string) |  | 讨论id |






<a name="Elasticsearch.RemoveTasksByFolderIdRequest"/>

### RemoveTasksByFolderIdRequest
批量根据项目id伪删除任务


| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| folderId | [string](#string) |  | 项目id |






<a name="Elasticsearch.RemoveTasksByTaskIdsRequest"/>

### RemoveTasksByTaskIdsRequest
批量根据任务id伪删除任务


| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| taskIds | [string](#string) | repeated | 任务id集合 |






<a name="Elasticsearch.SearchTasksRequest"/>

### SearchTasksRequest
任务搜索


| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| currentAId | [string](#string) |  | 操作用户 |
| relationAIds | [string](#string) | repeated | 关联用户 |
| keyword | [string](#string) |  | 关键字 |
| projectId | [string](#string) |  | 网络id（与好友协作：&#34;&#34;,全部网络&#34;all&#34;） |
| isPaid | [bool](#bool) |  | 是否付费 |
| pageIndex | [int32](#int32) |  | 请求页码 |
| pageSize | [int32](#int32) |  | 请求页面尺寸 |
| startTime | [int64](#int64) |  | 开始时间（没有开始时间:0） |
| endTime | [int64](#int64) |  | 截止时间（没有截止时间:0） |
| preTags | [string](#string) |  | 高亮前缀 |
| postTags | [string](#string) |  | 高亮后缀 |






<a name="Elasticsearch.SearchTasksResult"/>

### SearchTasksResult
任务搜索返回值


| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| code | [int32](#int32) |  | 执行结果 |
| msg | [string](#string) |  | 信息 |
| tasks | [TaskDto](#Elasticsearch.TaskDto) | repeated | 任务集合 |






<a name="Elasticsearch.Task"/>

### Task
任务


| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| taskId | [string](#string) |  | 任务id |
| taskName | [string](#string) |  | 任务名 |
| folderId | [string](#string) |  | 项目id |
| folderName | [string](#string) |  | 项目名 |
| parentId | [string](#string) |  | 母任务id |
| content | [string](#string) |  | 任务详情 |
| startTime | [int64](#int64) |  | 开始时间（无：0） |
| endTime | [int64](#int64) |  | 截止时间（无：0） |
| chargeAId | [string](#string) |  | 负责人id |
| status | [int32](#int32) |  | 任务状态 |
| completeTime | [int64](#int64) |  | 完成时间（无：0） |
| memberIds | [string](#string) | repeated | 成员id集合 |
| keywords | [string](#string) | repeated | 控件关键字 |
| appId | [string](#string) |  | appId |
| isDeleted | [bool](#bool) |  | 是否已删除 |
| updateTime | [int64](#int64) |  | 变更时间 |
| createTime | [int64](#int64) |  | 创建时间 |
| projectId | [string](#string) |  | 网络id |
| createAId | [string](#string) |  | 创建者id |






<a name="Elasticsearch.TaskDto"/>

### TaskDto
任务返回信息


| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| taskId | [string](#string) |  | 任务id |
| createAid | [string](#string) |  | 创建者id |
| taskName | [string](#string) |  | 任务名 |
| content | [string](#string) |  | 任务内容 |
| projectId | [string](#string) |  | 网络Id |
| createTime | [int64](#int64) |  | 创建时间 |






<a name="Elasticsearch.TaskMethod"/>

### TaskMethod



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| method | [TaskMethod.Method](#Elasticsearch.TaskMethod.Method) |  | 修改类型枚举 |
| task | [Task](#Elasticsearch.Task) |  | 任务实体 |






<a name="Elasticsearch.UnlockFolderAndTasksRequest"/>

### UnlockFolderAndTasksRequest
解锁项目下所有任务的关系(将指定项目下的所有任务中冗余的folderid和foldername清空)


| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| folderId | [string](#string) |  | 项目id |






<a name="Elasticsearch.UpdateTasksFolderNameByFolderIdRequest"/>

### UpdateTasksFolderNameByFolderIdRequest
批量修改指定项目id的所有任务冗余项目名


| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| folderId | [string](#string) |  | 项目id |
| folderName | [string](#string) |  | 项目名称 |






<a name="Elasticsearch.UpdateTasksRequest"/>

### UpdateTasksRequest
修改任务


| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| methods | [TaskMethod](#Elasticsearch.TaskMethod) | repeated | 修改任务对照表 |





 


<a name="Elasticsearch.TaskMethod.Method"/>

### TaskMethod.Method
修改类型枚举

| Name | Number | Description |
| ---- | ------ | ----------- |
| Default | 0 | 无效 |
| Set_UpdateTime | 1 | 替换UpdateTime |
| Set_CreateAccountId | 2 | 替换CreateAccountId |
| Set_TaskName | 3 | 替换TaskName |
| Set_FolderId | 4 | 替换FolderId |
| Set_FolderName | 5 | 替换FolderName |
| Set_ParentId | 6 | 替换ParentId |
| Set_Content | 7 | 替换Content |
| Set_StartTime | 8 | 替换StartTime |
| Set_EndTime | 9 | 替换EndTime |
| Set_Charge | 10 | 替换Charge |
| Set_Status | 11 | 替换Status |
| Set_CompleteTime | 12 | 替换CompleteTime |
| Set_Keywords | 13 | 替换Keywords |
| Pull_MemberIds | 14 | 删除指定memberIds |
| Push_MemberIds | 15 | 添加指定memberIds |


 

 


<a name="Elasticsearch.ESService"/>

### ESService


| Method Name | Request Type | Response Type | Description |
| ----------- | ------------ | ------------- | ------------|
| SearchTasks | [SearchTasksRequest](#Elasticsearch.SearchTasksRequest) | [SearchTasksResult](#Elasticsearch.SearchTasksRequest) | 发送讨论 |
| AddAttachmentsIntoTask | [AddAttachmentsIntoTaskRequest](#Elasticsearch.AddAttachmentsIntoTaskRequest) | [ExecuteResult](#Elasticsearch.AddAttachmentsIntoTaskRequest) | 添加附件 |
| RemoveAttachmentsInTask | [RemoveAttachmentsInTaskRequest](#Elasticsearch.RemoveAttachmentsInTaskRequest) | [ExecuteResult](#Elasticsearch.RemoveAttachmentsInTaskRequest) | 删除附件 |
| AddTaskDiscussionInTask | [AddTaskDiscussionInTaskRequest](#Elasticsearch.AddTaskDiscussionInTaskRequest) | [ExecuteResult](#Elasticsearch.AddTaskDiscussionInTaskRequest) | 添加讨论 |
| RemoveTaskDiscussion | [RemoveTaskDiscussionRequest](#Elasticsearch.RemoveTaskDiscussionRequest) | [ExecuteResult](#Elasticsearch.RemoveTaskDiscussionRequest) | 删除讨论 |
| UpdateTasks | [UpdateTasksRequest](#Elasticsearch.UpdateTasksRequest) | [ExecuteResult](#Elasticsearch.UpdateTasksRequest) | 修改任务 |
| AddTasks | [AddTasksRequest](#Elasticsearch.AddTasksRequest) | [ExecuteResult](#Elasticsearch.AddTasksRequest) | 批量增加任务 |
| RemoveTasksByTaskIds | [RemoveTasksByTaskIdsRequest](#Elasticsearch.RemoveTasksByTaskIdsRequest) | [ExecuteResult](#Elasticsearch.RemoveTasksByTaskIdsRequest) | 批量根据任务id伪删除任务 |
| RemoveTasksByFolderId | [RemoveTasksByFolderIdRequest](#Elasticsearch.RemoveTasksByFolderIdRequest) | [ExecuteResult](#Elasticsearch.RemoveTasksByFolderIdRequest) | 批量根据项目id伪删除任务 |
| UpdateTasksFolderNameByFolderId | [UpdateTasksFolderNameByFolderIdRequest](#Elasticsearch.UpdateTasksFolderNameByFolderIdRequest) | [ExecuteResult](#Elasticsearch.UpdateTasksFolderNameByFolderIdRequest) | 批量修改指定项目id的所有任务冗余项目名 |
| UnlockFolderAndTasks | [UnlockFolderAndTasksRequest](#Elasticsearch.UnlockFolderAndTasksRequest) | [ExecuteResult](#Elasticsearch.UnlockFolderAndTasksRequest) | 解锁项目下所有任务的关系(将指定项目下的所有任务中冗余的folderid和foldername清空) |

 



## Scalar Value Types

| .proto Type | Notes | C++ Type | Java Type | Python Type |
| ----------- | ----- | -------- | --------- | ----------- |
| <a name="double" /> double |  | double | double | float |
| <a name="float" /> float |  | float | float | float |
| <a name="int32" /> int32 | Uses variable-length encoding. Inefficient for encoding negative numbers – if your field is likely to have negative values, use sint32 instead. | int32 | int | int |
| <a name="int64" /> int64 | Uses variable-length encoding. Inefficient for encoding negative numbers – if your field is likely to have negative values, use sint64 instead. | int64 | long | int/long |
| <a name="uint32" /> uint32 | Uses variable-length encoding. | uint32 | int | int/long |
| <a name="uint64" /> uint64 | Uses variable-length encoding. | uint64 | long | int/long |
| <a name="sint32" /> sint32 | Uses variable-length encoding. Signed int value. These more efficiently encode negative numbers than regular int32s. | int32 | int | int |
| <a name="sint64" /> sint64 | Uses variable-length encoding. Signed int value. These more efficiently encode negative numbers than regular int64s. | int64 | long | int/long |
| <a name="fixed32" /> fixed32 | Always four bytes. More efficient than uint32 if values are often greater than 2^28. | uint32 | int | int |
| <a name="fixed64" /> fixed64 | Always eight bytes. More efficient than uint64 if values are often greater than 2^56. | uint64 | long | int/long |
| <a name="sfixed32" /> sfixed32 | Always four bytes. | int32 | int | int |
| <a name="sfixed64" /> sfixed64 | Always eight bytes. | int64 | long | int/long |
| <a name="bool" /> bool |  | bool | boolean | boolean |
| <a name="string" /> string | A string must always contain UTF-8 encoded or 7-bit ASCII text. | string | String | str/unicode |
| <a name="bytes" /> bytes | May contain any arbitrary sequence of bytes. | string | ByteString | str |

