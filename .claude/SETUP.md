# GitHub Setup for AI Agents

Before running the AI agents, you must configure GitHub properly so agents can:
1. Be recognized as contributors
2. Receive notifications about issues
3. React to GitHub events (new issues, comments, etc.)

## Step 1: Create GitHub Bot Accounts

You have two options:

### Option A: GitHub Bot Accounts (Recommended for Production)
Create 5 separate GitHub accounts for each agent:
- Username: `pm-agent-bot`
- Username: `backend-agent-bot`
- Username: `frontend-agent-bot`
- Username: `devops-agent-bot`
- Username: `qa-agent-bot`

**Note**: Each needs a unique email address. You can use email aliases:
- `your-email+pm-agent@gmail.com`
- `your-email+backend-agent@gmail.com`
- etc.

Add each bot as a collaborator to your repository.

### Option B: Git Identity Only (For Demo/Testing)
Use the PowerShell script to switch git identities locally:
```powershell
.\scripts\setup-agent-git.ps1 -Agent pm
# Make commits as PM agent
git commit -m "..."

.\scripts\setup-agent-git.ps1 -Agent backend
# Make commits as Backend agent
git commit -m "..."
```

This will show agents in commit history but won't enable GitHub notifications.

## Step 2: Configure GitHub Repository

### A. Enable Issues
1. Go to your repo on GitHub
2. Settings → General
3. Ensure "Issues" is checked under Features

### B. Create Labels
Create these labels in your repository (Settings → Issues → Labels):
- `feature` (blue)
- `bug` (red)
- `enhancement` (green)
- `test` (purple)
- `devops` (orange)
- `sprint-1` (yellow)
- `backend` (blue)
- `frontend` (green)
- `qa` (purple)

### C. Create GitHub Project (Optional but Recommended)
1. Go to your repo → Projects → New project
2. Name it "Sprint 1 - Task Priority"
3. Use "Board" view
4. Create columns: Todo, In Progress, Review, Done

## Step 3: Agent Notification System

Agents need to know when issues are created or assigned. You have several options:

### Option A: GitHub Actions with Webhooks (Recommended)

Create `.github/workflows/agent-notifier.yml`:

```yaml
name: Agent Notifier

on:
  issues:
    types: [opened, assigned, labeled]
  issue_comment:
    types: [created]

jobs:
  notify-agents:
    runs-on: ubuntu-latest
    steps:
      - name: Notify Assigned Agent
        uses: actions/github-script@v7
        with:
          script: |
            const issue = context.payload.issue;
            const assignee = issue.assignee?.login;

            // Check if assigned to an agent
            if (assignee && assignee.endsWith('-agent-bot')) {
              console.log(`Issue #${issue.number} assigned to ${assignee}`);
              // TODO: Trigger agent via webhook/API
              // For now, just log it
            }
```

### Option B: MCP Server for GitHub (Best for Claude Code)

Install the GitHub MCP server that's already available in this repo.

The agents can use the GitHub MCP server tools:
- `mcp__github__list_issues` - Check for assigned issues
- `mcp__github__get_issue` - Read issue details
- `mcp__github__create_issue` - Create new issues
- `mcp__github__add_issue_comment` - Comment on issues

### Option C: Polling System (Simple for Demo)

Create a simple script that agents can run to check for work:

```javascript
// scripts/check-my-issues.js
// Run this as each agent to see their assigned issues

