# DevSnapshot

DevSnapshot is a simple personal developer journal CLI.  
It helps track what you work on each day and can generate summaries using AI.

## Goals

- Quickly log what you worked on during the day.
- Generate daily summaries using AI (OpenAI API).
- Store entries locally (JSON file).
- Eventually integrate with:
  - GitHub commits
  - Email/Slack daily reports
  - Dashboards

## Roadmap

### MVP (Phase 1)
- [ ] \`add\` command: append entry to a local JSON file
- [ ] \`list\` command: list all entries for today
- [ ] \`summarize\` command: summarize today's entries using OpenAI

### Future (Phase 2+)
- Tagging entries by project
- Auto-detect changes from Git logs
- Generate weekly summaries
- Export summaries to Markdown/Wiki
- Optional GUI or web dashboard

## Getting Started

```powershell
dotnet run -- add "Fixed bug in API and updated docs"
dotnet run -- list
dotnet run -- summarize
```
