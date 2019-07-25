
.code _FindArray PROC near
	push ebp
	mov ebp, esp
	push edi

	mov eax, srchVal
	mov ecx, count
	mov edi, arrayPtr 
	repne scasd
	jz return True
return False :
	mov al, false
	jmp short exit
return True :
	mov al, true
exit :
	pop edi
	pop ebp
	ret
_FindArray ENDP
