# AI Agent Team

This repository uses AI agents as team members to develop features. Each agent has a specific role and makes commits using their own GitHub identity.

## Team Members

| Agent | GitHub Username | Role | Responsibilities |
|-------|----------------|------|------------------|
| Product Manager AI | `pm-agent-bot` | Product Owner | Creates issues, assigns tasks, coordinates sprints |
| Backend Developer AI | `backend-agent-bot` | Backend Dev | ASP.NET Core API, EF Core, services |
| Frontend Developer AI | `frontend-agent-bot` | Frontend Dev | React components, Redux, UI/UX |
| DevOps Engineer AI | `devops-agent-bot` | DevOps | CI/CD, builds, infrastructure |
| QA Engineer AI | `qa-agent-bot` | QA | Tests, quality assurance, verification |

## How It Works

1. **PM Agent** creates GitHub issues for features
2. **PM Agent** assigns issues to appropriate developer agents
3. **Developer Agents** implement features and make commits with their GitHub identities
4. **QA Agent** writes tests and verifies implementations
5. **DevOps Agent** maintains CI/CD pipeline

## Agent Detection

The agents are identified by their GitHub commit emails:
- `pm-agent-bot@todo-ai-agents.demo`
- `backend-agent-bot@todo-ai-agents.demo`
- `frontend-agent-bot@todo-ai-agents.demo`
- `devops-agent-bot@todo-ai-agents.demo`
- `qa-agent-bot@todo-ai-agents.demo`

External tools (like TechDebtGPT-agent-health-mvp) can discover these agents by scanning commit history for these email addresses.

## Performance Tracking

Agent performance metrics are NOT stored in this repository. They are maintained by the monitoring system (TechDebtGPT-agent-health-mvp) which:
- Discovers agents from commit history
- Integrates with TechDebtGPT for quality metrics
- Tracks agent performance over time
- Suggests improvements for underperforming agents
