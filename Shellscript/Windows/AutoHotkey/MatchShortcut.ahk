; Change Windows shortcut will matching macOS shortcut.

; Mission Control
^#!Left::
Send ^#{Left}
return

^#!Right::
Send ^#{Right}
return

; Lock account & Sleep
^#q::
Run rundll32.exe powrprof.dll SetSuspendState
return
