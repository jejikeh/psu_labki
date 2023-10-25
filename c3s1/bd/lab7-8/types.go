package main

import "github.com/google/uuid"

type Project struct {
	ID            uuid.UUID `json:"id"`
	Name          string    `json:"name"`
	Description   string    `json:"description"`
	UserManager   uuid.UUID `json:"user_manager"`
	ProjectStatus uuid.UUID `json:"project_status"`
}

type ProjectCreateRequest struct {
	Name          string `json:"name"`
	Description   string `json:"description"`
	UserManager   string `json:"user_manager"`
	ProjectStatus string `json:"project_status"`
}

func NewProject(name, description string, userManager, projectStatus uuid.UUID) *Project {
	return &Project{
		ID:            uuid.New(),
		Name:          name,
		Description:   description,
		UserManager:   userManager,
		ProjectStatus: projectStatus,
	}
}

type User struct {
	ID    uuid.UUID `json:"id"`
	Name  string    `json:"name"`
	Email string    `json:"email"`
}

type UserCreateRequest struct {
	Name  string `json:"name"`
	Email string `json:"email"`
}

func NewUser(name, email string) *User {
	return &User{
		ID:    uuid.New(),
		Name:  name,
		Email: email,
	}
}

type ProjectStatus struct {
	ID          uuid.UUID `json:"id"`
	Title       string    `json:"title"`
	Description string    `json:"description"`
}

type ProjectStatusCreateRequest struct {
	Title       string `json:"title"`
	Description string `json:"description"`
}

func NewProjectStatus(title, description string) *ProjectStatus {
	return &ProjectStatus{
		ID:          uuid.New(),
		Title:       title,
		Description: description,
	}
}

type FinancialReport struct {
	ID             uuid.UUID `json:"id"`
	Value          int       `json:"value"`
	AdditionalInfo string    `json:"additional_info"`
	Project        uuid.UUID `json:"project"`
}

type FinancialReportCreateRequest struct {
	Value          int       `json:"value"`
	AdditionalInfo string    `json:"additional_info"`
	Project        uuid.UUID `json:"project"`
}

func NewFinancialReport(value int, additionalInfo string, project uuid.UUID) *FinancialReport {
	return &FinancialReport{
		ID:             uuid.New(),
		Value:          value,
		AdditionalInfo: additionalInfo,
		Project:        project,
	}
}

type TaskStatus struct {
	ID          uuid.UUID `json:"id"`
	Title       string    `json:"title"`
	Description string    `json:"description"`
	Staging     bool      `json:"staging"`
}

type TaskStatusCreateRequest struct {
	Title       string `json:"title"`
	Description string `json:"description"`
	Staging     bool   `json:"staging"`
}

func NewTaskStatus(title, description string, staging bool) *TaskStatus {
	return &TaskStatus{
		ID:          uuid.New(),
		Title:       title,
		Description: description,
		Staging:     staging,
	}
}

type Task struct {
	ID          uuid.UUID `json:"id"`
	Title       string    `json:"title"`
	Description string    `json:"description"`
	Project     uuid.UUID `json:"project"`
	Status      uuid.UUID `json:"status"`
	AssignedTo  uuid.UUID `json:"assigned_to"`
}

type TaskCreateRequest struct {
	Title       string `json:"title"`
	Description string `json:"description"`
	Project     string `json:"project"`
	Status      string `json:"status"`
	AssignedTo  string `json:"assigned_to"`
}

func NewTask(title, description string, project, status, assignedTo uuid.UUID) *Task {
	return &Task{
		ID:          uuid.New(),
		Title:       title,
		Description: description,
		Project:     project,
		Status:      status,
		AssignedTo:  assignedTo,
	}
}

type Role struct {
	ID          uuid.UUID `json:"id"`
	Title       string    `json:"title"`
	Description string    `json:"description"`
}

type RoleCreateRequest struct {
	Title       string `json:"title"`
	Description string `json:"description"`
}

func NewRole(title, description string) *Role {
	return &Role{
		ID:          uuid.New(),
		Title:       title,
		Description: description,
	}
}

type Team struct {
	ID          uuid.UUID `json:"id"`
	Project     uuid.UUID `json:"project"`
	Description string    `json:"description"`
}

type TeamCreateRequest struct {
	Project     string `json:"project"`
	Description string `json:"description"`
}

func NewTeam(project, description string) *Team {
	return &Team{
		ID:          uuid.New(),
		Project:     uuid.MustParse(project),
		Description: description,
	}
}

type UserTeam struct {
	User uuid.UUID `json:"user"`
	Team uuid.UUID `json:"team"`
}

type UserTeamCreateRequest struct {
	User string `json:"user"`
	Team string `json:"team"`
}

func NewUserTeam(user, team string) *UserTeam {
	return &UserTeam{
		User: uuid.MustParse(user),
		Team: uuid.MustParse(team),
	}
}

type TaskComment struct {
	ID      uuid.UUID `json:"id"`
	Task    uuid.UUID `json:"task"`
	Author  uuid.UUID `json:"author"`
	Content string    `json:"content"`
}

type TaskCommentCreateRequest struct {
	Task    string `json:"task"`
	Author  string `json:"author"`
	Content string `json:"content"`
}

func NewTaskComment(task, author, content string) *TaskComment {
	return &TaskComment{
		ID:      uuid.New(),
		Task:    uuid.MustParse(task),
		Author:  uuid.MustParse(author),
		Content: content,
	}
}
