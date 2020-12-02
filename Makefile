.PHONY: all
all:
	dotnet run --project Runner ./inputs $(ex)
