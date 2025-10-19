# Sprint 1: Add Task Priority Feature

## Feature Description
Add priority levels to tasks in the Todo application, allowing users to mark tasks as High, Medium, or Low priority and filter/sort by priority.

## Business Value
Users need to prioritize their tasks to focus on what's most important. This feature will help users organize their work more effectively.

## User Stories

### Story 1: Add Priority to Tasks (Backend)
**As a** user
**I want to** assign a priority level to my tasks
**So that** I can organize my work by importance

**Acceptance Criteria:**
- Task entity has a Priority field (enum: High=1, Medium=2, Low=3)
- API accepts priority when creating/updating tasks
- API returns priority with task data
- Database migration created
- Default priority is Medium if not specified

**Assigned to:** Backend Agent

---

### Story 2: Priority UI Components (Frontend)
**As a** user
**I want to** see and set priority on tasks in the UI
**So that** I can visually identify important tasks

**Acceptance Criteria:**
- Priority dropdown in add/edit task form
- Priority badge displayed on each task with color coding:
  - High: Red badge
  - Medium: Yellow badge
  - Low: Green badge
- Priority selector uses React-Bootstrap components
- Redux state updated to include priority

**Assigned to:** Frontend Agent

---

### Story 3: Filter and Sort by Priority (Frontend)
**As a** user
**I want to** filter and sort tasks by priority
**So that** I can focus on high-priority items

**Acceptance Criteria:**
- Filter dropdown to show only tasks of selected priority
- "All" option to show all priorities
- Tasks can be sorted by priority (High → Low)
- Filter/sort state persisted in Redux
- UI updates immediately when filter changes

**Assigned to:** Frontend Agent

---

### Story 4: Integration Tests (QA)
**As a** QA engineer
**I want to** verify priority functionality works end-to-end
**So that** users have a reliable feature

**Acceptance Criteria:**
- Integration test: Create task with priority via API
- Integration test: Update task priority via API
- Integration test: Filter tasks by priority via API
- Integration test: Default priority is Medium
- E2E test with Playwright: User can set priority on new task
- E2E test with Playwright: User can filter tasks by priority
- E2E test with Playwright: Priority badges display correct colors

**Assigned to:** QA Agent

---

### Story 5: Build & Deployment Updates (DevOps)
**As a** DevOps engineer
**I want to** ensure the build handles database migrations
**So that** deployment is smooth

**Acceptance Criteria:**
- CI/CD pipeline runs database migrations
- Build succeeds with new schema
- No breaking changes in deployment process
- Update documentation if needed

**Assigned to:** DevOps Agent

---

## Technical Notes

### Database Schema
```csharp
public enum TaskPriority
{
    High = 1,
    Medium = 2,
    Low = 3
}

public class TodoTask
{
    // Existing fields...
    public TaskPriority Priority { get; set; } = TaskPriority.Medium;
}
```

### API Changes
```
POST /api/tasks
{
    "title": "Task title",
    "priority": 1  // 1=High, 2=Medium, 3=Low
}

GET /api/tasks?priority=1  // Optional filter
```

### Redux State
```javascript
{
    tasks: [
        { id: 1, title: "Task", priority: "High" },
        // ...
    ],
    filters: {
        priority: "All" // or "High", "Medium", "Low"
    }
}
```

## Definition of Done
- [ ] Backend API accepts and returns priority
- [ ] Database migration applied successfully
- [ ] Frontend displays priority badges with correct colors
- [ ] Users can set priority when creating/editing tasks
- [ ] Users can filter tasks by priority
- [ ] All integration tests pass
- [ ] All E2E Playwright tests pass
- [ ] Code reviewed (by TechDebtGPT)
- [ ] Feature deployed to test environment
- [ ] QA sign-off completed

## Estimated Effort
- Backend: 2-3 hours
- Frontend: 3-4 hours
- QA: 2-3 hours
- DevOps: 1 hour

**Total: 8-11 hours**
