.PHONY: all clean build test clean check add

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

add:
	git add .

check: test format add	
