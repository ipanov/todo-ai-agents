# Azure DevOps Setup Guide: AI Agent Accounts

## Email Account Strategy

### Recommended Approach: Outlook.com Aliases ✅

**Best Option**: Use ONE Outlook.com account with 10 aliases
- Create main account: `todo-ai-agents@outlook.com`
- Add 5 aliases for agents
- All emails go to one inbox (easy to manage)
- Each alias can be used as separate Azure DevOps identity
- **Cost: FREE**

### How Outlook Aliases Work
- You can create up to 10 aliases per year
- Each alias is a fully functional email address
- All share the same inbox and password
- Can send/receive as any alias
- Can use different alias for Azure DevOps sign-in

---

## Step-by-Step Setup

### Phase 1: Create Outlook Account & Aliases

#### Step 1: Create Main Outlook Account
1. Go to: https://outlook.com
2. Click "Create free account"
3. Create: `todo-ai-agents@outlook.com` (or your preferred name)
4. Complete registration

#### Step 2: Create 5 Aliases for Agents
1. Sign in to https://outlook.com
2. Go to Settings (gear icon) → View all Outlook settings
3. Navigate to: **Accounts** → **Email aliases**
4. Click "Add alias"

Create these 5 aliases:
```
1. pm-agent-bot@outlook.com
2. backend-agent-bot@outlook.com
3. frontend-agent-bot@outlook.com
4. devops-agent-bot@outlook.com
5. qa-agent-bot@outlook.com
```

**Note**: You can add 2 aliases per week, max 10 per year.

#### Alternative: Create 5 Separate Accounts
If aliases don't work for Azure DevOps (they should!), create 5 separate Outlook accounts:
1. Go to https://outlook.com
2. Create each account separately
3. Remember all passwords (or use same password)

---

### Phase 2: Create Azure DevOps Organization

#### Step 1: Create Organization
1. Go to: https://dev.azure.com
2. Sign in with your main account (`todo-ai-agents@outlook.com`)
3. Click "Create new organization"
4. Organization name: `todo-ai-agents-org` (or your preference)
5. Choose region closest to you
6. Click "Continue"

#### Step 2: Create Project
1. After organization creation, click "New project"
2. Project name: `techdebtgpt-ai-agent-health-mvp`
3. Visibility: **Private**
4. Version control: **Git**
5. Work item process: **Agile** (recommended for sprints)
6. Click "Create"

---

### Phase 3: Add Agent Users to Organization

#### Step 1: Invite Agents
1. In Azure DevOps, go to: **Organization Settings** (bottom left)
2. Click **Users** under General
3. Click "Add users"

#### Step 2: Add All 5 Agents at Once
In the "Users" field, enter all 5 agent emails separated by semicolons:
```
pm-agent-bot@outlook.com;backend-agent-bot@outlook.com;frontend-agent-bot@outlook.com;devops-agent-bot@outlook.com;qa-agent-bot@outlook.com
```

**Access level**: Basic (5 free)
**Add to projects**: Select `techdebtgpt-ai-agent-health-mvp`
**Azure DevOps Groups**: Project Contributors

Click "Add"

#### Step 3: Accept Invitations
For each agent:
1. Check inbox of `todo-ai-agents@outlook.com`
2. You'll receive 5 invitation emails
3. Open each email and click "Accept invitation"
4. Sign in with the specific alias:
   - For PM Agent invitation → Sign in as `pm-agent-bot@outlook.com`
   - For Backend Agent → Sign in as `backend-agent-bot@outlook.com`
   - etc.

**Note**: If using aliases, Azure DevOps should recognize each as separate user.
If it doesn't work, you'll need to create 5 separate Outlook accounts.

---

### Phase 4: Configure Project Settings

#### Step 1: Set Up Boards
1. Go to **Project Settings** → **Boards** → **Project configuration**
2. Verify "Agile" process template
3. Create areas:
   - `techdebtgpt-ai-agent-health-mvp\Backend`
   - `techdebtgpt-ai-agent-health-mvp\Frontend`
   - `techdebtgpt-ai-agent-health-mvp\DevOps`
   - `techdebtgpt-ai-agent-health-mvp\QA`

#### Step 2: Create Sprint
1. Go to **Project Settings** → **Boards** → **Team configuration**
2. Click **Iterations**
3. Add iteration: `Sprint 1 - Task Priority`
4. Set dates: Start today, 2 weeks duration

#### Step 3: Create Work Item Templates
1. Go to **Boards** → **Work items**
2. Click **New Work Item** → **User Story**
3. Create template with standard fields:
   - Title
   - Description
   - Acceptance Criteria
   - Assigned To
   - Area Path
   - Iteration Path

---

### Phase 5: Connect to GitHub (Optional but Recommended)

#### Step 1: Install Azure Boards GitHub Integration
1. Go to: https://github.com/marketplace/azure-boards
2. Click "Set up a plan"
3. Choose "Free" plan
4. Click "Install it for free"
5. Select your `todo-ai-agents` repository
6. Click "Install"

#### Step 2: Configure Connection
1. In Azure DevOps, go to **Project Settings** → **GitHub connections**
2. Click "Connect your GitHub account"
3. Authorize Azure Boards
4. Select repository: `ipanov/todo-ai-agents`

