Write-Host "Removing vscodevim cache files incompatible with this script..." -NoNewLine
Remove-Item "C:\Users\HM\AppData\Roaming\Code\User\globalStorage\vscodevim.vim\.cmdline_history" 2>$null
Remove-Item "C:\Users\HM\AppData\Roaming\Code\User\globalStorage\vscodevim.vim\.search_history" 2>$null
Write-Host " Done!"

Write-Host "Hiding dotfiles in C:\Users\HM..." -NoNewLine
Get-ChildItem "C:\Users\HM" -recurse -force 2>$null | Where-Object {$_.name -like ".*" -and $_.attributes -match 'Hidden' -eq $false} 2>$null | Set-ItemProperty -name Attributes -value ([System.IO.FileAttributes]::Hidden) 2>$null
Write-Host " Done!"

Write-Host "Hiding dotfiles in E:\Users\hm..." -NoNewLine
Get-ChildItem "E:\Users\hm" -recurse -force 2>$null | Where-Object {$_.name -like ".*" -and $_.attributes -match 'Hidden' -eq $false} 2>$null | Set-ItemProperty -name Attributes -value ([System.IO.FileAttributes]::Hidden) 2>$null
Write-Host " Done!"

Write-Host "This window will close automatically after 5 seconds..." -NoNewLine
for($i=5; $i -ge 0; $i--) {
    Write-Host "`b`b`b`b`b`b`b`b`b`b`b`b$i seconds..." -NoNewLine
    Start-Sleep -Seconds 1
}

Write-Host "`n`nPowerShell HideHidden.ps1 has been terminated."
