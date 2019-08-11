	.section	__TEXT,__text,regular,pure_instructions
	.build_version macos, 10, 14	sdk_version 10, 14
	.globl	_main                   ## -- Begin function main
	.p2align	4, 0x90
_main:                                  ## @main
	.cfi_startproc
## %bb.0:
	pushq	%rbp
	.cfi_def_cfa_offset 16
	.cfi_offset %rbp, -16
	movq	%rsp, %rbp
	.cfi_def_cfa_register %rbp
	subq	$64, %rsp
	movl	$305419896, %eax        ## imm = 0x12345678
	movl	%eax, %ecx
	movl	$0, -4(%rbp)
	movq	%rcx, -16(%rbp)
	movl	$10, -20(%rbp)
	leaq	-20(%rbp), %rcx
	movq	%rcx, -32(%rbp)
	movq	$0, -40(%rbp)
	movq	$0, -48(%rbp)
	movq	-32(%rbp), %rsi
	leaq	L_.str(%rip), %rdi
	movb	$0, %al
	callq	_printf
	movq	-40(%rbp), %rsi
	leaq	L_.str.1(%rip), %rdi
	movl	%eax, -52(%rbp)         ## 4-byte Spill
	movb	$0, %al
	callq	_printf
	movq	-48(%rbp), %rsi
	leaq	L_.str.2(%rip), %rdi
	movl	%eax, -56(%rbp)         ## 4-byte Spill
	movb	$0, %al
	callq	_printf
	xorl	%edx, %edx
	movl	%eax, -60(%rbp)         ## 4-byte Spill
	movl	%edx, %eax
	addq	$64, %rsp
	popq	%rbp
	retq
	.cfi_endproc
                                        ## -- End function
	.section	__TEXT,__cstring,cstring_literals
L_.str:                                 ## @.str
	.asciz	"p3 = %p\n"

L_.str.1:                               ## @.str.1
	.asciz	"p4 = %p\n"

L_.str.2:                               ## @.str.2
	.asciz	"p5 = %p\n"


.subsections_via_symbols
