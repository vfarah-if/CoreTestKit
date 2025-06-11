.PHONY: all clean build test clean

all: clean restore build

clean:
	dotnet clean

restore:
	dotnet restore

build:
	dotnet build

test:
	dotnet test
	
format:
	dotnet format

check:
	dotnet test
	dotnet format
	git add .
