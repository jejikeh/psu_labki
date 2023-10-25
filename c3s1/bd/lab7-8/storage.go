package main

import (
	"context"
	"fmt"
	"log"

	"github.com/google/uuid"
	"github.com/jackc/pgx/v5"
)

// https://medium.com/@emekadc/how-to-implement-one-to-one-one-to-many-and-many-to-many-relationships-when-designing-a-database-9da2de684710

type Storage interface {
	CreateProject(*Project) error
	DeleteProject(uuid.UUID) error
	UpdateProject(*Project) error
	GetProject(uuid.UUID) (*Project, error)
	GetProjects() ([]Project, error)

	CreateUser(*User) error
	DeleteUser(uuid.UUID) error
	UpdateUser(*User) error
	GetUser(uuid.UUID) (*User, error)
	GetUsers() ([]User, error)

	CreateProjectStatus(*ProjectStatus) error
	DeleteProjectStatus(uuid.UUID) error
	UpdateProjectStatus(*ProjectStatus) error
	GetProjectStatus(uuid.UUID) (*ProjectStatus, error)
	GetProjectStatuses() ([]ProjectStatus, error)

	CreateFinancialReport(*FinancialReport) error
	DeleteFinancialReport(uuid.UUID) error
	UpdateFinancialReport(*FinancialReport) error
	GetFinancialReport(uuid.UUID) (*FinancialReport, error)
	GetFinancialReports() ([]FinancialReport, error)

	CreateTaskStatus(*TaskStatus) error
	DeleteTaskStatus(uuid.UUID) error
	UpdateTaskStatus(*TaskStatus) error
	GetTaskStatus(uuid.UUID) (*TaskStatus, error)
	GetTaskStatuses() ([]TaskStatus, error)

	CreateTask(*Task) error
	DeleteTask(uuid.UUID) error
	UpdateTask(*Task) error
	GetTask(uuid.UUID) (*Task, error)
	GetTasks() ([]Task, error)

	CreateRole(*Role) error
	DeleteRole(uuid.UUID) error
	UpdateRole(*Role) error
	GetRole(uuid.UUID) (*Role, error)
	GetRoles() ([]Role, error)

	CreateTeam(*Team) error
	DeleteTeam(uuid.UUID) error
	UpdateTeam(*Team) error
	GetTeam(uuid.UUID) (*Team, error)
	GetTeams() ([]Team, error)

	AddUserToTeam(*UserTeam) error
	DeleteUserFromTeam(uuid.UUID, uuid.UUID) error
	GetUserTeam(uuid.UUID, uuid.UUID) (*UserTeam, error)
	GetUserTeams(uuid.UUID) ([]UserTeam, error)

	CreateTaskComment(*TaskComment) error
	DeleteTaskComment(uuid.UUID) error
	UpdateTaskComment(*TaskComment) error
	GetTaskComment(uuid.UUID) (*TaskComment, error)
	GetTaskComments() ([]TaskComment, error)
}

type PostgresStorage struct {
	db *pgx.Conn
}

func NewPostgresStorage(connectionString *string) (*PostgresStorage, error) {
	conn, err := pgx.Connect(context.Background(), *connectionString)
	if err != nil {
		return nil, err
	}

	return &PostgresStorage{
		db: conn,
	}, nil
}

func (s *PostgresStorage) Close() error {
	return s.db.Close(context.Background())
}

func (s *PostgresStorage) InitTables() error {
	err := createRoleTable(s.db)
	if err != nil {
		return err
	}

	err = createUserTable(s.db)
	if err != nil {
		return err
	}

	err = createProjectStatusTable(s.db)
	if err != nil {
		return err
	}

	err = createTaskStatusTable(s.db)
	if err != nil {
		return err
	}

	err = createProjectTable(s.db)
	if err != nil {
		return err
	}

	err = createFinancialReportTable(s.db)
	if err != nil {
		return err
	}

	err = createTaskTable(s.db)
	if err != nil {
		return err
	}

	err = createTeamTable(s.db)
	if err != nil {
		return err
	}

	err = createUserTeamTable(s.db)
	if err != nil {
		return err
	}

	err = createTaskCommentTable(s.db)
	if err != nil {
		return err
	}

	// Seed data
	err = s.seedProjectStatuses()
	if err != nil {
		log.Printf("Unable to seed project statuses: %v\n", err)
	}

	err = s.seedTaskStatuses()
	if err != nil {
		log.Printf("Unable to seed task statuses: %v\n", err)
	}

	err = s.seedRoles()
	if err != nil {
		log.Printf("Unable to seed roles: %v\n", err)
	}

	return nil
}

