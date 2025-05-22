SHELL := /bin/bash

.PHONY: publish run_help run_help_on run_add

publish:
	@echo "Publish Test Commander"
	dotnet publish -o publish && \
    cd ./publish

run:
	@echo "Run commander with no argument"
	cd ./publish && dotnet ConsoleApp.dll

run_help:
	@echo "Run to get help"
	cd ./publish && dotnet ConsoleApp.dll --help

run_help_on:
	@echo "Run to get help on"
	cd ./publish && dotnet ConsoleApp.dll add --help

run_add:
	@echo "Run Add numbers example"
	cd ./publish && dotnet ConsoleApp.dll add --values "2,3,4,5,6,7,100"
