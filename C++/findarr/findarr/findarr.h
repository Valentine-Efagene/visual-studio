
true = 1 
false = 0

srchVal equ [ebp + 08]
arrayPtr equ [ebp + 12]
count equ [ebp + 16]

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
	returnTrue :
	mov al, true
exit :
	pop edi
	pop ebp
	ret
_FindArray ENDP