func (s *PostgresStorage) seedProjectStatuses() error {
	projectStatuses := []ProjectStatusCreateRequest{
		{
			Title:       "Active",
			Description: "Active project",
		},
		{
			Title:       "Archived",
			Description: "Archived project",
		},
		{
			Title:       "Completed",
			Description: "Completed project",
		},
		{
			Title:       "Cancelled",
			Description: "Cancelled project",
		},
	}

	for _, projectStatus := range projectStatuses {
		if err := s.CreateProjectStatus(NewProjectStatus(projectStatus.Title, projectStatus.Description)); err != nil {
			return err
		}
	}

	return nil
}

func (s *PostgresStorage) seedTaskStatuses() error {
	taskStatuses := []TaskStatusCreateRequest{
		{
			Title:       "Open",
			Description: "The task is newly created and has not been assigned to anyone yet. It is awaiting further action or assignment.",
			Staging:     false,
		},
		{
			Title:       "In progress",
			Description: "The task has been assigned to a team member and is currently being worked on. It indicates that someone is actively working on the task.",
			Staging:     false,
		},
		{
			Title:       "On hold",
			Description: "The task is temporarily paused or delayed due to some external factors. It could be waiting for additional information, resources, or approvals before it can be continued.",
			Staging:     false,
		},
		{
			Title:       "Blocked",
			Description: "The task is unable to proceed due to dependencies or issues outside the control of the assigned team member. It requires resolution of the blocking issue before it can progress.",
			Staging:     true,
		},
		{
			Title:       "Staging",
			Description: "The Review stage is a critical phase in the task management workflow where tasks are carefully examined and assessed by designated reviewers or stakeholders. The purpose of the Review stage is to ensure that tasks meet the required standards, quality, and objectives before they can proceed to the next stage or be considered complete.",
			Staging:     true,
		},
		{
			Title:       "Completed",
			Description: "The task has been finished successfully and all required deliverables or objectives have been met.",
			Staging:     false,
		},
	}

	for _, projectStatus := range taskStatuses {
		if err := s.CreateTaskStatus(NewTaskStatus(projectStatus.Title, projectStatus.Description, projectStatus.Staging)); err != nil {
			return err
		}
	}

	return nil
}

func (s *PostgresStorage) seedRoles() error {
	roles := []RoleCreateRequest{
		{
			Title:       "Project Manager",
			Description: "A Project Manager is a key role in project management responsible for the overall planning, coordination, and execution of a project. The Project Manager serves as the central point of contact and acts as a leader, facilitator, and decision-maker throughout the project lifecycle.",
		},
		{
			Title:       "Human Resources",
			Description: "Human Resources is a department or function within an organization that is responsible for managing the organization's workforce and ensuring the effective utilization of human capital. The HR team is primarily focused on supporting and developing employees and aligning their efforts with the organization's goals and objectives.",
		},
		{
			Title:       "Quality Assurance",
			Description: "Quality Assurance is a set of activities and processes designed to ensure that products, services, or processes meet established quality standards. The primary objective of QA is to prevent defects, errors, or issues from occurring or to identify them early in the development or production lifecycle, enabling corrective actions to be taken.",
		},
		{
			Title:       "Custromer Support",
			Description: "Customer support involves providing assistance, guidance, and resolution to customers or users who have questions, problems, or feedback regarding a product, service, or system. The primary goal of customer support is to ensure customer satisfaction and maintain a positive relationship with customers.",
		},
	}

	for _, role := range roles {
		if err := s.CreateRole(NewRole(role.Title, role.Description)); err != nil {
			return err
		}
	}

	return nil
}

