extern ExitProcess:proc
extern outProc:proc
extern inProc:proc

.code
	main proc
		call inProc
		mov ecx, eax
		push rcx
		call inProc
		pop rcx
		add ecx, eax
		call outProc
		call exit
	main endp

	exit proc
		mov ecx, 0
		call ExitProcess
	exit endp
end
