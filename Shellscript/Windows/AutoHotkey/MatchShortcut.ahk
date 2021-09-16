; Change Windows shortcut will matching macOS shortcut.

; KoreanIM
^Space::
Send {vk15sc138}
return

; Clipboard
#c::
Send ^{c}
return

#x::
Send ^{x}
return

#v::
Send ^{v}
return

; Undo & Redo
#z::
Send ^{z}
return

#+z::
Send ^+{z}
return

; Save
#s::
Send ^{s}
return

; Mission Control
^#!Left::
Send ^#{Left}
return

^#!Right::
Send ^#{Right}
return

^#!Up::
Send #{Tab}
return

; Lock account & Sleep
^#q::
Run rundll32.exe user32.dll LockWorkStation
return

; Open System Preferences
#!,::
Send #{i}
return

; Open AppStore
#!^A::
Run ms-windows-store:
return

; Window control
#w::
Send !{F4}
return

#q::
WinGet, TARGET, ProcessName, A
if (TARGET == "Explorer.EXE") {
    SoundPlay %A_WinDir%\Media\Windows Foreground.wav
} else {
    Run taskkill /im %TARGET%,,Hide
}
return

; Instance path changer with Finder
#+g::
InputBox, TARGET, Go To...,Please enter Windows absolute path,,,,,,,2147483,%A_MyDocuments%
if ErrorLevel || !TARGET {
    return
} 

Run %TARGET%
return

; Launch Activity Monitor
#!ESC::
Send ^+{ESC}
return

