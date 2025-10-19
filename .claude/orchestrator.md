# Agent Orchestrator

This file defines how the AI agent team works together on this project.

## Workflow

### Sprint Initialization
1. **PM Agent** receives feature request
2. **PM Agent** creates GitHub issue with:
   - Clear description
   - Acceptance criteria
   - Labels
   - Assignment to appropriate agent(s)

### Development Flow
1. **Assigned Developer Agent** (Backend/Frontend) implements the feature
   - Reads the issue and acceptance criteria
   - Makes code changes
   - Commits with their agent identity
   - Comments on issue with progress

2. **DevOps Agent** (if needed) handles:
   - Build configuration changes
   - CI/CD pipeline updates
   - Dependency updates

3. **QA Agent** validates the implementation:
   - Writes integration tests
   - Writes Playwright E2E tests
   - Verifies acceptance criteria are met
   - Either: Closes issue as complete, OR opens bug report

### Bug Flow
If QA finds issues:
1. **QA Agent** creates bug issue
2. **QA Agent** assigns to original developer
3. **Developer Agent** fixes bug
4. **QA Agent** verifies fix with new test

## Git Commit Identity

Each agent must configure git before committing:

```bash
# For PM Agent
git config user.name "Product Manager AI"
git config user.email "pm-agent-bot@todo-ai-agents.demo"

# For Backend Agent
git config user.name "Backend Developer AI"
git config user.email "backend-agent-bot@todo-ai-agents.demo"

# For Frontend Agent
git config user.name "Frontend Developer AI"
git config user.email "frontend-agent-bot@todo-ai-agents.demo"

# For DevOps Agent
git config user.name "DevOps Engineer AI"
git config user.email "devops-agent-bot@todo-ai-agents.demo"

# For QA Agent
git config user.name "QA Engineer AI"
git config user.email "qa-agent-bot@todo-ai-agents.demo"
```

## Running Agents

To invoke a specific agent to work on a task:

```
@pm-agent create issue for [feature description]
@backend-agent implement #[issue-number]
@frontend-agent implement #[issue-number]
@devops-agent update CI/CD for #[issue-number]
@qa-agent test #[issue-number]
```

## Agent Communication

Agents communicate through:
- **GitHub Issues**: Primary task tracking
- **Issue Comments**: Progress updates, questions, clarifications
- **Commit Messages**: Reference issues with #[number]
- **Git History**: Shows which agent worked on what

## Important Rules

1. **One agent per commit**: Never mix agent identities in commits
2. **Reference issues**: Always use #[number] in commit messages
3. **Clear handoffs**: Comment on issue when passing to another agent
4. **Test before close**: QA must verify before issue can be closed
5. **No metrics in repo**: Performance tracking is external (TechDebtGPT-agent-health-mvp)
