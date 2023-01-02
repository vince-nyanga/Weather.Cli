# Weather CLI

![logo](docs/logo.png)

This is a demo CLI application that can be installed as a `dotnet` global tool.

## How To Install

### Package the application

```bash
dotnet pack
```

### Install the tool globally

```bash
dotnet tool install --global --add-source ./nupkg weather
```

## How To Run

```bash
weather --help # get help

weather current --help # help for the current weather cmd

weather forecast --help # help for the weather forecast cmd
```