const agent = process.env.AGENT_USERNAME; // e.g., "backend-agent-bot"
// Use GitHub MCP to list issues assigned to this agent
// mcp__github__list_issues with filter by assignee
```

## Step 4: Agent Authentication

For agents to interact with GitHub API:

### A. Create Personal Access Token (PAT)
1. Go to GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)
2. Generate new token with scopes:
   - `repo` (full control)
   - `workflow` (if using Actions)
3. Save token securely

### B. Configure Agent Environment
Create `.env` file (DO NOT COMMIT):
```
GITHUB_TOKEN=your_github_pat_here
GITHUB_REPO_OWNER=ipanov
GITHUB_REPO_NAME=todo-ai-agents
```

### C. GitHub MCP Server Configuration
The MCP server is already configured in your Claude Code. Agents can use it directly via tool calls like:
```
mcp__github__create_issue
mcp__github__list_issues
mcp__github__add_issue_comment
```

## Step 5: Agent Workflow Integration

### How PM Agent Creates Issues
```javascript
// PM Agent uses GitHub MCP tools
await mcp__github__create_issue({
  owner: "ipanov",
  repo: "todo-ai-agents",
  title: "Add Priority to Tasks (Backend)",
  body: "Story description and acceptance criteria...",
  assignees: ["backend-agent-bot"],
  labels: ["feature", "backend", "sprint-1"]
});
```

### How Developer Agents Check for Work
```javascript
// Backend Agent checks assigned issues
const issues = await mcp__github__list_issues({
  owner: "ipanov",
  repo: "todo-ai-agents",
  assignee: "backend-agent-bot",
  state: "open"
});
```

### How Agents Update Progress
```javascript
// Agent comments on issue
await mcp__github__add_issue_comment({
  owner: "ipanov",
  repo: "todo-ai-agents",
  issue_number: 1,
  body: "✅ Implementation complete. Ready for QA testing."
});
```

## Step 6: Email Notifications (Optional)

If you want agents to receive email notifications:

### Using GitHub Watch Settings
1. For each bot account, watch the repository
2. Enable email notifications for assigned issues
3. Set up email forwarding/polling if needed

### Using GitHub Webhooks
1. Repository Settings → Webhooks
2. Add webhook URL (if you have a server)
3. Subscribe to: issues, issue_comment, pull_request

## Step 7: Testing the Setup

### Test 1: Manual Issue Creation
1. Create a test issue on GitHub
2. Assign it to `backend-agent-bot` (or your username for testing)
3. Add label `feature`
4. Verify the agent can see it using MCP tools

### Test 2: Agent Commit
```powershell
# Set git identity
.\scripts\setup-agent-git.ps1 -Agent backend

# Make a test change
echo "test" > test.txt
git add test.txt
git commit -m "test: Verify backend agent identity"

# Check the commit shows correct author
git log -1 --format="%an <%ae>"
# Should show: Backend Developer AI <backend-agent-bot@todo-ai-agents.demo>
```

### Test 3: GitHub MCP Tools
In Claude Code, test:
```
Can you list all open issues in this repository using the GitHub MCP server?
```

## Recommended Setup Order

1. ✅ Create bot accounts (or decide to use git identity only)
2. ✅ Enable Issues in GitHub repo
3. ✅ Create labels
4. ✅ Create GitHub Project (optional)
5. ✅ Set up GitHub Personal Access Token
6. ✅ Test GitHub MCP tools work
7. ✅ Test git identity switching
8. ✅ Create first issue manually to test workflow
9. ✅ Push agent infrastructure to GitHub
10. ✅ Install TechDebtGPT trial

## Next Steps After Setup

Once everything is configured:
1. PM Agent creates issues from Sprint 1 feature spec
2. Agents check for assigned issues using MCP tools
3. Agents implement features and commit with their identities
4. QA Agent tests and verifies
5. Install TechDebtGPT to track agent performance
6. Build the meta-agent (techdebtgpt-agent-health-mvp) to optimize agents

---

## For Demo Purposes (Quick Setup)

If you just need to demo the concept quickly:

1. **Skip bot accounts** - Just use git identity switching
2. **Create issues manually** - No automation needed
3. **Switch git identity before each commit**:
   ```powershell
   .\scripts\setup-agent-git.ps1 -Agent pm
   # Make PM commits

   .\scripts\setup-agent-git.ps1 -Agent backend
   # Make backend commits

   .\scripts\setup-agent-git.ps1 -Agent frontend
   # Make frontend commits
   ```
4. **Push to GitHub** - Commits will show different agent authors
5. **Install TechDebtGPT** - It will see the different contributors
6. **Build meta-agent** - It will detect agents from commit history

This gives you the full demo without needing 5 separate GitHub accounts!
