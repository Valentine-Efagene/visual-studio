.code

addInts proc
	mov rax, rcx ; Move first argument into the accummulator
	add rax, rdx ;
	ret          ; Return control to the calling program (cpp)
addInts endp

subtractInts proc
	mov rax, rcx ; Move first argument into the accummulator
	sub rax, rdx ;
	ret          ; Return control to the calling program (cpp)
subtractInts endp

multiplyInts proc
	mov rax, rcx ; Move first argument into the accummulator
	imul rax, rdx ;
	ret          ; Return control to the calling program (cpp)
multiplyInts endp

quotientInts proc
	mov rax, rcx ; Move first argument into the accummulator
	mov rcx, rdx
	xor rdx, rdx
	idiv rcx ;
	ret          ; Return control to the calling program (cpp)
quotientInts endp

remainderInts proc
	mov rax, rcx ; Move first argument into the accummulator
	mov rcx, rdx
	xor rdx, rdx
	idiv rcx ;
	mov rax, rdx
	ret          ; Return control to the calling program (cpp)
remainderInts endp
end
