# TechDebtGPT AI Agent Health MVP - Project Status

**Last Updated:** 2025-10-19
**Repository:** https://github.com/ipanov/todo-ai-agents

---

## ✅ Completed Setup

### 1. Agent Infrastructure
All 5 AI agent definitions created and committed to GitHub:

| Agent | Role | Email Identity | File |
|-------|------|----------------|------|
| PM Agent | Product Manager | pm-agent-bot@todo-ai-agents.demo | `.claude/agents/pm-agent.md` |
| Backend Agent | Backend Developer | backend-agent-bot@todo-ai-agents.demo | `.claude/agents/backend-agent.md` |
| Frontend Agent | Frontend Developer | frontend-agent-bot@todo-ai-agents.demo | `.claude/agents/frontend-agent.md` |
| DevOps Agent | DevOps Engineer | devops-agent-bot@todo-ai-agents.demo | `.claude/agents/devops-agent.md` |
| QA Agent | QA Engineer | qa-agent-bot@todo-ai-agents.demo | `.claude/agents/qa-agent.md` |

**Key Features:**
- Each agent has unique Git identity for commit tracking
- Agents are Claude Code subagents (`.claude/agents/*.md`)
- Email pattern `*-agent-bot@todo-ai-agents.demo` for discovery
- Comprehensive role definitions and responsibilities

### 2. Sprint 1 Feature Specification
Created complete specification for "Task Priority" feature (`.claude/sprint-1-feature.md`):
- 5 user stories with acceptance criteria
- Backend: Add Priority enum to TodoTask entity
- Frontend: Priority UI components (badges, filters)
- QA: Integration tests (NUnit/Testcontainers) + E2E tests (Playwright)
- DevOps: Build and migration updates
- Estimated effort: 8-11 hours

### 3. Git Identity Management
**Verified Working:** Git local config approach for agent identities

**Manual approach (confirmed working):**
```bash
# Set agent identity
git config --local user.name "Backend Developer AI"
git config --local user.email "backend-agent-bot@todo-ai-agents.demo"

# Make commits as agent
git commit -m "feat: Implement feature"

# Reset to personal identity
git config --local --unset user.name
git config --local --unset user.email
```

**PowerShell script available:** `scripts/setup-agent-git.ps1`
- Note: Direct execution from bash may have issues
- Can be run manually in PowerShell: `.\scripts\setup-agent-git.ps1 -Agent backend`

### 4. Documentation Created
- ✅ `CLAUDE.md` - Repository development guide
- ✅ `.claude/agents/README.md` - Agent team overview
- ✅ `.claude/orchestrator.md` - Agent workflow and coordination
- ✅ `.claude/SETUP.md` - GitHub setup guide for agents
- ✅ `.claude/TECHDEBTGPT-RESEARCH.md` - TechDebtGPT investigation findings
- ✅ `.claude/AZURE-DEVOPS-VS-JIRA.md` - Platform comparison (concluded boards not needed)
- ✅ `.claude/AZURE-DEVOPS-SETUP-GUIDE.md` - Azure DevOps setup (may not be needed)

### 5. Repository Structure
```
todo-ai-agents/
├── .claude/
│   ├── agents/
│   │   ├── pm-agent.md
│   │   ├── backend-agent.md
│   │   ├── frontend-agent.md
│   │   ├── devops-agent.md
│   │   ├── qa-agent.md
│   │   └── README.md
│   ├── orchestrator.md
│   ├── sprint-1-feature.md
│   ├── SETUP.md
│   ├── TECHDEBTGPT-RESEARCH.md
│   ├── AZURE-DEVOPS-VS-JIRA.md
│   └── AZURE-DEVOPS-SETUP-GUIDE.md
├── scripts/
│   └── setup-agent-git.ps1
├── CLAUDE.md
└── [existing Todo app files]
```

---

## ⏳ Pending: TechDebtGPT Integration

### Investigation Findings

**Repository Search Results:**
- ❌ No `.techdebt*` configuration files found
- ❌ No `techdebtgpt.yml` or similar config
- ❌ No GitHub App installation detected
- ❌ No API keys or webhooks configured
- ❌ No package.json dependencies for TechDebtGPT
- ✅ Found only: `ReactReduxTodo/techdebtgpt-agent-health-workspace.code-workspace` (generic VS Code workspace file)

**Documentation Search Results:**
- ❌ No public installation guides found
- ❌ No API documentation accessible
- ❌ No GitHub Marketplace app found
- ✅ Website exists: www.techdebtgpt.com
- ✅ General product information available
- ✅ Platform URL (assumed): app.techdebtgpt.com

### What We Know About TechDebtGPT

From website research:
1. **Works on Git-based metrics** - Analyzes commits and PRs
2. **Tracks developers** - Via commit author information
3. **Provides dashboards** - Leaderboards and team insights
4. **Calculates metrics** - Code quality, contribution patterns, bug rates
5. **No boards required** - Pure Git analysis (Azure DevOps boards unnecessary)

### What We DON'T Know (Blockers)

1. **Installation Process:**
   - How to connect repository to TechDebtGPT?
   - Is it a GitHub App?
   - Is it a SaaS platform with OAuth?
   - Does it require configuration files?

2. **Agent Detection:**
   - Will it recognize agents by email pattern `*-agent-bot@todo-ai-agents.demo`?
   - How does it distinguish between human and AI contributors?
   - Can we see per-agent metrics in dashboard?

3. **API Access:**
   - Is there an API to query agent metrics?
   - How to authenticate for API calls?
   - What endpoints are available?