func createProjectTable(conn *pgx.Conn) error {
	query := `CREATE TABLE IF NOT EXISTS projects (
		id TEXT UNIQUE,	
		name TEXT NOT NULL,
		description TEXT,

		fk_project_manager_id TEXT UNIQUE,
		FOREIGN KEY (fk_project_manager_id) REFERENCES users(id),

		fk_project_status_id TEXT,
		FOREIGN KEY (fk_project_status_id) REFERENCES project_statuses(id),

		PRIMARY KEY (id, fk_project_manager_id)
	);`

	_, err := conn.Exec(context.Background(), query)
	if err != nil {
		return err
	}

	return nil
}

func createTaskTable(conn *pgx.Conn) error {
	query := `CREATE TABLE IF NOT EXISTS tasks (
		id TEXT PRIMARY KEY,
		title TEXT NOT NULL,
		description TEXT,

		fk_assignee_id TEXT,
		FOREIGN KEY (fk_assignee_id) REFERENCES users(id),

		fk_project_id TEXT,
		FOREIGN KEY (fk_project_id) REFERENCES projects(id),

		fk_task_status_id TEXT,
		FOREIGN KEY (fk_task_status_id) REFERENCES task_statuses(id)
	);`

	_, err := conn.Exec(context.Background(), query)
	if err != nil {
		return err
	}

	return nil
}

func createTaskCommentTable(conn *pgx.Conn) error {
	query := `CREATE TABLE IF NOT EXISTS task_comments (
		id TEXT PRIMARY KEY,

		content TEXT NOT NULL,
		fk_task_id TEXT NOT NULL,
		FOREIGN KEY (fk_task_id) REFERENCES tasks(id),

		fk_author_id TEXT NOT NULL,
		FOREIGN KEY (fk_author_id) REFERENCES users(id)
	);`

	_, err := conn.Exec(context.Background(), query)
	if err != nil {
		return err
	}

	return nil
}

func createUserTable(conn *pgx.Conn) error {
	query := `CREATE TABLE IF NOT EXISTS users (
		id TEXT PRIMARY KEY,
		name TEXT NOT NULL,
		email TEXT
	);`

	_, err := conn.Exec(context.Background(), query)
	if err != nil {
		return err
	}

	return nil
}

func createProjectStatusTable(conn *pgx.Conn) error {
	query := `CREATE TABLE IF NOT EXISTS project_statuses (
		id TEXT PRIMARY KEY,
		title TEXT UNIQUE NOT NULL,
		description TEXT
	);`

	_, err := conn.Exec(context.Background(), query)
	if err != nil {
		return err
	}

	return nil
}

func createRoleTable(conn *pgx.Conn) error {
	query := `CREATE TABLE IF NOT EXISTS roles (
		id TEXT PRIMARY KEY,
		title TEXT UNIQUE NOT NULL,
		description TEXT
	);`

	_, err := conn.Exec(context.Background(), query)
	if err != nil {
		return err
	}

	return nil
}

func createTaskStatusTable(conn *pgx.Conn) error {
	query := `CREATE TABLE IF NOT EXISTS task_statuses (
		id TEXT PRIMARY KEY,
		title TEXT UNIQUE NOT NULL,
		description TEXT,
		staging BOOLEAN NOT NULL
	);`

	_, err := conn.Exec(context.Background(), query)
	if err != nil {
		return err
	}

	return nil
}

func createFinancialReportTable(conn *pgx.Conn) error {
	query := `CREATE TABLE IF NOT EXISTS financial_reports (
		id TEXT PRIMARY KEY,
		value INT NOT NULL,
		additional_info TEXT,

		fk_project_id TEXT UNIQUE,
		FOREIGN KEY (fk_project_id) REFERENCES projects(id)
	);`

	_, err := conn.Exec(context.Background(), query)
	if err != nil {
		return err
	}

	return nil
}

func createTeamTable(conn *pgx.Conn) error {
	query := `CREATE TABLE IF NOT EXISTS teams (
		id TEXT PRIMARY KEY,
		description TEXT,

		fk_project_id TEXT NOT NULL,
		FOREIGN KEY (fk_project_id) REFERENCES projects(id)
	);`

	_, err := conn.Exec(context.Background(), query)
	if err != nil {
		return err
	}

	return nil
}

