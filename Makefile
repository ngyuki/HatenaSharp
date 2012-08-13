# call "%VS100COMNTOOLS%vsvars32.bat"

PHPDEPS = $(PHPDEPS) phpsrc/HatenaSyntax/lib/*.php
PHPDEPS = $(PHPDEPS) phpsrc/HatenaSyntax/lib/HatenaSyntax/*.php
PHPDEPS = $(PHPDEPS) phpsrc/HatenaSyntax/lib/HatenaSyntax/Tree/*.php

PHPDEPS = $(PHPDEPS) phpsrc/PHPPEG/code/*.php
PHPDEPS = $(PHPDEPS) phpsrc/PHPPEG/code/PEG/*.php

PHPC = tools\phpc

all : phplib/HatenaSyntax.dll

phplib/HatenaSyntax.dll : $(PHPDEPS)
	@echo:
	@echo *** Run testall ***
	@php phpsrc/HatenaSyntax/test/testall.php
	
	@echo:
	@echo *** Run phpc ***
	$(PHPC) /target:dll /debug+ /pure+ /static+ /encoding:UTF-8 /r:PhpNetClassLibrary \
		/recurse:phpsrc/HatenaSyntax/lib \
		/recurse:phpsrc/PHPPEG/code \
		/out:phplib/HatenaSyntax
	
	@echo:
	@echo *** End make phplib ***
	@echo:
