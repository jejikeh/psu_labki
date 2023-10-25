package main

import (
	"encoding/json"
	"fmt"
	"log"
	"net/http"

	"github.com/google/uuid"
	"github.com/gorilla/mux"
)

func (s *ApiServer) Run() {
	router := mux.NewRouter()

	router.HandleFunc("/project/", makeHttpHandleFunc(s.handleProject))
	router.HandleFunc("/project/{id}/", makeHttpHandleFunc(s.handleProjectWithId))

	router.HandleFunc("/user/", makeHttpHandleFunc(s.handleUser))
	router.HandleFunc("/user/{id}/", makeHttpHandleFunc(s.handleUserWithId))

	router.HandleFunc("/project_status/", makeHttpHandleFunc(s.handleProjectStatus))
	router.HandleFunc("/project_status/{id}/", makeHttpHandleFunc(s.handleProjectStatusWithId))

	router.HandleFunc("/financial_report/", makeHttpHandleFunc(s.handleFinancialReport))
	router.HandleFunc("/financial_report/{id}/", makeHttpHandleFunc(s.handleFinancialReportWithId))

	router.HandleFunc("/task_status/", makeHttpHandleFunc(s.handleTaskStatus))
	router.HandleFunc("/task_status/{id}/", makeHttpHandleFunc(s.handleTaskStatusWithId))

	router.HandleFunc("/task/", makeHttpHandleFunc(s.handleTask))
	router.HandleFunc("/task/{id}/", makeHttpHandleFunc(s.handleTaskWithId))

	router.HandleFunc("/role/", makeHttpHandleFunc(s.handleRole))
	router.HandleFunc("/role/{id}/", makeHttpHandleFunc(s.handleRoleWithId))

	router.HandleFunc("/team/", makeHttpHandleFunc(s.handleTeam))
	router.HandleFunc("/team/{id}/", makeHttpHandleFunc(s.handleTeamWithId))

	router.HandleFunc("/comment/", makeHttpHandleFunc(s.handleTaskComment))
	router.HandleFunc("/comment/{id}/", makeHttpHandleFunc(s.handleTaskCommentWithId))

	router.HandleFunc("/user/{user_id}/team/{id}/", makeHttpHandleFunc(s.handleAddUserToTeam))
	router.HandleFunc("/user/{id}/team/", makeHttpHandleFunc(s.handleUserTeams))

	log.Printf("Listening on %s\n", s.listenAddr)

	http.ListenAndServe(s.listenAddr, router)
}

func WriteJson(w http.ResponseWriter, status int, v any) error {
	w.Header().Add("Content-Type", "application/json")
	w.WriteHeader(status)

	return json.NewEncoder(w).Encode(v)
}

type apiFunc func(http.ResponseWriter, *http.Request) error

type ApiError struct {
	Error string `json:"error"`
}

func makeHttpHandleFunc(f apiFunc) http.HandlerFunc {
	return func(w http.ResponseWriter, r *http.Request) {
		if err := f(w, r); err != nil {
			WriteJson(w, http.StatusInternalServerError, ApiError{Error: err.Error()})
		}
	}
}

type ApiServer struct {
	listenAddr string
	store      Storage
}

func NewApiServer(listenAddr string, store Storage) *ApiServer {
	return &ApiServer{
		listenAddr: listenAddr,
		store:      store,
	}
}

// ======= Project =========

func (s *ApiServer) handleProject(w http.ResponseWriter, r *http.Request) error {
	if r.Method == http.MethodGet {
		return s.handleGetProjects(w, r)
	}

	if r.Method == http.MethodPost {
		return s.handleCreateProject(w, r)
	}

	if r.Method == http.MethodPut {
		return s.handleAssignManagerToProject(w, r)
	}

	return fmt.Errorf("unsupported method: %s", r.Method)
}

func (s *ApiServer) handleGetProjects(w http.ResponseWriter, r *http.Request) error {
	projects, err := s.store.GetProjects()
	if err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, projects)
}

func (s *ApiServer) handleProjectWithId(w http.ResponseWriter, r *http.Request) error {
	if r.Method == http.MethodGet {

		id := mux.Vars(r)["id"]
		project, err := s.store.GetProject(uuid.MustParse(id))
		if err != nil {
			return err
		}

		return WriteJson(w, http.StatusOK, project)
	}

	if r.Method == http.MethodDelete {
		return s.handleDeleteProject(w, r)
	}

	return fmt.Errorf("unsupported method: %s", r.Method)
}

func (s *ApiServer) handleCreateProject(w http.ResponseWriter, r *http.Request) error {
	projectRequest := ProjectCreateRequest{}
	if err := json.NewDecoder(r.Body).Decode(&projectRequest); err != nil {
		return err
	}

	project := NewProject(projectRequest.Name, projectRequest.Description, uuid.MustParse(projectRequest.UserManager), uuid.MustParse(projectRequest.ProjectStatus))
	if err := s.store.CreateProject(project); err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, project)
}

func (s *ApiServer) handleDeleteProject(w http.ResponseWriter, r *http.Request) error {
	err := s.store.DeleteProject(uuid.MustParse(mux.Vars(r)["id"]))
	if err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, map[string]uuid.UUID{
		"deleted": uuid.MustParse(mux.Vars(r)["id"]),
	})
}

func (s *ApiServer) handleAssignManagerToProject(w http.ResponseWriter, r *http.Request) error {
	return nil
}

// ====== USERS =======

func (s *ApiServer) handleUser(w http.ResponseWriter, r *http.Request) error {
	if r.Method == http.MethodGet {
		return s.handleGetUsers(w, r)
	}

	if r.Method == http.MethodPost {
		return s.handleCreateUser(w, r)
	}

	return fmt.Errorf("unsupported method: %s", r.Method)
}

func (s *ApiServer) handleGetUsers(w http.ResponseWriter, r *http.Request) error {
	projects, err := s.store.GetUsers()
	if err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, projects)
}

func (s *ApiServer) handleUserWithId(w http.ResponseWriter, r *http.Request) error {
	if r.Method == http.MethodGet {

		id := mux.Vars(r)["id"]
		project, err := s.store.GetUser(uuid.MustParse(id))
		if err != nil {
			return err
		}

		return WriteJson(w, http.StatusOK, project)
	}

	if r.Method == http.MethodDelete {
		return s.handleDeleteUser(w, r)
	}

	return fmt.Errorf("unsupported method: %s", r.Method)
}

func (s *ApiServer) handleCreateUser(w http.ResponseWriter, r *http.Request) error {
	userCreateRequest := UserCreateRequest{}
	if err := json.NewDecoder(r.Body).Decode(&userCreateRequest); err != nil {
		return err
	}

	user := NewUser(userCreateRequest.Name, userCreateRequest.Email)
	if err := s.store.CreateUser(user); err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, user)
}

func (s *ApiServer) handleDeleteUser(w http.ResponseWriter, r *http.Request) error {
	err := s.store.DeleteUser(uuid.MustParse(mux.Vars(r)["id"]))
	if err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, map[string]uuid.UUID{
		"deleted": uuid.MustParse(mux.Vars(r)["id"]),
	})
}

// ====== PROJECT STATUS =======

func (s *ApiServer) handleProjectStatus(w http.ResponseWriter, r *http.Request) error {
	if r.Method == http.MethodGet {
		return s.handleGetProjectStatuses(w, r)
	}

	if r.Method == http.MethodPost {
		return s.handleCreateProjectStatus(w, r)
	}

	return fmt.Errorf("unsupported method: %s", r.Method)
}

func (s *ApiServer) handleGetProjectStatuses(w http.ResponseWriter, r *http.Request) error {
	projects, err := s.store.GetProjectStatuses()
	if err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, projects)
}

func (s *ApiServer) handleProjectStatusWithId(w http.ResponseWriter, r *http.Request) error {
	if r.Method == http.MethodGet {
		id := mux.Vars(r)["id"]
		project, err := s.store.GetProjectStatus(uuid.MustParse(id))
		if err != nil {
			return err
		}

		return WriteJson(w, http.StatusOK, project)
	}

	if r.Method == http.MethodDelete {
		return s.handleDeleteProjectStatus(w, r)
	}

	return fmt.Errorf("unsupported method: %s", r.Method)
}

func (s *ApiServer) handleCreateProjectStatus(w http.ResponseWriter, r *http.Request) error {
	projectRequest := ProjectStatusCreateRequest{}
	if err := json.NewDecoder(r.Body).Decode(&projectRequest); err != nil {
		return err
	}

	projectStatus := NewProjectStatus(projectRequest.Title, projectRequest.Description)
	if err := s.store.CreateProjectStatus(projectStatus); err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, projectStatus)
}

func (s *ApiServer) handleDeleteProjectStatus(w http.ResponseWriter, r *http.Request) error {
	err := s.store.DeleteProjectStatus(uuid.MustParse(mux.Vars(r)["id"]))
	if err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, map[string]uuid.UUID{
		"deleted": uuid.MustParse(mux.Vars(r)["id"]),
	})
}