func createUserTeamTable(conn *pgx.Conn) error {
	query := `CREATE TABLE IF NOT EXISTS user_teams (
		fk_user_id TEXT,
		fk_team_id TEXT,
		FOREIGN KEY (fk_user_id) REFERENCES users(id),
		FOREIGN KEY (fk_team_id) REFERENCES teams(id),
		PRIMARY KEY (fk_user_id, fk_team_id)
	);`

	_, err := conn.Exec(context.Background(), query)
	if err != nil {
		return err
	}

	return nil
}

// ======== PROJECTS ============

func (s *PostgresStorage) CreateProject(project *Project) error {
	query := `INSERT INTO projects (id, name, description, fk_project_manager_id, fk_project_status_id) VALUES ($1, $2, $3, $4, $5) RETURNING id`

	pk := uuid.UUID{}
	err := s.db.QueryRow(context.Background(), query, project.ID, project.Name, project.Description, project.UserManager, project.ProjectStatus).Scan(&pk)
	if err != nil {
		return err
	}

	return nil
}

func (s *PostgresStorage) DeleteProject(id uuid.UUID) error {
	_, err := s.db.Exec(context.Background(), "DELETE FROM projects WHERE id = $1", id)
	if err != nil {
		return err
	}

	return nil
}

func (s *PostgresStorage) UpdateProject(project *Project) error {
	return nil
}

func (s *PostgresStorage) GetProject(id uuid.UUID) (*Project, error) {
	project := Project{}

	query := "SELECT id, name, description, fk_project_manager_id, fk_project_status_id FROM projects WHERE id = $1"
	err := s.db.QueryRow(context.Background(), query, id).Scan(&project.ID, &project.Name, &project.Description, &project.UserManager, &project.ProjectStatus)
	if err != nil {
		if err == pgx.ErrNoRows {
			return nil, fmt.Errorf("no project found with id: %v", id)
		}

		return nil, err
	}

	return &project, nil
}

func (s *PostgresStorage) GetProjects() ([]Project, error) {
	projects := []Project{}

	query := "SELECT id, name, description, fk_project_manager_id, fk_project_status_id FROM projects"

	rows, err := s.db.Query(context.Background(), query)
	if err != nil {
		log.Fatalf("Unable to select projects: %v\n", err)
	}

	defer rows.Close()

	for rows.Next() {
		project := Project{}
		err := rows.Scan(&project.ID, &project.Name, &project.Description, &project.UserManager, &project.ProjectStatus)
		if err != nil {
			log.Fatalf("Unable to scan project: %v\n", err)
		}

		projects = append(projects, project)
	}

	return projects, nil
}

// ========= USERS ============

func (s *PostgresStorage) CreateUser(user *User) error {
	query := `INSERT INTO users (id, name, email) VALUES ($1, $2, $3) RETURNING id`

	pk := uuid.UUID{}
	err := s.db.QueryRow(context.Background(), query, user.ID, user.Name, user.Email).Scan(&pk)
	if err != nil {
		return err
	}

	return nil
}

func (s *PostgresStorage) DeleteUser(id uuid.UUID) error {
	_, err := s.db.Exec(context.Background(), "DELETE FROM users WHERE id = $1", id)
	if err != nil {
		return err
	}

	return nil
}

func (s *PostgresStorage) UpdateUser(user *User) error {
	return nil
}

func (s *PostgresStorage) GetUser(id uuid.UUID) (*User, error) {
	user := User{}

	query := "SELECT id, name, email FROM users WHERE id = $1"
	err := s.db.QueryRow(context.Background(), query, id).Scan(&user.ID, &user.Name, &user.Email)
	if err != nil {
		if err == pgx.ErrNoRows {
			return nil, fmt.Errorf("no user found with id: %v", id)
		}

		return nil, err
	}

	return &user, nil
}

func (s *PostgresStorage) GetUsers() ([]User, error) {
	users := []User{}

	query := "SELECT id, name, email FROM users"

	rows, err := s.db.Query(context.Background(), query)
	if err != nil {
		log.Fatalf("Unable to select projects: %v\n", err)
	}

	defer rows.Close()

	for rows.Next() {
		user := User{}
		err := rows.Scan(&user.ID, &user.Name, &user.Email)
		if err != nil {
			log.Fatalf("Unable to scan users: %v\n", err)
		}

		users = append(users, user)
	}

	return users, nil
}

