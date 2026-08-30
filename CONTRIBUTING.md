# Contributing

Thanks for helping improve **IResultPattern**.

## Opening issues

Please follow these conventions so issues stay clear and actionable.

### Title format

```text
<type>: <Imperative summary>
```

Optional scope: `fix(typo): ...`

| Type | Use for |
|------|---------|
| `feat:` | New capability |
| `fix:` | Bug or incorrect behavior |
| `refactor:` | API/design change without a new feature |
| `docs:` | Documentation only |
| `chore:` | Small maintenance (typo, cleanup, light CI) |

Do **not** use `hotfix` in issue titles. For urgent bugs, use `fix:` and mark priority as High.

**Title rules**
- Start the summary with an imperative verb (`Restrict`, `Make`, `Remove`, `Rename`, `Support`, `Fix`, `Add`)
- Keep it short: about 5–12 words after the type
- Put priority in labels or in the Priority section — not in the title
- Be precise; check the code before filing

**Examples**
- `fix: Restrict Failure to non-success statuses only`
- `refactor: Make Result immutable`
- `refactor: Remove StatusTitle from Result`
- `fix(typo): Rename ReulstPatternExtenssion to ResultPatternExtension`
- `refactor: Rename Created parameter from errorMessage`
- `feat: Support value types in Result of T`

### Body template

```markdown
## Summary
<1–3 sentences: what and why>

## Problem
<current behavior / limitation; short code sample if useful>

## Proposed change
- <actionable bullets>
- <tests / breaking-change note if needed>

## Priority
High | Medium | Low — <one-line reason>
```

### Priority guide

| Priority | When |
|----------|------|
| **High** | Correctness bugs or major usability gaps |
| **Medium** | Naming/API clarity that does not break runtime logic |
| **Low** | Internal typos, presentation cleanup, non-urgent breaking removals |

### Automated checks

New and edited issues are validated by CI:

- Title must match `feat|fix|refactor|docs|chore` (optional scope), then `: `, then a non-empty summary
- Body must include **Summary**, **Problem**, **Proposed change**, and **Priority**

Issues that fail are labeled `invalid`, commented, and closed. Fix the title/body and reopen, or open a new issue with a template.

---

## Pull requests

- Keep PRs focused on one concern when possible
- Match existing code style
- Add or update tests for behavioral changes
- Call out breaking API changes in the PR description