#### Step 3: Test Connection
1. Create a test work item in Azure DevOps
2. Get work item ID (e.g., #1)
3. Make a git commit with: `git commit -m "test: AB#1 testing connection"`
4. Push to GitHub
5. Check work item - should show linked commit

---

### Phase 6: Configure Azure DevOps MCP Connection

#### Step 1: Get Personal Access Token (PAT)
1. In Azure DevOps, click your profile (top right)
2. Click **Personal access tokens**
3. Click "New Token"
4. Name: `Claude Code MCP Integration`
5. Organization: `todo-ai-agents-org`
6. Scopes: **Full access** (for demo purposes)
7. Click "Create"
8. **COPY THE TOKEN** - you won't see it again!

#### Step 2: Configure MCP Server
The Azure DevOps MCP server is already available in Claude Code.

To configure it, you need to set environment variables or configuration:
```json
{
  "AZURE_DEVOPS_ORG": "todo-ai-agents-org",
  "AZURE_DEVOPS_PAT": "your_personal_access_token_here"
}
```

**Note**: Check Claude Code MCP server settings to see exact configuration format.

#### Step 3: Test MCP Connection
In Claude Code, test:
```
Can you list all projects in my Azure DevOps organization?
```

Claude should use `mcp__azuredevops-mcp__listProjects` and show your project.

---

### Phase 7: Create Initial Work Items

#### Create Epic for Sprint 1
1. Go to **Boards** → **Work items**
2. New Work Item → **Epic**
3. Title: `Sprint 1: Add Task Priority Feature`
4. Description: Link to `.claude/sprint-1-feature.md`
5. Iteration: `Sprint 1 - Task Priority`

#### Create User Stories (via MCP or manually)

**Option A: Create Manually**
Create 5 user stories from `.claude/sprint-1-feature.md`:
1. Backend: Add Priority to Tasks
2. Frontend: Priority UI Components
3. Frontend: Filter and Sort
4. QA: Integration Tests
5. DevOps: Build Updates

Assign each to appropriate agent.

**Option B: Use Claude with MCP**
```
Can you create the 5 user stories from .claude/sprint-1-feature.md
in Azure DevOps project "techdebtgpt-ai-agent-health-mvp"?
Assign them to the appropriate agents.
```

---

## Verification Checklist

### ✅ Azure DevOps Organization
- [ ] Organization created: `todo-ai-agents-org`
- [ ] Project created: `techdebtgpt-ai-agent-health-mvp`
- [ ] Project type: Private, Git, Agile

### ✅ Agent Accounts
- [ ] Main account: `todo-ai-agents@outlook.com`
- [ ] PM Agent: `pm-agent-bot@outlook.com`
- [ ] Backend Agent: `backend-agent-bot@outlook.com`
- [ ] Frontend Agent: `frontend-agent-bot@outlook.com`
- [ ] DevOps Agent: `devops-agent-bot@outlook.com`
- [ ] QA Agent: `qa-agent-bot@outlook.com`
- [ ] All 5 agents invited to Azure DevOps (using 5 free Basic licenses)
- [ ] All invitations accepted

### ✅ Project Configuration
- [ ] Sprint 1 created
- [ ] Area paths created for each team
- [ ] GitHub connection configured (optional)

### ✅ MCP Integration
- [ ] Personal Access Token created
- [ ] PAT configured in Claude Code MCP settings
- [ ] Test query successful

### ✅ Work Items
- [ ] Epic created for Sprint 1
- [ ] 5 User Stories created
- [ ] Stories assigned to agents
- [ ] Stories added to Sprint 1

---

## Troubleshooting

### Issue: Aliases Don't Work as Separate Users
**Problem**: Azure DevOps treats all aliases as same user

**Solution**: Create 5 completely separate Outlook accounts instead
- `pm-agent-bot@outlook.com`
- `backend-agent-bot@outlook.com`
- `frontend-agent-bot@outlook.com`
- `devops-agent-bot@outlook.com`
- `qa-agent-bot@outlook.com`

### Issue: Can't Add More Than 5 Users
**Problem**: Free tier only allows 5 Basic users

**Solution**: You're using exactly 5 agents - this is perfect!
If you need to add yourself as a viewer, use "Stakeholder" (free, unlimited)

### Issue: MCP Connection Fails
**Problem**: Claude Code can't connect to Azure DevOps

**Solution**:
1. Verify PAT is valid and not expired
2. Check organization name is correct
3. Ensure PAT has correct scopes (Full access for testing)

---

## Next Steps After Setup

1. ✅ Test agent accounts can see project
2. ✅ Create Sprint 1 work items
3. ✅ Test GitHub → Azure DevOps linking
4. ✅ Run PM Agent to manage work items
5. ✅ Install TechDebtGPT
6. ✅ Connect TechDebtGPT to Azure DevOps + GitHub

---

## Important Notes

- **Free Tier Limits**: 5 Basic users (perfect for agents) + unlimited Stakeholders
- **Alias Limitation**: Outlook allows 10 aliases, but Azure DevOps may treat them as one user
- **Best Practice**: If aliases fail, create 5 separate accounts
- **Password Management**: Use same password for all agent accounts for easy management
- **Email Management**: All emails go to one inbox (if using aliases)

---

## Resources

- **Azure DevOps**: https://dev.azure.com
- **Create Outlook Account**: https://outlook.com
- **Azure Boards GitHub App**: https://github.com/marketplace/azure-boards
- **Azure DevOps Docs**: https://learn.microsoft.com/en-us/azure/devops/

---

**Status**: Ready to implement
**Estimated Time**: 30-45 minutes
**Cost**: $0 (Free tier)