// ====== PROJECT STATUSES ============

func (s *PostgresStorage) CreateProjectStatus(projectStatus *ProjectStatus) error {
	query := `INSERT INTO project_statuses (id, title, description) VALUES ($1, $2, $3) RETURNING id`

	pk := uuid.UUID{}
	err := s.db.QueryRow(context.Background(), query, projectStatus.ID, projectStatus.Title, projectStatus.Description).Scan(&pk)
	if err != nil {
		return err
	}

	return nil
}

func (s *PostgresStorage) DeleteProjectStatus(id uuid.UUID) error {
	_, err := s.db.Exec(context.Background(), "DELETE FROM project_statuses WHERE id = $1", id)
	if err != nil {
		return err
	}

	return nil
}

func (s *PostgresStorage) UpdateProjectStatus(user *ProjectStatus) error {
	return nil
}

func (s *PostgresStorage) GetProjectStatus(id uuid.UUID) (*ProjectStatus, error) {
	projectStatus := ProjectStatus{}

	query := "SELECT id, title, description FROM project_statuses WHERE id = $1"
	err := s.db.QueryRow(context.Background(), query, id).Scan(&projectStatus.ID, &projectStatus.Title, &projectStatus.Description)
	if err != nil {
		if err == pgx.ErrNoRows {
			return nil, fmt.Errorf("no project_status found with id: %v", id)
		}

		return nil, err
	}

	return &projectStatus, nil
}

func (s *PostgresStorage) GetProjectStatuses() ([]ProjectStatus, error) {
	projectStatuses := []ProjectStatus{}

	query := "SELECT id, title, description FROM project_statuses"

	rows, err := s.db.Query(context.Background(), query)
	if err != nil {
		log.Fatalf("Unable to select project_statuses: %v\n", err)
	}

	defer rows.Close()

	for rows.Next() {
		projectStatus := ProjectStatus{}
		err := rows.Scan(&projectStatus.ID, &projectStatus.Title, &projectStatus.Description)
		if err != nil {
			log.Fatalf("Unable to scan project_statuses: %v\n", err)
		}

		projectStatuses = append(projectStatuses, projectStatus)
	}

	return projectStatuses, nil
}

// ====== FINANCIAL REPORT =====

func (s *PostgresStorage) CreateFinancialReport(financialReport *FinancialReport) error {
	query := `INSERT INTO financial_reports (id, value, additional_info, fk_project_id) VALUES ($1, $2, $3, $4) RETURNING id`

	pk := uuid.UUID{}
	err := s.db.QueryRow(context.Background(), query, financialReport.ID, financialReport.Value, financialReport.AdditionalInfo, financialReport.Project).Scan(&pk)
	if err != nil {
		return err
	}

	return nil
}

func (s *PostgresStorage) DeleteFinancialReport(id uuid.UUID) error {
	_, err := s.db.Exec(context.Background(), "DELETE FROM financial_reports WHERE id = $1", id)
	if err != nil {
		return err
	}

	return nil
}

func (s *PostgresStorage) UpdateFinancialReport(financialReport *FinancialReport) error {
	return nil
}

func (s *PostgresStorage) GetFinancialReport(id uuid.UUID) (*FinancialReport, error) {
	financialReport := FinancialReport{}

	query := "SELECT id, value, additional_info, fK_project_id FROM financial_reports WHERE id = $1"
	err := s.db.QueryRow(context.Background(), query, id).Scan(&financialReport.ID, &financialReport.Value, &financialReport.AdditionalInfo, &financialReport.Project)
	if err != nil {
		if err == pgx.ErrNoRows {
			return nil, fmt.Errorf("no financial_report found with id: %v", id)
		}

		return nil, err
	}

	return &financialReport, nil
}

func (s *PostgresStorage) GetFinancialReports() ([]FinancialReport, error) {
	financialReports := []FinancialReport{}

	query := "SELECT id, value, additional_info, fK_project_id FROM financial_reports"

	rows, err := s.db.Query(context.Background(), query)
	if err != nil {
		log.Fatalf("Unable to select financial_reports: %v\n", err)
	}

	defer rows.Close()

	for rows.Next() {
		financialReport := FinancialReport{}
		err := rows.Scan(&financialReport.ID, &financialReport.Value, &financialReport.AdditionalInfo, &financialReport.Project)
		if err != nil {
			log.Fatalf("Unable to scan financial_reports: %v\n", err)
		}

		financialReports = append(financialReports, financialReport)
	}

	return financialReports, nil
}

