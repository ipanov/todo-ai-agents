# Azure DevOps vs Jira: Platform Comparison for AI Agent Tracking

## Quick Recommendation: **Azure DevOps** ✅

**Reasons:**
1. Easier to set up and use out-of-the-box
2. 5 free users (perfect for our 5 agents)
3. Unlimited free "Stakeholder" users (for viewing)
4. Better API support for automation
5. We have extensive MCP tools already available
6. No licensing cost for bot users
7. Unified interface for work items, repos, and CI/CD

---

## Detailed Comparison

### Free Tier

| Feature | Azure DevOps | Jira |
|---------|-------------|------|
| **Free Users** | 5 Basic + Unlimited Stakeholders | 10 users |
| **Bot Users Cost** | Free (don't count against limit) | Require licensed seat |
| **Work Item Tracking** | ✅ Full Azure Boards access | ✅ Basic issue tracking |
| **API Access** | ✅ Full REST API | ✅ REST API |
| **Git Integration** | ✅ Built-in Azure Repos | Requires separate Bitbucket |
| **CI/CD** | ✅ Azure Pipelines included | Requires separate tool |

### Setup Difficulty

**Azure DevOps: ⭐⭐⭐⭐⭐ (Easier)**
- Simple organization creation
- Works out-of-the-box with minimal configuration
- Unified interface for all services
- Templates ready to use immediately
- No technical expertise needed for basic setup

**Jira: ⭐⭐⭐ (More Complex)**
- Steeper learning curve
- More customization options = more complexity
- Requires configuration before productive use
- Need to learn separate tools for different components
- Best suited for teams with dedicated admin

### Bot/Service Account Creation

**Azure DevOps: ✅ Better for Bots**
```
Option 1: Service Principal (Recommended)
- Use Azure Entra ID service principal
- Doesn't count as user
- No PAT expiration worries
- Best practice for 2025

Option 2: Regular User Account
- Create user: agent-bot@yourdomain.com
- Counts as 1 of 5 free users
- Simple to set up
- Can assign work items

Option 3: PAT (Personal Access Token)
- Use your own account
- Generate PAT for automation
- No additional user needed
```

**Jira: ❌ Problematic for Bots**
```
Problem: No free bot accounts
- Every bot needs a licensed user seat
- Bot users count toward 10-user limit
- Must verify email (no +aliases work)
- Can't create "service accounts"

Workaround: Use personal account API tokens
- Not ideal for tracking individual agents
- All actions appear under one user
```

### Our Use Case: 5 AI Agents

**With Azure DevOps:**
```
✅ Perfect fit for 5 agents:
1. pm-agent-bot@todo-ai-agents.demo (1/5 free users)
2. backend-agent-bot@todo-ai-agents.demo (2/5)
3. frontend-agent-bot@todo-ai-agents.demo (3/5)
4. devops-agent-bot@todo-ai-agents.demo (4/5)
5. qa-agent-bot@todo-ai-agents.demo (5/5)

Each agent can:
- Be assigned work items
- Update work item status
- Comment on work items
- Appear in reports/dashboards
- Be tracked individually by TechDebtGPT
```

**With Jira:**
```
❌ Would require paid licenses:
- 5 bot accounts = 5 of 10 free users
- Leaves only 5 users for humans
- OR: All agents share 1 account (defeats purpose)
- Can't distinguish between agents in reporting
```

### MCP Server Integration

**Azure DevOps MCP Tools Available:**

We already have extensive Azure DevOps MCP integration:

```javascript
// Work Item Management
mcp__azuredevops-mcp__createWorkItem
mcp__azuredevops-mcp__listWorkItems
mcp__azuredevops-mcp__getWorkItemById
mcp__azuredevops-mcp__updateWorkItem
mcp__azuredevops-mcp__searchWorkItems
mcp__azuredevops-mcp__getRecentlyUpdatedWorkItems
mcp__azuredevops-mcp__getMyWorkItems

// Boards & Sprints
mcp__azuredevops-mcp__getBoards
mcp__azuredevops-mcp__getBoardItems
mcp__azuredevops-mcp__getSprints
mcp__azuredevops-mcp__getCurrentSprint
mcp__azuredevops-mcp__getSprintWorkItems

// Repository
mcp__azuredevops-mcp__listRepositories
mcp__azuredevops-mcp__getFileContent
mcp__azuredevops-mcp__searchCode

// Pull Requests
mcp__azuredevops-mcp__listPullRequests
mcp__azuredevops-mcp__getPullRequest
mcp__azuredevops-mcp__createPullRequest
mcp__azuredevops-mcp__approvePullRequest

// Projects
mcp__azuredevops-mcp__listProjects
mcp__azuredevops-mcp__getProjectDetails
```

**GitHub MCP Tools (for Jira):**
- Less integration with Jira
- Would need to use Jira REST API directly
- More manual configuration needed

### API & Automation

**Azure DevOps:**
- ✅ Comprehensive REST API
- ✅ PAT tokens for authentication
- ✅ Service hooks (webhooks)
- ✅ Easy to query work items
- ✅ MCP server already configured

**Jira:**
- ✅ REST API available
- ✅ API tokens for auth
- ⚠️ More complex API structure
- ⚠️ Requires separate authentication setup
- ❌ No MCP server available (yet)

### Integration with GitHub

**Azure DevOps:**
```
Option 1: Use Azure Repos (built-in)
- Tight integration with work items
- Link commits to work items automatically

Option 2: Connect external GitHub
- Azure Boards <-> GitHub integration available
- Can link GitHub commits to Azure work items
```

**Jira:**
```
GitHub integration:
- Install "GitHub for Jira" app
- Connect repositories
- Link commits to Jira issues
- More setup steps required
```

### TechDebtGPT Integration

Both platforms can integrate with TechDebtGPT, but:

**Azure DevOps Benefits:**
- TechDebtGPT can track Azure DevOps work items
- Can correlate commits with work items
- Better visibility into agent assignments
- Unified view of code + work tracking

**Jira:**
- Would need separate GitHub + Jira integration
- TechDebtGPT might only see GitHub side
- Less unified view

---

## Implementation Plan: Azure DevOps

### Step 1: Create Azure DevOps Organization
```
1. Go to: https://dev.azure.com
2. Sign in with Microsoft account
3. Create new organization: "todo-ai-agents"
4. Create project: "Todo Priority Feature"
```

### Step 2: Create Agent User Accounts
```
Option A: Real Email Accounts (Recommended)
- Create 5 Microsoft accounts with +aliases:
  - your-email+pm-agent@outlook.com
  - your-email+backend-agent@outlook.com
  - your-email+frontend-agent@outlook.com
  - your-email+devops-agent@outlook.com
  - your-email+qa-agent@outlook.com

- Invite each to Azure DevOps organization
- Each gets Basic license (5 free)

Option B: Service Principal (Advanced)
- Create Azure Entra ID service principal
- Add to Azure DevOps
- Use for automation (doesn't count as user)
```

### Step 3: Connect to GitHub
```
1. Install Azure Boards GitHub integration
2. Link GitHub repository
3. Configure commit linking
```

### Step 4: Create Work Items via MCP
```javascript
// PM Agent creates work items
await mcp__azuredevops-mcp__createWorkItem({
  workItemType: "User Story",
  title: "Add Priority Field to Tasks",
  description: "Story description...",
  areaPath: "Todo Priority Feature",
  iterationPath: "Sprint 1",
  additionalFields: {
    "System.AssignedTo": "backend-agent-bot@todo-ai-agents.demo"
  }
});

// Backend Agent checks their work
await mcp__azuredevops-mcp__getMyWorkItems({
  state: "Active"
});

// Backend Agent updates status
await mcp__azuredevops-mcp__updateWorkItem({
  id: 1,
  fields: {
    "System.State": "Completed"
  }
});
```

### Step 5: Configure TechDebtGPT
```
1. Install TechDebtGPT
2. Connect to Azure DevOps organization
3. Connect to GitHub repository
4. TechDebtGPT tracks:
   - Commits by each agent (from GitHub)
   - Work items assigned to each agent (from Azure DevOps)
   - Agent performance across both systems
```

---

## Cost Comparison

### Azure DevOps: **FREE** ✅
- 5 agent accounts: $0 (included in free tier)
- Unlimited Stakeholders: $0
- Azure Repos: $0
- Azure Pipelines: $0 (1,800 minutes/month)
- **Total: $0/month**

### Jira: **Potential Cost** ⚠️
- Free tier: 10 users
- 5 agents + you = 6 users (still free)
- BUT: Need GitHub separately
- If you need more features: $8.15/user/month
- **Total: $0 if within 10 users**

---

## Final Recommendation: Azure DevOps

**Why Azure DevOps is the clear winner:**

1. ✅ **Perfect for 5 agents** - Free tier covers exactly our needs
2. ✅ **Easier setup** - Works out of the box
3. ✅ **Better automation** - Comprehensive MCP tools already available
4. ✅ **Unified platform** - Work items + repos + CI/CD in one place
5. ✅ **Bot-friendly** - Service principals or regular user accounts work fine
6. ✅ **TechDebtGPT ready** - Can track across Azure DevOps + GitHub
7. ✅ **No learning curve** - Simple interface, ready to go
8. ✅ **GitHub integration** - Native integration available

**Next Steps:**
1. Create Azure DevOps organization
2. Create 5 agent user accounts
3. Set up project and sprints
4. Connect GitHub repository
5. Test MCP tools for work item creation
6. Install TechDebtGPT to track agents

---

## Decision: **Use Azure DevOps** ✅
