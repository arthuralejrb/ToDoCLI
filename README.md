# ToDoList - CLI Task Manager

A simple C# command-line task manager that stores tasks in a JSON file.

## Commands

| Command | Usage | Description |
|---------|-------|-------------|
| add | `dotnet run add Buy milk` | Add a new task |
| update | `dotnet run update 1 Buy organic milk` | Update task description |
| mark | `dotnet run mark 1 in-progress` | Change task status |
| delete | `dotnet run delete 1` | Remove a task |
| list | `dotnet run list` | Show all tasks |
| list | `dotnet run list done` | Filter tasks by status |

## Status options
- `to-do`
- `in-progress`
- `done`

## How to run

```bash
dotnet build
dotnet run -- add Write documentation
dotnet run -- mark 1 done
dotnet run -- list