// ====== TASK STATUSES ============

func (s *PostgresStorage) CreateTaskStatus(taskStatus *TaskStatus) error {
	query := `INSERT INTO task_statuses (id, title, description, staging) VALUES ($1, $2, $3, $4) RETURNING id`

	pk := uuid.UUID{}
	err := s.db.QueryRow(context.Background(), query, taskStatus.ID, taskStatus.Title, taskStatus.Description, taskStatus.Staging).Scan(&pk)
	if err != nil {
		return err
	}

	return nil
}

func (s *PostgresStorage) DeleteTaskStatus(id uuid.UUID) error {
	_, err := s.db.Exec(context.Background(), "DELETE FROM task_statuses WHERE id = $1", id)
	if err != nil {
		return err
	}

	return nil
}

func (s *PostgresStorage) UpdateTaskStatus(user *TaskStatus) error {
	return nil
}

func (s *PostgresStorage) GetTaskStatus(id uuid.UUID) (*TaskStatus, error) {
	taskStatus := TaskStatus{}

	query := "SELECT id, title, description, staging FROM task_statuses WHERE id = $1"
	err := s.db.QueryRow(context.Background(), query, id).Scan(&taskStatus.ID, &taskStatus.Title, &taskStatus.Description, &taskStatus.Staging)
	if err != nil {
		if err == pgx.ErrNoRows {
			return nil, fmt.Errorf("no task_status found with id: %v", id)
		}

		return nil, err
	}

	return &taskStatus, nil
}

func (s *PostgresStorage) GetTaskStatuses() ([]TaskStatus, error) {
	taskStatuses := []TaskStatus{}

	query := "SELECT id, title, description, staging FROM task_statuses"

	rows, err := s.db.Query(context.Background(), query)
	if err != nil {
		log.Fatalf("Unable to select task_statuses: %v\n", err)
	}

	defer rows.Close()

	for rows.Next() {
		taskStatus := TaskStatus{}
		err := rows.Scan(&taskStatus.ID, &taskStatus.Title, &taskStatus.Description, &taskStatus.Staging)
		if err != nil {
			log.Fatalf("Unable to scan task_statuses: %v\n", err)
		}

		taskStatuses = append(taskStatuses, taskStatus)
	}

	return taskStatuses, nil
}

// ======== TASK ============

func (s *PostgresStorage) CreateTask(task *Task) error {
	query := `INSERT INTO tasks (id, title, description, fk_project_id, fk_assignee_id, fk_task_status_id) VALUES ($1, $2, $3, $4, $5, $6) RETURNING id`

	pk := uuid.UUID{}
	err := s.db.QueryRow(context.Background(), query, task.ID, task.Title, task.Description, task.Project, task.AssignedTo, task.Status).Scan(&pk)
	if err != nil {
		return err
	}

	return nil
}

func (s *PostgresStorage) DeleteTask(id uuid.UUID) error {
	_, err := s.db.Exec(context.Background(), "DELETE FROM tasks WHERE id = $1", id)
	if err != nil {
		return err
	}

	return nil
}

func (s *PostgresStorage) UpdateTask(task *Task) error {
	return nil
}

func (s *PostgresStorage) GetTask(id uuid.UUID) (*Task, error) {
	task := Task{}

	query := "SELECT id, title, description, fk_project_id, fk_assignee_id, fk_task_status_id FROM tasks WHERE id = $1"
	err := s.db.QueryRow(context.Background(), query, id).Scan(&task.ID, &task.Title, &task.Description, &task.Project, &task.AssignedTo, &task.Status)
	if err != nil {
		if err == pgx.ErrNoRows {
			return nil, fmt.Errorf("no project found with id: %v", id)
		}

		return nil, err
	}

	return &task, nil
}

