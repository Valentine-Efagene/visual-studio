.code

summation proc
	mov rbx , rcx
	xor rcx, rcx
	xor rax, rax

loop_:
	cmp rdx , rcx
	je end_loop
	adc rax , [rbx+rcx*8]
	inc rcx
	jmp loop_

end_loop:
	ret; Return control to the calling program (cpp)
summation endp

mean proc
	cvtsi2sd xmm0, rcx
	cvtsi2sd xmm1, rdx
	divsd xmm0, xmm1
	ret
mean endp
end
