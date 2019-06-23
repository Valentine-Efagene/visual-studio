.code

addInts proc
	mov rax, rcx ; Move first argument into the accummulator
	add rax, rdx ; Add second argument to the content of the accumulator
	ret          ; Return control to the calling program (cpp)
addInts endp
end