func (s *PostgresStorage) GetTasks() ([]Task, error) {
	tasks := []Task{}

	query := "SELECT id, title, description, fk_project_id, fk_assignee_id, fk_task_status_id FROM tasks"

	rows, err := s.db.Query(context.Background(), query)
	if err != nil {
		log.Fatalf("Unable to select tasks: %v\n", err)
	}

	defer rows.Close()

	for rows.Next() {
		task := Task{}
		err := rows.Scan(&task.ID, &task.Title, &task.Description, &task.Project, &task.AssignedTo, &task.Status)
		if err != nil {
			log.Fatalf("Unable to scan tasks: %v\n", err)
		}

		tasks = append(tasks, task)
	}

	return tasks, nil
}

// ======== ROLE ============

func (s *PostgresStorage) CreateRole(role *Role) error {
	query := `INSERT INTO roles (id, title, description) VALUES ($1, $2, $3) RETURNING id`

	pk := uuid.UUID{}
	err := s.db.QueryRow(context.Background(), query, role.ID, role.Title, role.Description).Scan(&pk)
	if err != nil {
		return err
	}

	return nil
}

func (s *PostgresStorage) DeleteRole(id uuid.UUID) error {
	_, err := s.db.Exec(context.Background(), "DELETE FROM roles WHERE id = $1", id)
	if err != nil {
		return err
	}

	return nil
}

func (s *PostgresStorage) UpdateRole(role *Role) error {
	return nil
}

func (s *PostgresStorage) GetRole(id uuid.UUID) (*Role, error) {
	role := Role{}

	query := "SELECT id, title, description FROM roles WHERE id = $1"
	err := s.db.QueryRow(context.Background(), query, id).Scan(&role.ID, &role.Title, &role.Description)
	if err != nil {
		if err == pgx.ErrNoRows {
			return nil, fmt.Errorf("no roles found with id: %v", id)
		}

		return nil, err
	}

	return &role, nil
}

func (s *PostgresStorage) GetRoles() ([]Role, error) {
	roles := []Role{}

	query := "SELECT id, title, description FROM roles"

	rows, err := s.db.Query(context.Background(), query)
	if err != nil {
		log.Fatalf("Unable to select roles: %v\n", err)
	}

	defer rows.Close()

	for rows.Next() {
		role := Role{}
		err := rows.Scan(&role.ID, &role.Title, &role.Description)
		if err != nil {
			log.Fatalf("Unable to scan roles: %v\n", err)
		}

		roles = append(roles, role)
	}

	return roles, nil
}

// ======= TEAM ============

func (s *PostgresStorage) CreateTeam(team *Team) error {
	query := `INSERT INTO teams (id, description, fk_project_id) VALUES ($1, $2, $3) RETURNING id`

	pk := uuid.UUID{}
	err := s.db.QueryRow(context.Background(), query, team.ID, team.Description, team.Project).Scan(&pk)
	if err != nil {
		return err
	}

	return nil
}

func (s *PostgresStorage) DeleteTeam(id uuid.UUID) error {
	_, err := s.db.Exec(context.Background(), "DELETE FROM teams WHERE id = $1", id)
	if err != nil {
		return err
	}

	return nil
}

func (s *PostgresStorage) UpdateTeam(team *Team) error {
	return nil
}

func (s *PostgresStorage) GetTeam(id uuid.UUID) (*Team, error) {
	team := Team{}

	query := "SELECT id, description, fK_project_id FROM teams WHERE id = $1"
	err := s.db.QueryRow(context.Background(), query, id).Scan(&team.ID, &team.Description, &team.Project)
	if err != nil {
		if err == pgx.ErrNoRows {
			return nil, fmt.Errorf("no team found with id: %v", id)
		}

		return nil, err
	}

	return &team, nil
}

func (s *PostgresStorage) GetTeams() ([]Team, error) {
	teams := []Team{}

	query := "SELECT id, description, fK_project_id FROM teams"

	rows, err := s.db.Query(context.Background(), query)
	if err != nil {
		log.Fatalf("Unable to select teams: %v\n", err)
	}

	defer rows.Close()

	for rows.Next() {
		team := Team{}
		err := rows.Scan(&team.ID, &team.Description, &team.Project)
		if err != nil {
			log.Fatalf("Unable to scan teams: %v\n", err)
		}

		teams = append(teams, team)
	}

	return teams, nil
}

// ======= USER TEAM ============

