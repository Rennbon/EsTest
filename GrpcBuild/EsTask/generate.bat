
setlocal

@rem enter this directory
cd /d %~dp0

set TOOLS_PATH=..\..\packages\Grpc.Tools.1.6.0\tools\windows_x64
set DOC_TOOL_PATH=..\Tools

%TOOLS_PATH%\protoc.exe -I./protos --csharp_out build ./protos/ESService.proto --grpc_out build --plugin=protoc-gen-grpc=%TOOLS_PATH%\grpc_csharp_plugin.exe
%TOOLS_PATH%\protoc.exe --plugin=protoc-gen-doc=%DOC_TOOL_PATH%\protoc-gen-doc.exe --doc_out=markdown,ESService.md:./protos/ protos/ESService.proto 

endlocal
