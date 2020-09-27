[CmdletBinding()]
param(
    [switch]$Report,
    [switch]$Download,
    [string]$DownloadPath=".\packages\download",
    [switch]$Upload,
    [string]$UploadSource,
    [string]$Projects="source\**\*.sln",
    [string]$ReportFile=".\asset-report.md",
    [switch]$NoInteractive,
    [switch]$NoRestore
)

$mdFileHeader=@"
# Packaged Dependencies as of $(Get-Date)

| *Package* | *Version* | *URI* |
|----------|-----|--------------------|
"@

Write-Verbose "Retrieving project files - $Projects"
$projectFiles=Get-ChildItem $Projects -Recurse
Write-Verbose "Retrieved $($projectFiles.Count) project(s)"

if(-not $NoRestore) {
    $projectFiles | ForEach-Object {
        Write-Verbose "Restoring - $($_.FullName)"
        if($NoInteractive) {
            dotnet restore "$($_.FullName)"
        } else {
            dotnet restore "$($_.FullName)" --interactive
        }
    }
}

Write-Verbose "Retrieving project.assets.json files"
$assetFiles = Get-ChildItem -Include "project.assets.json" -Recurse
Write-Verbose "Retrieved $($assetFiles.Count) file(s)"

if($Download -and $(Test-Path -Path $DownloadPath -PathType Container)) {
    Remove-Item $DownloadPath -Recurse -Force | Out-Null
}

if (-not $(Test-Path -Path $DownloadPath -PathType Container)) {
    New-Item $DownloadPath -ItemType Directory  | Out-Null
}

$packageNames=@()

$assetFiles.FullName | ForEach-Object {
    $content=$(Get-Content "$($_)" | ConvertFrom-Json)
    $libraries=$content.libraries[0]
    (($libraries `
            | Get-Member).Name `
            | Where-Object { $_ -ne "Equals" -and $_ -ne "GetHashCode" -and $_ -ne  "GetType" -and $_ -ne "ToString" -and "$($_)" -inotlike "Jha*" }) `
        | ForEach-Object {
            if (-not $packageNames.Contains("$($_)")) {
                $packageNames += "$($_)"
            }
    }
}

if($Download) {
    Write-Host "Downloading $($packageNames.Count) package(s)"
}

if($Report) {
    # "=-=-=-=-=-= Asset Report =-=-=-=-=-=" | Out-File $ReportFile -Force
    $mdFileHeader | Out-File $ReportFile -Force
    # "Package`tVersion`tUri" | Out-File $ReportFile -Append
}

$packageNames | ForEach-Object {
    $name=Split-Path $_
    $version=Split-Path $_ -Leaf

    $pkgUri="https://nuget.org/api/v2/package/$name/$version"
    $pageUri="https://www.nuget.org/packages/$name/"

    $pkg="$name.$version.nupkg"
    $pkgDownloadPath=Join-Path -Path $DownloadPath -ChildPath $pkg

    if($Download) {        
        $result=Invoke-WebRequest -uri "$pkgUri" -outfile "$pkgDownloadPath" -PassThru
        if($result.StatusCode -ne "200") {
            Write-Error "Error downloading $pkg"
        }
    }

    if($Report) {
        "| $name | $version | [$pageUri]($pageUri) |" | Out-File $ReportFile -Append
    }
}

if($Upload -and $UploadSource) {
    
    $doUpload=$false

    if($NoInteractive) {
        $doUpload=$true
    }
    else {
        Write-Host "About attempt to publish $($packageNames.Count) packages to $UploadSource."
        $answer=Read-Host "Continue? ( y / N )"

        switch($answer) {
            y { $doUpload=$true }
            default { $doUpload=$false }
        }
    }

    if($doUpload) {
        Get-ChildItem -Path $DownloadPath -Filter *.nupkg | ForEach-Object {
            if($NoInteractive) {
                dotnet nuget push "$($_.FullName)" --source "$UploadSource" --api-key "upload"
            } else {
                dotnet nuget push "$($_.FullName)" --source "$UploadSource" --api-key "upload" --interactive
            }
        }
    }
}
    
    


# $(gci project.assets.json -Recurse).FullName
# get-content Jha.Edpp.WebHost\obj\project.assets.json | convertfrom-json
# $(($obj.libraries[0] | gm).Name | Where-Object { $_ -ne "Equals" -and $_ -ne "GetHashCode" -and $_ -ne  "GetType" -and $_ -ne "ToString" })
# $(gci "project.assets.json" -Recurse).FullName | ForEach-Object { $(((get-content $_ | convertfrom-json).libraries[0] | gm ).name | where-object { $_ -ne "Equals" -and $_ -ne "GetHashCode" -and $_ -ne  "GetType" -and $_ -ne "ToString" }) | ForEach-Object { Invoke-WebRequest -uri "https://nuget.org/api/v2/package/$($_)" -outfile ".\nuget\$(Split-Path $_).$(Split-Path $_ -Leaf).nupkg" -PassThru } }
# $(gci "project.assets.json" -Recurse).FullName | ForEach-Object { $(((get-content $_ | convertfrom-json).libraries[0] | gm ).name | where-object { $_ -ne "Equals" -and $_ -ne "GetHashCode" -and $_ -ne  "GetType" -and $_ -ne "ToString" }) | ForEach-Obje