// ===== FINANCIAL REPORTS =======

func (s *ApiServer) handleFinancialReport(w http.ResponseWriter, r *http.Request) error {
	if r.Method == http.MethodGet {
		return s.handleGetFinancialReports(w, r)
	}

	if r.Method == http.MethodPost {
		return s.handleCreateFinancialReport(w, r)
	}

	return fmt.Errorf("unsupported method: %s", r.Method)
}

func (s *ApiServer) handleGetFinancialReports(w http.ResponseWriter, r *http.Request) error {
	financialReport, err := s.store.GetFinancialReports()
	if err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, financialReport)
}

func (s *ApiServer) handleFinancialReportWithId(w http.ResponseWriter, r *http.Request) error {
	if r.Method == http.MethodGet {
		id := mux.Vars(r)["id"]
		financialReport, err := s.store.GetFinancialReport(uuid.MustParse(id))
		if err != nil {
			return err
		}

		return WriteJson(w, http.StatusOK, financialReport)
	}

	if r.Method == http.MethodDelete {
		return s.handleDeleteFinancialReport(w, r)
	}

	return fmt.Errorf("unsupported method: %s", r.Method)
}

func (s *ApiServer) handleCreateFinancialReport(w http.ResponseWriter, r *http.Request) error {
	financialRequest := FinancialReportCreateRequest{}
	if err := json.NewDecoder(r.Body).Decode(&financialRequest); err != nil {
		return err
	}

	financialReport := NewFinancialReport(financialRequest.Value, financialRequest.AdditionalInfo, financialRequest.Project)
	if err := s.store.CreateFinancialReport(financialReport); err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, financialReport)
}

func (s *ApiServer) handleDeleteFinancialReport(w http.ResponseWriter, r *http.Request) error {
	err := s.store.DeleteFinancialReport(uuid.MustParse(mux.Vars(r)["id"]))
	if err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, map[string]uuid.UUID{
		"deleted": uuid.MustParse(mux.Vars(r)["id"]),
	})
}

// ====== TASK STATUS =======

func (s *ApiServer) handleTaskStatus(w http.ResponseWriter, r *http.Request) error {
	if r.Method == http.MethodGet {
		return s.handleGetTaskStatuses(w, r)
	}

	if r.Method == http.MethodPost {
		return s.handleCreateTaskStatus(w, r)
	}

	return fmt.Errorf("unsupported method: %s", r.Method)
}

func (s *ApiServer) handleGetTaskStatuses(w http.ResponseWriter, r *http.Request) error {
	taskStatus, err := s.store.GetTaskStatuses()
	if err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, taskStatus)
}

func (s *ApiServer) handleTaskStatusWithId(w http.ResponseWriter, r *http.Request) error {
	if r.Method == http.MethodGet {
		id := mux.Vars(r)["id"]
		taskStatus, err := s.store.GetTaskStatus(uuid.MustParse(id))
		if err != nil {
			return err
		}

		return WriteJson(w, http.StatusOK, taskStatus)
	}

	if r.Method == http.MethodDelete {
		return s.handleDeleteTaskStatus(w, r)
	}

	return fmt.Errorf("unsupported method: %s", r.Method)
}

func (s *ApiServer) handleCreateTaskStatus(w http.ResponseWriter, r *http.Request) error {
	taskStatusRequest := TaskStatusCreateRequest{}
	if err := json.NewDecoder(r.Body).Decode(&taskStatusRequest); err != nil {
		return err
	}

	taskStatus := NewTaskStatus(taskStatusRequest.Title, taskStatusRequest.Description, taskStatusRequest.Staging)
	if err := s.store.CreateTaskStatus(taskStatus); err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, taskStatus)
}

func (s *ApiServer) handleDeleteTaskStatus(w http.ResponseWriter, r *http.Request) error {
	err := s.store.DeleteTaskStatus(uuid.MustParse(mux.Vars(r)["id"]))
	if err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, map[string]uuid.UUID{
		"deleted": uuid.MustParse(mux.Vars(r)["id"]),
	})
}

// ======= TASK =========

func (s *ApiServer) handleTask(w http.ResponseWriter, r *http.Request) error {
	if r.Method == http.MethodGet {
		return s.handleGetTasks(w, r)
	}

	if r.Method == http.MethodPost {
		return s.handleCreateTask(w, r)
	}

	return fmt.Errorf("unsupported method: %s", r.Method)
}

