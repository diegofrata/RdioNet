SET VERSION=1.0.2

.nuget\NuGet.exe pack "RdioNet\RdioNet.csproj" -Version %VERSION% -Build -BasePath "RdioNet\bin\Release" -OutputDirectory "RdioNet\bin\Release" -Properties Configuration=Release;Platform=AnyCPU
.nuget\NuGet.exe push "RdioNet\bin\Release\RdioNet.%VERSION%.nupkg"
PAUSE