4. **Meta-Agent Integration:**
   - How will `techdebtgpt-agent-health-mvp` query TechDebtGPT?
   - API access vs web scraping?
   - Real-time vs batch analysis?

---

## 📋 Next Steps

### Phase 1: TechDebtGPT Access (BLOCKED)
**Requires user action:**
1. Visit https://www.techdebtgpt.com
2. Sign up / request trial access
3. Connect `ipanov/todo-ai-agents` repository
4. Verify dashboard shows commit history
5. Confirm agents are detected by their email addresses

**Alternative if not available:**
- Contact Ritech Solutions for internal access
- Request AI Challenge participant credentials
- Ask for installation documentation

### Phase 2: Sprint 1 Execution
Once TechDebtGPT is confirmed working:

1. **PM Agent Creates Issues**
   - Use GitHub MCP tools: `mcp__github__create_issue`
   - Create 5 issues from `sprint-1-feature.md`
   - Assign to respective agents

2. **Agents Implement Features**
   - Each agent switches Git identity
   - Makes commits with their email
   - Creates PRs for review

3. **Generate TechDebtGPT Data**
   - Agents make commits over 1-2 days
   - TechDebtGPT analyzes commits
   - Dashboard shows agent performance metrics

### Phase 3: Meta-Agent Development
Create `techdebtgpt-agent-health-mvp` repository:

1. **Integrate with TechDebtGPT**
   - Query agent metrics via API (if available)
   - Parse dashboard data (if no API)
   - Identify lowest-performing agent

2. **Generate Improvement Suggestions**
   - Analyze low-performing agent's commits
   - Identify code quality issues
   - Create improvement recommendations

3. **Update Agent Configuration**
   - Edit `.claude/agents/{agent}-agent.md`
   - Add improvement instructions
   - Document optimization in meta-agent logs

4. **Sprint 2: Verify Improvement**
   - Re-run same feature with optimized agent
   - Compare metrics (Sprint 1 vs Sprint 2)
   - Demonstrate measurable improvement

---

## 🎯 Success Criteria

### For Demo
1. ✅ 5 agents visible in Git commit history
2. ⏳ TechDebtGPT dashboard shows all 5 agents
3. ⏳ Each agent has individual performance metrics
4. ⏳ Meta-agent identifies lowest-performing agent
5. ⏳ Meta-agent generates and applies optimization
6. ⏳ Sprint 2 shows measurable improvement

### Measurable Improvement Examples
- Code quality score: 45/100 → 78/100
- Commit complexity: High → Medium
- Bug introduction rate: 8 bugs → 2 bugs
- Code review feedback: 15 issues → 5 issues

---

## 🔧 Technical Approach

### Agent Workflow (Current)
```
1. PM Agent → Creates issues on GitHub
2. Dev Agents → Check GitHub for assigned issues
3. Dev Agents → Switch Git identity
4. Dev Agents → Implement feature + commit
5. QA Agent → Runs tests + commits results
6. TechDebtGPT → Analyzes all commits
7. Meta-Agent → Queries TechDebtGPT metrics
8. Meta-Agent → Identifies underperformer
9. Meta-Agent → Updates agent definition
10. Sprint 2 → Repeat with improved agent
```

### Git Identity Switching (Verified)
```bash
# Before agent work
git config --local user.name "Backend Developer AI"
git config --local user.email "backend-agent-bot@todo-ai-agents.demo"

# Agent makes commits
git add .
git commit -m "feat: Add priority field to Task model"

# After agent work
git config --local --unset user.name
git config --local --unset user.email
```

### TechDebtGPT Detection (Theory)
TechDebtGPT should detect agents via commit author info:
```
Author: Backend Developer AI <backend-agent-bot@todo-ai-agents.demo>
Date: 2025-10-19

feat: Add priority field to Task model
```

---

## 📊 Current Status Summary

| Component | Status | Notes |
|-----------|--------|-------|
| Agent Definitions | ✅ Complete | All 5 agents defined and committed |
| Sprint 1 Spec | ✅ Complete | Feature fully specified |
| Git Identity System | ✅ Verified | Manual approach tested and working |
| Documentation | ✅ Complete | Comprehensive guides created |
| TechDebtGPT Installation | ❌ Blocked | Awaiting access to platform |
| GitHub Setup | ⏳ Pending | Needs TechDebtGPT confirmation |
| Sprint 1 Execution | ⏳ Pending | Blocked by TechDebtGPT |
| Meta-Agent Repo | ⏳ Pending | Blocked by TechDebtGPT API |

---

## 🚀 Ready to Proceed

**Infrastructure is ready.** All agent definitions, specifications, and Git identity management are in place and working.

**Blocker:** Need access to TechDebtGPT platform to:
1. Confirm repository connection
2. Verify agent detection
3. Access dashboard metrics
4. Understand API (if available)

**Recommended Next Action:**
- User visits techdebtgpt.com
- Signs up / requests trial
- Connects repository
- Shares dashboard access with meta-agent

Once TechDebtGPT access is confirmed, Sprint 1 can begin immediately.

---

## 📞 Contact & Resources

- **TechDebtGPT Website:** https://www.techdebtgpt.com
- **Repository:** https://github.com/ipanov/todo-ai-agents
- **Ritech Solutions:** For AI Challenge access
- **Claude Code:** Already configured with GitHub MCP tools

---

**Project Timeline:** 2 weeks for MVP
**Days Remaining:** ~13 days (estimated)
**Current Phase:** Infrastructure Complete, Awaiting TechDebtGPT Access