func (s *ApiServer) handleGetTasks(w http.ResponseWriter, r *http.Request) error {
	tasks, err := s.store.GetTasks()
	if err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, tasks)
}

func (s *ApiServer) handleTaskWithId(w http.ResponseWriter, r *http.Request) error {
	if r.Method == http.MethodGet {

		id := mux.Vars(r)["id"]
		project, err := s.store.GetTask(uuid.MustParse(id))
		if err != nil {
			return err
		}

		return WriteJson(w, http.StatusOK, project)
	}

	if r.Method == http.MethodDelete {
		return s.handleDeleteTask(w, r)
	}

	return fmt.Errorf("unsupported method: %s", r.Method)
}

func (s *ApiServer) handleCreateTask(w http.ResponseWriter, r *http.Request) error {
	taskRequest := TaskCreateRequest{}
	if err := json.NewDecoder(r.Body).Decode(&taskRequest); err != nil {
		return err
	}

	task := NewTask(taskRequest.Title, taskRequest.Description, uuid.MustParse(string(taskRequest.Project)), uuid.MustParse(taskRequest.Status), uuid.MustParse(taskRequest.AssignedTo))
	if err := s.store.CreateTask(task); err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, task)
}

func (s *ApiServer) handleDeleteTask(w http.ResponseWriter, r *http.Request) error {
	err := s.store.DeleteTask(uuid.MustParse(mux.Vars(r)["id"]))
	if err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, map[string]uuid.UUID{
		"deleted": uuid.MustParse(mux.Vars(r)["id"]),
	})
}

// ====== ROLE =======

func (s *ApiServer) handleRole(w http.ResponseWriter, r *http.Request) error {
	if r.Method == http.MethodGet {
		return s.handleGetRoles(w, r)
	}

	if r.Method == http.MethodPost {
		return s.handleCreateRole(w, r)
	}

	return fmt.Errorf("unsupported method: %s", r.Method)
}

func (s *ApiServer) handleGetRoles(w http.ResponseWriter, r *http.Request) error {
	projects, err := s.store.GetRoles()
	if err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, projects)
}

func (s *ApiServer) handleRoleWithId(w http.ResponseWriter, r *http.Request) error {
	if r.Method == http.MethodGet {
		id := mux.Vars(r)["id"]
		project, err := s.store.GetRole(uuid.MustParse(id))
		if err != nil {
			return err
		}

		return WriteJson(w, http.StatusOK, project)
	}

	if r.Method == http.MethodDelete {
		return s.handleDeleteRole(w, r)
	}

	return fmt.Errorf("unsupported method: %s", r.Method)
}

func (s *ApiServer) handleCreateRole(w http.ResponseWriter, r *http.Request) error {
	projectRequest := RoleCreateRequest{}
	if err := json.NewDecoder(r.Body).Decode(&projectRequest); err != nil {
		return err
	}

	projectStatus := NewRole(projectRequest.Title, projectRequest.Description)
	if err := s.store.CreateRole(projectStatus); err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, projectStatus)
}

func (s *ApiServer) handleDeleteRole(w http.ResponseWriter, r *http.Request) error {
	err := s.store.DeleteRole(uuid.MustParse(mux.Vars(r)["id"]))
	if err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, map[string]uuid.UUID{
		"deleted": uuid.MustParse(mux.Vars(r)["id"]),
	})
}

// ====== TEAM =======

func (s *ApiServer) handleTeam(w http.ResponseWriter, r *http.Request) error {
	if r.Method == http.MethodGet {
		return s.handleGetTeams(w, r)
	}

	if r.Method == http.MethodPost {
		return s.handleCreateTeam(w, r)
	}

	return fmt.Errorf("unsupported method: %s", r.Method)
}

func (s *ApiServer) handleGetTeams(w http.ResponseWriter, r *http.Request) error {
	projects, err := s.store.GetTeams()
	if err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, projects)
}

func (s *ApiServer) handleTeamWithId(w http.ResponseWriter, r *http.Request) error {
	if r.Method == http.MethodGet {
		id := mux.Vars(r)["id"]
		project, err := s.store.GetTeam(uuid.MustParse(id))
		if err != nil {
			return err
		}

		return WriteJson(w, http.StatusOK, project)
	}

	if r.Method == http.MethodDelete {
		return s.handleDeleteTeam(w, r)
	}

	return fmt.Errorf("unsupported method: %s", r.Method)
}

