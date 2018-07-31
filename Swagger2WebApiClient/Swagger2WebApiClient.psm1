function WebApiClient-Generate-Invoke{

	$project = Get-Project
	$projectPath = [System.IO.Path]::GetDirectoryName($project.FullName)
	$root = (Join-Path $projectPath "WebApiClient\").ToString()
	$taskPath = ($project.Object.References | where {$_.Identity -eq 'Swagger2WebApiClient'} | Select-Object -first 1).Path

	$generateJob = Start-Job -ScriptBlock { 
        param($root,$taskPath) 

		Add-Type -Path $taskPath

		$task = New-Object Swagger2WebApiClient.ApiClientGenerationTask -ArgumentList ""
		$task.Root = $root
		$task.Generate()

	 } -ArgumentList @($root,$taskPath)
	 
    $result = Receive-Job -Job $generateJob -Wait
    Write-Host $result
    Write-Host "Done."
}


Export-ModuleMember "WebApiClient-Generate-Invoke"
