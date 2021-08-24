
$srcDirectory=Join-Path $PSScriptRoot -ChildPath "..\src" -Resolve

Get-ChildItem "$srcDirectory" -Recurse -Include "bin","obj",".vs","*.csproj.user" -Exclude ".git" | Remove-Item -Recurse -Force -Verbose