func (s *PostgresStorage) AddUserToTeam(userTeam *UserTeam) error {
	query := `INSERT INTO user_teams (fk_user_id, fk_team_id) VALUES ($1, $2) RETURNING fk_user_id`

	pk := uuid.UUID{}
	err := s.db.QueryRow(context.Background(), query, userTeam.User, userTeam.Team).Scan(&pk)
	if err != nil {
		return err
	}

	return nil
}

func (s *PostgresStorage) DeleteUserFromTeam(userId, teamId uuid.UUID) error {
	_, err := s.db.Exec(context.Background(), "DELETE FROM user_teams WHERE fk_user_id = $1 AND fk_team_id = $2", userId, teamId)
	if err != nil {
		return err
	}

	return nil
}

func (s *PostgresStorage) GetUserTeam(id, teamId uuid.UUID) (*UserTeam, error) {
	userTeam := UserTeam{}

	query := "SELECT fk_user_id, fk_team_id FROM user_teams WHERE fk_user_id = $1 OR fk_team_id = $2"
	err := s.db.QueryRow(context.Background(), query, id, teamId).Scan(&userTeam.User, &userTeam.Team)
	if err != nil {
		if err == pgx.ErrNoRows {
			return nil, fmt.Errorf("no team found with id: %v", id)
		}

		return nil, err
	}

	return &userTeam, nil
}

func (s *PostgresStorage) GetUserTeams(userId uuid.UUID) ([]UserTeam, error) {
	teams := []UserTeam{}

	query := "SELECT fk_user_id, fk_team_id FROM user_teams WHERE fk_user_id = $1"

	rows, err := s.db.Query(context.Background(), query, userId)
	if err != nil {
		log.Fatalf("Unable to select user teams: %v\n", err)
	}

	defer rows.Close()

	for rows.Next() {
		team := UserTeam{}
		err := rows.Scan(&team.User, &team.Team)
		if err != nil {
			log.Fatalf("Unable to scan user teams: %v\n", err)
		}

		teams = append(teams, team)
	}

	return teams, nil
}

// ======= TASK COMMENT ============

func (s *PostgresStorage) CreateTaskComment(taskComment *TaskComment) error {
	query := `INSERT INTO task_comments (id, fk_task_id, fk_author_id, content) VALUES ($1, $2, $3, $4) RETURNING id`

	pk := uuid.UUID{}
	err := s.db.QueryRow(context.Background(), query, taskComment.ID, taskComment.Task, taskComment.Author, taskComment.Content).Scan(&pk)
	if err != nil {
		return err
	}

	return nil
}

func (s *PostgresStorage) DeleteTaskComment(id uuid.UUID) error {
	_, err := s.db.Exec(context.Background(), "DELETE FROM task_comments WHERE id = $1", id)
	if err != nil {
		return err
	}

	return nil
}

func (s *PostgresStorage) UpdateTaskComment(taskComment *TaskComment) error {
	return nil
}

func (s *PostgresStorage) GetTaskComment(id uuid.UUID) (*TaskComment, error) {
	taskComment := TaskComment{}

	query := "SELECT id, fK_task_id, fk_author_id, content FROM task_comments WHERE id = $1"
	err := s.db.QueryRow(context.Background(), query, id).Scan(&taskComment.ID, &taskComment.Task, &taskComment.Author, &taskComment.Content)
	if err != nil {
		if err == pgx.ErrNoRows {
			return nil, fmt.Errorf("no task comment found with id: %v", id)
		}

		return nil, err
	}

	return &taskComment, nil
}

func (s *PostgresStorage) GetTaskComments() ([]TaskComment, error) {
	taskComments := []TaskComment{}

	query := "SELECT id, fk_task_id, fk_author_id, content FROM task_comments"

	rows, err := s.db.Query(context.Background(), query)
	if err != nil {
		log.Fatalf("Unable to select task comments: %v\n", err)
	}

	defer rows.Close()

	for rows.Next() {
		taskComment := TaskComment{}
		err := rows.Scan(&taskComment.ID, &taskComment.Task, &taskComment.Author, &taskComment.Content)
		if err != nil {
			log.Fatalf("Unable to scan task comments: %v\n", err)
		}

		taskComments = append(taskComments, taskComment)
	}

	return taskComments, nil
}
