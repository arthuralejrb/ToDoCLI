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


```mermaid
sequenceDiagram
    autonumber
    actor Worker as Worker Service
    participant Scraper as Scraper Engine
    participant DB as PostgreSQL
    participant AI as API da IA (LLM)
    participant TTS as API Text-to-Speech
    participant Telegram as Telegram Bot

    Worker->>Scraper: Inicia coleta diária
    Scraper->>DB: Salva notícias (checa URLs duplicadas)
    Worker->>DB: Busca matérias relevantes do dia
    DB-->>Worker: Retorna lote de notícias
    Worker->>AI: Envia prompt + textos das notícias
    AI-->>Worker: Retorna resumo consolidado (Markdown)
    Worker->>TTS: Envia texto resumido
    TTS-->>Worker: Retorna arquivo de áudio (MP3)
    Worker->>Telegram: Envia mensagem em texto + áudio MP3
    Worker->>DB: Atualiza status das notícias para "Enviado"
