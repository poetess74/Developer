Remove-Item "C:\Users\HM\AppData\Roaming\Code\User\globalStorage\vscodevim.vim\.cmdline_history"
Remove-Item "C:\Users\HM\AppData\Roaming\Code\User\globalStorage\vscodevim.vim\.search_history"

Get-ChildItem "C:\Users\HM" -recurse -force | Where-Object {$_.name -like ".*" -and $_.attributes -match 'Hidden' -eq $false} | Set-ItemProperty -name Attributes -value ([System.IO.FileAttributes]::Hidden)

