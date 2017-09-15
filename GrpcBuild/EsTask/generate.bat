
setlocal

@rem enter this directory
cd /d %~dp0

set TOOLS_PATH=..\..\packages\Grpc.Tools.1.6.0\tools\windows_x64

%TOOLS_PATH%\protoc.exe -I./protos --csharp_out build ./protos/ESTest.proto --grpc_out build --plugin=protoc-gen-grpc=%TOOLS_PATH%\grpc_csharp_plugin.exe


endlocal
