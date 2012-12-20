..\NuGet.exe pack "RdioNet\RdioNet.csproj" -Build -BasePath "RdioNet\bin\Release" -OutputDirectory "RdioNet\bin\Release" -Properties Configuration=Release;Platform=AnyCPU
..\NuGet.exe push "RdioNet\bin\Release\RdioNet.1.0.2.nupkg"
PAUSE