func (s *ApiServer) handleCreateTeam(w http.ResponseWriter, r *http.Request) error {
	projectRequest := TeamCreateRequest{}
	if err := json.NewDecoder(r.Body).Decode(&projectRequest); err != nil {
		return err
	}

	projectStatus := NewTeam(projectRequest.Project, projectRequest.Description)
	if err := s.store.CreateTeam(projectStatus); err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, projectStatus)
}

func (s *ApiServer) handleDeleteTeam(w http.ResponseWriter, r *http.Request) error {
	err := s.store.DeleteTeam(uuid.MustParse(mux.Vars(r)["id"]))
	if err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, map[string]uuid.UUID{
		"deleted": uuid.MustParse(mux.Vars(r)["id"]),
	})
}

func (s *ApiServer) handleAddUserToTeam(w http.ResponseWriter, r *http.Request) error {
	if r.Method == http.MethodPost {
		teamId := mux.Vars(r)["id"]
		userId := mux.Vars(r)["user_id"]

		err := s.store.AddUserToTeam(NewUserTeam(userId, teamId))
		if err != nil {
			return err
		}

		return WriteJson(w, http.StatusOK, map[string]uuid.UUID{
			"added": uuid.MustParse(mux.Vars(r)["id"]),
			"user":  uuid.MustParse(mux.Vars(r)["user_id"]),
		})
	}

	if r.Method == http.MethodDelete {
		teamId := mux.Vars(r)["id"]
		userId := mux.Vars(r)["user_id"]

		err := s.store.DeleteUserFromTeam(uuid.MustParse(userId), uuid.MustParse(teamId))
		if err != nil {
			return err
		}

		return WriteJson(w, http.StatusOK, map[string]uuid.UUID{
			"deleted": uuid.MustParse(mux.Vars(r)["id"]),
			"user":    uuid.MustParse(mux.Vars(r)["user_id"]),
		})
	}

	if r.Method == http.MethodGet {
		teamId := mux.Vars(r)["id"]
		userId := mux.Vars(r)["user_id"]

		team, err := s.store.GetUserTeam(uuid.MustParse(userId), uuid.MustParse(teamId))
		if err != nil {
			return err
		}

		return WriteJson(w, http.StatusOK, team)
	}

	return fmt.Errorf("unsupported method: %s", r.Method)
}

func (s *ApiServer) handleUserTeams(w http.ResponseWriter, r *http.Request) error {
	id := mux.Vars(r)["id"]
	project, err := s.store.GetUserTeams(uuid.MustParse(id))
	if err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, project)
}

// ======= TASK COMMENT =========

func (s *ApiServer) handleTaskComment(w http.ResponseWriter, r *http.Request) error {
	if r.Method == http.MethodGet {
		return s.handleGetTaskComments(w, r)
	}

	if r.Method == http.MethodPost {
		return s.handleCreateTaskComment(w, r)
	}

	return fmt.Errorf("unsupported method: %s", r.Method)
}

func (s *ApiServer) handleGetTaskComments(w http.ResponseWriter, r *http.Request) error {
	tasks, err := s.store.GetTaskComments()
	if err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, tasks)
}

func (s *ApiServer) handleTaskCommentWithId(w http.ResponseWriter, r *http.Request) error {
	if r.Method == http.MethodGet {
		id := mux.Vars(r)["id"]
		project, err := s.store.GetTaskComment(uuid.MustParse(id))
		if err != nil {
			return err
		}

		return WriteJson(w, http.StatusOK, project)
	}

	if r.Method == http.MethodDelete {
		return s.handleDeleteTaskComment(w, r)
	}

	return fmt.Errorf("unsupported method: %s", r.Method)
}

func (s *ApiServer) handleCreateTaskComment(w http.ResponseWriter, r *http.Request) error {
	taskRequest := TaskCommentCreateRequest{}
	if err := json.NewDecoder(r.Body).Decode(&taskRequest); err != nil {
		return err
	}

	task := NewTaskComment(taskRequest.Task, taskRequest.Author, taskRequest.Content)
	if err := s.store.CreateTaskComment(task); err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, task)
}

func (s *ApiServer) handleDeleteTaskComment(w http.ResponseWriter, r *http.Request) error {
	err := s.store.DeleteTaskComment(uuid.MustParse(mux.Vars(r)["id"]))
	if err != nil {
		return err
	}

	return WriteJson(w, http.StatusOK, map[string]uuid.UUID{
		"deleted": uuid.MustParse(mux.Vars(r)["id"]),
	})
}
